using System;
using System.Windows.Forms;
using System.Drawing;

#region COLUMN
public class DataGridViewControlColumn : DataGridViewColumn
{
    public DataGridViewControlColumn()
        : base(new DataGridViewControlCell())
    {
    }
}
#endregion

#region CELL
public class DataGridViewControlCell : DataGridViewTextBoxCell
{
    public Control HostedControl;

    public override Type EditType
    {
        get { return typeof(ControlEditingControl); }
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

        ControlEditingControl ctl =
            DataGridView.EditingControl as ControlEditingControl;

        if (ctl != null)
        {
            ctl.Controls.Clear();

            if (HostedControl != null)
            {
                Control clone = CloneControl(HostedControl);

                clone.Dock = DockStyle.Fill;

                ctl.Controls.Add(clone);
            }
        }
    }

    // ⚠️ IMPORTANT : évite partage du même control entre lignes
    private Control CloneControl(Control original)
    {
        Control copy =
            (Control)Activator.CreateInstance(original.GetType());

        copy.Text = original.Text;
        copy.BackColor = original.BackColor;
        copy.ForeColor = original.ForeColor;
        copy.Font = original.Font;

        return copy;
    }
}
#endregion

#region EDITING CONTROL
public class ControlEditingControl :
    Panel,
    IDataGridViewEditingControl
{
    public DataGridView EditingControlDataGridView { get; set; }

    public int EditingControlRowIndex { get; set; }

    private bool valueChanged = false;

    public bool EditingControlValueChanged
    {
        get { return valueChanged; }
        set { valueChanged = value; }
    }

    public object EditingControlFormattedValue
    {
        get { return null; }
        set { }
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
        return null;
    }

    public void ApplyCellStyleToEditingControl(
        DataGridViewCellStyle dataGridViewCellStyle)
    {
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
}
#endregion