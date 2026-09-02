using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("TextChanged")]
public class MyRoundedTextBox : UserControl
{
    // =========================================================
    // CHAMPS PRIVÉS
    // =========================================================
    private readonly TextBox _textBox;

    private int _borderRadius = 12;
    private int _borderSize = 2;

    private Color _borderColor = Color.DeepSkyBlue;
    private Color _focusBorderColor = Color.Orange;

    private string _placeholderText = "Enter text...";
    private Color _placeholderColor = Color.Gray;
    private bool _isPlaceholderActive = false;

    private Image _image;
    private ContentAlignment _imageAlign = ContentAlignment.MiddleLeft;
    private int _imagePadding = 8;
    private HorizontalAlignment _textAlign = HorizontalAlignment.Left;

    // =========================================================
    // CONSTRUCTEUR
    // =========================================================
    public MyRoundedTextBox()
    {
        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor,
            true);

        // 1. Initialisation du TextBox interne EN PREMIER
        _textBox = new TextBox
        {
            BorderStyle = BorderStyle.None,
            TextAlign = _textAlign,
            TabStop = true
        };

        // 2. Application des styles et valeurs par défaut
        Size = new Size(250, 40);
        BackColor = Color.White;
        ForeColor = Color.Black;
        Padding = new Padding(10, 7, 10, 7);

        _textBox.BackColor = BackColor;
        _textBox.ForeColor = ForeColor;
        _textBox.Font = Font;

        Controls.Add(_textBox);

        // 3. Événements
        _textBox.Enter += TextBox_Enter;
        _textBox.Leave += TextBox_Leave;
        _textBox.TextChanged += InnerTextBox_TextChanged;
        _textBox.Click += delegate(object sender, EventArgs e) { OnClick(e); };

        Click += delegate(object sender, EventArgs e) { _textBox.Focus(); };

