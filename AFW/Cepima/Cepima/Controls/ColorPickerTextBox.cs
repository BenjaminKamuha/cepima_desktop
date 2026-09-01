using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

[DefaultEvent("ColorChanged")]
[DefaultProperty("HexColor")]
public class ColorPickerTextBox : UserControl
{
    private TextBox _textBox;
    private Button _colorButton;

    private Color _selectedColor = Color.DodgerBlue;

    private int _borderRadius = 12;
    private int _borderSize = 1;

    private Color _borderColor = Color.LightGray;
    private Color _focusBorderColor = Color.DeepSkyBlue;

    private bool _updatingText = false;

    // =========================================================
    // NOUVELLES PROPRIETES DU BOUTON COULEUR
    // =========================================================

    private int _colorButtonSize = 24;
    private int _colorButtonMargin = 6;
    private int _colorButtonRadius = 4;


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public ColorPickerTextBox()
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

        this.Size =
            new Size(220, 40);

        this.BackColor =
            Color.White;


        // =====================================================
        // TEXTBOX
        // =====================================================

        _textBox =
            new TextBox();

        _textBox.BorderStyle =
            BorderStyle.None;

        _textBox.BackColor =
            Color.White;

        _textBox.ForeColor =
            Color.Black;

        _textBox.Font =
            new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular);

        _textBox.Text =
            ColorToHex(
                _selectedColor);

        _textBox.TextAlign =
            HorizontalAlignment.Left;


        // =====================================================
        // BOUTON COULEUR
        // =====================================================

        _colorButton =
            new Button();

        _colorButton.FlatStyle =
            FlatStyle.Flat;

        _colorButton.FlatAppearance.BorderSize =
            0;

        _colorButton.BackColor =
            _selectedColor;

        _colorButton.Cursor =
            Cursors.Hand;

        _colorButton.Text =
            "";

        _colorButton.TabStop =
            false;


        // =====================================================
        // AJOUT
        // =====================================================

        this.Controls.Add(
            _textBox);

        this.Controls.Add(
            _colorButton);


        // =====================================================
        // EVENEMENTS
        // =====================================================

        _textBox.TextChanged +=
            TextBox_TextChanged;

        _textBox.Enter +=
            TextBox_Enter;

        _textBox.Leave +=
            TextBox_Leave;

        _colorButton.Click +=
            ColorButton_Click;

        this.Resize +=
            ColorPickerTextBox_Resize;


        UpdateLayout();

        UpdateColorButton();

        Invalidate();
    }


    // =========================================================
    // HEX COLOR
    // =========================================================

    [Category("Color")]
    [Browsable(true)]
    [Description("Code couleur hexadécimal.")]
    [DefaultValue("#1E90FF")]
    public string HexColor
    {
        get
        {
            return ColorToHex(
                _selectedColor);
        }

        set
        {
            Color color;

            if (TryParseHexColor(
                value,
                out color))
            {
                SetSelectedColor(
                    color);
            }
        }
    }


    // =========================================================
    // SELECTED COLOR
    // =========================================================

    [Category("Color")]
    [Browsable(true)]
    [Description("Couleur actuellement sélectionnée.")]
    public Color SelectedColor
    {
        get
        {
            return _selectedColor;
        }

        set
        {
            SetSelectedColor(
                value);
        }
    }


    // =========================================================
    // COLOR BUTTON SIZE
    // =========================================================

    [Category("Color Button")]
    [Browsable(true)]
    [DefaultValue(24)]
    [Description("Taille du carré permettant de choisir la couleur.")]
    public int ColorButtonSize
    {
        get
        {
            return _colorButtonSize;
        }

        set
        {
            if (value < 10)
            {
                value = 10;
            }

            _colorButtonSize =
                value;

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // COLOR BUTTON MARGIN
    // =========================================================

    [Category("Color Button")]
    [Browsable(true)]
    [DefaultValue(6)]
    [Description("Espace entre le carré de couleur et les bords du contrôle.")]
    public int ColorButtonMargin
    {
        get
        {
            return _colorButtonMargin;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _colorButtonMargin =
                value;

            UpdateLayout();

            Invalidate();
        }
    }


    // =========================================================
    // COLOR BUTTON RADIUS
    // =========================================================

    [Category("Color Button")]
    [Browsable(true)]
    [DefaultValue(4)]
    [Description("Rayon des coins du carré de couleur.")]
    public int ColorButtonRadius
    {
        get
        {
            return _colorButtonRadius;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _colorButtonRadius =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // BORDER RADIUS
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(12)]
    [Description("Rayon des coins.")]
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

            _borderRadius =
                value;

            Invalidate();
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
            return _borderSize;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _borderSize =
                value;

            Invalidate();
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
            return _borderColor;
        }

        set
        {
            _borderColor =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // FOCUS BORDER COLOR
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur de la bordure lorsque le champ est sélectionné.")]
    public Color FocusBorderColor
    {
        get
        {
            return _focusBorderColor;
        }

        set
        {
            _focusBorderColor =
                value;

            Invalidate();
        }
    }


    // =========================================================
    // TEXT
    // =========================================================

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override string Text
    {
        get
        {
            return _textBox == null
                ? ""
                : _textBox.Text;
        }

        set
        {
            Color color;

            if (TryParseHexColor(
                value,
                out color))
            {
                SetSelectedColor(
                    color);
            }
            else
            {
                if (_textBox != null)
                {
                    _textBox.Text =
                        value ?? "";
                }
            }
        }
    }


    // =========================================================
    // FONT
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    public override Font Font
    {
        get
        {
            return base.Font;
        }

        set
        {
            base.Font =
                value;

            if (_textBox != null)
            {
                _textBox.Font =
                    value;
            }

            UpdateLayout();
        }
    }


    // =========================================================
    // FORECOLOR
    // =========================================================

    [Browsable(true)]
    [Category("Appearance")]
    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }

        set
        {
            base.ForeColor =
                value;

            if (_textBox != null)
            {
                _textBox.ForeColor =
                    value;
            }
        }
    }


    // =========================================================
    // COLOR CHANGED
    // =========================================================

    [Category("Action")]
    [Description("Se produit lorsque la couleur change.")]
    public event EventHandler ColorChanged;


    // =========================================================
    // SET COLOR
    // =========================================================

    private void SetSelectedColor(
        Color color)
    {
        if (_selectedColor ==
            color)
        {
            UpdateColorButton();

            return;
        }

        _selectedColor =
            color;

        _updatingText =
            true;

        if (_textBox != null)
        {
            _textBox.Text =
                ColorToHex(
                    _selectedColor);
        }

        _updatingText =
            false;

        UpdateColorButton();

        Invalidate();

        OnColorChanged(
            EventArgs.Empty);
    }


    // =========================================================
    // COLOR CHANGED EVENT
    // =========================================================

    protected virtual void OnColorChanged(
        EventArgs e)
    {
        if (ColorChanged != null)
        {
            ColorChanged(
                this,
                e);
        }
    }


    // =========================================================
    // CONVERT COLOR TO HEX
    // =========================================================

    private string ColorToHex(
        Color color)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "#{0:X2}{1:X2}{2:X2}",
            color.R,
            color.G,
            color.B);
    }


    // =========================================================
    // PARSE HEX COLOR
    // =========================================================

    private bool TryParseHexColor(
        string value,
        out Color color)
    {
        color =
            Color.Empty;

        if (string.IsNullOrWhiteSpace(
            value))
        {
            return false;
        }

        string hex =
            value.Trim();

        if (hex.StartsWith("#"))
        {
            hex =
                hex.Substring(1);
        }


        // -----------------------------------------------------
        // #RGB
        // -----------------------------------------------------

        if (hex.Length == 3)
        {
            hex =
                string.Format(
                    "#{0}{0}{1}{1}{2}{2}",
                    hex[0],
                    hex[1],
                    hex[2]);

            hex =
                hex.Substring(1);
        }


        // -----------------------------------------------------
        // RGB
        // -----------------------------------------------------

        if (hex.Length != 6)
        {
            return false;
        }

        int red;
        int green;
        int blue;


        if (!int.TryParse(
            hex.Substring(0, 2),
            NumberStyles.HexNumber,
            CultureInfo.InvariantCulture,
            out red))
        {
            return false;
        }


        if (!int.TryParse(
            hex.Substring(2, 2),
            NumberStyles.HexNumber,
            CultureInfo.InvariantCulture,
            out green))
        {
            return false;
        }


        if (!int.TryParse(
            hex.Substring(4, 2),
            NumberStyles.HexNumber,
            CultureInfo.InvariantCulture,
            out blue))
        {
            return false;
        }


        color =
            Color.FromArgb(
                red,
                green,
                blue);

        return true;
    }


    // =========================================================
    // TEXT CHANGED
    // =========================================================

    private void TextBox_TextChanged(
        object sender,
        EventArgs e)
    {
        if (_updatingText)
        {
            return;
        }

        Color color;

        if (TryParseHexColor(
            _textBox.Text,
            out color))
        {
            if (_selectedColor != color)
            {
                _selectedColor =
                    color;

                UpdateColorButton();

                Invalidate();

                OnColorChanged(
                    EventArgs.Empty);
            }
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
        Color color;

        if (!TryParseHexColor(
            _textBox.Text,
            out color))
        {
            _updatingText =
                true;

            _textBox.Text =
                ColorToHex(
                    _selectedColor);

            _updatingText =
                false;
        }

        Invalidate();
    }


    // =========================================================
    // COLOR BUTTON CLICK
    // =========================================================

    private void ColorButton_Click(
        object sender,
        EventArgs e)
    {
        using (ColorDialog dialog =
               new ColorDialog())
        {
            dialog.Color =
                _selectedColor;

            dialog.FullOpen =
                true;

            if (dialog.ShowDialog() ==
                DialogResult.OK)
            {
                SetSelectedColor(
                    dialog.Color);
            }
        }
    }


    // =========================================================
    // RESIZE
    // =========================================================

    private void ColorPickerTextBox_Resize(
        object sender,
        EventArgs e)
    {
        UpdateLayout();

        Invalidate();
    }


    // =========================================================
    // LAYOUT
    // =========================================================

    private void UpdateLayout()
    {
        if (_textBox == null ||
            _colorButton == null)
        {
            return;
        }


        // =====================================================
        // TAILLE DU BOUTON
        // =====================================================

        int buttonSize =
            _colorButtonSize;


        // Ne jamais dépasser la hauteur disponible
        int maxButtonSize =
            this.Height -
            (_colorButtonMargin * 2);


        if (maxButtonSize < 10)
        {
            maxButtonSize = 10;
        }


        if (buttonSize >
            maxButtonSize)
        {
            buttonSize =
                maxButtonSize;
        }


        // =====================================================
        // POSITION DU BOUTON
        // =====================================================

        int buttonX =
            this.Width -
            buttonSize -
            _colorButtonMargin;


        int buttonY =
            (this.Height -
             buttonSize) / 2;


        _colorButton.Size =
            new Size(
                buttonSize,
                buttonSize);


        _colorButton.Location =
            new Point(
                buttonX,
                buttonY);


        // =====================================================
        // TEXTBOX
        // =====================================================

        int textWidth =
            buttonX -
            15;


        if (textWidth < 20)
        {
            textWidth = 20;
        }


        int textHeight =
            _textBox.PreferredHeight;


        int textY =
            (this.Height -
             textHeight) / 2;


        _textBox.Location =
            new Point(
                10,
                textY);


        _textBox.Size =
            new Size(
                textWidth,
                textHeight);
    }


    // =========================================================
    // UPDATE COLOR BUTTON
    // =========================================================

    private void UpdateColorButton()
    {
        if (_colorButton == null)
        {
            return;
        }

        _colorButton.BackColor =
            _selectedColor;

        _colorButton.Invalidate();
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

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;


        // =====================================================
        // FOND
        // =====================================================

        RectangleF rectangle =
            new RectangleF(
                0.5f,
                0.5f,
                this.Width - 1,
                this.Height - 1);


        using (GraphicsPath path =
               CreateRoundedPath(
                   rectangle,
                   _borderRadius))
        {
            using (SolidBrush brush =
                   new SolidBrush(
                       this.BackColor))
            {
                g.FillPath(
                    brush,
                    path);
            }


            // =================================================
            // BORDURE
            // =================================================

            if (_borderSize > 0)
            {
                Color borderColor =
                    _textBox != null &&
                    _textBox.Focused
                    ? _focusBorderColor
                    : _borderColor;


                using (Pen pen =
                       new Pen(
                           borderColor,
                           _borderSize))
                {
                    pen.Alignment =
                        PenAlignment.Inset;

                    g.DrawPath(
                        pen,
                        path);
                }
            }
        }
    }


    // =========================================================
    // ROUNDED PATH
    // =========================================================

    private GraphicsPath CreateRoundedPath(
        RectangleF rect,
        float radius)
    {
        GraphicsPath path =
            new GraphicsPath();


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


        path.StartFigure();


        path.AddArc(
            rect.X,
            rect.Y,
            diameter,
            diameter,
            180,
            90);


        path.AddArc(
            rect.Right - diameter,
            rect.Y,
            diameter,
            diameter,
            270,
            90);


        path.AddArc(
            rect.Right - diameter,
            rect.Bottom - diameter,
            diameter,
            diameter,
            0,
            90);


        path.AddArc(
            rect.X,
            rect.Bottom - diameter,
            diameter,
            diameter,
            90,
            90);


        path.CloseFigure();


        return path;
    }
}