using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("Click")]
[DefaultProperty("Text")]
public class RoundedButton : Button
{
    private int _borderRadius = 20;
    private int _borderSize = 1;

    private Color _borderColor = Color.DeepSkyBlue;
    private Color _hoverBackColor = Color.SteelBlue;
    private Color _defaultBackColor = Color.DodgerBlue;
    private Color _textColor = Color.White;

    private bool _isHovered = false;


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public RoundedButton()
    {
        this.DoubleBuffered = true;

        this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        this.UpdateStyles();

        this.Size = new Size(150, 50);

        this.Cursor = Cursors.Hand;

        this.Text = "Button";

        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;

        this.TextAlign =
            ContentAlignment.MiddleCenter;

        this.ImageAlign =
            ContentAlignment.MiddleLeft;

        this.TextImageRelation =
            TextImageRelation.ImageBeforeText;

        this.BackColor = Color.Transparent;

        this.ForeColor =
            this._textColor;
    }


    // =========================================================
    // BUTTON TEXT
    // =========================================================

    [Category("Appearance")]
    [Browsable(true)]
    [Description("Texte affiché sur le bouton.")]
    public string ButtonText
    {
        get
        {
            return this.Text;
        }

        set
        {
            this.Text = value;
            this.Invalidate();
        }
    }