        CheckPlaceholder();
        UpdateControlLayout();
    }

    // =========================================================
    // GESTION DU PLACEHOLDER ET FOCUS
    // =========================================================
    private void CheckPlaceholder()
    {
        if (_textBox == null) return;

        if (string.IsNullOrEmpty(_textBox.Text) || _isPlaceholderActive)
        {
            _isPlaceholderActive = true;
            _textBox.Text = _placeholderText;
            _textBox.ForeColor = _placeholderColor;
            if (UseSystemPasswordChar || PasswordChar != '\0')
                _textBox.UseSystemPasswordChar = false;
        }
    }

    private void TextBox_Enter(object sender, EventArgs e)
    {
        if (_isPlaceholderActive)
        {
            _isPlaceholderActive = false;
            _textBox.Text = string.Empty;
            _textBox.ForeColor = ForeColor;

            if (UseSystemPasswordChar)
                _textBox.UseSystemPasswordChar = true;
        }
        Invalidate();
    }

    private void TextBox_Leave(object sender, EventArgs e)
    {
        CheckPlaceholder();
        Invalidate();
    }

    private void InnerTextBox_TextChanged(object sender, EventArgs e)
    {
        if (!_isPlaceholderActive)
            base.OnTextChanged(e);
    }

    // =========================================================
    // PROPRIÉTÉS PERSONNALISÉES (STYLE & COMPORTEMENT)
    // =========================================================
    [Category("Appearance")]
    [DefaultValue(12)]
    public int BorderRadius
    {
        get { return _borderRadius; }
        set
        {
            _borderRadius = Math.Max(0, value);
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(2)]
    public int BorderSize
    {
        get { return _borderSize; }
        set
        {
            _borderSize = Math.Max(0, value);
            UpdateControlLayout();
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get { return _borderColor; }
        set { _borderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    public Color FocusBorderColor
    {
        get { return _focusBorderColor; }
        set { _focusBorderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    public string PlaceholderText
    {
        get { return _placeholderText; }
        set
        {
            _placeholderText = value;
            if (_isPlaceholderActive && _textBox != null)
                _textBox.Text = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color PlaceholderColor
    {
        get { return _placeholderColor; }
        set
        {
            _placeholderColor = value;
            if (_isPlaceholderActive && _textBox != null)
                _textBox.ForeColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Image Image
    {
        get { return _image; }
        set
        {
            _image = value;
            UpdateControlLayout();
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleLeft)]
    public ContentAlignment ImageAlign
    {
        get { return _imageAlign; }
        set
        {
            _imageAlign = value;
            UpdateControlLayout();
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(8)]
    public int ImagePadding
    {
        get { return _imagePadding; }
        set
        {
            _imagePadding = Math.Max(0, value);
            UpdateControlLayout();
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment TextAlign
    {
        get { return _textAlign; }
        set
        {
            _textAlign = value;
            if (_textBox != null)
                _textBox.TextAlign = value;
        }
    }

    // =========================================================
    // PROPRIÉTÉS DÉLÉGUÉES ET SÉCURISÉES POUR _TEXTBOX
    // =========================================================
    [Category("Behavior")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get
        {
            if (_textBox == null) return string.Empty;
            return _isPlaceholderActive ? string.Empty : _textBox.Text;
        }
        set
        {
            if (_textBox == null) return;

            if (string.IsNullOrEmpty(value))
            {
                _isPlaceholderActive = true;
                _textBox.Text = _placeholderText;
                _textBox.ForeColor = _placeholderColor;
            }
            else
            {
                _isPlaceholderActive = false;
                _textBox.ForeColor = ForeColor;
                _textBox.Text = value;
            }
            Invalidate();
        }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool Multiline
    {
        get { return _textBox != null && _textBox.Multiline; }
        set
        {
            if (_textBox != null)
            {
                _textBox.Multiline = value;
                UpdateControlLayout();
            }
        }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool ReadOnly
    {
        get { return _textBox != null && _textBox.ReadOnly; }
        set
        {
            if (_textBox != null)
                _textBox.ReadOnly = value;
        }
    }

    [Category("Behavior")]
    [DefaultValue(0)]
    public int MaxLength
    {
        get { return _textBox != null ? _textBox.MaxLength : 32767; }
        set
        {
            if (_textBox != null)
                _textBox.MaxLength = value;
        }
    }

    [Category("Behavior")]
    [DefaultValue('\0')]
    public char PasswordChar
    {
        get { return _textBox != null ? _textBox.PasswordChar : '\0'; }
        set
        {
            if (_textBox != null)
            {
                _textBox.PasswordChar = value;
                if (!_isPlaceholderActive)
                    _textBox.UseSystemPasswordChar = false;
            }
        }
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool UseSystemPasswordChar
    {
        get { return _textBox != null && _textBox.UseSystemPasswordChar; }
        set
        {
            if (_textBox != null && !_isPlaceholderActive)
                _textBox.UseSystemPasswordChar = value;
        }
    }

    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            if (_textBox != null)
            {
                _textBox.Font = value;
                UpdateControlLayout();
            }
        }
    }

    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            base.BackColor = value;
            if (_textBox != null)
            {
                _textBox.BackColor = value;
            }
            Invalidate();
        }
    }

    public override Color ForeColor
    {
        get { return base.ForeColor; }
        set
        {
            base.ForeColor = value;
            if (_textBox != null && !_isPlaceholderActive)
            {
                _textBox.ForeColor = value;
            }
            Invalidate();
        }
    }

    // =========================================================
    // LAYOUT ET POSITIONNEMENT
    // =========================================================
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateControlLayout();
    }

    private void UpdateControlLayout()
    {
        if (_textBox == null) return;

        int leftOffset = Padding.Left + _borderSize;
        int rightOffset = Padding.Right + _borderSize;

        if (_image != null)
        {
            if (_imageAlign == ContentAlignment.MiddleLeft ||
                _imageAlign == ContentAlignment.TopLeft ||
                _imageAlign == ContentAlignment.BottomLeft)
            {
                leftOffset += _image.Width + _imagePadding;
            }

            if (_imageAlign == ContentAlignment.MiddleRight ||
                _imageAlign == ContentAlignment.TopRight ||
                _imageAlign == ContentAlignment.BottomRight)
            {
                rightOffset += _image.Width + _imagePadding;
            }
        }

        _textBox.Left = leftOffset;
        _textBox.Width = Math.Max(10, Width - leftOffset - rightOffset);

        if (!_textBox.Multiline)
        {
            int txtHeight = _textBox.PreferredHeight;
            _textBox.Top = (Height - txtHeight) / 2;
            _textBox.Height = txtHeight;
        }
        else
        {
            _textBox.Top = Padding.Top + _borderSize;
            _textBox.Height = Math.Max(10, Height - (Padding.Top + Padding.Bottom + (_borderSize * 2)));
        }
    }

    // =========================================================
    // RENDU GRAPHIQUE (PAINT)
    // =========================================================
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        float halfBorder = _borderSize / 2f;
        RectangleF rect = new RectangleF(
            halfBorder,
            halfBorder,
            Width - _borderSize,
            Height - _borderSize);

        float radius = Math.Min(_borderRadius, Math.Min(rect.Width, rect.Height) / 2f);

        using (GraphicsPath path = GetRoundedPath(rect, radius))
        {
            // Dessin du fond
            using (SolidBrush bgBrush = new SolidBrush(BackColor))
            {
                g.FillPath(bgBrush, path);
            }

            // Dessin de la bordure
            if (_borderSize > 0)
            {
                bool isFocused = _textBox != null && _textBox.Focused;
                Color currentBorderColor = isFocused ? _focusBorderColor : _borderColor;
                using (Pen pen = new Pen(currentBorderColor, _borderSize))
                {
                    pen.Alignment = PenAlignment.Center;
                    g.DrawPath(pen, path);
                }
            }
        }

        // Dessin de l'image
        if (_image != null)
        {
            DrawControlImage(g);
        }
    }

    private void DrawControlImage(Graphics g)
    {
        int x = Padding.Left + _borderSize;
        int y = (Height - _image.Height) / 2;

        switch (_imageAlign)
        {
            case ContentAlignment.TopLeft:
            case ContentAlignment.TopCenter:
            case ContentAlignment.TopRight:
                y = Padding.Top + _borderSize;
                break;
            case ContentAlignment.BottomLeft:
            case ContentAlignment.BottomCenter:
            case ContentAlignment.BottomRight:
                y = Height - _image.Height - Padding.Bottom - _borderSize;
                break;
        }

        switch (_imageAlign)
        {
            case ContentAlignment.TopCenter:
            case ContentAlignment.MiddleCenter:
            case ContentAlignment.BottomCenter:
                x = (Width - _image.Width) / 2;
                break;
            case ContentAlignment.TopRight:
            case ContentAlignment.MiddleRight:
            case ContentAlignment.BottomRight:
                x = Width - _image.Width - Padding.Right - _borderSize;
                break;
        }

        g.DrawImage(_image, new Rectangle(x, y, _image.Width, _image.Height));
    }

    private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        if (radius <= 0f)
        {
            path.AddRectangle(rect);
            return path;
        }

        float diameter = radius * 2f;
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}