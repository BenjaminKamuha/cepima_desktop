using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
public class RoundedNumericUpDown : UserControl
{
    private TextBox _textBox;

    // =========================================================
    // VALEURS
    // =========================================================

    private decimal _value = 0;
    private decimal _minimum = 0;
    private decimal _maximum = 100;
    private decimal _increment = 1;

    private int _decimalPlaces = 0;
    private bool _thousandsSeparator = false;


    // =========================================================
    // APPARENCE
    // =========================================================

    private int _borderRadius = 12;
    private int _borderSize = 1;

    private Color _borderColor = Color.LightGray;
    private Color _focusBorderColor = Color.DeepSkyBlue;

    // Espace entre la valeur et le bord gauche
    private int _textPadding = 8;


    // =========================================================
    // BOUTONS
    // =========================================================

    private int _buttonWidth = 30;

    private Color _buttonBackColor = Color.White;
    private Color _buttonHoverColor =
        Color.FromArgb(235, 235, 235);

    private Color _buttonForeColor = Color.DimGray;

    private Font _buttonFont;


    // =========================================================
    // ETAT
    // =========================================================

    private bool _upHovered = false;
    private bool _downHovered = false;

    private bool _internalUpdate = false;
    private bool _adjustingSize = false;


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public RoundedNumericUpDown()
    {
        DoubleBuffered = true;

        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        UpdateStyles();


        // =====================================================
        // POLICES
        // =====================================================

        base.Font =
            new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular);

        _buttonFont =
            new Font(
                "Segoe UI",
                8F,
                FontStyle.Bold);


        // =====================================================
        // COULEURS
        // =====================================================

        BackColor =
            Color.White;

        ForeColor =
            Color.Black;


        // =====================================================
        // TEXTBOX
        // =====================================================

        _textBox =
            new TextBox();

        _textBox.BorderStyle =
            BorderStyle.None;

        _textBox.BackColor =
            BackColor;

        _textBox.ForeColor =
            ForeColor;

        _textBox.Font =
            Font;

        _textBox.TextAlign =
            HorizontalAlignment.Left;

        _textBox.Margin =
            new Padding(0);

        _textBox.Padding =
            new Padding(0);

        _textBox.TabStop =
            true;


        Controls.Add(
            _textBox);


        // =====================================================
        // EVENEMENTS TEXTBOX
        // =====================================================

        _textBox.TextChanged +=
            TextBox_TextChanged;

        _textBox.KeyPress +=
            TextBox_KeyPress;

        _textBox.KeyDown +=
            TextBox_KeyDown;

        _textBox.Enter +=
            TextBox_Enter;

        _textBox.Leave +=
            TextBox_Leave;


        // =====================================================
        // EVENEMENTS CONTROLE
        // =====================================================

        Resize +=
            RoundedNumericUpDown_Resize;

        FontChanged +=
            RoundedNumericUpDown_FontChanged;

        BackColorChanged +=
            RoundedNumericUpDown_BackColorChanged;

        ForeColorChanged +=
            RoundedNumericUpDown_ForeColorChanged;


        // =====================================================
        // INITIALISATION
        // =====================================================

        UpdateMinimumSize();

        EnsureMinimumSize();

        UpdateText();

        UpdateLayout();

