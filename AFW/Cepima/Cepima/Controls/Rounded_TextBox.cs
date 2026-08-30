using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MyRoundedTextBox : UserControl
{
    private TextBox _textBox;
    private int _borderRadius = 15;
    private int _borderSize = 2;
    private Color _borderColor = Color.DeepSkyBlue;
    private Color _focusBorderColor = Color.Orange;
    private string _placeholderText = "Enter text...";
    private Color _placeholderColor = Color.Gray;
    private bool _isPlaceholderActive = true;

    public MyRoundedTextBox()
    {
        _textBox = new TextBox
        {
            BorderStyle = BorderStyle.None,
            BackColor = Color.White,
            ForeColor = _placeholderColor,
            Font = new Font("Arial", 10F),
            Text = _placeholderText,
            Location = new Point(10, 5),
            UseSystemPasswordChar = false
        };

        Controls.Add(_textBox);
        Resize += MyRoundedTextBox_Resize;
        _textBox.Enter += RemovePlaceholder;
        _textBox.Leave += SetPlaceholder;

        Invalidate();
    }

    // Propriétés
    public int BorderRadius
    {
        get { return _borderRadius; }
        set { _borderRadius = value; Invalidate(); }
    }

    public int BorderSize
    {
        get { return _borderSize; }
        set { _borderSize = value; Invalidate(); }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set { _borderColor = value; Invalidate(); }
    }

    public Color FocusBorderColor
    {
        get { return _focusBorderColor; }
        set { _focusBorderColor = value; Invalidate(); }
    }

    public string PlaceholderText
    {
        get { return _placeholderText; }
        set { _placeholderText = value; UpdatePlaceholder(); }
    }

    public Color PlaceholderColor
    {
        get { return _placeholderColor; }
        set { _placeholderColor = value; UpdatePlaceholder(); }
    }

    public override string Text
    {
        get { return _isPlaceholderActive ? string.Empty : _textBox.Text; }
        set
        {
            _textBox.Text = value;
            _isPlaceholderActive = string.IsNullOrWhiteSpace(value);
            UpdatePlaceholder();
        }
    }

    public char PasswordChar
    {
        get { return _textBox.PasswordChar; }
        set { _textBox.PasswordChar = value; }
    }

    public bool UseSystemPasswordChar
    {
        get { return _textBox.UseSystemPasswordChar; }
        set { _textBox.UseSystemPasswordChar = value; }
    }

    private void UpdatePlaceholder()
    {
        if (_isPlaceholderActive)
        {
            _textBox.Text = _placeholderText;
            _textBox.ForeColor = _placeholderColor;
            _textBox.UseSystemPasswordChar = false;
        }
        else
        {
            _textBox.ForeColor = Color.Black;
        }
    }

    private void RemovePlaceholder(object sender, EventArgs e)
    {
        if (_isPlaceholderActive)
        {
            _textBox.Text = string.Empty;
            _textBox.ForeColor = Color.Black;
            _isPlaceholderActive = false;
            _textBox.UseSystemPasswordChar = UseSystemPasswordChar;
        }
    }

    private void SetPlaceholder(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_textBox.Text))
        {
            _textBox.Text = _placeholderText;
            _textBox.ForeColor = _placeholderColor;
            _isPlaceholderActive = true;
            _textBox.UseSystemPasswordChar = false;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

        // Dessiner le fond avec coins arrondis
        using (GraphicsPath path = CreateRoundedRectanglePath(rect, _borderRadius))
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                graphics.FillPath(brush, path);
            }

            // Dessiner la bordure
            Color borderColor = _textBox.Focused ? _focusBorderColor : _borderColor;
            using (Pen pen = new Pen(borderColor, _borderSize))
            {
                pen.Alignment = PenAlignment.Inset;
                graphics.DrawPath(pen, path);
            }
        }
    }

    private void MyRoundedTextBox_Resize(object sender, EventArgs e)
    {
        // Ajuster la taille et la position du TextBox pour qu'il laisse de l'espace pour la bordure
        _textBox.Width = Width - 20;
        _textBox.Height = Height - 10;
        _textBox.Location = new Point(10, (Height - _textBox.Height) / 2);
    }

    private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
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