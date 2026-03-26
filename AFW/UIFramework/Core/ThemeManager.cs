using System;
using System.Windows.Forms;

public static class ThemeManager
{
    public static event Action ThemeChanged;

    public static ThemeMode CurrentMode
    {
        get { return Theme.CurrentMode; }
        set
        {
            if (Theme.CurrentMode != value)
            {
                Theme.CurrentMode = value;

                if (ThemeChanged != null)
                    ThemeChanged();
            }
        }
    }

    public static void ToggleTheme()
    {
        CurrentMode =
            CurrentMode == ThemeMode.Dark
            ? ThemeMode.Light
            : ThemeMode.Dark;
    }

    public static void ApplyTheme(Control root)
    {
        ApplyThemeInternal(root);

        // IMPORTANT : écouter l’ajout futur de contrôles
        root.ControlAdded -= Root_ControlAdded;
        root.ControlAdded += Root_ControlAdded;
    }

    private static void Root_ControlAdded(object sender, ControlEventArgs e)
    {
        ApplyThemeInternal(e.Control);
    }

    private static void ApplyThemeInternal(Control c)
    {
        // Couleur de fond
        c.BackColor = Theme.GetBackground();

        // Texte (si supporté)
        if (c is Label || c is Button || c is CheckBox || c is RadioButton)
            c.ForeColor = Theme.GetTextPrimary();

        // Appliquer récursivement
        foreach (Control child in c.Controls)
            ApplyThemeInternal(child);

        c.Invalidate();
    }
}