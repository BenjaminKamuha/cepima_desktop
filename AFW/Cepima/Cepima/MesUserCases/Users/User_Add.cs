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
using System.Security.Cryptography;
namespace Cepima.MesUserCases.Users
{
    public partial class User_Add : Form
    {
        public User_Add()
        {
            InitializeComponent();
        }

        private void User_Add_Load(object sender, EventArgs e)
        {
            ChargerRoles();
        }
        private void CreerUtilisateur()
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text;

            // Vérification du username
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom d'utilisateur.",
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
                    "Veuillez saisir le mot de passe.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_password.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show(
                    "Le mot de passe doit contenir au moins 6 caractères.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_password.Focus();
                return;
            }

            // Vérifier qu'au moins un rôle est sélectionné
            if (check_list_role.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Veuillez sélectionner au moins un rôle.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    // 1. Vérifier si le username existe déjà
                    string sqlVerification = @"
                SELECT COUNT(*)
                FROM utilisateurs
                WHERE username = @username";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlVerification, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username);

                        int existe =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Ce nom d'utilisateur existe déjà.",
                                "Utilisateur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            tb_username.Focus();
                            return;
                        }
                    }

                    // 2. Hasher le mot de passe
                    string passwordHash =
                        HasherMotDePasse(password);

                    // 3. Insérer l'utilisateur
                    string sqlUtilisateur = @"
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

                    long idUtilisateur;

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlUtilisateur, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username);

                        cmd.Parameters.AddWithValue(
                            "@password_hash",
                            passwordHash);

                        cmd.ExecuteNonQuery();

                        idUtilisateur =
                            cmd.LastInsertedId;
                    }

                    // 4. Enregistrer les rôles cochés
                    foreach (object element
                        in check_list_role.CheckedItems)
                    {
                        RoleItem role =
                            (RoleItem)element;

                        string sqlRole = @"
                    INSERT INTO utilisateur_role
                    (
                        id_utilisateur,
                        id_role
                    )
                    VALUES
                    (
                        @id_utilisateur,
                        @id_role
                    )";

                        using (MySqlCommand cmdRole =
                            new MySqlCommand(sqlRole, con))
                        {
                            cmdRole.Parameters.AddWithValue(
                                "@id_utilisateur",
                                idUtilisateur);

                            cmdRole.Parameters.AddWithValue(
                                "@id_role",
                                role.IdRole);

                            cmdRole.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    "Le compte utilisateur a été créé avec succès.",
                    "Création du compte",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Nettoyage
                tb_username.Text = "";
                tb_password.Text = "";

                for (int i = 0;
                     i < check_list_role.Items.Count;
                     i++)
                {
                    check_list_role.SetItemChecked(i, false);
                }

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
        private string HasherMotDePasse(string motDePasse)
        {
            byte[] sel = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(sel);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                motDePasse,
                sel,
                100000))
            {
                byte[] hash = pbkdf2.GetBytes(32);

                string selBase64 =
                    Convert.ToBase64String(sel);

                string hashBase64 =
                    Convert.ToBase64String(hash);

                return selBase64 + ":" + hashBase64;
            }
        }
        private void ChargerRoles()
        {
            try
            {
                string query = @"
            SELECT id_role, nom_role
            FROM role
            WHERE statut = 'actif'
            ORDER BY nom_role ASC";

                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            check_list_role.Items.Clear();

                            while (reader.Read())
                            {
                                int idRole =
                                    Convert.ToInt32(reader["id_role"]);

                                string nomRole =
                                    reader["nom_role"].ToString();

                                check_list_role.Items.Add(
                                    new RoleItem
                                    {
                                        IdRole = idRole,
                                        NomRole = nomRole
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement des rôles :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bt_save_user_Click(object sender, EventArgs e)
        {
            CreerUtilisateur();
        }
    }

    public class RoleItem
    {
        public int IdRole { get; set; }
        public string NomRole { get; set; }

        public override string ToString()
        {
            return NomRole;
        }
    }
}
