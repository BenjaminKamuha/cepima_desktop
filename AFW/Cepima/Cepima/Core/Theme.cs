using System.Drawing;

public static class Theme
{
    public static ThemeMode CurrentMode = ThemeMode.Light;

    public static Color GetBackground()
    {
        return CurrentMode == ThemeMode.Dark
            ? Color.FromArgb(18, 22, 33)
            : Color.FromArgb(245, 247, 250);
    }

    public static Color GetCard()
    {
        return CurrentMode == ThemeMode.Dark
            ? Color.FromArgb(28, 32, 45)
            : Color.White;
    }

    public static Color GetTextPrimary()
    {
        return CurrentMode == ThemeMode.Dark
            ? Color.WhiteSmoke
            : Color.FromArgb(40, 40, 40);
    }

    public static Color GetTextSecondary()
    {
        return CurrentMode == ThemeMode.Dark
            ? Color.Gray
            : Color.DimGray;
    }

    public static Color GetAccent()
    {
        return ColorPalette.Primary;
    }
}
