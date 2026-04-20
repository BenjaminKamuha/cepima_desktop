using System;
using System.Drawing;
using System.Windows.Forms;

public class StatCard : UserControl
{
    public string Title { get; set; }
    public string Value { get; set; }
    public string Subtitle { get; set; }

    public StatCard()
    {
        Title = "Title";
        Value = "0";
        Subtitle = "Subtitle";

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

        using (Brush bg = new SolidBrush(Color.FromArgb(47, 133, 90)))
            g.FillRectangle(bg, this.ClientRectangle);

        using (Brush white = new SolidBrush(Color.White))
        {
            g.DrawString(Title, new Font(this.Font.FontFamily,9,FontStyle.Bold), white, new PointF(20, 10));
            g.DrawString(Value, new Font(this.Font.FontFamily, 14, FontStyle.Bold), white, new PointF(10, 35));
            g.DrawString(Subtitle, new Font(this.Font.FontFamily,9,FontStyle.Bold), white, new PointF(10, 60));

        }
    }
}
