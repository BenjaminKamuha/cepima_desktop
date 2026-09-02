using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("Click")]
[DefaultProperty("Title")]
public class ModernListItem : UserControl
{
    private string _title = "Titre";
    private string _subtitle = "Sous-information";

    private Color _indicatorColor = Color.LightBlue;
    private Color _titleColor = Color.Black;
    private Color _subtitleColor = Color.Gray;

    private Font _titleFont;
    private Font _subtitleFont;

    private int _indicatorSize = 35;
    private int _indicatorMarginLeft = 8;

    private int _titleSubtitleSpacing = 2;

    private bool _indicatorShadow = true;
    private Color _indicatorShadowColor =
        Color.FromArgb(70, Color.Black);

    private int _indicatorShadowSize = 3;
    private int _indicatorShadowOffsetX = 0;
    private int _indicatorShadowOffsetY = 2;

    private Label lblTitle;
    private Label lblSubtitle;


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public ModernListItem()
    {
        _titleFont =
            new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular);

        _subtitleFont =
            new Font(
                "Segoe UI",
                7F,
                FontStyle.Regular);


        this.DoubleBuffered = true;

        this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        this.UpdateStyles();

        this.Size =
            new Size(160, 60);

        this.BackColor =
            Color.Transparent;

        this.Cursor =
            Cursors.Hand;


        // =====================================================
        // TITRE
        // =====================================================

        lblTitle =
            new Label();

        lblTitle.AutoSize =
            false;

        lblTitle.Text =
            _title;

        lblTitle.Font =
            _titleFont;

        lblTitle.ForeColor =
            _titleColor;

        lblTitle.BackColor =
            Color.Transparent;

        lblTitle.TextAlign =
            ContentAlignment.MiddleLeft;


        // =====================================================
        // SOUS-TITRE
        // =====================================================

        lblSubtitle =
            new Label();

        lblSubtitle.AutoSize =
            false;

        lblSubtitle.Text =
            _subtitle;

        lblSubtitle.Font =
            _subtitleFont;

        lblSubtitle.ForeColor =
            _subtitleColor;

        lblSubtitle.BackColor =
            Color.Transparent;

        lblSubtitle.TextAlign =
            ContentAlignment.MiddleLeft;


        this.Controls.Add(lblTitle);
        this.Controls.Add(lblSubtitle);


        // =====================================================
        // CLIC
        // =====================================================

        lblTitle.Click +=
            ChildControl_Click;

        lblSubtitle.Click +=
            ChildControl_Click;


        this.Resize +=
            ModernListItem_Resize;


        UpdateLayout();

