using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

public class DataGridViewProgressBarColumn : DataGridViewColumn
{
    public DataGridViewProgressBarColumn()
        : base(new DataGridViewProgressBarCell())
    {
    }
}

public class DataGridViewProgressBarCell : DataGridViewTextBoxCell
{
    protected override void Paint(
        Graphics g,
        Rectangle clipBounds,
        Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates cellState,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        // 🔥 anti-aliasing (IMPORTANT pour smooth)
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.CompositingQuality = CompositingQuality.HighQuality;

        base.Paint(g, clipBounds, cellBounds, rowIndex,
            cellState, value, formattedValue, errorText,
            cellStyle, advancedBorderStyle,
            DataGridViewPaintParts.Background |
            DataGridViewPaintParts.Border);

        int progress = 0;

        if (value != null)
            int.TryParse(value.ToString(), out progress);

        progress = Math.Max(0, Math.Min(100, progress));

        float percent = progress / 100f;

        // 📏 padding propre (évite les bords cassés)
        Rectangle barRect = new Rectangle(
            cellBounds.X + 4,
            cellBounds.Y + 5,
            (int)((cellBounds.Width - 8) * percent),
            cellBounds.Height - 10);

        // 🎨 couleur dynamique
        Color color =
            progress <= 30 ? Color.Red :
            progress <= 70 ? Color.Orange :
            Color.Green;

        // 🧼 background track (gris propre)
        Rectangle backRect = new Rectangle(
            cellBounds.X + 4,
            cellBounds.Y + 5,
            cellBounds.Width - 8,
            cellBounds.Height - 10);

        using (SolidBrush bg = new SolidBrush(Color.FromArgb(230, 230, 230)))
        {
            FillRounded(g, backRect, bg, 6);
        }

        using (SolidBrush brush = new SolidBrush(color))
        {
            FillRounded(g, barRect, brush, 6);
        }

        // 🧾 texte
        TextRenderer.DrawText(
            g,
            progress + "%",
            cellStyle.Font,
            cellBounds,
            Color.Black,
            TextFormatFlags.HorizontalCenter |
            TextFormatFlags.VerticalCenter);
    }

    // ⭐ ARRONDI PROPRE + sans cassures
    private void FillRounded(Graphics g, Rectangle rect, Brush brush, int radius)
    {
        using (GraphicsPath path = GetRoundedRect(rect, radius))
        {
            g.FillPath(brush, path);
        }
    }

    private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();

        radius = Math.Min(radius,
            Math.Min(rect.Width, rect.Height) / 2);

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

        path.CloseFigure();
        return path;
    }
}