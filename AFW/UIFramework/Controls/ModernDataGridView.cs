using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class ModernDataGridView : DataGridView
{
    public ModernDataGridView()
    {
        // Activer le double buffering (réduit le scintillement)
        this.DoubleBuffered = true;
        this.EnableHeadersVisualStyles = false;

        //Autoriser l'édition
        this.ReadOnly = false;
        this.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

        //Poue éviter le mode lecture seule par défaut
        this.AllowUserToAddRows = false;
        this.AllowUserToDeleteRows = false;
        // Styles par défaut
        this.BackgroundColor = Color.White;
        this.BorderStyle = BorderStyle.None;

        // En-têtes colonnes
        this.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        this.ColumnHeadersHeight = 40;
        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

        // Lignes
        this.DefaultCellStyle.BackColor = Color.White;
        this.DefaultCellStyle.ForeColor = Color.Black;
        this.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        this.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        this.DefaultCellStyle.SelectionForeColor = Color.Black;

        // Alternance des couleurs
        this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

        // Bordures
        this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        this.GridColor = Color.LightGray;

        // Autres réglages
        this.RowHeadersVisible = false;
        this.AllowUserToResizeRows = false;
    }

    // Pour arrondir les coins du DataGridView
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
        {
            int radius = 15;
            Rectangle bounds = this.ClientRectangle;

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
    }
}
