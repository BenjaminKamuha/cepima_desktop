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
namespace Cepima.MesForms
{
    public partial class FormConnexion : Form
    {
        private int tentativesConnexion = 0;
        private const int maxTentatives = 3;
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Méthode de chargement de la session lors du démarrage du programme
        bool ChargerSession()
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
        //sauvegarder la session
        private void SauvegarderSession(string username, string password, int jours)
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

        private void FormConnexion_Load(object sender, EventArgs e)
        {
            bool sessionExist = ChargerSession();
            if (sessionExist)
            {
                // si la session existe et n'est pas expirée, tu peut directement mettre le focus sur le mot de passe
                tb_password.Focus();
                cb_remember.Visible = false;
            }
            else
            {
                //sinon, focus sur le champs username
                tb_username.Focus();
                cb_remember.Visible = true;
            }
        }

        private void bt_connexion_Click(object sender, EventArgs e)
        {
            string userTex = tb_username.Text;
            string passText = tb_password.Text;

            string username = "";
            string idUser = "";
            string pass = "";
            bool isSuccess = false;
            try
            {
                string query = "SELECT u.id_utilisateurs,u.username,u.password_hash,u.role,p.id_personnel,c.id_centre,c.nom_centre FROM utilisateurs u JOIN personnels p ON p.id_personnel = u.id_personnel INNER JOIN centres c ON c.id_centre = p.id_centre WHERE u.username = @username AND password_hash = @password";
                MesClasses.ManagerClasse.request_params.Clear();
                MesClasses.ManagerClasse.request_params.Add("@username",userTex);
                MesClasses.ManagerClasse.request_params.Add("@password",passText);

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    if (reader.Read())
                    {
                        username = reader["username"].ToString();
                        idUser = reader["id_utilisateurs"].ToString();
                        pass = reader["password_hash"].ToString();
                        isSuccess = true;
                        SessionUtilisateur.idUser = Convert.ToInt32(idUser);
                        SessionUtilisateur.idCentre = Convert.ToInt32(reader["id_centre"]);
                        SessionUtilisateur.Centre = reader["nom_centre"].ToString();
                        SessionUtilisateur.Nom = username;
                        SessionUtilisateur.Role = reader["role"].ToString();
                        SessionUtilisateur.EstConnecte = true;

                        if (cb_remember.Checked)
                        {
                            File.WriteAllText("session.dat", username);
                            SauvegarderSession(username, pass, 2);
                        }
                        
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                return;
            }
            if (isSuccess)
            {
                  tentativesConnexion = 0;
                  // Ouvrir l'application en soi
                  Form1 frm = new Form1();
                  frm.Show();
                  this.Hide();
                  MessageBox.Show("Connexion établie");
            }
            else
            {
                tentativesConnexion++;
                int tentativesRestantes = maxTentatives - tentativesConnexion;
                if (tentativesRestantes > 0)
                {
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorect. \n Tentatives restantes : " + tentativesRestantes, " Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_password.Text = "";
                    tb_password.Focus(); // remet le focus sur le mot de passe

                }
                else
                {

                    MessageBox.Show("Vous avez atteint le nombre maximal de tentative.\nCliquer sur 'Mot de passe oublié' pour récupérer votre compte", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb_password.Text = "";
                    tb_password.Focus();
                    link_forgot.Visible = true;
                }
            }
        }

        private void link_forgot_Click(object sender, EventArgs e)
        {

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
    public  class SessionPersist
    {
        public string UserName { get; set; }
        public string PasswordEncrypte { get; set; }
        public DateTime Expiration { get; set; }
    }

}
