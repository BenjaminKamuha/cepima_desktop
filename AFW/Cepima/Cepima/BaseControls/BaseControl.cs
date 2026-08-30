using System;
using System.Drawing;
using System.Windows.Forms;

public class BaseControl : UserControl
{
    public BaseControl()
    {
        // Active la transparence et le rendu custom
        this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.UserPaint |
                      ControlStyles.AllPaintingInWmPaint, true);

        this.BackColor = Color.Transparent;
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        // Si le fond est transparent, on peint le parent
        //if (this.BackColor == Color.Transparent && this.Parent != null)
        //{
        //    //Graphics g = pevent.Graphics;
        //    //Rectangle rect = this.Bounds;
        //    //// Translate pour la position du parent
        //    //g.TranslateTransform(-this.Left, -this.Top);
        //    //PaintEventArgs pea = new PaintEventArgs(g, rect);
        //    //// Appelle le Paint du parent
        //    ////this.Parent.InvokePaintBackground(this.Parent, pea);
        //    ////this.Parent.InvokePaint(this.Parent, pea);
        //    //g.TranslateTransform(this.Left, this.Top);
        //}
        //else
        //{
        //    //base.OnPaintBackground(pevent);
        //}
    }
}
