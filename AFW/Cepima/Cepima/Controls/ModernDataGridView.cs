using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class ModernDataGridView : DataGridView
{
    // =========================================================
    // VARIABLES PRIVÉES
    // =========================================================

    private int _headerHeight = 55;

    private Color _headerBackColor =
        Color.SteelBlue;

    private Color _headerForeColor =
        Color.White;

    private int _borderRadius = 12;

    private Color _outerBorderColor =
        Color.FromArgb(225, 225, 225);

    private int _outerBorderSize = 1;

    private int _rowHeight = 48;


    // =========================================================
    // HAUTEUR DE L'EN-TÊTE
    // =========================================================

    [Category("Appearance")]
    [Description("Hauteur de l'en-tête du DataGridView.")]
    [DefaultValue(55)]
    public int HeaderHeight
    {
        get
        {
            return _headerHeight;
        }

        set
        {
            if (value < 20)
                value = 20;

            _headerHeight = value;

            base.ColumnHeadersHeight = _headerHeight;

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR DE L'EN-TÊTE
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur de fond de l'en-tête.")]
    public Color HeaderBackColor
    {
        get
        {
            return _headerBackColor;
        }

        set
        {
            _headerBackColor = value;

            ColumnHeadersDefaultCellStyle.BackColor =
                _headerBackColor;

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR DU TEXTE DE L'EN-TÊTE
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur du texte de l'en-tête.")]
    public Color HeaderForeColor
    {
        get
        {
            return _headerForeColor;
        }

        set
        {
            _headerForeColor = value;

            ColumnHeadersDefaultCellStyle.ForeColor =
                _headerForeColor;

            Invalidate();
        }
    }


    // =========================================================
    // HAUTEUR DES LIGNES
    // =========================================================

    [Category("Appearance")]
    [Description("Hauteur des lignes.")]
    [DefaultValue(48)]
    public int RowHeight
    {
        get
        {
            return _rowHeight;
        }

        set
        {
            if (value < 20)
                value = 20;

            _rowHeight = value;

            RowTemplate.Height = _rowHeight;

            Invalidate();
        }
    }


    // =========================================================
    // RAYON DE LA BORDURE
    // =========================================================

    [Category("Appearance")]
    [Description("Rayon des coins du DataGridView.")]
    [DefaultValue(12)]
    public int BorderRadius
    {
        get
        {
            return _borderRadius;
        }

        set
        {
            if (value < 0)
                value = 0;

            _borderRadius = value;

            Invalidate();
        }
    }


    // =========================================================
    // COULEUR DE LA BORDURE EXTÉRIEURE
    // =========================================================

    [Category("Appearance")]
    [Description("Couleur de la bordure extérieure.")]
    public Color OuterBorderColor
    {
        get
        {
            return _outerBorderColor;
        }

        set
        {
            _outerBorderColor = value;

            Invalidate();
        }
    }


    // =========================================================
    // ÉPAISSEUR DE LA BORDURE EXTÉRIEURE
    // =========================================================

    [Category("Appearance")]
    [Description("Épaisseur de la bordure extérieure.")]
    [DefaultValue(1)]
    public int OuterBorderSize
    {
        get
        {
            return _outerBorderSize;
        }

        set
        {
            if (value < 0)
                value = 0;

            _outerBorderSize = value;

            Invalidate();
        }
    }


    // =========================================================
    // MASQUER LA PROPRIÉTÉ NATIVE ColumnHeadersHeight
    // =========================================================

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new int ColumnHeadersHeight
    {
        get
        {
            return base.ColumnHeadersHeight;
        }

        set
        {
            base.ColumnHeadersHeight = value;
        }
    }


    // =========================================================
    // CONSTRUCTEUR
    // =========================================================

    public ModernDataGridView()
    {
        // =====================================================
        // DOUBLE BUFFERING
        // =====================================================

        this.DoubleBuffered = true;

        this.EnableHeadersVisualStyles = false;


        // =====================================================
        // COMPORTEMENT
        // =====================================================

        this.ReadOnly = false;

        this.EditMode =
            DataGridViewEditMode.EditOnKeystrokeOrF2;

        this.AllowUserToAddRows = false;
        this.AllowUserToDeleteRows = false;

        this.AllowUserToResizeRows = false;

        this.AllowUserToResizeColumns = true;

        this.RowHeadersVisible = false;

        this.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        this.MultiSelect = false;

        this.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.None;


        // =====================================================
        // FOND
        // =====================================================

        this.BackgroundColor =
            Color.White;

        this.BorderStyle =
            BorderStyle.None;


        // =====================================================
        // EN-TÊTE
        // =====================================================

        this.ColumnHeadersDefaultCellStyle.BackColor =
            _headerBackColor;

        this.ColumnHeadersDefaultCellStyle.ForeColor =
            _headerForeColor;

        this.ColumnHeadersDefaultCellStyle.Font =
            new Font(
                "Segoe UI",
                10,
                FontStyle.Bold);

        this.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleLeft;

        this.ColumnHeadersDefaultCellStyle.Padding =
            new Padding(
                10,
                0,
                10,
                0);

        this.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode
            .DisableResizing;

        base.ColumnHeadersHeight =
            _headerHeight;

        this.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.None;


        // =====================================================
        // CELLULES
        // =====================================================

        this.DefaultCellStyle.BackColor =
            Color.White;

        this.DefaultCellStyle.ForeColor =
            Color.FromArgb(50, 50, 50);

        this.DefaultCellStyle.Font =
            new Font(
                "Segoe UI",
                10,
                FontStyle.Regular);

        this.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleLeft;

        this.DefaultCellStyle.SelectionBackColor =
            Color.White;

        this.DefaultCellStyle.SelectionForeColor =
            Color.FromArgb(50, 50, 50);

        this.DefaultCellStyle.Padding =
            new Padding(
                10,
                4,
                10,
                4);


        // =====================================================
        // AUCUNE ALTERNANCE DE COULEUR
        // =====================================================

        this.AlternatingRowsDefaultCellStyle.BackColor =
            Color.White;

        this.AlternatingRowsDefaultCellStyle.ForeColor =
            Color.FromArgb(50, 50, 50);


        // =====================================================
        // HAUTEUR DES LIGNES
        // =====================================================

        this.RowTemplate.Height =
            _rowHeight;


        // =====================================================
        // SÉPARATION HORIZONTALE
        // =====================================================

        this.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        this.GridColor =
            Color.FromArgb(
                235,
                235,
                235);
    }


    // =========================================================
    // CRÉATION DU CONTRÔLE
    // =========================================================

    protected override void OnCreateControl()
    {
        base.OnCreateControl();

        // Réappliquer les valeurs après le chargement
        // du Designer.

        base.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode
            .DisableResizing;

        base.ColumnHeadersHeight =
            _headerHeight;

        RowTemplate.Height =
            _rowHeight;
    }


    // =========================================================
    // AJOUT D'UNE COLONNE
    // =========================================================

    protected override void OnColumnAdded(
        DataGridViewColumnEventArgs e)
    {
        base.OnColumnAdded(e);

        e.Column.AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;

        e.Column.MinimumWidth = 50;
    }


    // =========================================================
    // PEINTURE
    // =========================================================

    protected override void OnPaint(
        PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_outerBorderSize <= 0)
            return;

        if (Width <= 0 || Height <= 0)
            return;


        Rectangle rect =
            new Rectangle(
                _outerBorderSize / 2,
                _outerBorderSize / 2,
                Width - _outerBorderSize,
                Height - _outerBorderSize);


        using (GraphicsPath path =
               GetRoundedPath(
                   rect,
                   _borderRadius))
        {
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            using (Pen pen =
                   new Pen(
                       _outerBorderColor,
                       _outerBorderSize))
            {
                pen.Alignment =
                    PenAlignment.Center;

                e.Graphics.DrawPath(
                    pen,
                    path);
            }
        }
    }


    // =========================================================
    // CRÉER LE CHEMIN ARRONDI
    // =========================================================

    private GraphicsPath GetRoundedPath(
        Rectangle rect,
        int radius)
    {
        GraphicsPath path =
            new GraphicsPath();

        if (radius <= 0)
        {
            path.AddRectangle(rect);

            return path;
        }


        int diameter =
            radius * 2;


        if (diameter > rect.Width)
            diameter = rect.Width;


        if (diameter > rect.Height)
            diameter = rect.Height;


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