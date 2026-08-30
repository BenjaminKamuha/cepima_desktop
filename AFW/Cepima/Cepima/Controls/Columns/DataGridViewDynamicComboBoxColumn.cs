using System;
using System.Windows.Forms;
using System.Drawing;

public class DataGridViewDynamicComboBoxColumn :
    DataGridViewComboBoxColumn
{
    public Func<int, object[]> GetItemsForRow;

    public DataGridViewDynamicComboBoxColumn()
    {
        this.FlatStyle = FlatStyle.Flat;
    }
}

public class DynamicComboHandler
{
    public static void Attach(
        DataGridView grid,
        DataGridViewDynamicComboBoxColumn column)
    {
        grid.EditingControlShowing += (s, e) =>
        {
            if (grid.CurrentCell.ColumnIndex
                == column.Index)
            {
                ComboBox cb =
                    e.Control as ComboBox;

                if (cb != null &&
                    column.GetItemsForRow != null)
                {
                    cb.Items.Clear();

                    var items =
                        column.GetItemsForRow(
                            grid.CurrentCell.RowIndex);

                    cb.Items.AddRange(items);
                }
            }
        };
    }
}