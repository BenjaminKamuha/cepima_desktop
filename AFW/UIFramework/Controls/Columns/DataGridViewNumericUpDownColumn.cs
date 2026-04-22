using System;
using System.Windows.Forms;
using System.Drawing;

#region COLUMN
public class DataGridViewNumericUpDownColumn : DataGridViewColumn
{
    public DataGridViewNumericUpDownColumn()
        : base(new DataGridViewNumericUpDownCell())
    {
    }

    public decimal Minimum
    {
        get { return ((DataGridViewNumericUpDownCell)CellTemplate).Minimum; }
        set { ((DataGridViewNumericUpDownCell)CellTemplate).Minimum = value; }
    }

    public decimal Maximum
    {
        get { return ((DataGridViewNumericUpDownCell)CellTemplate).Maximum; }
        set { ((DataGridViewNumericUpDownCell)CellTemplate).Maximum = value; }
    }
}
#endregion

#region CELL
public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
{
    public decimal Minimum = 0;
    public decimal Maximum = 100;

    public override Type EditType
    {
        get { return typeof(NumericUpDownEditingControl); }
    }

    public override Type ValueType
    {
        get { return typeof(decimal); }
    }

    public override object DefaultNewRowValue
    {
        get { return 0; }
    }

    public override void InitializeEditingControl(
        int rowIndex,
        object initialFormattedValue,
        DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(
            rowIndex,
            initialFormattedValue,
            dataGridViewCellStyle);

        NumericUpDownEditingControl ctl =
            DataGridView.EditingControl as NumericUpDownEditingControl;

        if (ctl != null)
        {
            ctl.Minimum = Minimum;
            ctl.Maximum = Maximum;

            if (this.Value != null &&
                this.Value != DBNull.Value)
            {
                ctl.Value = Convert.ToDecimal(this.Value);
            }
        }
    }
}
#endregion

#region EDITING CONTROL
public class NumericUpDownEditingControl :
    NumericUpDown,
    IDataGridViewEditingControl
{
    public DataGridView EditingControlDataGridView { get; set; }

    private bool valueChanged = false;

    public object EditingControlFormattedValue
    {
        get { return this.Value.ToString(); }
        set
        {
            if (value != null)
                this.Value = Convert.ToDecimal(value);
        }
    }

    public int EditingControlRowIndex { get; set; }

    public bool EditingControlValueChanged
    {
        get { return valueChanged; }
        set { valueChanged = value; }
    }

    public bool RepositionEditingControlOnValueChange
    {
        get { return false; }
    }

    public Cursor EditingPanelCursor
    {
        get { return base.Cursor; }
    }

    public object GetEditingControlFormattedValue(
        DataGridViewDataErrorContexts context)
    {
        return this.Value.ToString();
    }

    public void ApplyCellStyleToEditingControl(
        DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.ForeColor = dataGridViewCellStyle.ForeColor;
        this.BackColor = dataGridViewCellStyle.BackColor;
    }

    public bool EditingControlWantsInputKey(
        Keys keyData,
        bool dataGridViewWantsInputKey)
    {
        return true;
    }

    public void PrepareEditingControlForEdit(
        bool selectAll)
    {
    }

    protected override void OnValueChanged(EventArgs e)
    {
        base.OnValueChanged(e);

        valueChanged = true;

        if (EditingControlDataGridView != null)
        {
            EditingControlDataGridView
                .NotifyCurrentCellDirty(true);
        }
    }
}
#endregion