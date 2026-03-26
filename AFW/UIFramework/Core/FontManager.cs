using System.Drawing;

public static class FontManager
{
    public static Font GetTitleFont()
    {
        return new Font("Segoe UI", 11, FontStyle.Bold);
    }

    public static Font GetSubtitleFont()
    {
        return new Font("Segoe UI", 9, FontStyle.Regular);
    }

    public static Font GetValueFont()
    {
        return new Font("Segoe UI", 14, FontStyle.Bold);
    }
}
