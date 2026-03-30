using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
namespace Cepima.MesClasses
{
    class ManagerClasse
    {
        //====================================méthode de connexion à la base de données==============================
        private static readonly string con_string = "server=localhost;database = cepimaDb;user id=root;pwd='trackshop_1.0'";
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
    }
    //class session
    public static class SessionUtilisateur
    {
        public static int idUser { get; set; }
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
