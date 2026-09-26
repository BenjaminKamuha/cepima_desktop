using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;
namespace Cepima.MesForms
{
    public partial class FormConnexion : Form
    {
        private int tentativesConnexion = 0;
        private const int maxTentatives = 3;
        public FormConnexion()
        {
            InitializeComponent();
            DisplayNotice();
        }

        private void DisplayNotice()
        {
            lb_notice.AutoSize = false;
            lb_notice.Size = new Size(300, 300);
            lb_notice.TextAlign = ContentAlignment.TopLeft;
            lb_notice.Font = new Font("Calibri", 12F, FontStyle.Regular);
            lb_notice.ForeColor = Color.FromArgb(70, 70, 70);

            lb_notice.Text =
                            "Bienvenue sur CEPIMA\r\n\r\n" +

                            "Vous avez déjà un compte ?\r\n" +
                            "Saisissez votre nom d'utilisateur et votre mot de passe,\r\n" +
                            "puis cliquez sur « Se connecter ».\r\n\r\n" +

                            "Vous n'avez pas encore de compte ?\r\n" +
                            "Cliquez sur « Créer un compte » et suivez les instructions\r\n" +
                            "pour enregistrer votre compte utilisateur.\r\n\r\n";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Méthode de chargement de la session lors du démarrage du programme
        bool ChargerSession()
        {
            string path = Path.Combine(
                Application.StartupPath,
                "session.dat");

            if (!File.Exists(path))
                return false;

            try
            {
                using (var stream =
                    new FileStream(
                        path,
                        FileMode.Open))
                {
                    var formatter =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    var session =
                        (SessionPersist)formatter.Deserialize(stream);

                    if (session.Expiration < DateTime.Now)
                    {
                        File.Delete(path);
                        return false;
                    }

                    tb_username.Text =
                        session.UserName;

                    // On ne remplit plus le mot de passe
                    tb_password.Text = "";

                    tb_username.Focus();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //sauvegarder la session
        private void SauvegarderSession(
        string username,
        int jours)
        {
            var session = new SessionPersist
            {
                UserName = username,
                Expiration = DateTime.Now.AddDays(jours)
            };

            string path = Path.Combine(
                Application.StartupPath,
                "session.dat");

            using (var stream =
                new FileStream(
                    path,
                    FileMode.Create))
            {
                var formatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                formatter.Serialize(
                    stream,
                    session);
            }
        }

        private void FormConnexion_Load(object sender, EventArgs e)
        {
            bool sessionExist = ChargerSession();
            if (sessionExist)
            {
                // si la session existe et n'est pas expirée, tu peut directement mettre le focus sur le mot de passe
                tb_password.Focus();
                cb_remember.Visible = false;

                //bt_connexion_Click(null, null);
            }

            else
            {
                //sinon, focus sur le champs username
                tb_username.Focus();
                cb_remember.Visible = true;
            }
        }

        private bool VerifierMotDePasse(string motDePasse,string hashStocke)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hashStocke))
                    return false;

                string[] parties = hashStocke.Split(':');

                if (parties.Length != 2)
                    return false;

                byte[] sel = Convert.FromBase64String(parties[0]);
                byte[] hashOriginal = Convert.FromBase64String(parties[1]);

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    motDePasse,
                    sel,
                    100000))
                {
                    byte[] hashNouveau = pbkdf2.GetBytes(
                        hashOriginal.Length);

                    return ComparerTableaux(
                        hashOriginal,
                        hashNouveau);
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ComparerTableaux(byte[] tableau1,byte[] tableau2)
        {
            if (tableau1 == null || tableau2 == null)
                return false;

            if (tableau1.Length != tableau2.Length)
                return false;

            bool resultat = true;

            for (int i = 0; i < tableau1.Length; i++)
            {
                if (tableau1[i] != tableau2[i])
                    resultat = false;
            }

            return resultat;
        }
        private void bt_connexion_Click(object sender, EventArgs e)
        {
            string userText = tb_username.Text.Trim();
            string passText = tb_password.Text;

            if (string.IsNullOrWhiteSpace(userText))
            {
                MessageBox.Show(
                    "Veuillez saisir votre nom d'utilisateur.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_username.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passText))
            {
                MessageBox.Show(
                    "Veuillez saisir votre mot de passe.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_password.Focus();
                return;
            }

            try
            {
                string query = @"
    SELECT 
        u.id_utilisateurs,
        u.username,
        u.password_hash,
        u.id_personnel,
        p.id_centre,
        c.nom_centre,
        r.id_role,
        r.nom_role
    FROM utilisateurs u
    LEFT JOIN personnels p 
        ON p.id_personnel = u.id_personnel
    LEFT JOIN centres c 
        ON c.id_centre = p.id_centre
    LEFT JOIN utilisateur_role ur
        ON ur.id_utilisateur = u.id_utilisateurs
    LEFT JOIN role r
        ON r.id_role = ur.id_role
        AND r.statut = 'actif'
    WHERE u.username = @username
    AND u.actif = 1
    ORDER BY r.nom_role";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@username",
                    userText);

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show(
                            "Nom d'utilisateur ou mot de passe incorrect.",
                            "Connexion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        tb_password.Text = "";
                        tb_password.Focus();
                        return;
                    }

                    string hashStocke =
                        reader["password_hash"].ToString();

                    // Vérification du mot de passe
                    bool motDePasseCorrect = VerifierMotDePasse(passText,hashStocke);

                    if (!motDePasseCorrect)
                    {
                        MessageBox.Show(
                            "Nom d'utilisateur ou mot de passe incorrect.",
                            "Connexion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        tb_password.Text = "";
                        tb_password.Focus();
                        return;
                    }

                    // Récupération des informations utilisateur
                    string username =
                        reader["username"].ToString();

                    string idUser =
                        reader["id_utilisateurs"].ToString();

                    string role =
                        reader["nom_role"].ToString();

                    // Session utilisateur
                    SessionUtilisateur.idUser =
                        Convert.ToInt32(idUser);

                    SessionUtilisateur.Nom =
                        username;

                    SessionUtilisateur.Role =
                        role;

                    SessionUtilisateur.EstConnecte =
                        true;

                    // Centre
                    if (reader["id_centre"] != DBNull.Value)
                    {
                        SessionUtilisateur.idCentre =
                            Convert.ToInt32(reader["id_centre"]);

                        SessionUtilisateur.Centre =
                            reader["nom_centre"].ToString();
                    }
                    else
                    {
                        SessionUtilisateur.idCentre = 0;
                        SessionUtilisateur.Centre = "";
                    }

                    // Sauvegarder la session si demandé
                    if (cb_remember.Checked)
                    {
                        SauvegarderSession(username,15);
                    }
                }

              
                // Connexion réussie
                Form1 frm = new Form1();

                frm.Show();

                this.Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur de connexion à la base de données :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue lors de la connexion :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void link_forgot_Click(object sender, EventArgs e)
        {

        }

        private void bt_connexion_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void link_create_compte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void bt_add_compte_Click(object sender, EventArgs e)
        {
            Creer_compte compte = new Creer_compte();
            compte.ShowDialog();
        }
    }
    // gerer la session quand l'utilisateur se deconnecte ================
     public static class SessionManager
     {
        public static void Logout()
        {
            //Réinitialiser la session en memoire
            SessionUtilisateur.idUser = 0;
            SessionUtilisateur.Nom = null;
            SessionUtilisateur.Role = null;
            SessionUtilisateur.EstConnecte = false;
            SessionUtilisateur.RememberMe = false;

            //Supprimer la session persistée
            string path = Path.Combine(Application.StartupPath,"session.dat");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
    // =================== class session =================================
    public static class SessionUtilisateur
    {
        public static int idUser { get; set; }
        public static int idCentre { get; set; }
        public static string Centre { get; set; }
        public static string Nom { get; set; }
        public static string Role { get; set; }
        public static bool EstConnecte { get; set; }
        public static bool RememberMe { get; set; }
    }
    //class pour stocker le session pendant une dureé bien définie
    [Serializable]
    public class SessionPersist
    {
        public string UserName { get; set; }

        public DateTime Expiration { get; set; }
    }

}
