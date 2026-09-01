using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomRoundedPanel : Panel
{
    // =========================================================
    // BORDER
    // =========================================================

    private int _borderRadius = 20;
    private Color _borderColor = Color.Transparent;
    private int _borderSize = 0;


    // =========================================================
    // HOVER
    // =========================================================

    private Color _hoverBackColor = Color.Empty;
    private Color _defaultBackColor;
    private bool _isDefaultSaved = false;
    private Cursor _hoverCursor = Cursors.Hand;


    // =========================================================
    // SHADOW
    // =========================================================

    private bool _shadowEnabled = false;

    private Color _shadowColor = Color.Black;

    private int _shadowOpacity = 60;

    private int _shadowBlur = 10;

    private int _shadowOffsetX = 0;

    private int _shadowOffsetY = 4;

    private int _shadowSpread = 0;

    private int _shadowBorderRadius = -1;


    // =========================================================
    // HOVER CURSOR
    // =========================================================

    public Cursor HoverCursor
    {
        get
        {
            return _hoverCursor;
        }

        set
        {
            _hoverCursor = value;
        }
    }


    // =========================================================
    // HOVER BACK COLOR
    // =========================================================

    public Color HoverBackColor
    {
        get
        {
            return _hoverBackColor;
        }

        set
        {
            _hoverBackColor = value;
        }
    }


    // =========================================================
    // BORDER RADIUS
    // =========================================================

    public int BorderRadius
    {
        get
        {
            return _borderRadius;
        }

        set
        {
            _borderRadius = Math.Max(0, value);

            Invalidate();
        }
    }


    // =========================================================
    // BORDER COLOR
    // =========================================================

    public Color BorderColor
    {
        get
        {
            return _borderColor;
        }

        set
        {
            _borderColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // BORDER SIZE
    // =========================================================

    public int BorderSize
    {
        get
        {
            return _borderSize;
        }

        set
        {
            _borderSize = Math.Max(0, value);

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW ENABLED
    // =========================================================

    public bool ShadowEnabled
    {
        get
        {
            return _shadowEnabled;
        }

        set
        {
            _shadowEnabled = value;

            UpdateShadowMargin();

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW COLOR
    // =========================================================

    public Color ShadowColor
    {
        get
        {
            return _shadowColor;
        }

        set
        {
            _shadowColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW OPACITY
    // =========================================================

    public int ShadowOpacity
    {
        get
        {
            return _shadowOpacity;
        }

        set
        {
            _shadowOpacity =
                Math.Max(
                    0,
                    Math.Min(
                        255,
                        value));

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW BLUR
    // =========================================================

    public int ShadowBlur
    {
        get
        {
            return _shadowBlur;
        }

        set
        {
            _shadowBlur =
                Math.Max(
                    0,
                    value);

            UpdateShadowMargin();

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW OFFSET X
    // =========================================================

    public int ShadowOffsetX
    {
        get
        {
            return _shadowOffsetX;
        }

        set
        {
            _shadowOffsetX = value;

            UpdateShadowMargin();

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW OFFSET Y
    // =========================================================

    public int ShadowOffsetY
    {
        get
        {
            return _shadowOffsetY;
        }

        set
        {
            _shadowOffsetY = value;

            UpdateShadowMargin();

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW SPREAD
    // =========================================================

    public int ShadowSpread
    {
        get
        {
            return _shadowSpread;
        }

        set
        {
            _shadowSpread = value;

            UpdateShadowMargin();

            Invalidate();
        }
    }


    // =========================================================
    // SHADOW BORDER RADIUS
    // =========================================================

    public int ShadowBorderRadius
    {
        get
        {
            return _shadowBorderRadius;
        }

        set
        {
            _shadowBorderRadius = value;

            Invalidate();
        }
    }


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public CustomRoundedPanel()
    {
        DoubleBuffered = true;

        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);


        _defaultBackColor =
            this.BackColor;


        // -----------------------------------------------------
        // HOVER
        // -----------------------------------------------------

        this.MouseEnter +=
            (s, e) =>
            {
                if (!_isDefaultSaved)
                {
                    _defaultBackColor =
                        this.BackColor;

                    _isDefaultSaved =
                        true;
                }


                if (_hoverBackColor !=
                    Color.Empty)
                {
                    this.BackColor =
                        _hoverBackColor;
                }


                this.Cursor =
                    _hoverCursor;
            };


        this.MouseLeave +=
            (s, e) =>
            {
                this.BackColor =
                    _defaultBackColor;

                this.Cursor =
                    Cursors.Default;
            };
    }


    // =========================================================
    // CALCUL MARGE OMBRE
    // =========================================================

    private void UpdateShadowMargin()
    {
        if (!_shadowEnabled)
        {
            return;
        }


        int blur =
            Math.Max(
                0,
                _shadowBlur);


        int spread =
            Math.Max(
                0,
                _shadowSpread);


        int left =
            blur +
            spread +
            Math.Max(
                0,
                -_shadowOffsetX);


        int right =
            blur +
            spread +
            Math.Max(
                0,
                _shadowOffsetX);


        int top =
            blur +
            spread +
            Math.Max(
                0,
                -_shadowOffsetY);


        int bottom =
            blur +
            spread +
            Math.Max(
                0,
                _shadowOffsetY);


        Padding =
            new Padding(
                left,
                top,
                right,
                bottom);
    }


    // =========================================================
    // ROUNDED PATH
    // =========================================================

    private GraphicsPath GetRoundPath(
        RectangleF rect,
        float radius)
    {
        GraphicsPath path =
            new GraphicsPath();


        if (rect.Width <= 0 ||
            rect.Height <= 0)
        {
            return path;
        }


        radius =
            Math.Max(
                0,
                Math.Min(
                    radius,
                    Math.Min(
                        rect.Width,
                        rect.Height) / 2f));


        if (radius <= 0)
        {
            path.AddRectangle(rect);

            return path;
        }


        float diameter =
            radius * 2f;


        path.StartFigure();


        path.AddArc(
            rect.X,
            rect.Y,
            diameter,
            diameter,
            180,
            90);


        path.AddArc(
            rect.Right -
            diameter,
            rect.Y,
            diameter,
            diameter,
            270,
            90);


        path.AddArc(
            rect.Right -
            diameter,
            rect.Bottom -
            diameter,
            diameter,
            diameter,
            0,
            90);


        path.AddArc(
            rect.X,
            rect.Bottom -
            diameter,
            diameter,
            diameter,
            90,
            90);


        path.CloseFigure();


        return path;
    }


    // =========================================================
    // DRAW SHADOW
    // =========================================================

    private void DrawShadow(
        Graphics g)
    {
        if (!_shadowEnabled ||
            _shadowOpacity <= 0 ||
            _shadowBlur < 0)
        {
            return;
        }


        RectangleF shadowRect =
            new RectangleF(
                _shadowBlur +
                _shadowSpread +
                _shadowOffsetX,

                _shadowBlur +
                _shadowSpread +
                _shadowOffsetY,

                Width -
                (_shadowBlur * 2) -
                (_shadowSpread * 2),

                Height -
                (_shadowBlur * 2) -
                (_shadowSpread * 2));


        if (shadowRect.Width <= 0 ||
            shadowRect.Height <= 0)
        {
            return;
        }


        float radius =
            _shadowBorderRadius >= 0
            ? _shadowBorderRadius
            : _borderRadius;


        // -----------------------------------------------------
        // Plusieurs couches pour simuler un flou doux
        // -----------------------------------------------------

        int layers =
            Math.Max(
                1,
                _shadowBlur);


        for (int i = layers;
             i >= 1;
             i--)
        {
            float progress =
                (float)i /
                layers;


            float expansion =
                progress *
                _shadowBlur;


            RectangleF rect =
                new RectangleF(
                    shadowRect.X -
                    expansion,

                    shadowRect.Y -
                    expansion,

                    shadowRect.Width +
                    expansion * 2,

                    shadowRect.Height +
                    expansion * 2);


            float currentRadius =
                radius +
                expansion;


            int alpha =
                (int)(
                    _shadowOpacity *
                    (1f - progress) *
                    0.65f);


            if (alpha <= 0)
            {
                continue;
            }


            Color color =
                Color.FromArgb(
                    alpha,
                    _shadowColor);


            using (GraphicsPath path =
                   GetRoundPath(
                       rect,
                       currentRadius))
            {
                using (SolidBrush brush =
                       new SolidBrush(
                           color))
                {
                    g.FillPath(
                        brush,
                        path);
                }
            }
        }


        // -----------------------------------------------------
        // Partie principale de l'ombre
        // -----------------------------------------------------

        using (GraphicsPath path =
               GetRoundPath(
                   shadowRect,
                   radius))
        {
            Color color =
                Color.FromArgb(
                    Math.Max(
                        1,
                        _shadowOpacity),
                    _shadowColor);


            using (SolidBrush brush =
                   new SolidBrush(
                       color))
            {
                g.FillPath(
                    brush,
                    path);
            }
        }
    }


    // =========================================================
    // PAINT BACKGROUND
    // =========================================================

    protected override void OnPaintBackground(
        PaintEventArgs e)
    {
        Graphics g =
            e.Graphics;


        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.CompositingQuality =
            CompositingQuality.HighQuality;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;


        // -----------------------------------------------------
        // FOND DU PARENT
        // -----------------------------------------------------

        Color parentColor =
            Parent != null
            ? Parent.BackColor
            : BackColor;


        using (SolidBrush parentBrush =
               new SolidBrush(
                   parentColor))
        {
            g.FillRectangle(
                parentBrush,
                ClientRectangle);
        }


        // -----------------------------------------------------
        // FOND DU PANEL
        // -----------------------------------------------------

        RectangleF surface =
            new RectangleF(
                0,
                0,
                Width - 1,
                Height - 1);


        float radius =
            Math.Min(
                _borderRadius,
                Math.Min(
                    surface.Width,
                    surface.Height) / 2f);


        using (GraphicsPath path =
               GetRoundPath(
                   surface,
                   radius))
        {
            using (SolidBrush brush =
                   new SolidBrush(
                       this.BackColor))
            {
                g.FillPath(
                    brush,
                    path);
            }
        }
    }


    // =========================================================
    // PAINT
    // =========================================================

    protected override void OnPaint(
        PaintEventArgs e)
    {
        base.OnPaint(e);


        Graphics g =
            e.Graphics;


        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.CompositingQuality =
            CompositingQuality.HighQuality;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        g.InterpolationMode =
            InterpolationMode.HighQualityBicubic;


        // =====================================================
        // OMBRE
        // =====================================================

        DrawShadow(g);


        // =====================================================
        // SURFACE
        // =====================================================

        RectangleF rectSurface =
            new RectangleF(
                0,
                0,
                Width - 1,
                Height - 1);


        float radius =
            Math.Min(
                _borderRadius,
                Math.Min(
                    rectSurface.Width,
                    rectSurface.Height) / 2f);


        using (GraphicsPath path =
               GetRoundPath(
                   rectSurface,
                   radius))
        {
            // -------------------------------------------------
            // FOND
            // -------------------------------------------------

            using (SolidBrush brush =
                   new SolidBrush(
                       this.BackColor))
            {
                g.FillPath(
                    brush,
                    path);
            }


            // -------------------------------------------------
            // BORDER
            // -------------------------------------------------

            if (_borderSize > 0)
            {
                using (Pen pen =
                       new Pen(
                           _borderColor,
                           _borderSize))
                {
                    pen.Alignment =
                        PenAlignment.Inset;

                    pen.LineJoin =
                        LineJoin.Round;

                    g.DrawPath(
                        pen,
                        path);
                }
            }
        }
    }
}