    // =========================================================
    // BORDER RADIUS
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(20)]
    [Description("Rayon des coins.")]
    public int BorderRadius
    {
        get
        {
            return this._borderRadius;
        }

        set
        {
            if (value < 0)
                value = 0;

            this._borderRadius = value;

            this.Invalidate();
        }
    }


    // =========================================================
    // BORDER SIZE
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(1)]
    [Description("Épaisseur de la bordure.")]
    public int BorderSize
    {
        get
        {
            return this._borderSize;
        }

        set
        {
            if (value < 0)
                value = 0;

            this._borderSize = value;

            this.Invalidate();
        }
    }


    // =========================================================
    // BORDER COLOR
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur de la bordure.")]
    public Color BorderColor
    {
        get
        {
            return this._borderColor;
        }

        set
        {
            this._borderColor = value;
            this.Invalidate();
        }
    }


    // =========================================================
    // DEFAULT BACK COLOR
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur normale du bouton.")]
    public Color DefaultBackColor
    {
        get
        {
            return this._defaultBackColor;
        }

        set
        {
            this._defaultBackColor = value;
            this.Invalidate();
        }
    }


    // =========================================================
    // HOVER BACK COLOR
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur lorsque la souris passe dessus.")]
    public Color HoverBackColor
    {
        get
        {
            return this._hoverBackColor;
        }

        set
        {
            this._hoverBackColor = value;
            this.Invalidate();
        }
    }


    // =========================================================
    // TEXT COLOR
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur du texte.")]
    public Color TextColor
    {
        get
        {
            return this._textColor;
        }

        set
        {
            this._textColor = value;
            this.Invalidate();
        }
    }


    // =========================================================
    // MOUSE ENTER
    // =========================================================

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);

        this._isHovered = true;

        this.Invalidate();
    }


    // =========================================================
    // MOUSE LEAVE
    // =========================================================

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        this._isHovered = false;

        this.Invalidate();
    }


    // =========================================================
    // BACKGROUND
    // =========================================================

    protected override void OnPaintBackground(
        PaintEventArgs e)
    {
        /*
         * Désactivé pour laisser OnPaint gérer le rendu du fond
         * sans scintillement (flickering).
         */
    }


    // =========================================================
    // PAINT
    // =========================================================

    protected override void OnPaint(
        PaintEventArgs e)
    {
        Graphics g =
            e.Graphics;


        // =====================================================
        // QUALITÉ ET LISSAGE DES BORDS
        // =====================================================

        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        g.CompositingQuality =
            CompositingQuality.HighQuality;


        // =====================================================
        // 1. RECOUUVREMENT DU FOND PARENT (Remplace la Region)
        // =====================================================

        if (this.Parent != null)
        {
            using (SolidBrush parentBrush =
                   new SolidBrush(this.Parent.BackColor))
            {
                g.FillRectangle(
                    parentBrush,
                    this.ClientRectangle);
            }
        }


        // =====================================================
        // 2. RECTANGLE AVEC DECALAGE DE BORDURE (Anti-aliasing)
        // =====================================================

        float penOffset =
            this._borderSize > 0 ? this._borderSize / 2f : 0.5f;

        RectangleF rectangle =
            new RectangleF(
                penOffset,
                penOffset,
                this.Width - (penOffset * 2f),
                this.Height - (penOffset * 2f));


        if (rectangle.Width <= 0 ||
            rectangle.Height <= 0)
        {
            return;
        }


        // =====================================================
        // RAYON
        // =====================================================

        float radius =
            this._borderRadius;


        float maxRadius =
            Math.Min(
                rectangle.Width,
                rectangle.Height) / 2f;


        if (radius > maxRadius)
        {
            radius = maxRadius;
        }


        // =====================================================
        // CHEMIN
        // =====================================================

        using (GraphicsPath path =
               CreateRoundedPath(
                   rectangle,
                   radius))
        {
            // =================================================
            // FOND DU BOUTON
            // =================================================

            Color backgroundColor;

            if (!this.Enabled)
            {
                backgroundColor =
                    SystemColors.Control;
            }
            else if (this._isHovered)
            {
                backgroundColor =
                    this._hoverBackColor;
            }
            else
            {
                backgroundColor =
                    this._defaultBackColor;
            }


            using (SolidBrush brush =
                   new SolidBrush(
                       backgroundColor))
            {
                g.FillPath(
                    brush,
                    path);
            }


            // =================================================
            // BORDURE LISSE
            // =================================================

            if (this._borderSize > 0)
            {
                Color borderColor =
                    this._borderColor;


                if (!this.Enabled)
                {
                    borderColor =
                        SystemColors.ControlDark;
                }


                using (Pen pen =
                       new Pen(
                           borderColor,
                           this._borderSize))
                {
                    pen.LineJoin =
                        LineJoin.Round;

                    g.DrawPath(
                        pen,
                        path);
                }
            }
        }


        // =====================================================
        // CONTENU
        // =====================================================

        DrawButtonContent(g);
    }


    // =========================================================
    // CONTENU
    // =========================================================

    private void DrawButtonContent(
        Graphics g)
    {
        Image buttonImage =
            this.Image;

        string buttonText =
            this.Text;


        if (buttonImage == null &&
            string.IsNullOrEmpty(buttonText))
        {
            return;
        }


        // =====================================================
        // IMAGE SEULE
        // =====================================================

        if (buttonImage != null &&
            string.IsNullOrEmpty(buttonText))
        {
            Rectangle imageRectangle =
                GetImageRectangle(
                    buttonImage);

            g.DrawImage(
                buttonImage,
                imageRectangle);

            return;
        }


        // =====================================================
        // TEXTE SEUL
        // =====================================================

        if (buttonImage == null)
        {
            DrawText(
                g,
                buttonText,
                this.ClientRectangle);

            return;
        }


        // =====================================================
        // IMAGE AVANT TEXTE
        // =====================================================

        if (this.TextImageRelation ==
            TextImageRelation.ImageBeforeText)
        {
            DrawImageBeforeText(
                g,
                buttonImage,
                buttonText);

            return;
        }


        // =====================================================
        // TEXTE AVANT IMAGE
        // =====================================================

        if (this.TextImageRelation ==
            TextImageRelation.TextBeforeImage)
        {
            DrawTextBeforeImage(
                g,
                buttonImage,
                buttonText);

            return;
        }


        // =====================================================
        // SUPERPOSITION
        // =====================================================

        Rectangle overlayRectangle =
            GetImageRectangle(
                buttonImage);

        g.DrawImage(
            buttonImage,
            overlayRectangle);

        DrawText(
            g,
            buttonText,
            this.ClientRectangle);
    }


    // =========================================================
    // IMAGE AVANT TEXTE
    // =========================================================

    private void DrawImageBeforeText(
        Graphics g,
        Image buttonImage,
        string buttonText)
    {
        Size textSize =
            TextRenderer.MeasureText(
                buttonText,
                this.Font);


        int spacing = 6;


        int totalWidth =
            buttonImage.Width +
            spacing +
            textSize.Width;


        int startX =
            (this.Width -
             totalWidth) / 2;


        int imageY =
            (this.Height -
             buttonImage.Height) / 2;


        Rectangle imageRectangle =
            new Rectangle(
                startX,
                imageY,
                buttonImage.Width,
                buttonImage.Height);


        g.DrawImage(
            buttonImage,
            imageRectangle);


        RectangleF textRectangle =
            new RectangleF(
                startX +
                buttonImage.Width +
                spacing,
                0,
                textSize.Width,
                this.Height);


        DrawText(
            g,
            buttonText,
            textRectangle);
    }


    // =========================================================
    // TEXTE AVANT IMAGE
    // =========================================================

    private void DrawTextBeforeImage(
        Graphics g,
        Image buttonImage,
        string buttonText)
    {
        Size textSize =
            TextRenderer.MeasureText(
                buttonText,
                this.Font);


        int spacing = 6;


        int totalWidth =
            textSize.Width +
            spacing +
            buttonImage.Width;


        int startX =
            (this.Width -
             totalWidth) / 2;


        RectangleF textRectangle =
            new RectangleF(
                startX,
                0,
                textSize.Width,
                this.Height);


        DrawText(
            g,
            buttonText,
            textRectangle);


        int imageY =
            (this.Height -
             buttonImage.Height) / 2;


        Rectangle imageRectangle =
            new Rectangle(
                startX +
                textSize.Width +
                spacing,
                imageY,
                buttonImage.Width,
                buttonImage.Height);


        g.DrawImage(
            buttonImage,
            imageRectangle);
    }


    // =========================================================
    // TEXTE
    // =========================================================

    private void DrawText(
        Graphics g,
        string buttonText,
        RectangleF rectangle)
    {
        if (string.IsNullOrEmpty(buttonText))
        {
            return;
        }


        using (StringFormat format =
               new StringFormat())
        {
            format.Alignment =
                GetHorizontalAlignment(
                    this.TextAlign);

            format.LineAlignment =
                GetVerticalAlignment(
                    this.TextAlign);

            format.FormatFlags =
                StringFormatFlags.NoWrap;


            Color textColor =
                this._textColor;


            if (!this.Enabled)
            {
                textColor =
                    SystemColors.GrayText;
            }


            using (SolidBrush brush =
                   new SolidBrush(
                       textColor))
            {
                g.DrawString(
                    buttonText,
                    this.Font,
                    brush,
                    rectangle,
                    format);
            }
        }
    }


    // =========================================================
    // ALIGNEMENT HORIZONTAL
    // =========================================================

    private StringAlignment GetHorizontalAlignment(
        ContentAlignment alignment)
    {
        switch (alignment)
        {
            case ContentAlignment.TopLeft:
            case ContentAlignment.MiddleLeft:
            case ContentAlignment.BottomLeft:

                return StringAlignment.Near;


            case ContentAlignment.TopRight:
            case ContentAlignment.MiddleRight:
            case ContentAlignment.BottomRight:

                return StringAlignment.Far;


            default:

                return StringAlignment.Center;
        }
    }


    // =========================================================
    // ALIGNEMENT VERTICAL
    // =========================================================

    private StringAlignment GetVerticalAlignment(
        ContentAlignment alignment)
    {
        switch (alignment)
        {
            case ContentAlignment.TopLeft:
            case ContentAlignment.TopCenter:
            case ContentAlignment.TopRight:

                return StringAlignment.Near;


            case ContentAlignment.BottomLeft:
            case ContentAlignment.BottomCenter:
            case ContentAlignment.BottomRight:

                return StringAlignment.Far;


            default:

                return StringAlignment.Center;
        }
    }


    // =========================================================
    // POSITION IMAGE
    // =========================================================

    private Rectangle GetImageRectangle(
        Image buttonImage)
    {
        int imageX;
        int imageY;


        switch (this.ImageAlign)
        {
            case ContentAlignment.TopLeft:
            case ContentAlignment.MiddleLeft:
            case ContentAlignment.BottomLeft:

                imageX = 8;

                break;


            case ContentAlignment.TopRight:
            case ContentAlignment.MiddleRight:
            case ContentAlignment.BottomRight:

                imageX =
                    this.Width -
                    buttonImage.Width -
                    8;

                break;


            default:

                imageX =
                    (this.Width -
                     buttonImage.Width) / 2;

                break;
        }


        switch (this.ImageAlign)
        {
            case ContentAlignment.TopLeft:
            case ContentAlignment.TopCenter:
            case ContentAlignment.TopRight:

                imageY = 5;

                break;


            case ContentAlignment.BottomLeft:
            case ContentAlignment.BottomCenter:
            case ContentAlignment.BottomRight:

                imageY =
                    this.Height -
                    buttonImage.Height -
                    5;

                break;


            default:

                imageY =
                    (this.Height -
                     buttonImage.Height) / 2;

                break;
        }


        return new Rectangle(
            imageX,
            imageY,
            buttonImage.Width,
            buttonImage.Height);
    }


    // =========================================================
    // CHEMIN ARRONDI
    // =========================================================

    private GraphicsPath CreateRoundedPath(
        RectangleF rectangle,
        float radius)
    {
        GraphicsPath path =
            new GraphicsPath();


        if (radius <= 0)
        {
            path.AddRectangle(
                rectangle);

            return path;
        }


        float diameter =
            radius * 2f;


        if (diameter >
            rectangle.Width)
        {
            diameter =
                rectangle.Width;
        }


        if (diameter >
            rectangle.Height)
        {
            diameter =
                rectangle.Height;
        }


        path.AddArc(
            rectangle.X,
            rectangle.Y,
            diameter,
            diameter,
            180,
            90);


        path.AddArc(
            rectangle.Right -
            diameter,
            rectangle.Y,
            diameter,
            diameter,
            270,
            90);


        path.AddArc(
            rectangle.Right -
            diameter,
            rectangle.Bottom -
            diameter,
            diameter,
            diameter,
            0,
            90);


        path.AddArc(
            rectangle.X,
            rectangle.Bottom -
            diameter,
            diameter,
            diameter,
            90,
            90);


        path.CloseFigure();


        return path;
    }
}