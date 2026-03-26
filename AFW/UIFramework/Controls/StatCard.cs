using System;
using System.Drawing;
using System.Windows.Forms;

public class StatCard : UserControl
{
    public string Title { get; set; }
    public string Value_one { get; set; }
    public string Subtitle_one { get; set; }
    public string Value_two { get; set; }
    public string Subtitle_two { get; set; }

    public StatCard()
    {
        Title = "Title";
        Value_one = "0";
        Subtitle_one = "Subtitle";

        Value_two = "0";
        Subtitle_two = "Subtitle";

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
            g.DrawString(Value_one, new Font(this.Font.FontFamily, 14, FontStyle.Bold), white, new PointF(10, 35));
            g.DrawString(Subtitle_one, new Font(this.Font.FontFamily,9,FontStyle.Bold), white, new PointF(10, 60));

            g.DrawString(Value_two,new Font(this.Font.FontFamily,14,FontStyle.Bold),white,new PointF(155,35));
            g.DrawString(Subtitle_two,new Font(this.Font.FontFamily,9,FontStyle.Bold),white,new PointF(155,60));
        }
    }
}
