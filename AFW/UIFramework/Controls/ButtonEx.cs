using System;
using System.Drawing;
using System.Windows.Forms;

public class ButtonEx : UserControl
{
    public string TextValue { get; set; }
    public Color HoverColor { get; set; }
    public Color NormalColor { get; set; }
    private bool isHovering = false;

    public ButtonEx()
    {
        TextValue = "Button";
        HoverColor = Color.LightBlue;
        NormalColor = Color.Blue;

        // Styles pour transparence et rendu custom
        this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint, true);

        this.BackColor = Color.Transparent;

        this.MouseEnter += delegate { isHovering = true; Invalidate(); };
        this.MouseLeave += delegate { isHovering = false; Invalidate(); };
        this.MouseDown += delegate { this.BackColor = HoverColor; };
        this.MouseUp += delegate { this.BackColor = Color.Transparent; Invalidate(); };
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // Fond du bouton
        Color fillColor = isHovering ? HoverColor : NormalColor;
        using (SolidBrush brush = new SolidBrush(fillColor))
        {
            g.FillRectangle(brush, 0, 0, this.Width, this.Height);
        }

        // Texte centré
        using (SolidBrush textBrush = new SolidBrush(Color.White))
        using (StringFormat sf = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        })
        {
            g.DrawString(TextValue, this.Font, textBrush, this.ClientRectangle, sf);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate(); // Redessine automatiquement
    }
}
