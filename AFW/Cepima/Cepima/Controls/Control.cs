using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class LineChartControl : Control
{
    public List<PointF> Point;

    private float progres;
    private Timer timer;

    // Propriétés
    public Color LineColor { get; set; }
    public int LineWidth { get; set; }

    public LineChartControl()
    {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;

        Point = new List<PointF>();
        progres = 0f;

        // Initialisation des attributs ici
        LineColor = Color.SeaGreen;
        LineWidth = 2;

        timer = new Timer();
        timer.Interval = 16; // ~60 fps
        timer.Tick += Timer_Tick;
    }

    public void LoadData(List<PointF> points)
    {
        Point = points;
        progres = 0f;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        progres += 0.03f;
        if (progres >= 1f)
        {
            progres = 1f;
            timer.Stop();
        }
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        if (Point.Count < 2) return;

        // min/max pour normaliser
        float minX = Point[0].X, maxX = Point[0].X;
        float minY = Point[0].Y, maxY = Point[0].Y;

        foreach (var p in Point)
        {
            if (p.X < minX) minX = p.X;
            if (p.X > maxX) maxX = p.X;
            if (p.Y < minY) minY = p.Y;
            if (p.Y > maxY) maxY = p.Y;
        }

        int n = (int)(Point.Count * progres);
        if (n < 2) return;

        using (Pen pen = new Pen(LineColor, LineWidth))
        {
            for (int i = 0; i < n - 1; i++)
            {
                float x1 = (Point[i].X - minX) / (maxX - minX) * this.Width;
                float y1 = this.Height - (Point[i].Y - minY) / (maxY - minY) * this.Height;
                float x2 = (Point[i + 1].X - minX) / (maxX - minX) * this.Width;
                float y2 = this.Height - (Point[i + 1].Y - minY) / (maxY - minY) * this.Height;

                e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
}