        Invalidate();
    }


    // =========================================================
    // TITLE
    // =========================================================

    [Category("Item")]
    [Browsable(true)]
    [Description("Titre principal de l'élément.")]
    [DefaultValue("Titre")]
    public string Title
    {
        get
        {
            return _title;
        }

        set
        {
            _title =
                value ?? "";

            if (lblTitle != null)
            {
                lblTitle.Text =
                    _title;
            }

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // SUBTITLE
    // =========================================================

    [Category("Item")]
    [Browsable(true)]
    [Description("Information secondaire.")]
    [DefaultValue("Sous-information")]
    public string Subtitle
    {
        get
        {
            return _subtitle;
        }

        set
        {
            _subtitle =
                value ?? "";

            if (lblSubtitle != null)
            {
                lblSubtitle.Text =
                    _subtitle;
            }

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // TITLE FONT
    // =========================================================

    [Category("Item")]
    [Browsable(true)]
    [Description("Police du titre.")]
    public Font TitleFont
    {
        get
        {
            return _titleFont;
        }

        set
        {
            if (value == null)
                return;

            _titleFont =
                value;

            if (lblTitle != null)
            {
                lblTitle.Font =
                    _titleFont;
            }

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // SUBTITLE FONT
    // =========================================================

    [Category("Item")]
    [Browsable(true)]
    [Description("Police de la sous-information.")]
    public Font SubtitleFont
    {
        get
        {
            return _subtitleFont;
        }

        set
        {
            if (value == null)
                return;

            _subtitleFont =
                value;

            if (lblSubtitle != null)
            {
                lblSubtitle.Font =
                    _subtitleFont;
            }

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // ESPACEMENT TITRE / SOUS-TITRE
    // =========================================================

    [Category("Item")]
    [Browsable(true)]
    [Description(
        "Espacement entre le titre et la sous-information.")]
    [DefaultValue(2)]
    public int TitleSubtitleSpacing
    {
        get
        {
            return _titleSubtitleSpacing;
        }

        set
        {
            if (value < 0)
                value = 0;

            _titleSubtitleSpacing =
                value;

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // COULEUR TITRE
    // =========================================================

    [Category("Item")]
    [Description("Couleur du titre.")]
    public Color TitleColor
    {
        get
        {
            return _titleColor;
        }

        set
        {
            _titleColor =
                value;

            if (lblTitle != null)
            {
                lblTitle.ForeColor =
                    _titleColor;
            }

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR SOUS-TITRE
    // =========================================================

    [Category("Item")]
    [Description("Couleur de la sous-information.")]
    public Color SubtitleColor
    {
        get
        {
            return _subtitleColor;
        }

        set
        {
            _subtitleColor =
                value;

            if (lblSubtitle != null)
            {
                lblSubtitle.ForeColor =
                    _subtitleColor;
            }

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR INDICATEUR
    // =========================================================

    [Category("Indicator")]
    [Description("Couleur de l'indicateur.")]
    public Color IndicatorColor
    {
        get
        {
            return _indicatorColor;
        }

        set
        {
            _indicatorColor =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // TAILLE INDICATEUR
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(35)]
    [Description("Taille de l'indicateur.")]
    public int IndicatorSize
    {
        get
        {
            return _indicatorSize;
        }

        set
        {
            if (value < 10)
                value = 10;

            _indicatorSize =
                value;

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // MARGE GAUCHE INDICATEUR
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(8)]
    [Description(
        "Espace entre le bord gauche et l'indicateur.")]
    public int IndicatorMarginLeft
    {
        get
        {
            return _indicatorMarginLeft;
        }

        set
        {
            if (value < 0)
                value = 0;

            _indicatorMarginLeft =
                value;

            UpdateLayout();
            Invalidate();
        }
    }


    // =========================================================
    // OMBRE
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(true)]
    [Description("Active ou désactive l'ombre.")]
    public bool IndicatorShadow
    {
        get
        {
            return _indicatorShadow;
        }

        set
        {
            _indicatorShadow =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR OMBRE
    // =========================================================

    [Category("Indicator")]
    [Description("Couleur de l'ombre.")]
    public Color IndicatorShadowColor
    {
        get
        {
            return _indicatorShadowColor;
        }

        set
        {
            _indicatorShadowColor =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // TAILLE OMBRE
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(3)]
    [Description("Diffusion de l'ombre.")]
    public int IndicatorShadowSize
    {
        get
        {
            return _indicatorShadowSize;
        }

        set
        {
            if (value < 0)
                value = 0;

            _indicatorShadowSize =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // OFFSET X OMBRE
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(0)]
    [Description("Décalage horizontal de l'ombre.")]
    public int IndicatorShadowOffsetX
    {
        get
        {
            return _indicatorShadowOffsetX;
        }

        set
        {
            _indicatorShadowOffsetX =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // OFFSET Y OMBRE
    // =========================================================

    [Category("Indicator")]
    [DefaultValue(2)]
    [Description("Décalage vertical de l'ombre.")]
    public int IndicatorShadowOffsetY
    {
        get
        {
            return _indicatorShadowOffsetY;
        }

        set
        {
            _indicatorShadowOffsetY =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // RESIZE
    // =========================================================

    private void ModernListItem_Resize(
        object sender,
        EventArgs e)
    {
        UpdateLayout();
        Invalidate();
    }


    // =========================================================
    // CALCUL DE LA HAUTEUR
    // =========================================================

    private int GetContentHeight()
    {
        int titleHeight =
            TextRenderer.MeasureText(
                "Ag",
                _titleFont).Height;

        int subtitleHeight =
            TextRenderer.MeasureText(
                "Ag",
                _subtitleFont).Height;

        return
            titleHeight +
            _titleSubtitleSpacing +
            subtitleHeight;
    }


    // =========================================================
    // LAYOUT
    // =========================================================

    private void UpdateLayout()
    {
        if (lblTitle == null ||
            lblSubtitle == null)
        {
            return;
        }


        // =====================================================
        // HAUTEUR DU TITRE
        // =====================================================

        int titleHeight =
            TextRenderer.MeasureText(
                "Ag",
                _titleFont).Height;


        // =====================================================
        // HAUTEUR DU SOUS-TITRE
        // =====================================================

        int subtitleHeight =
            TextRenderer.MeasureText(
                "Ag",
                _subtitleFont).Height;


        // =====================================================
        // HAUTEUR TOTALE DU CONTENU
        // =====================================================

        int contentHeight =
            titleHeight +
            _titleSubtitleSpacing +
            subtitleHeight;


        // =====================================================
        // HAUTEUR NECESSAIRE
        // =====================================================

        int requiredHeight =
            Math.Max(
                _indicatorSize,
                contentHeight);


        requiredHeight += 6;


        // =====================================================
        // AGRANDISSEMENT AUTOMATIQUE
        // =====================================================

        if (this.Height <
            requiredHeight)
        {
            this.Height =
                requiredHeight;
        }


        // =====================================================
        // POSITION DU TEXTE
        // =====================================================

        int left =
            _indicatorMarginLeft +
            _indicatorSize +
            5;


        int width =
            this.Width - left;


        if (width < 20)
        {
            width = 20;
        }


        // =====================================================
        // CENTRAGE VERTICAL
        // =====================================================

        int startY =
            (this.Height -
             contentHeight) / 2;


        if (startY < 0)
        {
            startY = 0;
        }


        // =====================================================
        // TITRE
        // =====================================================

        lblTitle.Location =
            new Point(
                left,
                startY);

        lblTitle.Size =
            new Size(
                width,
                titleHeight);


        // =====================================================
        // SOUS-TITRE
        // =====================================================

        lblSubtitle.Location =
            new Point(
                left,
                startY +
                titleHeight +
                _titleSubtitleSpacing);

        lblSubtitle.Size =
            new Size(
                width,
                subtitleHeight);
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


        // =====================================================
        // QUALITE
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
        // POSITION INDICATEUR
        // =====================================================

        float circleX =
            _indicatorMarginLeft;


        float circleY =
            (this.Height -
             _indicatorSize) / 2f;


        RectangleF circleRectangle =
            new RectangleF(
                circleX,
                circleY,
                _indicatorSize,
                _indicatorSize);


        // =====================================================
        // OMBRE
        // =====================================================

        if (_indicatorShadow &&
            _indicatorShadowSize > 0)
        {
            DrawIndicatorShadow(
                g,
                circleRectangle);
        }


        // =====================================================
        // INDICATEUR
        // =====================================================

        using (SolidBrush brush =
               new SolidBrush(
                   _indicatorColor))
        {
            g.FillEllipse(
                brush,
                circleRectangle);
        }


        // =====================================================
        // BORDURE INDICATEUR
        // =====================================================

        using (Pen pen =
               new Pen(
                   Color.FromArgb(
                       35,
                       Color.Black),
                   1))
        {
            g.DrawEllipse(
                pen,
                circleRectangle);
        }
    }


    // =========================================================
    // OMBRE INDICATEUR
    // =========================================================

    private void DrawIndicatorShadow(
        Graphics g,
        RectangleF circleRectangle)
    {
        int shadowSize =
            _indicatorShadowSize;


        if (shadowSize <= 0)
        {
            return;
        }


        for (int i = shadowSize;
             i >= 1;
             i--)
        {
            float expansion =
                (float)i;


            RectangleF shadowRectangle =
                new RectangleF(
                    circleRectangle.X -
                    expansion / 2f +
                    _indicatorShadowOffsetX,

                    circleRectangle.Y -
                    expansion / 2f +
                    _indicatorShadowOffsetY,

                    circleRectangle.Width +
                    expansion,

                    circleRectangle.Height +
                    expansion);


            int alpha =
                _indicatorShadowColor.A;


            alpha =
                (alpha * i) /
                (shadowSize + 1);


            if (alpha <= 0)
            {
                continue;
            }


            Color shadowColor =
                Color.FromArgb(
                    alpha,
                    _indicatorShadowColor.R,
                    _indicatorShadowColor.G,
                    _indicatorShadowColor.B);


            using (SolidBrush brush =
                   new SolidBrush(
                       shadowColor))
            {
                g.FillEllipse(
                    brush,
                    shadowRectangle);
            }
        }
    }


    // =========================================================
    // PROPAGER LE CLIC
    // =========================================================

    private void ChildControl_Click(
        object sender,
        EventArgs e)
    {
        this.OnClick(e);
    }
}