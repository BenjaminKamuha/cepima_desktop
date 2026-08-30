using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


public class AvatarControl : UserControl
{
    private Image avatar;

    public Image Avatar
    {
        get { return avatar; }
        set
        {
            avatar = value;
            this.Invalidate();
        }
    }

    private Color borderColor = Color.White;
    public Color BorderColor
    {
        get { return borderColor; }
        set
        {
            borderColor = value;
            this.Invalidate();
        }
    }

    private int borderSize = 2;
    public int BorderSize
    {
        get { return borderSize; }
        set
        {
            borderSize = value;
            this.Invalidate();
        }
    }

    public AvatarControl()
    {
        this.SetStyle(
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint,
            true);

        this.BackColor = Color.Transparent;

        this.Width = 80;
        this.Height = 80;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        int diameter = Math.Min(this.Width, this.Height);

        Rectangle rect = new Rectangle(
            borderSize,
            borderSize,
            diameter - borderSize * 2,
            diameter - borderSize * 2
        );

        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(rect);

        g.SetClip(path);

        if (Avatar != null)
        {
            g.DrawImage(
                Avatar,
                rect,
                new Rectangle(0, 0, Avatar.Width, Avatar.Height),
                GraphicsUnit.Pixel
            );
        }
        else
        {
            Brush brush = new SolidBrush(Color.Gray);
            g.FillEllipse(brush, rect);
            brush.Dispose();
        }

        g.ResetClip();

        Pen pen = new Pen(borderColor, borderSize);
        g.DrawEllipse(pen, rect);

        pen.Dispose();
        path.Dispose();
    }
}