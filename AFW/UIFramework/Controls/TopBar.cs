using System.Drawing;
using System.Windows.Forms;

public class TopBar : Panel, IThemeable
{
    public TopBar()
    {
        Dock = DockStyle.Top;
        Height = 55;

        ThemeManager.ThemeChanged += OnThemeChanged;
        OnThemeChanged();
    }

    public void OnThemeChanged()
    {
        BackColor = Theme.CurrentMode == ThemeMode.Dark
            ? Color.FromArgb(28, 32, 45)
            : Color.WhiteSmoke;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.DrawString(
            "Dashboard",
            FontManager.GetTitleFont(),
            new SolidBrush(Theme.GetTextPrimary()),
            15,
            15
        );
    }
}
