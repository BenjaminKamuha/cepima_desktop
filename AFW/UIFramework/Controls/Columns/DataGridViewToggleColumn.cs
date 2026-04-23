using System;
using System.Windows.Forms;
using System.Drawing;


public class DataGridViewToggleColumn :
    DataGridViewCheckBoxColumn
{
    public DataGridViewToggleColumn()
    {
        this.CellTemplate =
            new DataGridViewToggleCell();
    }
}

public class DataGridViewToggleCell :
    DataGridViewCheckBoxCell
{
    protected override void Paint(
        Graphics g,
        Rectangle clipBounds,
        Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates state,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle style,
        DataGridViewAdvancedBorderStyle borderStyle,
        DataGridViewPaintParts paintParts)
    {
        bool checkedVal =
            value != null &&
            Convert.ToBoolean(value);

        g.FillRectangle(
            new SolidBrush(style.BackColor),
            cellBounds);

        Rectangle toggleRect =
            new Rectangle(
                cellBounds.X + 5,
                cellBounds.Y + 5,
                cellBounds.Width - 10,
                cellBounds.Height - 10);

        Color backColor =
            checkedVal ?
            Color.Green :
            Color.Gray;

        g.FillRectangle(
            new SolidBrush(backColor),
            toggleRect);
    }
}