        UpdateRegion();
    }


    // =========================================================
    // VALUE
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Value")]
    [Description("Valeur actuelle.")]
    [DefaultValue(typeof(decimal), "0")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public decimal Value
    {
        get
        {
            return _value;
        }

        set
        {
            SetValue(value);
        }
    }


    // =========================================================
    // MINIMUM
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Minimum")]
    [Description("Valeur minimale.")]
    [DefaultValue(typeof(decimal), "0")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public decimal Minimum
    {
        get
        {
            return _minimum;
        }

        set
        {
            if (value > _maximum)
            {
                _maximum = value;
            }

            _minimum = value;

            if (_value < _minimum)
            {
                SetValue(_minimum);
            }

            Invalidate();
        }
    }


    // =========================================================
    // MAXIMUM
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Maximum")]
    [Description("Valeur maximale.")]
    [DefaultValue(typeof(decimal), "100")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public decimal Maximum
    {
        get
        {
            return _maximum;
        }

        set
        {
            if (value < _minimum)
            {
                _minimum = value;
            }

            _maximum = value;

            if (_value > _maximum)
            {
                SetValue(_maximum);
            }

            Invalidate();
        }
    }


    // =========================================================
    // INCREMENT
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Increment")]
    [Description("Pas d'incrémentation.")]
    [DefaultValue(typeof(decimal), "1")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public decimal Increment
    {
        get
        {
            return _increment;
        }

        set
        {
            if (value <= 0)
            {
                value = 1;
            }

            _increment = value;
        }
    }


    // =========================================================
    // DECIMAL PLACES
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Decimal Places")]
    [Description("Nombre de chiffres après la virgule.")]
    [DefaultValue(0)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int DecimalPlaces
    {
        get
        {
            return _decimalPlaces;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            if (value > 28)
            {
                value = 28;
            }

            _decimalPlaces = value;

            _value =
                decimal.Round(
                    _value,
                    _decimalPlaces);

            UpdateText();

            UpdateMinimumSize();

            EnsureMinimumSize();

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // SEPARATEUR DE MILLIERS
    // =========================================================

    [Browsable(true)]
    [Category("Data")]
    [DisplayName("Thousands Separator")]
    [Description("Affiche un séparateur de milliers.")]
    [DefaultValue(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public bool ThousandsSeparator
    {
        get
        {
            return _thousandsSeparator;
        }

        set
        {
            _thousandsSeparator = value;

            UpdateText();
        }
    }


    // =========================================================
    // READ ONLY
    // =========================================================

    [Browsable(true)]
    [Category("Behavior")]
    [DisplayName("Read Only")]
    [Description("Empêche la saisie manuelle.")]
    [DefaultValue(false)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public bool ReadOnly
    {
        get
        {
            return _textBox.ReadOnly;
        }

        set
        {
            _textBox.ReadOnly = value;
        }
    }


    // =========================================================
    // ALIGNEMENT
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Text Align")]
    [Description("Alignement de la valeur.")]
    [DefaultValue(HorizontalAlignment.Left)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public HorizontalAlignment TextAlign
    {
        get
        {
            return _textBox.TextAlign;
        }

        set
        {
            _textBox.TextAlign = value;
        }
    }


    // =========================================================
    // TEXT PADDING
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Text Padding")]
    [Description(
        "Espace entre la valeur et le bord gauche du contrôle.")]
    [DefaultValue(8)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int TextPadding
    {
        get
        {
            return _textPadding;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _textPadding = value;

            UpdateMinimumSize();

            EnsureMinimumSize();

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // BORDER RADIUS
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Border Radius")]
    [Description("Rayon des coins arrondis.")]
    [DefaultValue(12)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int BorderRadius
    {
        get
        {
            return _borderRadius;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _borderRadius = value;

            UpdateRegion();

            Invalidate();
        }
    }


    // =========================================================
    // BORDER SIZE
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Border Size")]
    [Description("Épaisseur de la bordure.")]
    [DefaultValue(1)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int BorderSize
    {
        get
        {
            return _borderSize;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _borderSize = value;

            UpdateMinimumSize();

            EnsureMinimumSize();

            UpdateLayout();

            UpdateRegion();

            Invalidate();
        }
    }


    // =========================================================
    // BORDER COLOR
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Border Color")]
    [Description("Couleur normale de la bordure.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
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
    // FOCUS BORDER COLOR
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    [DisplayName("Focus Border Color")]
    [Description(
        "Couleur de la bordure lorsque le contrôle est actif.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public Color FocusBorderColor
    {
        get
        {
            return _focusBorderColor;
        }

        set
        {
            _focusBorderColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // BUTTON WIDTH
    // =========================================================

    [Browsable(true)]
    [Category("Buttons")]
    [DisplayName("Button Width")]
    [Description("Largeur de la zone des boutons + et −.")]
    [DefaultValue(30)]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public int ButtonWidth
    {
        get
        {
            return _buttonWidth;
        }

        set
        {
            if (value < 18)
            {
                value = 18;
            }

            _buttonWidth = value;

            UpdateMinimumSize();

            EnsureMinimumSize();

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // BUTTON FONT
    // =========================================================

    [Browsable(true)]
    [Category("Buttons")]
    [DisplayName("Button Font")]
    [Description("Police des symboles + et −.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public Font ButtonFont
    {
        get
        {
            return _buttonFont;
        }

        set
        {
            if (value == null)
            {
                return;
            }

            _buttonFont = value;

            UpdateMinimumSize();

            EnsureMinimumSize();

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // BUTTON BACK COLOR
    // =========================================================

    [Browsable(true)]
    [Category("Buttons")]
    [DisplayName("Button Back Color")]
    [Description("Couleur de fond des boutons.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public Color ButtonBackColor
    {
        get
        {
            return _buttonBackColor;
        }

        set
        {
            _buttonBackColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // BUTTON HOVER COLOR
    // =========================================================

    [Browsable(true)]
    [Category("Buttons")]
    [DisplayName("Button Hover Color")]
    [Description("Couleur des boutons au survol.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public Color ButtonHoverColor
    {
        get
        {
            return _buttonHoverColor;
        }

        set
        {
            _buttonHoverColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // BUTTON FORE COLOR
    // =========================================================

    [Browsable(true)]
    [Category("Buttons")]
    [DisplayName("Button Fore Color")]
    [Description("Couleur des symboles + et −.")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Visible)]
    public Color ButtonForeColor
    {
        get
        {
            return _buttonForeColor;
        }

        set
        {
            _buttonForeColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // VALUE CHANGED
    // =========================================================

    [Browsable(true)]
    [Category("Action")]
    [Description("Se produit lorsque la valeur change.")]
    public event EventHandler ValueChanged;


    protected virtual void OnValueChanged(
        EventArgs e)
    {
        if (ValueChanged != null)
        {
            ValueChanged(
                this,
                e);
        }
    }


    // =========================================================
    // SET VALUE
    // =========================================================

    private void SetValue(
        decimal value)
    {
        if (value < _minimum)
        {
            value = _minimum;
        }

        if (value > _maximum)
        {
            value = _maximum;
        }

        value =
            decimal.Round(
                value,
                _decimalPlaces);

        if (_value == value)
        {
            UpdateText();
            return;
        }

        _value = value;

        UpdateText();

        OnValueChanged(
            EventArgs.Empty);

        Invalidate();
    }


    // =========================================================
    // AUGMENTER
    // =========================================================

    private void IncreaseValue()
    {
        SetValue(
            _value +
            _increment);
    }


    // =========================================================
    // DIMINUER
    // =========================================================

    private void DecreaseValue()
    {
        SetValue(
            _value -
            _increment);
    }


    // =========================================================
    // UPDATE TEXT
    // =========================================================

    private void UpdateText()
    {
        if (_textBox == null)
        {
            return;
        }

        _internalUpdate = true;

        string format;

        if (_thousandsSeparator)
        {
            format =
                "N" +
                _decimalPlaces.ToString();
        }
        else
        {
            format =
                "F" +
                _decimalPlaces.ToString();
        }

        _textBox.Text =
            _value.ToString(
                format,
                CultureInfo.CurrentCulture);

        _internalUpdate = false;
    }


    // =========================================================
    // TEXT CHANGED
    // =========================================================

    private void TextBox_TextChanged(
        object sender,
        EventArgs e)
    {
        if (_internalUpdate)
        {
            return;
        }

        decimal value;

        if (decimal.TryParse(
            _textBox.Text,
            NumberStyles.Number,
            CultureInfo.CurrentCulture,
            out value))
        {
            if (value >= _minimum &&
                value <= _maximum)
            {
                value =
                    decimal.Round(
                        value,
                        _decimalPlaces);

                if (_value != value)
                {
                    _value = value;

                    OnValueChanged(
                        EventArgs.Empty);
                }
            }
        }
    }


    // =========================================================
    // KEY PRESS
    // =========================================================

    private void TextBox_KeyPress(
        object sender,
        KeyPressEventArgs e)
    {
        if (char.IsControl(
            e.KeyChar))
        {
            return;
        }

        if (char.IsDigit(
            e.KeyChar))
        {
            return;
        }

        if ((e.KeyChar == '.' ||
             e.KeyChar == ',') &&
            _decimalPlaces > 0)
        {
            return;
        }

        if (e.KeyChar == '-' &&
            _minimum < 0 &&
            _textBox.SelectionStart == 0)
        {
            return;
        }

        e.Handled = true;
    }


    // =========================================================
    // KEY DOWN
    // =========================================================

    private void TextBox_KeyDown(
        object sender,
        KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up)
        {
            IncreaseValue();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Down)
        {
            DecreaseValue();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }


    // =========================================================
    // ENTER
    // =========================================================

    private void TextBox_Enter(
        object sender,
        EventArgs e)
    {
        Invalidate();
    }


    // =========================================================
    // LEAVE
    // =========================================================

    private void TextBox_Leave(
        object sender,
        EventArgs e)
    {
        decimal value;

        if (decimal.TryParse(
            _textBox.Text,
            NumberStyles.Number,
            CultureInfo.CurrentCulture,
            out value))
        {
            SetValue(value);
        }
        else
        {
            UpdateText();
        }

        Invalidate();
    }


    // =========================================================
    // MOUSE MOVE
    // =========================================================

    protected override void OnMouseMove(
        MouseEventArgs e)
    {
        base.OnMouseMove(e);

        Rectangle upRectangle;
        Rectangle downRectangle;

        GetButtonRectangles(
            out upRectangle,
            out downRectangle);


        bool up =
            upRectangle.Contains(
                e.Location);

        bool down =
            downRectangle.Contains(
                e.Location);


        if (_upHovered != up ||
            _downHovered != down)
        {
            _upHovered = up;
            _downHovered = down;

            Cursor =
                (up || down)
                ? Cursors.Hand
                : Cursors.Default;

            Invalidate();
        }
    }


    // =========================================================
    // MOUSE LEAVE
    // =========================================================

    protected override void OnMouseLeave(
        EventArgs e)
    {
        base.OnMouseLeave(e);

        _upHovered = false;
        _downHovered = false;

        Cursor =
            Cursors.Default;

        Invalidate();
    }


    // =========================================================
    // MOUSE DOWN
    // =========================================================

    protected override void OnMouseDown(
        MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        Rectangle upRectangle;
        Rectangle downRectangle;

        GetButtonRectangles(
            out upRectangle,
            out downRectangle);


        if (upRectangle.Contains(
            e.Location))
        {
            IncreaseValue();

            Invalidate();

            return;
        }


        if (downRectangle.Contains(
            e.Location))
        {
            DecreaseValue();

            Invalidate();

            return;
        }


        if (_textBox != null)
        {
            _textBox.Focus();
        }
    }


    // =========================================================
    // RECTANGLES DES BOUTONS
    // =========================================================

    private void GetButtonRectangles(
        out Rectangle upRectangle,
        out Rectangle downRectangle)
    {
        int padding =
            Math.Max(
                2,
                _borderSize);


        int buttonWidth =
            GetRealButtonWidth();


        int buttonHeight =
            GetSingleButtonHeight();


        int totalHeight =
            buttonHeight * 2;


        int x =
            Width -
            padding -
            buttonWidth;


        int y =
            (Height -
             totalHeight) / 2;


        if (y < padding)
        {
            y = padding;
        }


        upRectangle =
            new Rectangle(
                x,
                y,
                buttonWidth,
                buttonHeight);


        downRectangle =
            new Rectangle(
                x,
                y +
                buttonHeight,
                buttonWidth,
                buttonHeight);
    }


    // =========================================================
    // LARGEUR BOUTON
    // =========================================================

    private int GetRealButtonWidth()
    {
        int symbolWidth =
            TextRenderer.MeasureText(
                "+",
                _buttonFont).Width;


        return Math.Max(
            _buttonWidth,
            symbolWidth + 10);
    }


    // =========================================================
    // HAUTEUR BOUTON
    // =========================================================

    private int GetSingleButtonHeight()
    {
        int symbolHeight =
            TextRenderer.MeasureText(
                "+",
                _buttonFont).Height;


        int height =
            symbolHeight + 1;


        if (height < 8)
        {
            height = 8;
        }


        return height;
    }


    // =========================================================
    // TAILLE MINIMALE
    // =========================================================

    private void UpdateMinimumSize()
    {
        if (_textBox == null)
        {
            return;
        }


        int padding =
            Math.Max(
                2,
                _borderSize);


        // =====================================================
        // TEXTE
        // =====================================================

        int textHeight =
            TextRenderer.MeasureText(
                "0",
                Font).Height;


        int textRequiredHeight =
            textHeight +
            padding * 2;


        // =====================================================
        // BOUTONS
        // =====================================================

        int buttonHeight =
            GetSingleButtonHeight();


        int buttonsRequiredHeight =
            (buttonHeight * 2) +
            padding * 2;


        // =====================================================
        // HAUTEUR FINALE
        // =====================================================

        int requiredHeight =
            Math.Max(
                textRequiredHeight,
                buttonsRequiredHeight);


        // Hauteur compacte
        if (requiredHeight < 26)
        {
            requiredHeight = 26;
        }


        // =====================================================
        // LARGEUR
        // =====================================================

        int buttonWidth =
            GetRealButtonWidth();


        int requiredWidth =
            padding +
            _textPadding +
            35 +
            buttonWidth +
            padding;


        if (requiredWidth < 65)
        {
            requiredWidth = 65;
        }


        base.MinimumSize =
            new Size(
                requiredWidth,
                requiredHeight);
    }


    // =========================================================
    // GARANTIR MINIMUM
    // =========================================================

    private void EnsureMinimumSize()
    {
        if (_adjustingSize)
        {
            return;
        }


        _adjustingSize = true;


        int width =
            Math.Max(
                Width,
                MinimumSize.Width);


        int height =
            Math.Max(
                Height,
                MinimumSize.Height);


        if (Width != width ||
            Height != height)
        {
            base.Size =
                new Size(
                    width,
                    height);
        }


        _adjustingSize = false;
    }


    // =========================================================
    // SET BOUNDS
    // =========================================================

    protected override void SetBoundsCore(
        int x,
        int y,
        int width,
        int height,
        BoundsSpecified specified)
    {
        if (!_adjustingSize)
        {
            width =
                Math.Max(
                    width,
                    MinimumSize.Width);

            height =
                Math.Max(
                    height,
                    MinimumSize.Height);
        }


        base.SetBoundsCore(
            x,
            y,
            width,
            height,
            specified);
    }


    // =========================================================
    // LAYOUT
    // =========================================================

    private void UpdateLayout()
    {
        if (_textBox == null)
        {
            return;
        }


        int padding =
            Math.Max(
                2,
                _borderSize);


        int buttonWidth =
            GetRealButtonWidth();


        // =====================================================
        // LARGEUR TEXTBOX
        // =====================================================

        int textWidth =
            Width -
            buttonWidth -
            padding -
            _textPadding -
            3;


        if (textWidth < 15)
        {
            textWidth = 15;
        }


        // =====================================================
        // HAUTEUR TEXTBOX
        // =====================================================

        int textHeight =
            TextRenderer.MeasureText(
                "0",
                Font).Height;


        int availableHeight =
            Height -
            padding * 2;


        if (textHeight >
            availableHeight)
        {
            textHeight =
                Math.Max(
                    8,
                    availableHeight);
        }


        // =====================================================
        // POSITION VERTICALE
        // =====================================================

        int textY =
            (Height -
             textHeight) / 2;


        if (textY < padding)
        {
            textY =
                padding;
        }


        // =====================================================
        // POSITION HORIZONTALE
        // =====================================================

        int textX =
            padding +
            _textPadding;


        // =====================================================
        // TEXTBOX
        // =====================================================

        _textBox.Location =
            new Point(
                textX,
                textY);


        _textBox.Size =
            new Size(
                textWidth,
                textHeight);


        _textBox.Font =
            Font;

        _textBox.BackColor =
            BackColor;

        _textBox.ForeColor =
            ForeColor;
    }


    // =========================================================
    // FONT CHANGED
    // =========================================================

    private void RoundedNumericUpDown_FontChanged(
        object sender,
        EventArgs e)
    {
        if (_textBox != null)
        {
            _textBox.Font =
                Font;
        }


        UpdateMinimumSize();

        EnsureMinimumSize();

        UpdateLayout();

        UpdateRegion();

        Invalidate();
    }


    // =========================================================
    // RESIZE
    // =========================================================

    private void RoundedNumericUpDown_Resize(
        object sender,
        EventArgs e)
    {
        if (!_adjustingSize)
        {
            EnsureMinimumSize();
        }


        UpdateLayout();

        UpdateRegion();

        Invalidate();
    }


    // =========================================================
    // BACK COLOR CHANGED
    // =========================================================

    private void RoundedNumericUpDown_BackColorChanged(
        object sender,
        EventArgs e)
    {
        if (_textBox != null)
        {
            _textBox.BackColor =
                BackColor;
        }

        Invalidate();
    }


    // =========================================================
    // FORE COLOR CHANGED
    // =========================================================

    private void RoundedNumericUpDown_ForeColorChanged(
        object sender,
        EventArgs e)
    {
        if (_textBox != null)
        {
            _textBox.ForeColor =
                ForeColor;
        }

        Invalidate();
    }


    // =========================================================
    // REGION
    // =========================================================

    private void UpdateRegion()
    {
        if (Width <= 0 ||
            Height <= 0)
        {
            return;
        }


        using (GraphicsPath path =
               CreateRoundedPath(
                   new RectangleF(
                       0,
                       0,
                       Width,
                       Height),
                   _borderRadius))
        {
            Region =
                new Region(path);
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


        // =====================================================
        // RENDU HAUTE QUALITE
        // =====================================================

        g.SmoothingMode =
            SmoothingMode.HighQuality;

        g.CompositingQuality =
            CompositingQuality.HighQuality;

        g.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        g.CompositingMode =
            CompositingMode.SourceOver;


        // =====================================================
        // RECTANGLE INTERIEUR
        // =====================================================

        float halfBorder =
            _borderSize / 2f;


        RectangleF rect =
            new RectangleF(
                halfBorder,
                halfBorder,
                Width -
                _borderSize,
                Height -
                _borderSize);


        if (rect.Width <= 0 ||
            rect.Height <= 0)
        {
            return;
        }


        float radius =
            _borderRadius;


        float maxRadius =
            Math.Min(
                rect.Width,
                rect.Height) / 2f;


        radius =
            Math.Min(
                radius,
                maxRadius);


        // =====================================================
        // FOND + BORDURE
        // =====================================================

        using (GraphicsPath path =
               CreateRoundedPath(
                   rect,
                   radius))
        {
            // Fond
            using (SolidBrush brush =
                   new SolidBrush(
                       BackColor))
            {
                g.FillPath(
                    brush,
                    path);
            }


            // Bordure
            if (_borderSize > 0)
            {
                Color borderColor =
                    (_textBox != null &&
                     _textBox.Focused)
                    ? _focusBorderColor
                    : _borderColor;


                using (Pen pen =
                       new Pen(
                           borderColor,
                           _borderSize))
                {
                    pen.Alignment =
                        PenAlignment.Center;

                    pen.LineJoin =
                        LineJoin.Round;

                    pen.StartCap =
                        LineCap.Round;

                    pen.EndCap =
                        LineCap.Round;


                    g.DrawPath(
                        pen,
                        path);
                }
            }
        }


        // =====================================================
        // BOUTONS
        // =====================================================

        DrawButtons(g);
    }


    // =========================================================
    // DESSIN DES BOUTONS
    // =========================================================

    private void DrawButtons(
        Graphics g)
    {
        Rectangle upRectangle;
        Rectangle downRectangle;

        GetButtonRectangles(
            out upRectangle,
            out downRectangle);


        // =====================================================
        // FOND BOUTON +
        // =====================================================

        if (_upHovered)
        {
            using (SolidBrush brush =
                   new SolidBrush(
                       _buttonHoverColor))
            {
                g.FillRectangle(
                    brush,
                    upRectangle);
            }
        }


        // =====================================================
        // FOND BOUTON -
        // =====================================================

        if (_downHovered)
        {
            using (SolidBrush brush =
                   new SolidBrush(
                       _buttonHoverColor))
            {
                g.FillRectangle(
                    brush,
                    downRectangle);
            }
        }


        // =====================================================
        // +
        // =====================================================

        DrawSymbol(
            g,
            "+",
            upRectangle);


        // =====================================================
        // -
        // =====================================================

        DrawSymbol(
            g,
            "−",
            downRectangle);
    }


    // =========================================================
    // DESSIN SYMBOL
    // =========================================================

    private void DrawSymbol(
        Graphics g,
        string symbol,
        Rectangle rectangle)
    {
        using (SolidBrush brush =
               new SolidBrush(
                   _buttonForeColor))
        {
            using (StringFormat format =
                   new StringFormat())
            {
                format.Alignment =
                    StringAlignment.Center;

                format.LineAlignment =
                    StringAlignment.Center;

                format.FormatFlags =
                    StringFormatFlags.NoWrap;


                g.DrawString(
                    symbol,
                    _buttonFont,
                    brush,
                    rectangle,
                    format);
            }
        }
    }


    // =========================================================
    // CHEMIN ARRONDI
    // =========================================================

    private GraphicsPath CreateRoundedPath(
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


        if (radius <= 0)
        {
            path.AddRectangle(
                rect);

            return path;
        }


        float maxRadius =
            Math.Min(
                rect.Width,
                rect.Height) / 2f;


        radius =
            Math.Min(
                radius,
                maxRadius);


        float diameter =
            radius * 2f;


        // Haut gauche
        path.AddArc(
            rect.X,
            rect.Y,
            diameter,
            diameter,
            180,
            90);


        // Haut droit
        path.AddArc(
            rect.Right -
            diameter,
            rect.Y,
            diameter,
            diameter,
            270,
            90);


        // Bas droit
        path.AddArc(
            rect.Right -
            diameter,
            rect.Bottom -
            diameter,
            diameter,
            diameter,
            0,
            90);


        // Bas gauche
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
}