using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cepima.MesClasses
{
    public static class LoadingHelper
    {
        public static void Start(Control button)
        {
            if (button == null || button.Parent == null)
                return;

            Control parent = button.Parent;

            // Éviter de démarrer deux fois
            if (button.Tag != null)
                return;

            ModernLoader loader = new ModernLoader();

            loader.Size = new Size(60, 60);
            loader.Location = button.Location;
            loader.Anchor = button.Anchor;

            loader.CircleColor = Color.DodgerBlue;
            loader.LineThickness = 8;

            loader.Location = new Point(
                button.Left + (button.Width - loader.Width) / 2,
                button.Top + (button.Height - loader.Height) / 2
            );



            // Mémoriser le loader
            button.Tag = loader;

            int index = parent.Controls.GetChildIndex(button);

            parent.Controls.Add(loader);
            parent.Controls.SetChildIndex(loader, index);

            button.Visible = false;

            loader.Start();
            loader.BringToFront();
        }

        public static void Stop(Control button)
        {
            if (button == null || button.Parent == null)
                return;

            ModernLoader loader =
                button.Tag as ModernLoader;

            if (loader == null)
                return;

            Control parent = button.Parent;

            loader.Stop();

            parent.Controls.Remove(loader);

            loader.Dispose();

            button.Tag = null;

            button.Visible = true;
            button.BringToFront();
        }
    }
}