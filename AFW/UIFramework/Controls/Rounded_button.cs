//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace test_arrondissement2012
{

    public class PerfectRoundedButton : UserControl
    {
        private int _borderRadius = 20;
        private int _borderSize = 2;
        private Color _borderColor = Color.DeepSkyBlue;
        private Color _hoverBackColor = Color.SteelBlue;
        private Color _defaultBackColor = Color.DodgerBlue;
        private Color _textColor = Color.White;
        private bool _isHovered = false;

        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public Color HoverBackColor
        {
            get { return _hoverBackColor; }
            set { _hoverBackColor = value; Invalidate(); }
        }

        public Color DefaultBackColor
        {
            get { return _defaultBackColor; }
            set { _defaultBackColor = value; Invalidate(); }
        }

        public string ButtonText { get; set; }

        public PerfectRoundedButton()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(150, 50);
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            // Rectangle d'affichage
            RectangleF buttonRect = new RectangleF(0, 0, this.Width - 1, this.Height - 1);
            Color backColor = _isHovered ? _hoverBackColor : _defaultBackColor;

            using (GraphicsPath path = CreateRoundedRectanglePath(buttonRect, _borderRadius))
            {
                // Remplir le bouton
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    graphics.FillPath(brush, path);
                }

                // Dessiner la bordure
                if (_borderSize > 0)
                {
                    using (Pen pen = new Pen(_borderColor, _borderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        graphics.DrawPath(pen, path);
                    }
                }

                // Dessiner le texte centré
                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                using (Brush textBrush = new SolidBrush(_textColor))
                {
                    graphics.DrawString(ButtonText, this.Font, textBrush, buttonRect, stringFormat);
                }
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        // Méthode avancée pour créer un tracé ultra-lisse avec des coins arrondis
        private GraphicsPath CreateRoundedRectanglePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90); // Haut-gauche
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90); // Haut-droit
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90); // Bas-droit
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90); // Bas-gauche
            path.CloseFigure();

            return path;
        }
    }

}

