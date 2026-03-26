using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private SidebarMenu sidebar;
    private TopBar topbar;
    private StatCard cardRevenue, cardUsers;
    private LineChartControl lineChart;
    private DonutChartControl donutChart;
    private ButtonEx btnToggleTheme;
    private AvatarControl avatar;
    private EmployeeTableControl employeeTable;

    public Form1()
    {
        this.Text = "Dashboard";
        this.Size = new Size(1200, 700);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Theme.GetBackground();

        ThemeManager.ThemeChanged += ApplyTheme;

        InitializeControls();
    }

    // Copie le reste de InitializeControls() et ApplyTheme() depuis FormDashboard
}
