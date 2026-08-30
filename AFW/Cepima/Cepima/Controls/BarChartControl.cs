//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;

//public class BarChartControl : Control, IThemeAware
//{

//   //ajout de code par richard marcus

//    private VScrollBar vScrollBar;
//    private int scrollOffset = 0;
//    private int barreHauteur = 30, marge = 5;

//    private HScrollBar hScrollBar;
//    private int hScrollOffset = 0;

//    private void UpdateScroll()
//    {
//        int hauteurTotale = Bars.Count * (barreHauteur + marge);
//        if (hauteurTotale > Height)
//        {
//            vScrollBar.Maximum = hauteurTotale - 1;
//            vScrollBar.LargeChange = Height;
//            vScrollBar.Enabled = true;
//        }
//        else
//        {
//            scrollOffset = 0;
//            vScrollBar.Enabled = false;
//        }
//    }



//    /*//////////////////////////////////////////////////////*/
//    public class Bar
//    {
//        public float Value;
//        public Color Color;
//        public string Label;
 

//        public Bar(float value, Color color, string label = "")
//        {
//            Value = value;
//            Color = color;
//            Label = label;
//        }
//    }

   
//    private List<Bar> bars = new List<Bar>();
//    public List<Bar> Bars
//    {
//        get { return bars; }
//        set
//        {
//            bars = value ?? new List<Bar>();
//            animatedValues = new float[bars.Count];
//            Invalidate();
//        }
//    }

//    private float[] animatedValues;
//    private Timer timer;

//    public int BarWidth { get; set; }
//    public int BarSpacing { get; set; }

//    public Font LabelFont { get; set; }
//    public Font ValueFont { get; set; }

//    public Color LabelColor { get; set; }

//    /*//////////////////////////Constructeur///////////////////////////////*/

//    public BarChartControl()
//    {
//        BarWidth = 30;
//        BarSpacing = 15;


//        //ajoute par richard
//         vScrollBar = new VScrollBar { Dock = DockStyle.Right };
//        vScrollBar.Scroll += (s, e) => { scrollOffset = e.NewValue; Invalidate(); };
//        Controls.Add(vScrollBar);

//        SetStyle(ControlStyles.OptimizedDoubleBuffer |
//                 ControlStyles.AllPaintingInWmPaint |
//                 ControlStyles.UserPaint, true);

//        hScrollBar = new HScrollBar { Dock = DockStyle.Bottom };
//        hScrollBar.Scroll += (s, e) =>
//        {
//            hScrollOffset = e.NewValue;
//            Invalidate();
//        };
//        Controls.Add(hScrollBar);
//        /*////////////////////////////fin//////////////////////////////*/
//        LabelFont = new Font("Segoe UI", 8f);
//        ValueFont = new Font("Segoe UI", 8f, FontStyle.Bold);
//        LabelColor = Color.Black;

//        SetStyle(
//            ControlStyles.AllPaintingInWmPaint |
//            ControlStyles.OptimizedDoubleBuffer |
//            ControlStyles.UserPaint,
//            true);

//        ResizeRedraw = true;

//        timer = new Timer();
//        timer.Interval = 16;
//        timer.Tick += Animate;

//        // Écoute le thème
//        ThemeManager.ThemeChanged += ApplyTheme;

//        ApplyTheme();
//    }

//    public void StartAnimation()
//    {
//        if (bars.Count == 0) return;

//        animatedValues = new float[bars.Count];
//        timer.Start();
//    }

//    private void Animate(object sender, EventArgs e)
//    {
//        bool updating = false;

//        for (int i = 0; i < bars.Count; i++)
//        {
//            if (animatedValues[i] < bars[i].Value)
//            {
//                animatedValues[i] += Math.Max(1f, bars[i].Value / 40f);
//                if (animatedValues[i] > bars[i].Value)
//                    animatedValues[i] = bars[i].Value;

//                updating = true;
//            }
//        }

//        Invalidate();

//        if (!updating)
//            timer.Stop();
//    }

//    // IThemeAware
//    public void ApplyTheme()
//    {
//        BackColor = Theme.GetBackground();
//        LabelColor = Theme.GetTextPrimary();
//        Invalidate();
//    }

 
//    protected override void OnPaint(PaintEventArgs e)
//    {
       
//        base.OnPaint(e);

//        /*///Code ajouté par richard marc////////////////////////////////////////////////*/

//        e.Graphics.TranslateTransform(0, -scrollOffset);
//        e.Graphics.TranslateTransform(-hScrollOffset, -scrollOffset);
//        int y = 0;

//        foreach (var bar in Bars)
//        {
//            Rectangle rect = new Rectangle(10, y, (int)bar.Value, 30);

//            using (Brush b = new SolidBrush(bar.Color))
//                e.Graphics.FillRectangle(b, rect);

//            // Nom du produit
//            e.Graphics.DrawString(
//                bar.Label,
//                this.Font,
//                Brushes.Black,
//                rect.Right + 10,
//                y + 6
//            );

//            y += 35;
//        }

//        /*///////////////////////////// Te End/////////////////////////////////////////////////*/
//        e.Graphics.Clear(Theme.GetBackground());
//        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

//        if (bars.Count == 0) return;

//        // Calcul du max pour échelle
//        float max = 1;
//        foreach (var b in bars)
//            if (b.Value > max) max = b.Value;

//        int chartHeight = Height - 50;
//        int x = BarSpacing;

//        // Dessin des barres
//        for (int i = 0; i < bars.Count; i++)
//        {
//            float ratio = animatedValues[i] / max;
//            int barHeight = (int)(ratio * chartHeight);

//            Rectangle barRect = new Rectangle(
//                x,
//                Height - barHeight - 30,
//                BarWidth,
//                barHeight
//            );

//            // BAR
//            using (Brush bBrush = new SolidBrush(bars[i].Color))
//                e.Graphics.FillRectangle(bBrush, barRect);

//            // VALUE (même couleur que la barre)
//            string valueText = ((int)animatedValues[i]).ToString();
//            SizeF valueSize = e.Graphics.MeasureString(valueText, ValueFont);

//            using (Brush vb = new SolidBrush(bars[i].Color))
//                e.Graphics.DrawString(
//                    valueText,
//                    ValueFont,
//                    vb,
//                    barRect.X + barRect.Width / 2 - valueSize.Width / 2,
//                    barRect.Y - valueSize.Height - 2
//                );

//            x += BarWidth + BarSpacing;
//        }

//        // Dessin de la légende à droite
//        int legendX = x + 20;
//        int legendY = 10;
//        int legendSpacing = 20;

//        for (int i = 0; i < bars.Count; i++)
//        {
//            // Carré de couleur
//            Rectangle colorBox = new Rectangle(legendX, legendY + i * legendSpacing, 12, 12);
//            using (Brush brush = new SolidBrush(bars[i].Color))
//                e.Graphics.FillRectangle(brush, colorBox);

//            // Label + valeur
//            string legendText = bars[i].Label + " (" + bars[i].Value + ")";
//            using (Brush brush = new SolidBrush(LabelColor))
//            {
//                e.Graphics.DrawString(
//                    legendText,
//                    LabelFont,
//                    brush,
//                    legendX + 16,
//                    legendY + i * legendSpacing - 2
//                );
//            }
//        }
//    }
//}