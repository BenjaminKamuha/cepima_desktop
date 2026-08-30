using System;
using System.Drawing;
using System.Windows.Forms;

public class DonutChartControl : Control
{
    public float Percentage = 75f;

    private float animatedValue;
    private Timer timer;

    private Color _arcColor = Color.Empty; // si vide, utilise le thème
    public Color ArcColor
    {
        get { return _arcColor; }
        set { _arcColor = value; Invalidate(); }
    }

    private Color _textColor = Color.Empty; // si vide, utilise le thème
    public Color TextColor
    {
        get { return _textColor; }
        set { _textColor = value; Invalidate(); }
    }

    private int _thickness = 10;
    public int Thickness
    {
        get { return _thickness; }
        set { _thickness = value; Invalidate(); }
    }

    private Font _valueFont = null;
    public Font ValueFont
    {
        get { return _valueFont; }
        set { _valueFont = value; Invalidate(); }
    }

    public DonutChartControl()
    {
        // Active le double buffering pour éviter le flickering
        this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint,
            true
        );

        this.ResizeRedraw = true;

        timer = new Timer();
        timer.Interval = 16;
        timer.Tick += Animate;

        // S'abonner au changement de thème
        ThemeManager.ThemeChanged += OnThemeChanged;
    }

    private void OnThemeChanged()
    {
        this.Invalidate(); // redessine automatiquement lorsque le thème change
    }

    public void StartAnimation()
    {
        animatedValue = 0;
        timer.Start();
    }

    private void Animate(object sender, EventArgs e)
    {
        animatedValue += 1.5f;

        if (animatedValue >= Percentage)
        {
            animatedValue = Percentage;
            timer.Stop();
        }

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        // Couleurs adaptatives
        Color arcColor = _arcColor == Color.Empty ? Theme.GetAccent() : _arcColor;
        Color textColor = _textColor == Color.Empty ? Theme.GetTextPrimary() : _textColor;
        Color bgColor = Theme.GetBackground();

        // Calculer la taille du cercle selon le contrôle
        int size = Math.Max(0, Math.Min(this.Width, this.Height) - _thickness * 2);
        Rectangle rect = new Rectangle(_thickness, _thickness, size, size);

        using (Pen bg = new Pen(bgColor, _thickness))
        using (Pen fg = new Pen(arcColor, _thickness))
        {
            e.Graphics.DrawArc(bg, rect, 0, 360);
            e.Graphics.DrawArc(fg, rect, -90, animatedValue * 360 / 100);
        }

        // Texte centré
        string txt = ((int)animatedValue) + "%";

        Font fontToUse;
        bool disposeFont = false;

        if (_valueFont != null)
        {
            fontToUse = _valueFont;
        }
        else
        {
            fontToUse = new Font(this.Font.FontFamily, Math.Max(1, size / 4f), FontStyle.Bold);
            disposeFont = true;
        }

        SizeF textSize = e.Graphics.MeasureString(txt, fontToUse);
        e.Graphics.DrawString(
            txt,
            fontToUse,
            new SolidBrush(textColor),
            rect.X + rect.Width / 2 - textSize.Width / 2,
            rect.Y + rect.Height / 2 - textSize.Height / 2
        );

        if (disposeFont)
            fontToUse.Dispose();
    }
}