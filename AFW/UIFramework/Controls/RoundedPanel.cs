using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomRoundedPanel : Panel
{
    private int _borderRadius = 20;
    private Color _borderColor = Color.Transparent;
    private int _borderSize = 0;

    private Color _hoverBackColor = Color.Empty;
    private Color _defaultBackColor;
    private bool _isDefaultSaved = false;
    private Cursor _hoverCursor = Cursors.Hand;

    public Cursor HoverCursor
    {
        get { return _hoverCursor; }
        set { _hoverCursor = value; }
    }

    public Color HoverBackColor
    {
        get { return _hoverBackColor; }
        set { _hoverBackColor = value; }
    }


    public int BorderRadius
    {
        get { return _borderRadius; }
        set { _borderRadius = value; Invalidate(); }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set { _borderColor = value; Invalidate(); }
    }

    public int BorderSize
    {
        get { return _borderSize; }
        set { _borderSize = value; Invalidate(); }
    }

    public CustomRoundedPanel()
    {
        //this.DoubleBuffered = true;
        //this.BackColor = Color.White;

        //sauvegarde au demarrage
        _defaultBackColor = this.BackColor;


        this.MouseEnter += (s, e) =>
        {
            if (!_isDefaultSaved)
            {
                _defaultBackColor = this.BackColor;
                _isDefaultSaved = true;
            }
            if (_hoverBackColor != Color.Empty)
            {
                this.BackColor = _hoverBackColor;
            }
            this.Cursor = _hoverCursor;
        };

        this.MouseLeave += (s, e) =>
        {
            this.BackColor = _defaultBackColor;
            this.Cursor = Cursors.Default;
        };
    }

    private GraphicsPath GetRoundPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int r = radius * 2;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, r, r, 180, 90);
        path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
        path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
        path.CloseFigure();

        return path;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -1, -1);

        using (GraphicsPath path = GetRoundPath(rectSurface, _borderRadius))
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillPath(brush, path);
            this.Region = new Region(path);
        }

        if (_borderSize > 0)
        {
            using (GraphicsPath path = GetRoundPath(rectBorder, _borderRadius))
            using (Pen pen = new Pen(_borderColor, _borderSize))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

}

