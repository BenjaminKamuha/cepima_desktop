using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class BunifuRoundedPanel : Panel
{
    private int _borderRadius = 30;
    private int _borderSize = 2;
    private Color _borderColor = Color.DarkBlue;
    private int _shadowDepth = 15;
    private Color _shadowColor = Color.Gray;

    [Category("Appearance"), Description("Définir le rayon des coins arrondis")]
    public int BorderRadius
    {
        get { return _borderRadius; }
        set
        {
            _borderRadius = value;
            Invalidate();
        }
    }

    [Category("Appearance"), Description("Définir la taille de la bordure")]
    public int BorderSize
    {
        get { return _borderSize; }
        set
        {
            _borderSize = value;
            Invalidate();
        }
    }

    [Category("Appearance"), Description("Définir la couleur de la bordure")]
    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            Invalidate();
        }
    }

    [Category("Appearance"), Description("Définir la profondeur de l'ombre")]
    public int ShadowDepth
    {
        get { return _shadowDepth; }
        set
        {
            _shadowDepth = value;
            Invalidate();
        }
    }

    [Category("Appearance"), Description("Définir la couleur de l'ombre")]
    public Color ShadowColor
    {
        get { return _shadowColor; }
        set
        {
            _shadowColor = value;
            Invalidate();
        }
    }

    public BunifuRoundedPanel()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Dessiner l'ombre
        DrawShadow(graphics);

        // Dessiner le panneau arrondi avec la bordure
        DrawRoundedPanelWithBorder(graphics);
    }

    private void DrawShadow(Graphics graphics)
    {
        // Ombre avec dégradé progressif pour plus de visibilité
        for (int i = ShadowDepth; i >= 0; i--)
        {
            int alpha = (int)(20 * (1 - (float)i / ShadowDepth)); // Alpha dégressif
            using (GraphicsPath shadowPath = CreateRoundedRectanglePath(
                i, i, Width - (i * 2), Height - (i * 2), BorderRadius))
            {
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, ShadowColor)))
                {
                    graphics.FillPath(shadowBrush, shadowPath);
                }
            }
        }
    }

    private void DrawRoundedPanelWithBorder(Graphics graphics)
    {
        // Panneau intérieur (sans dépasser la bordure)
        Rectangle innerRectangle = new Rectangle(
            BorderSize + ShadowDepth / 2,
            BorderSize + ShadowDepth / 2,
            Width - 2 * (BorderSize + ShadowDepth / 2),
            Height - 2 * (BorderSize + ShadowDepth / 2)
        );

        // Tracé du panneau arrondi
        using (GraphicsPath panelPath = CreateRoundedRectanglePath(
            innerRectangle.X, innerRectangle.Y,
            innerRectangle.Width, innerRectangle.Height, BorderRadius))
        {
            // Dessiner le remplissage du panneau
            using (SolidBrush panelBrush = new SolidBrush(BackColor))
            {
                graphics.FillPath(panelBrush, panelPath);
            }

            // Dessiner la bordure
            if (BorderSize > 0)
            {
                using (Pen borderPen = new Pen(BorderColor, BorderSize))
                {
                    borderPen.Alignment = PenAlignment.Inset;
                    graphics.DrawPath(borderPen, panelPath);
                }
            }
        }
    }

    private GraphicsPath CreateRoundedRectanglePath(int x, int y, int width, int height, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        float diameter = radius * 2f;

        path.StartFigure();
        path.AddArc(x, y, diameter, diameter, 180, 90);
        path.AddArc(x + width - diameter, y, diameter, diameter, 270, 90);
        path.AddArc(x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);
        path.AddArc(x, y + height - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}