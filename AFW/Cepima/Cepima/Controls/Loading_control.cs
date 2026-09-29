using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ModernLoader : Control
{
    private readonly Timer timer;
    private int angle;

    private Color circleColor = Color.DeepSkyBlue;
    private int lineThickness = 4;
    private int segments = 12;

    public Color CircleColor
    {
        get { return circleColor; }
        set
        {
            circleColor = value;
            Invalidate();
        }
    }

    public int LineThickness
    {
        get { return lineThickness; }
        set
        {
            lineThickness = Math.Max(1, value);
            Invalidate();
        }
    }

    public int Segments
    {
        get { return segments; }
        set
        {
            segments = Math.Max(6, value);
            Invalidate();
        }
    }

    public ModernLoader()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw,
            true);

        DoubleBuffered = true;

        Size = new Size(60, 60);

        timer = new Timer();
        timer.Interval = 80;
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        angle = (angle + 30) % 360;
        Invalidate();
    }

    public void Start()
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action(Start));
            return;
        }

        if (!timer.Enabled)
            timer.Start();

        Visible = true;
    }

    public void Stop()
    {
        if (InvokeRequired)
        {
            BeginInvoke(new Action(Stop));
            return;
        }

        timer.Stop();
        Visible = false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.CompositingQuality = CompositingQuality.HighQuality;

        int size = Math.Min(
            Width,
            Height) - (lineThickness * 2);

        if (size <= 0)
            return;

        Rectangle rect = new Rectangle(
            lineThickness,
            lineThickness,
            size,
            size);

        float segmentAngle =
            360f / segments;

        for (int i = 0; i < segments; i++)
        {
            int alpha =
                (int)(255f * (i + 1) / segments);

            using (Pen pen = new Pen(
                Color.FromArgb(
                    alpha,
                    circleColor),
                lineThickness))
            {
                float startAngle =
                    angle +
                    (i * segmentAngle);

                g.DrawArc(
                    pen,
                    rect,
                    startAngle,
                    segmentAngle * 0.55f);
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
                timer.Dispose();
            }
        }

        base.Dispose(disposing);
    }
}