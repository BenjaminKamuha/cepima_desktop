using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

[DefaultEvent("SelectedIndexChanged")]
[DefaultProperty("Text")]
public class MyRoundedComboBox : UserControl
{
    // =========================================================
    // COMBOBOX INTERNE
    // =========================================================

    private ComboBox _comboBox;

    // =========================================================
    // POPUP
    // =========================================================

    private ToolStripDropDown _popup;
    private ListBox _listBox;

    // =========================================================
    // APPARENCE
    // =========================================================

    private int _borderRadius = 15;
    private int _borderSize = 2;

    private Color _borderColor = Color.DeepSkyBlue;
    private Color _focusBorderColor = Color.Orange;
    private Color _arrowColor = Color.DimGray;

    private int _innerPadding = 10;

    // =========================================================
    // DROPDOWN
    // =========================================================

    private Color _dropDownBackColor = Color.White;
    private Color _dropDownForeColor = Color.Black;

    private Color _dropDownSelectedBackColor =
        Color.DeepSkyBlue;

    private Color _dropDownSelectedForeColor =
        Color.White;

    private int _dropDownMaxHeight = 250;
    private int _dropDownWidth = 0;
    private int _maxDropDownItems = 8;

    private bool _integralHeight = true;


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public MyRoundedComboBox()
    {
        DoubleBuffered = true;

        SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.Selectable,
            true);

        // -----------------------------------------------------
        // COMBOBOX INTERNE
        // -----------------------------------------------------

        _comboBox = new ComboBox();

        _comboBox.DropDownStyle =
            ComboBoxStyle.DropDownList;

        _comboBox.Visible = false;
        _comboBox.TabStop = false;
        _comboBox.Font = Font;

        Controls.Add(_comboBox);

        // -----------------------------------------------------
        // ÉVÉNEMENTS COMBOBOX
        // -----------------------------------------------------

        _comboBox.SelectedIndexChanged +=
            InnerComboBox_SelectedIndexChanged;

        _comboBox.SelectedValueChanged +=
            InnerComboBox_SelectedValueChanged;

        _comboBox.TextChanged +=
            InnerComboBox_TextChanged;

        // -----------------------------------------------------
        // ÉVÉNEMENTS CONTRÔLE
        // -----------------------------------------------------

        MouseDown +=
            MyRoundedComboBox_MouseDown;

        MouseEnter +=
            MyRoundedComboBox_MouseEnter;

        MouseLeave +=
            MyRoundedComboBox_MouseLeave;

