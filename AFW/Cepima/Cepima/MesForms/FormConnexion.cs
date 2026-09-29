using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Cepima.MesForms
{
    public partial class FormConnexion : Form
    {
        private int tentativesConnexion = 0;
        private const int maxTentatives = 3;

        private const int DUREE_SESSION_JOURS = 15;
        private const int PBKDF2_ITERATIONS = 100000;

        private readonly string sessionPath;

        public FormConnexion()
        {
            InitializeComponent();

            sessionPath = Path.Combine(
                Application.StartupPath,
                "session.dat");

            DisplayNotice();
        }


        // =========================================================
        // MESSAGE D'ACCUEIL
        // =========================================================

        private void DisplayNotice()
        {
            lb_notice.AutoSize = false;
            lb_notice.Size = new Size(300, 300);
            lb_notice.TextAlign = ContentAlignment.TopLeft;
            lb_notice.Font =
                new Font(
                    "Calibri",
                    12F,
                    FontStyle.Regular);

            lb_notice.ForeColor =
                Color.FromArgb(
                    70,
                    70,
                    70);

            lb_notice.Text =
                "Bienvenue sur CEPIMA\r\n\r\n" +

                "Vous avez déjà un compte ?\r\n" +
                "Saisissez votre nom d'utilisateur et votre mot de passe,\r\n" +
                "puis cliquez sur « Se connecter ».\r\n\r\n" +

                "Vous n'avez pas encore de compte ?\r\n" +
                "Cliquez sur « Créer un compte » et suivez les instructions\r\n" +
                "pour enregistrer votre compte utilisateur.\r\n\r\n";
        }


        // =========================================================
        // FERMER LA FENETRE
        // =========================================================

        private void button1_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }


        // =========================================================
        // CHARGER LA SESSION
        // =========================================================

        private bool ChargerSession()
        {
            if (!File.Exists(sessionPath))
                return false;

            try
            {
                using (FileStream stream =
                    new FileStream(
                        sessionPath,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    SessionPersist session =
                        formatter.Deserialize(stream)
                        as SessionPersist;

                    if (session == null)
                    {
                        SupprimerSession();
                        return false;
                    }

                    if (session.Expiration <= DateTime.Now)
                    {
                        SupprimerSession();
                        return false;
                    }

                    tb_username.Text =
                        session.UserName ?? "";

                    // Pour des raisons de sécurité,
                    // le mot de passe n'est jamais sauvegardé.
                    tb_password.Text = "";

                    tb_username.Focus();

                    return true;
                }
            }
            catch
            {
                // Une session corrompue ou illisible
                // ne doit pas empêcher la connexion.
                return false;
            }
        }


        // =========================================================
        // SAUVEGARDER LA SESSION
        // =========================================================

        private void SauvegarderSession(
            string username,
            int jours)
        {
            if (string.IsNullOrWhiteSpace(username))
                return;

            if (jours <= 0)
                return;

            try
            {
                SessionPersist session =
                    new SessionPersist
                    {
                        UserName = username,
                        Expiration =
                            DateTime.Now.AddDays(jours)
                    };

                using (FileStream stream =
                    new FileStream(
                        sessionPath,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None))
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                        new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    formatter.Serialize(
                        stream,
                        session);
                }
            }
            catch (Exception ex)
            {
                // La sauvegarde de session ne doit pas
                // empêcher une connexion réussie.
                MessageBox.Show(
                    "La connexion a réussi, mais la session " +
                    "n'a pas pu être sauvegardée.\n\n" +
                    ex.Message,
                    "Session",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        // =========================================================
        // SUPPRIMER LA SESSION
        // =========================================================

        private void SupprimerSession()
        {
            try
            {
                if (File.Exists(sessionPath))
                {
                    File.Delete(sessionPath);
                }
            }
            catch
            {
                // Ne pas bloquer l'application
                // si le fichier ne peut pas être supprimé.
            }
        }


        // =========================================================
        // CHARGEMENT DU FORMULAIRE
        // =========================================================

        private void FormConnexion_Load(
            object sender,
            EventArgs e)
        {
            bool sessionExist =
                ChargerSession();

            if (sessionExist)
            {
                // Session existante :
                // l'utilisateur doit uniquement
                // saisir son mot de passe.
                tb_password.Focus();

                cb_remember.Visible = false;
            }
            else
            {
                tb_username.Focus();

                cb_remember.Visible = true;
            }
        }


        // =========================================================
        // VERIFIER LE MOT DE PASSE
        // =========================================================

        private bool VerifierMotDePasse(
            string motDePasse,
            string hashStocke)
        {
            if (string.IsNullOrEmpty(motDePasse))
                return false;

            if (string.IsNullOrWhiteSpace(hashStocke))
                return false;

            try
            {
                string[] parties =
                    hashStocke.Split(':');

                if (parties.Length != 2)
                    return false;

                byte[] sel =
                    Convert.FromBase64String(
                        parties[0]);

                byte[] hashOriginal =
                    Convert.FromBase64String(
                        parties[1]);

                if (sel.Length == 0 ||
                    hashOriginal.Length == 0)
                {
                    return false;
                }

                using (Rfc2898DeriveBytes pbkdf2 =
                    new Rfc2898DeriveBytes(
                        motDePasse,
                        sel,
                        PBKDF2_ITERATIONS))
                {
                    byte[] hashNouveau =
                        pbkdf2.GetBytes(
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


        // =========================================================
        // COMPARAISON SECURISEE DES HASH
        // =========================================================

        private bool ComparerTableaux(
            byte[] tableau1,
            byte[] tableau2)
        {
            if (tableau1 == null ||
                tableau2 == null)
            {
                return false;
            }

            if (tableau1.Length !=
                tableau2.Length)
            {
                return false;
            }

            int resultat = 0;

            for (int i = 0;
                 i < tableau1.Length;
                 i++)
            {
                resultat |=
                    tableau1[i] ^
                    tableau2[i];
            }

            return resultat == 0;
        }


        // =========================================================
        // CONNEXION
        // =========================================================

        private async void bt_connexion_Click(
            object sender,
            EventArgs e)
        {
            string userText =
                tb_username.Text.Trim();

            string passText =
                tb_password.Text;


            // =====================================================
            // VALIDATION USERNAME
            // =====================================================

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


            // =====================================================
            // VALIDATION MOT DE PASSE
            // =====================================================

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


            // =====================================================
            // DEMARRER LE LOADER
            // =====================================================

            MesClasses.LoadingHelper.Start(bt_connexion);


            try
            {
                // =================================================
                // EXECUTION HORS THREAD UI
                // =================================================

                bool connexionReussie = await Task.Run(() =>
                {
                    return EffectuerConnexion(
                        userText,
                        passText);
                });


                // =================================================
                // RESULTAT
                // =================================================

                if (!connexionReussie)
                {
                    AfficherErreurConnexion();
                    return;
                }


                // =================================================
                // SAUVEGARDE SESSION
                // =================================================

                if (cb_remember.Checked)
                {
                    SessionUtilisateur.RememberMe =
                        true;

                    SauvegarderSession(
                        userText,
                        DUREE_SESSION_JOURS);
                }
                else
                {
                    SessionUtilisateur.RememberMe =
                        false;
                }


                // =================================================
                // OUVRIR L'APPLICATION
                // =================================================

                Form1 frm =
                    new Form1();

                frm.Show();

                Hide();
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
            finally
            {
                // =================================================
                // ARRETER LE LOADER
                // =================================================

                MesClasses.LoadingHelper.Stop(
                    bt_connexion);
            }
        }

        private bool EffectuerConnexion(
    string userText,
    string passText)
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


            // =====================================================
            // PARAMETRES
            // =====================================================

            MesClasses.ManagerClasse.request_params.Clear();

            MesClasses.ManagerClasse.request_params.Add(
                "@username",
                userText);


            // =====================================================
            // EXECUTION
            // =====================================================

            using (MySqlDataReader reader =
                MesClasses.ManagerClasse.CRUD(
                    query,
                    MesClasses.ManagerClasse.request_params,
                    true))
            {
                if (reader == null ||
                    !reader.Read())
                {
                    return false;
                }


                // =================================================
                // VERIFICATION MOT DE PASSE
                // =================================================

                string hashStocke =
                    reader["password_hash"]
                        .ToString();

                if (!VerifierMotDePasse(
                    passText,
                    hashStocke))
                {
                    return false;
                }


                // =================================================
                // RECUPERATION
                // =================================================

                string username =
                    reader["username"]
                        .ToString();

                int idUser =
                    Convert.ToInt32(
                        reader["id_utilisateurs"]);

                string role =
                    reader["nom_role"] == DBNull.Value
                        ? ""
                        : reader["nom_role"].ToString();


                // =================================================
                // SESSION
                // =================================================

                SessionUtilisateur.idUser =
                    idUser;

                SessionUtilisateur.Nom =
                    username;

                SessionUtilisateur.Role =
                    role;

                SessionUtilisateur.EstConnecte =
                    true;


                // =================================================
                // CENTRE
                // =================================================

                if (reader["id_centre"] != DBNull.Value)
                {
                    SessionUtilisateur.idCentre =
                        Convert.ToInt32(
                            reader["id_centre"]);

                    SessionUtilisateur.Centre =
                        reader["nom_centre"] == DBNull.Value
                            ? ""
                            : reader["nom_centre"].ToString();
                }
                else
                {
                    SessionUtilisateur.idCentre = 0;

                    SessionUtilisateur.Centre = "";
                }


                return true;
            }
        }

        // =========================================================
        // MESSAGE ERREUR CONNEXION
        // =========================================================

        private void AfficherErreurConnexion()
        {
            tentativesConnexion++;

            MessageBox.Show(
                "Nom d'utilisateur ou mot de passe incorrect.",
                "Connexion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            tb_password.Text = "";
            tb_password.Focus();

            /*
             * Les variables tentativesConnexion et maxTentatives
             * existaient déjà dans ton fichier.
             *
             * On conserve ici leur comportement sans bloquer
             * automatiquement le compte.
             */
        }


        // =========================================================
        // MOT DE PASSE OUBLIE
        // =========================================================

        private void link_forgot_Click(
            object sender,
            EventArgs e)
        {
        }


        // =========================================================
        // EVENEMENT LOAD
        // =========================================================

        private void bt_connexion_Load(
            object sender,
            EventArgs e)
        {
        }


        // =========================================================
        // PAINT
        // =========================================================

        private void panel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }


        // =========================================================
        // CREATION COMPTE - LINK
        // =========================================================

        private void link_create_compte_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
        }


        // =========================================================
        // CREER UN COMPTE
        // =========================================================

        private void bt_add_compte_Click(
            object sender,
            EventArgs e)
        {
            Creer_compte compte =
                new Creer_compte();

            compte.ShowDialog();
        }

        private void modernLoader1_Click(object sender, EventArgs e)
        {

        }
    }


    // =============================================================
    // GESTION DE LA SESSION
    // =============================================================

    public static class SessionManager
    {
        public static void Logout()
        {
            // =====================================================
            // REINITIALISER LA SESSION EN MEMOIRE
            // =====================================================

            SessionUtilisateur.idUser = 0;
            SessionUtilisateur.idCentre = 0;
            SessionUtilisateur.Centre = null;
            SessionUtilisateur.Nom = null;
            SessionUtilisateur.Role = null;
            SessionUtilisateur.EstConnecte = false;
            SessionUtilisateur.RememberMe = false;


            // =====================================================
            // SUPPRIMER SESSION PERSISTANTE
            // =====================================================

            string path =
                Path.Combine(
                    Application.StartupPath,
                    "session.dat");

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch
            {
                // Ne pas faire planter l'application
                // si le fichier ne peut pas être supprimé.
            }
        }
    }


    // =============================================================
    // SESSION UTILISATEUR
    // =============================================================

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


    // =============================================================
    // SESSION PERSISTANTE
    // =============================================================

    [Serializable]
    public class SessionPersist
    {
        public string UserName { get; set; }

        public DateTime Expiration { get; set; }
    }
}