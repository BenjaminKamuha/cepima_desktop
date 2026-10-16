using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Cepima.MesForms
{
    public partial class Creer_compte : Form
    {
        public Creer_compte()
        {
            InitializeComponent();
        }

        private void Creer_compte_Load(object sender, EventArgs e)
        {

        }

        private string HasherMotDePasse(string motDePasse)
        {
            // Génération d'un sel aléatoire de 16 octets
            byte[] sel = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(sel);
            }

            // Génération du hash avec PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                motDePasse,
                sel,
                100000))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                // On stocke le sel + le hash dans une seule chaîne
                string selBase64 = Convert.ToBase64String(sel);
                string hashBase64 = Convert.ToBase64String(hash);

                return selBase64 + ":" + hashBase64;
            }
        }

        private void CreerCompte()
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text;

            // Vérification du nom utilisateur
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Veuillez saisir un nom d'utilisateur.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_username.Focus();
                return;
            }

            // Vérification du mot de passe
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Veuillez saisir un mot de passe.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_password.Focus();
                return;
            }

            // Petite sécurité sur la longueur
            if (password.Length < 6)
            {
                MessageBox.Show(
                    "Le mot de passe doit contenir au moins 6 caractères.",
                    "Mot de passe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_password.Focus();
                return;
            }

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    // Vérifier si le nom d'utilisateur existe déjà
                    string sqlVerification = @"
                SELECT COUNT(*)
                FROM utilisateurs
                WHERE username = @username";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlVerification, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        int nombre = Convert.ToInt32(cmd.ExecuteScalar());

                        if (nombre > 0)
                        {
                            MessageBox.Show(
                                "Ce nom d'utilisateur existe déjà.",
                                "Compte utilisateur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            tb_username.Focus();
                            return;
                        }
                    }

                    // Hash du mot de passe
                    string passwordHash = HasherMotDePasse(password);

                    // Création du compte
                    string sql = @"
                INSERT INTO utilisateurs
                (
                    id_personnel,
                    username,
                    password_hash,
                    date_creation,
                    actif
                )
                VALUES
                (
                    NULL,
                    @username,
                    @password_hash,
                    CURDATE(),
                    1
                )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue(
                            "@password_hash",
                            passwordHash);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Le compte administrateur a été créé avec succès.",
                    "Création du compte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Nettoyage des champs
                tb_username.Text = "";
                tb_password.Text = "";

                // Fermer le formulaire
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL lors de la création du compte :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bt_compte_Click(object sender, EventArgs e)
        {
            CreerCompte();
        }
    }
}
