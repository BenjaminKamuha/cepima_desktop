using System.Drawing;
using System.Windows.Forms;

public static class BadgeControl
{
    public static void Draw(Graphics g, Rectangle rect, string text)
    {
        Color bg = text == "Paid"
            ? ColorPalette.Success
            : ColorPalette.Warning;

        using (SolidBrush brush = new SolidBrush(bg))
        using (Font font = new Font("Segoe UI", 8, FontStyle.Bold))
        {
            g.FillPath(brush, GraphicsHelper.RoundedRect(rect, 10));

            TextRenderer.DrawText(
                g, text, font, rect, Color.White,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter);
        }
    }
}
