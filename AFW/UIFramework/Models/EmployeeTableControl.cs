using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Employee
{
    public string FirstName;
    public string LastName;
    public string Email;
    public string Department;
    public string Role;
    public string Salary;
    public string Status;
}

public class EmployeeTableControl : BaseControl
{
    public List<Employee> Employees = new List<Employee>();

    private int rowHeight = 35;
    private int headerHeight = 40;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Dessiner le fond
        using (SolidBrush bg = new SolidBrush(Theme.GetCard()))
        {
            e.Graphics.FillRectangle(bg, ClientRectangle);
        }

        // Dessiner l'entête
        string[] headers = { "First Name", "Last Name", "Email", "Department", "Role", "Salary", "Status" };
        int[] widths = { 100, 100, 150, 100, 80, 80, 60 };

        int x = 0;
        for (int i = 0; i < headers.Length; i++)
        {
            Rectangle rect = new Rectangle(x, 0, widths[i], headerHeight);
            TextRenderer.DrawText(e.Graphics, headers[i], FontManager.GetSubtitleFont(), rect, Theme.GetTextPrimary(), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            x += widths[i];
        }

        // Dessiner les lignes
        for (int r = 0; r < Employees.Count; r++)
        {
            Employee emp = Employees[r];
            int y = headerHeight + r * rowHeight;

            // Fond alterné
            Color rowBg = r % 2 == 0 ? Color.FromArgb(245, 245, 245) : Color.White;
            using (SolidBrush brush = new SolidBrush(rowBg))
            {
                e.Graphics.FillRectangle(brush, 0, y, this.Width, rowHeight);
            }

            // Texte
            int colX = 0;
            DrawCell(e, emp.FirstName, colX, y, widths[0]);
            colX += widths[0];
            DrawCell(e, emp.LastName, colX, y, widths[1]);
            colX += widths[1];
            DrawCell(e, emp.Email, colX, y, widths[2]);
            colX += widths[2];
            DrawCell(e, emp.Department, colX, y, widths[3]);
            colX += widths[3];
            DrawCell(e, emp.Role, colX, y, widths[4]);
            colX += widths[4];
            DrawCell(e, emp.Salary, colX, y, widths[5]);
            colX += widths[5];

            // Badge status
            Rectangle badgeRect = new Rectangle(colX + 5, y + 5, widths[6] - 10, rowHeight - 10);
            BadgeControl.Draw(e.Graphics, badgeRect, emp.Status);
        }
    }

    private void DrawCell(PaintEventArgs e, string text, int x, int y, int width)
    {
        Rectangle rect = new Rectangle(x, y, width, rowHeight);
        TextRenderer.DrawText(e.Graphics, text, FontManager.GetSubtitleFont(), rect, Theme.GetTextPrimary(), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
