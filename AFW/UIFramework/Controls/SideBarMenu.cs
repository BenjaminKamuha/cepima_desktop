using System.Drawing;
using System.Windows.Forms;

public class SidebarMenu : Panel, IThemeable
{
    public SidebarMenu()
    {
        Dock = DockStyle.Left;
        Width = 220;

        ThemeManager.ThemeChanged += OnThemeChanged;
        OnThemeChanged();
    }

    public void OnThemeChanged()
    {
        BackColor = Theme.CurrentMode == ThemeMode.Dark
            ? Color.FromArgb(18, 22, 33)
            : Color.White;
    }
}
