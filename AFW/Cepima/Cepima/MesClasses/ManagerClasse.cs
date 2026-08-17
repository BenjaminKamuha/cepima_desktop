using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Cepima.MesClasses
{
    class ManagerClasse
    {
       
        //==================================== méthode de connexion à la base de données==============================

        //private static readonly string con_string = "server=192.168.31.2;database=cepimadb;Uid=cepima_desk;pwd=cepima";
        //private static readonly string con_string = "server=localhost;database=cepimadb;user id=root;pwd=''";

        //private static readonly string con_string = "server=192.168.203.2;database=cepimadb;Uid=cepima_desk;pwd=cepima";
        private static readonly string con_string = "server=localhost;database=cepimadb;user id=root;pwd=''";


        public static Dictionary<string, string> request_params = new Dictionary<string, string>();
        public static MySqlConnection GetConnexion()
        {
            MySqlConnection con = new MySqlConnection(con_string);
            try
            {
                con.Open();
                return con;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur de connexion :" + ex.Message);
                return null;
            }
        }
        //sauvegarder la session
        public static void SauvegarderSession(string username, string password, int jours)
        {
            var session = new SessionPersist
            {
                UserName = username,
                PasswordEncrypte = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)), // simple encodage base64
                Expiration = DateTime.Now.AddDays(jours)
            };

            string path = Path.Combine(Application.StartupPath, "session.dat");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formater.Serialize(stream, session);
            };
        }

        // Méthode de chargement de la session lors du démarrage du programme
        public static bool ChargerSession(TextBox tb_username, TextBox tb_password)
        {
            string path = Path.Combine(Application.StartupPath, "session.dat");
            if (!File.Exists(path)) return false;

            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    var session = (SessionPersist)formatter.Deserialize(stream);

                    if (session.Expiration < DateTime.Now)
                    {
                        // session expirée → supprimer fichier
                        File.Delete(path);
                        return false;
                    }

                    // remplir automatiquement le username et mot de passe
                    tb_username.Text = session.UserName;
                    tb_password.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(session.PasswordEncrypte));
                    tb_password.Focus();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        // Définition de la méthode pour les opérataions "CRUD" à la base de données

        public static MySqlDataReader CRUD(string request, Dictionary<string, string> cmd_params = null, bool read = false, bool adapt = false)
        {
            // Initialisation de la méthode
            MySqlConnection connection = GetConnexion();

            MySqlCommand cmd = new MySqlCommand(request, connection);


            if (read)
            {
                // On execute la commande
                if (cmd_params != null) // Si les paramètres sont données 
                {
                    // On parcour la liste des parametres pour les ajouters à la commande
                    foreach (KeyValuePair<string, string> cle_valeur in cmd_params)
                    {
                        cmd.Parameters.AddWithValue(cle_valeur.Key, cle_valeur.Value);
                    }
                }

                MySqlDataReader reader = cmd.ExecuteReader();

                return reader; // La méthode retourne les resultats dans "reader"
            }

            else
            {
                if (cmd_params != null) // Si les paramètres sont données 
                {
                    // On parcour la liste des parametres pour les ajouters à la commande
                    foreach (KeyValuePair<string, string> cle_valeur in cmd_params)
                    {
                        cmd.Parameters.AddWithValue(cle_valeur.Key, cle_valeur.Value);
                    }
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                // Exécution de la commande 
                cmd.ExecuteNonQuery();
            }
            return null;
        }

        // Centrer les éléments
        public static Control CenterObject(Control childControl, Control parentControl)
        {
            parentControl.Controls.Add(childControl);

            int x = (parentControl.ClientSize.Width - childControl.Width) / 2;
            int y = (parentControl.ClientSize.Height - childControl.Height) / 2;

            childControl.Location = new Point(Math.Max(0, x), Math.Max(0, y));

            parentControl.Resize += (s, e) =>
            {
                int newX = (parentControl.ClientSize.Width - childControl.Width) / 2;
                int newY = (parentControl.ClientSize.Height - childControl.Height) / 2;
                childControl.Location = new Point(Math.Max(0, newX), Math.Max(0, newY));
            };

            return childControl;
        }
        // Variables positionnement pour la methode (Addcontrol)
        public static Control last_added = null;
        public static int parentWidthRestant = 0;
        public static int parentHeight_restant = 0;
        public static void AddControl(Control parent, Control child, int constanteX = 20, int ConstateY = 20, int decalageX = 3, int decalageY = 3, bool scrolling = false)
        {

            child.Visible = false;
            // Récupération de la taille du control parent
            int parentWidth = parent.Width;
            int parentHeight = parent.Height;

            Control Control_precedent_X = null;
            Control Control_precedent_Y = null;

            // Vérifier s'il y a d'autre controle enfant
            List<Control> autres_controls = new List<Control>();
            List<Int32> position_X = new List<Int32>();
            List<Int32> position_Y = new List<Int32>();
            List<Int32> width_X = new List<Int32>();


            foreach (Control autre_control in parent.Controls)
            {
                autres_controls.Add(autre_control);
            }

            // S'il y'a des controls dans parent, on récupère les positions
            if (autres_controls.Count() == 0)
            {
                child.Location = new Point(constanteX, ConstateY);
                parent.Controls.Add(child);
                last_added = child;
                parentWidthRestant = parentWidth - (last_added.Width + last_added.Location.X + constanteX);
            }

            else
            {
                // on récupère max_X et max_Y

                last_added = autres_controls.Last();

                foreach (Control autre_control in autres_controls)
                {
                    position_X.Add(autre_control.Location.X);
                    position_Y.Add(autre_control.Location.Y);

                }

                // Récupération de la taille restante du control parent

                if (parentWidthRestant > child.Size.Width)
                {
                    child.Location = new Point(last_added.Width + last_added.Location.X + (constanteX * decalageX), last_added.Location.Y);
                    parent.Controls.Add(child);
                    last_added = child;
                    parentWidthRestant = parentWidth - (last_added.Width + constanteX + last_added.Location.X);

                }
                else
                {
                    child.Location = new Point(constanteX, last_added.Height + last_added.Location.Y + (ConstateY * decalageY));
                    parent.Controls.Add(child);
                    last_added = child;
                    parentWidthRestant = parentWidth - (last_added.Width + last_added.Location.X + constanteX);

                }
            }
        }
        // Fonction pour Ajouter un label 
        public static Label CustomLabel(string text = "Custom Label", Point? location = null, int font_size = 8, FontStyle? font_style = null)
        {
            Label label = new Label
            {
                Text = text,
                Location = location ?? new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", font_size, font_style ?? FontStyle.Regular),
                ForeColor = Color.FromArgb(69, 64, 50),
                Margin = new Padding(20, 10, 20, 10),
            };

            return label;
        }
        public static void focused_child(Control parent, Control child, Color? child_color = null, Color? others_controls_color = null)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr is Button)
                {
                    ctr.BackColor = others_controls_color ?? ColorTranslator.FromHtml("#F7FAFC");
                    ctr.Font = new Font("Calibri", 8, FontStyle.Regular);
                    ctr.ForeColor = Color.Black;
                }
            }

            // appliquer le focus UNE SEULE FOIS
            if (child is Button)
            {
                child.BackColor = child_color ?? ColorTranslator.FromHtml("#434F63");
                child.Font = new Font("Calibri", 9, FontStyle.Bold);
                child.ForeColor = Color.White;
            }
        }
        // Fonction pour ajouter l'image
        public static PictureBox AddPicture(Image img, Point location, Size size)
        {
            PictureBox picture = new PictureBox
            {
                Image = img,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = location,
                Size = size
            };

            return picture;
        }
        // Fonction pour ajouter un bouton
        public static RoundedButton Rbutton(string text = "Button", Point? location = null, Size? size = null, Color? bgc = null, Color? fgc = null)
        {
            RoundedButton btn = new RoundedButton();
            btn.Location = location ?? new Point(20, 20);
            btn.Size = size ?? new Size(100, 40);
            btn.AutoSize = true;
            btn.ButtonText = text;
            btn.DefaultBackColor = bgc ?? Color.SkyBlue;
            btn.ForeColor = fgc ?? Color.Black;
            btn.BorderRadius = 10;
            btn.BorderSize = 0;
            btn.Font = new Font("Verdana", 8, FontStyle.Bold);

            return btn;
        }
        public static CustomRoundedPanel Rpanel(Point? location = null, Size? size = null, DockStyle dock = DockStyle.None)
        {
            CustomRoundedPanel panel = new CustomRoundedPanel();
            //CustomRoundedPanel panel = new CustomRoundedPanel();
            panel.Location = location ?? new Point(300, 150);
            panel.Size = size ?? panel.Size;
            //panel.Size = size.Value;
            //panel.AutoSize = true;
            panel.BorderSize = 1;
            panel.BorderRadius = 15;
            //panel.ShadowColor = Color.FromArgb(113, 128, 150);
            //panel.ShadowDepth = 1;
            panel.Margin = new Padding(10);
            //panel.ShadowColor = Color.FromArgb(113, 128, 150);
            panel.Dock = dock;
            //panel.BackColor = Color.Blue;

            // Animation
            return panel;
        }

    }
    //class session
    public static class SessionUtilisateur
    {
        public static int idUser { get; set; }
        public static int id_personnel { get; set; }
        public static string Nom { get; set; }
        public static string mail { get; set; }
        public static string Role { get; set; }
        public static bool EstConnecte { get; set; }
        public static bool RememberMe { get; set; }
    }
    //class pour stocker le session pendant une dureé bien définie
    [Serializable]
    public class SessionPersist
    {
        public string UserName { get; set; }
        public string PasswordEncrypte { get; set; }
        public DateTime Expiration { get; set; }
    }
}
