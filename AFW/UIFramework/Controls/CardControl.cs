using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


public class CardControl : BaseAnimatedControl
{
    public int BorderRadius = 5;
    public int HoverLift = 6;

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        int lift = (int)(HoverLift * hoverProgress);
        Rectangle rect = new Rectangle(0, lift, Width - 1, Height - lift - 1);

        using (SolidBrush shadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
        {
            Rectangle shadowRect = rect;
            shadowRect.Offset(0, 4);
            e.Graphics.FillPath(shadow,
                GraphicsHelper.RoundedRect(shadowRect, BorderRadius));
        }

        using (SolidBrush brush = new SolidBrush(Theme.GetCard()))
        {
            e.Graphics.FillPath(brush,
                GraphicsHelper.RoundedRect(rect, BorderRadius));
        }
    }
}
