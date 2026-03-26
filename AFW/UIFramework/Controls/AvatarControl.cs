using System;
using System.Drawing;
using System.Windows.Forms;

public class AvatarControl : UserControl
{
    public Image Avatar { get; set; }

    public AvatarControl()
    {
        this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint, true);

        this.BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        if (Avatar != null)
            g.DrawImage(Avatar, 0, 0, this.Width, this.Height);
        else
        {
            // Cercle par défaut
            using (Brush brush = new SolidBrush(Color.Gray))
            {
                g.FillEllipse(brush, 0, 0, this.Width, this.Height);
            }
        }
    }
}