        Resize +=
            MyRoundedComboBox_Resize;
    }


    // =========================================================
    // ÉVÉNEMENT SELECTED INDEX
    // =========================================================

    [Category("Action")]
    public event EventHandler SelectedIndexChanged;

    private void InnerComboBox_SelectedIndexChanged(
        object sender,
        EventArgs e)
    {
        Invalidate();

        if (SelectedIndexChanged != null)
        {
            SelectedIndexChanged(this, e);
        }
    }


    // =========================================================
    // ÉVÉNEMENT SELECTED VALUE
    // =========================================================

    [Category("Action")]
    public event EventHandler SelectedValueChanged;

    private void InnerComboBox_SelectedValueChanged(
        object sender,
        EventArgs e)
    {
        Invalidate();

        if (SelectedValueChanged != null)
        {
            SelectedValueChanged(this, e);
        }
    }


    // =========================================================
    // ÉVÉNEMENT TEXT
    // =========================================================

    [Category("Action")]
    public event EventHandler TextChangedEx;

    private void InnerComboBox_TextChanged(
        object sender,
        EventArgs e)
    {
        Invalidate();

        if (TextChangedEx != null)
        {
            TextChangedEx(this, e);
        }
    }


    // =========================================================
    // ITEMS
    // =========================================================

    [Category("Behavior")]
    [DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
    public ComboBox.ObjectCollection Items
    {
        get
        {
            return _comboBox.Items;
        }
    }


    // =========================================================
    // DATASOURCE
    // =========================================================

    [Category("Data")]
    [DefaultValue(null)]
    [AttributeProvider(typeof(IListSource))]
    public object DataSource
    {
        get
        {
            return _comboBox.DataSource;
        }

        set
        {
            _comboBox.DataSource = value;
            Invalidate();
        }
    }


    // =========================================================
    // DISPLAY MEMBER
    // =========================================================

    [Category("Data")]
    [DefaultValue("")]
    public string DisplayMember
    {
        get
        {
            return _comboBox.DisplayMember;
        }

        set
        {
            _comboBox.DisplayMember = value;
            Invalidate();
        }
    }


    // =========================================================
    // VALUE MEMBER
    // =========================================================

    [Category("Data")]
    [DefaultValue("")]
    public string ValueMember
    {
        get
        {
            return _comboBox.ValueMember;
        }

        set
        {
            _comboBox.ValueMember = value;
            Invalidate();
        }
    }


    // =========================================================
    // FORMATTING ENABLED
    // =========================================================

    [Category("Data")]
    [DefaultValue(false)]
    public bool FormattingEnabled
    {
        get
        {
            return _comboBox.FormattingEnabled;
        }

        set
        {
            _comboBox.FormattingEnabled = value;
        }
    }


    // =========================================================
    // SELECTED INDEX
    // =========================================================

    [Category("Behavior")]
    [DefaultValue(-1)]
    public int SelectedIndex
    {
        get
        {
            return _comboBox.SelectedIndex;
        }

        set
        {
            _comboBox.SelectedIndex = value;
            Invalidate();
        }
    }


    // =========================================================
    // SELECTED ITEM
    // =========================================================

    [Category("Behavior")]
    [Browsable(false)]
    public object SelectedItem
    {
        get
        {
            return _comboBox.SelectedItem;
        }

        set
        {
            _comboBox.SelectedItem = value;
            Invalidate();
        }
    }


    // =========================================================
    // SELECTED VALUE
    // =========================================================

    [Category("Behavior")]
    public object SelectedValue
    {
        get
        {
            return _comboBox.SelectedValue;
        }

        set
        {
            _comboBox.SelectedValue = value;
            Invalidate();
        }
    }


    // =========================================================
    // TEXT
    // =========================================================

    [Category("Appearance")]
    public override string Text
    {
        get
        {
            if (_comboBox == null)
            {
                return base.Text;
            }

            return _comboBox.Text;
        }

        set
        {
            if (_comboBox != null)
            {
                _comboBox.Text = value;
            }

            Invalidate();
        }
    }


    // =========================================================
    // FONT
    // =========================================================

    [Category("Appearance")]
    public override Font Font
    {
        get
        {
            return base.Font;
        }

        set
        {
            base.Font = value;

            if (_comboBox != null &&
                value != null)
            {
                _comboBox.Font = value;
            }

            Invalidate();
        }
    }


    // =========================================================
    // FORE COLOR
    // =========================================================

    [Category("Appearance")]
    public override Color ForeColor
    {
        get
        {
            return base.ForeColor;
        }

        set
        {
            base.ForeColor = value;

            if (_comboBox != null)
            {
                _comboBox.ForeColor = value;
            }

            Invalidate();
        }
    }


    // =========================================================
    // BACK COLOR
    // =========================================================

    [Category("Appearance")]
    public override Color BackColor
    {
        get
        {
            return base.BackColor;
        }

        set
        {
            base.BackColor = value;
            Invalidate();
        }
    }


    // =========================================================
    // BORDER RADIUS
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(15)]
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
            Invalidate();
        }
    }


    // =========================================================
    // BORDER SIZE
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(2)]
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
            Invalidate();
        }
    }


    // =========================================================
    // BORDER COLOR
    // =========================================================

    [Category("Appearance")]
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

    [Category("Appearance")]
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
    // INNER PADDING
    // =========================================================

    [Category("Appearance")]
    [DefaultValue(10)]
    public int InnerPadding
    {
        get
        {
            return _innerPadding;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _innerPadding = value;
            Invalidate();
        }
    }


    // =========================================================
    // ARROW COLOR
    // =========================================================

    [Category("Appearance")]
    public Color ArrowColor
    {
        get
        {
            return _arrowColor;
        }

        set
        {
            _arrowColor = value;
            Invalidate();
        }
    }


    // =========================================================
    // DROPDOWN BACK COLOR
    // =========================================================

    [Category("DropDown")]
    public Color DropDownBackColor
    {
        get
        {
            return _dropDownBackColor;
        }

        set
        {
            _dropDownBackColor = value;

            if (_listBox != null)
            {
                _listBox.BackColor = value;
                _listBox.Invalidate();
            }
        }
    }


    // =========================================================
    // DROPDOWN FORE COLOR
    // =========================================================

    [Category("DropDown")]
    public Color DropDownForeColor
    {
        get
        {
            return _dropDownForeColor;
        }

        set
        {
            _dropDownForeColor = value;

            if (_listBox != null)
            {
                _listBox.ForeColor = value;
                _listBox.Invalidate();
            }
        }
    }


    // =========================================================
    // DROPDOWN SELECTED BACK COLOR
    // =========================================================

    [Category("DropDown")]
    public Color DropDownSelectedBackColor
    {
        get
        {
            return _dropDownSelectedBackColor;
        }

        set
        {
            _dropDownSelectedBackColor = value;

            if (_listBox != null)
            {
                _listBox.Invalidate();
            }
        }
    }


    // =========================================================
    // DROPDOWN SELECTED FORE COLOR
    // =========================================================

    [Category("DropDown")]
    public Color DropDownSelectedForeColor
    {
        get
        {
            return _dropDownSelectedForeColor;
        }

        set
        {
            _dropDownSelectedForeColor = value;

            if (_listBox != null)
            {
                _listBox.Invalidate();
            }
        }
    }


    // =========================================================
    // DROPDOWN WIDTH
    // =========================================================

    [Category("DropDown")]
    [DefaultValue(0)]
    public int DropDownWidth
    {
        get
        {
            return _dropDownWidth;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _dropDownWidth = value;
        }
    }


    // =========================================================
    // MAX DROPDOWN ITEMS
    // =========================================================

    [Category("DropDown")]
    [DefaultValue(8)]
    public int MaxDropDownItems
    {
        get
        {
            return _maxDropDownItems;
        }

        set
        {
            if (value < 1)
            {
                value = 1;
            }

            _maxDropDownItems = value;
        }
    }


    // =========================================================
    // DROPDOWN MAX HEIGHT
    // =========================================================

    [Category("DropDown")]
    [DefaultValue(250)]
    public int DropDownMaxHeight
    {
        get
        {
            return _dropDownMaxHeight;
        }

        set
        {
            if (value < 1)
            {
                value = 1;
            }

            _dropDownMaxHeight = value;
        }
    }


    // =========================================================
    // DROPDOWN HEIGHT
    // =========================================================

    [Category("DropDown")]
    [DefaultValue(0)]
    public int DropDownHeight
    {
        get
        {
            if (_listBox != null)
            {
                return _listBox.Height;
            }

            return 0;
        }

        set
        {
            if (_listBox != null &&
                value > 0)
            {
                _listBox.Height = value;
            }
        }
    }


    // =========================================================
    // INTEGRAL HEIGHT
    // =========================================================

    [Category("DropDown")]
    [DefaultValue(true)]
    public bool IntegralHeight
    {
        get
        {
            return _integralHeight;
        }

        set
        {
            _integralHeight = value;

            if (_listBox != null)
            {
                _listBox.IntegralHeight = value;
            }
        }
    }


    // =========================================================
    // AUTOCOMPLETE MODE
    // =========================================================

    [Category("Behavior")]
    public AutoCompleteMode AutoCompleteMode
    {
        get
        {
            return _comboBox.AutoCompleteMode;
        }

        set
        {
            _comboBox.AutoCompleteMode = value;
        }
    }


    // =========================================================
    // AUTOCOMPLETE SOURCE
    // =========================================================

    [Category("Behavior")]
    public AutoCompleteSource AutoCompleteSource
    {
        get
        {
            return _comboBox.AutoCompleteSource;
        }

        set
        {
            _comboBox.AutoCompleteSource = value;
        }
    }


    // =========================================================
    // SORTED
    // =========================================================

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool Sorted
    {
        get
        {
            return _comboBox.Sorted;
        }

        set
        {
            _comboBox.Sorted = value;
        }
    }


    // =========================================================
    // DROPDOWN STYLE
    // =========================================================

    [Browsable(false)]
    public ComboBoxStyle DropDownStyle
    {
        get
        {
            return _comboBox.DropDownStyle;
        }

        set
        {
            _comboBox.DropDownStyle = value;
        }
    }


    // =========================================================
    // MOUSE DOWN
    // =========================================================

    private void MyRoundedComboBox_MouseDown(
        object sender,
        MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        if (!Enabled)
        {
            return;
        }

        Focus();

        OpenDropDown();
    }


    // =========================================================
    // MOUSE ENTER
    // =========================================================

    private void MyRoundedComboBox_MouseEnter(
        object sender,
        EventArgs e)
    {
        Invalidate();
    }


    // =========================================================
    // MOUSE LEAVE
    // =========================================================

    private void MyRoundedComboBox_MouseLeave(
        object sender,
        EventArgs e)
    {
        Invalidate();
    }


    // =========================================================
    // RESIZE
    // =========================================================

    private void MyRoundedComboBox_Resize(
        object sender,
        EventArgs e)
    {
        Invalidate();
    }


    // =========================================================
    // FONT CHANGED
    // =========================================================

    protected override void OnFontChanged(
        EventArgs e)
    {
        base.OnFontChanged(e);

        if (_comboBox != null)
        {
            _comboBox.Font = Font;
        }

        Invalidate();
    }


    // =========================================================
    // ENABLED CHANGED
    // =========================================================

    protected override void OnEnabledChanged(
        EventArgs e)
    {
        base.OnEnabledChanged(e);

        Invalidate();
    }


    // =========================================================
    // FOCUS
    // =========================================================

    protected override void OnEnter(
        EventArgs e)
    {
        base.OnEnter(e);

        Invalidate();
    }


    protected override void OnLeave(
        EventArgs e)
    {
        base.OnLeave(e);

        Invalidate();
    }


    // =========================================================
    // BACKGROUND
    // =========================================================

    protected override void OnPaintBackground(
        PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.CompositingQuality =
            CompositingQuality.HighQuality;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;


        Color parentColor =
            Parent == null
            ? BackColor
            : Parent.BackColor;


        using (SolidBrush brush =
               new SolidBrush(parentColor))
        {
            g.FillRectangle(
                brush,
                ClientRectangle);
        }


        RectangleF rect =
            GetBorderRectangle();


        if (rect.Width <= 0 ||
            rect.Height <= 0)
        {
            return;
        }


        float radius =
            GetSafeRadius(rect);


        using (GraphicsPath path =
               CreateRoundedRectanglePath(
                   rect,
                   radius))
        {
            using (SolidBrush brush =
                   new SolidBrush(BackColor))
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


        Graphics g = e.Graphics;

        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.CompositingQuality =
            CompositingQuality.HighQuality;

        g.InterpolationMode =
            InterpolationMode.HighQualityBicubic;

        g.PixelOffsetMode =
            PixelOffsetMode.HighQuality;

        g.TextRenderingHint =
            TextRenderingHint.ClearTypeGridFit;


        DrawBorder(g);

        DrawText(g);

        DrawArrow(g);
    }


    // =========================================================
    // RECTANGLE
    // =========================================================

    private RectangleF GetBorderRectangle()
    {
        float half =
            _borderSize / 2f;


        return new RectangleF(
            half,
            half,

            Math.Max(
                0,
                Width - _borderSize),

            Math.Max(
                0,
                Height - _borderSize));
    }


    // =========================================================
    // RAYON SÉCURISÉ
    // =========================================================

    private float GetSafeRadius(
        RectangleF rect)
    {
        float maxRadius =
            Math.Min(
                rect.Width,
                rect.Height) / 2f;


        return Math.Max(
            0,
            Math.Min(
                _borderRadius,
                maxRadius));
    }


    // =========================================================
    // BORDER
    // =========================================================

    private void DrawBorder(
        Graphics g)
    {
        if (_borderSize <= 0)
        {
            return;
        }


        RectangleF rect =
            GetBorderRectangle();


        if (rect.Width <= 0 ||
            rect.Height <= 0)
        {
            return;
        }


        float radius =
            GetSafeRadius(rect);


        using (GraphicsPath path =
               CreateRoundedRectanglePath(
                   rect,
                   radius))
        {
            Color color =
                Focused
                ? _focusBorderColor
                : _borderColor;


            if (!Enabled)
            {
                color =
                    Color.LightGray;
            }


            using (Pen pen =
                   new Pen(
                       color,
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


    // =========================================================
    // ZONE FLÈCHE
    // =========================================================

    private int GetArrowAreaWidth()
    {
        if (Height <= 0)
        {
            return 0;
        }


        int width =
            Height / 2;


        if (width < 14)
        {
            width = 14;
        }


        if (width > 40)
        {
            width = 40;
        }


        return width;
    }


    // =========================================================
    // TEXTE
    // =========================================================

    private void DrawText(
        Graphics g)
    {
        string text =
            GetSelectedDisplayText();


        if (string.IsNullOrEmpty(text))
        {
            return;
        }


        int arrowWidth =
            GetArrowAreaWidth();


        int left =
            _borderSize +
            _innerPadding;


        int right =
            Width -
            _borderSize -
            _innerPadding -
            arrowWidth;


        int availableWidth =
            right - left;


        if (availableWidth <= 0)
        {
            return;
        }


        Size measured =
            TextRenderer.MeasureText(
                text,
                Font);


        int textHeight =
            measured.Height;


        int textY =
            (Height -
             textHeight) / 2;


        Rectangle textRect =
            new Rectangle(
                left,
                textY,
                availableWidth,
                Math.Max(
                    1,
                    textHeight));


        Color color =
            Enabled
            ? ForeColor
            : SystemColors.GrayText;


        TextRenderer.DrawText(
            g,
            text,
            Font,
            textRect,
            color,

            TextFormatFlags.Left |
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.SingleLine |
            TextFormatFlags.EndEllipsis |
            TextFormatFlags.NoPadding);
    }


    // =========================================================
    // TEXTE SÉLECTIONNÉ
    // =========================================================

    private string GetSelectedDisplayText()
    {
        object item =
            _comboBox.SelectedItem;


        if (item == null)
        {
            return _comboBox.Text;
        }


        return GetDisplayText(item);
    }


    // =========================================================
    // DISPLAY TEXT
    // =========================================================

    private string GetDisplayText(
        object item)
    {
        if (item == null)
        {
            return string.Empty;
        }


        if (!string.IsNullOrEmpty(
            _comboBox.DisplayMember))
        {
            PropertyDescriptor property =
                TypeDescriptor.GetProperties(
                    item)[
                        _comboBox.DisplayMember];


            if (property != null)
            {
                object value =
                    property.GetValue(item);


                if (value != null)
                {
                    return value.ToString();
                }

                return string.Empty;
            }


            System.Data.DataRowView row =
                item as System.Data.DataRowView;


            if (row != null &&
                row.Row.Table.Columns.Contains(
                    _comboBox.DisplayMember))
            {
                object value =
                    row[
                        _comboBox.DisplayMember];


                if (value != null &&
                    value != DBNull.Value)
                {
                    return value.ToString();
                }
            }
        }


        return item.ToString();
    }


    // =========================================================
    // FLÈCHE
    // =========================================================

    // =========================================================
    // FLÈCHE
    // =========================================================

    private void DrawArrow(Graphics g)
    {
        if (Width <= 0 || Height <= 0)
            return;

        int areaWidth = GetArrowAreaWidth();

        if (areaWidth <= 0)
            return;

        // Espace supplémentaire entre la flèche
        // et le bord droit
        float rightPadding = 8f;

        // Centre horizontal de la zone de la flèche
        float centerX =
            Width -
            _borderSize -
            rightPadding -
            (areaWidth / 2f);

        float centerY =
            Height / 2f;

        // Taille de la flèche adaptée à la hauteur
        float arrowSize =
            Math.Max(
                1.5f,
                Math.Min(
                    7f,
                    Height / 5f));

        // Épaisseur adaptée à la taille du contrôle
        float penWidth =
            Math.Max(
                1f,
                Math.Min(
                    2.5f,
                    Height / 15f));

        PointF p1 =
            new PointF(
                centerX - arrowSize,
                centerY - arrowSize / 2f);

        PointF p2 =
            new PointF(
                centerX,
                centerY + arrowSize / 2f);

        PointF p3 =
            new PointF(
                centerX + arrowSize,
                centerY - arrowSize / 2f);


        using (GraphicsPath path =
               new GraphicsPath())
        {
            path.AddLine(p1, p2);
            path.AddLine(p2, p3);

            using (Pen pen =
                   new Pen(
                       Enabled
                       ? _arrowColor
                       : Color.LightGray,
                       penWidth))
            {
                pen.StartCap =
                    LineCap.Round;

                pen.EndCap =
                    LineCap.Round;

                pen.LineJoin =
                    LineJoin.Round;

                g.DrawPath(
                    pen,
                    path);
            }
        }
    }


    // =========================================================
    // OUVRIR DROPDOWN
    // =========================================================

    private void OpenDropDown()
    {
        if (!Enabled)
        {
            return;
        }


        CloseDropDown();


        _listBox =
            new ListBox();


        _listBox.BorderStyle =
            BorderStyle.None;

        _listBox.BackColor =
            _dropDownBackColor;

        _listBox.ForeColor =
            _dropDownForeColor;

        _listBox.Font =
            Font;

        _listBox.IntegralHeight =
            _integralHeight;

        _listBox.SelectionMode =
            SelectionMode.One;

        _listBox.DrawMode =
            DrawMode.OwnerDrawFixed;


        _listBox.DrawItem +=
            ListBox_DrawItem;

        _listBox.MouseDown +=
            ListBox_MouseDown;

        _listBox.KeyDown +=
            ListBox_KeyDown;


        FillListBox();


        if (_comboBox.SelectedIndex >= 0 &&
            _comboBox.SelectedIndex <
            _listBox.Items.Count)
        {
            _listBox.SelectedIndex =
                _comboBox.SelectedIndex;
        }


        int itemHeight =
            TextRenderer.MeasureText(
                "Ag",
                Font).Height + 8;


        if (itemHeight < 20)
        {
            itemHeight = 20;
        }


        _listBox.ItemHeight =
            itemHeight;


        int itemCount =
            _listBox.Items.Count;


        if (itemCount < 1)
        {
            itemCount = 1;
        }


        int visibleItems =
            Math.Min(
                itemCount,
                _maxDropDownItems);


        int height =
            itemHeight *
            visibleItems;


        if (height >
            _dropDownMaxHeight)
        {
            height =
                _dropDownMaxHeight;
        }


        int width =
            _dropDownWidth > 0
            ? _dropDownWidth
            : Width;


        if (width < 1)
        {
            width = 1;
        }


        ToolStripControlHost host =
            new ToolStripControlHost(
                _listBox);


        host.AutoSize =
            false;

        host.Padding =
            new Padding(0);

        host.Margin =
            new Padding(0);

        host.Size =
            new Size(
                width,
                height);


        _popup =
            new ToolStripDropDown();


        _popup.Padding =
            new Padding(1);

        _popup.Margin =
            new Padding(0);

        _popup.AutoSize =
            false;

        _popup.Size =
            new Size(
                width + 2,
                height + 2);

        _popup.BackColor =
            _dropDownBackColor;


        _popup.Closing +=
            Popup_Closing;


        _popup.Items.Add(host);


        Point location =
            PointToScreen(
                new Point(
                    0,
                    Height));


        _popup.Show(
            location);
    }


    // =========================================================
    // REMPLIR LISTBOX
    // =========================================================

    private void FillListBox()
    {
        _listBox.Items.Clear();


        for (int i = 0;
             i < _comboBox.Items.Count;
             i++)
        {
            _listBox.Items.Add(
                _comboBox.Items[i]);
        }
    }


    // =========================================================
    // DRAW ITEM
    // =========================================================

    private void ListBox_DrawItem(
        object sender,
        DrawItemEventArgs e)
    {
        if (e.Index < 0)
        {
            return;
        }


        Graphics g =
            e.Graphics;


        g.SmoothingMode =
            SmoothingMode.AntiAlias;

        g.TextRenderingHint =
            TextRenderingHint.ClearTypeGridFit;


        bool selected =
            (e.State &
             DrawItemState.Selected)
            != 0;


        Color background =
            selected
            ? _dropDownSelectedBackColor
            : _dropDownBackColor;


        Color foreground =
            selected
            ? _dropDownSelectedForeColor
            : _dropDownForeColor;


        using (SolidBrush brush =
               new SolidBrush(background))
        {
            g.FillRectangle(
                brush,
                e.Bounds);
        }


        string text =
            GetDisplayText(
                _listBox.Items[e.Index]);


        Rectangle textRect =
            new Rectangle(
                e.Bounds.X +
                _innerPadding,

                e.Bounds.Y,

                Math.Max(
                    1,
                    e.Bounds.Width -
                    (_innerPadding * 2)),

                e.Bounds.Height);


        TextRenderer.DrawText(
            g,
            text,
            Font,
            textRect,
            foreground,

            TextFormatFlags.Left |
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.SingleLine |
            TextFormatFlags.EndEllipsis |
            TextFormatFlags.NoPadding);
    }


    // =========================================================
    // CLICK LISTBOX
    // =========================================================

    private void ListBox_MouseDown(
        object sender,
        MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
        {
            return;
        }


        int index =
            _listBox.IndexFromPoint(
                e.Location);


        if (index < 0)
        {
            return;
        }


        SelectPopupItem(index);

        CloseDropDown();
    }


    // =========================================================
    // CLAVIER LISTBOX
    // =========================================================

    private void ListBox_KeyDown(
        object sender,
        KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (_listBox.SelectedIndex >= 0)
            {
                SelectPopupItem(
                    _listBox.SelectedIndex);

                CloseDropDown();

                e.Handled = true;
            }
        }


        if (e.KeyCode == Keys.Escape)
        {
            CloseDropDown();

            Focus();

            e.Handled = true;
        }
    }


    // =========================================================
    // SÉLECTION
    // =========================================================

    private void SelectPopupItem(
        int index)
    {
        if (index < 0 ||
            index >= _comboBox.Items.Count)
        {
            return;
        }


        _comboBox.SelectedIndex =
            index;


        Invalidate();

        Focus();
    }


    // =========================================================
    // POPUP CLOSING
    // =========================================================

    private void Popup_Closing(
        object sender,
        ToolStripDropDownClosingEventArgs e)
    {
        Invalidate();
    }


    // =========================================================
    // FERMER DROPDOWN
    // =========================================================

    private void CloseDropDown()
    {
        if (_popup != null)
        {
            _popup.Close();
            _popup.Dispose();
            _popup = null;
        }


        _listBox = null;
    }


    // =========================================================
    // CLAVIER DU CONTRÔLE
    // =========================================================

    protected override void OnKeyDown(
        KeyEventArgs e)
    {
        base.OnKeyDown(e);


        if (e.KeyCode == Keys.Enter ||
            e.KeyCode == Keys.Space ||
            e.KeyCode == Keys.Down)
        {
            OpenDropDown();

            e.Handled = true;
        }
    }


    // =========================================================
    // ROUNDED RECTANGLE
    // =========================================================

    private GraphicsPath CreateRoundedRectanglePath(
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
            path.AddRectangle(rect);
            return path;
        }


        float diameter =
            radius * 2f;


        if (diameter >
            rect.Width)
        {
            diameter =
                rect.Width;
        }


        if (diameter >
            rect.Height)
        {
            diameter =
                rect.Height;
        }


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


    // =========================================================
    // DISPOSE
    // =========================================================

    protected override void Dispose(
        bool disposing)
    {
        if (disposing)
        {
            CloseDropDown();


            if (_comboBox != null)
            {
                _comboBox.Dispose();

                _comboBox = null;
            }
        }


        base.Dispose(disposing);
    }
}