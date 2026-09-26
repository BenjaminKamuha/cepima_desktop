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
    public partial class Update_user : Form
    {
        int  userID;
        private bool administrateurConnecte = false;
        private bool monCompte = false;
        private bool chargementRoles = false;
        public Update_user(int idUser)
        {
            InitializeComponent();
            this.userID = idUser;
            check_list_role.ItemCheck += check_list_role_ItemCheck;
        }

        void check_list_role_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chargementRoles)
                return;

            if (e.Index < 0 ||
                e.Index >= check_list_role.Items.Count)
                return;

            if (!administrateurConnecte && !monCompte)
                return;

            RoleItem role =
                (RoleItem)check_list_role.Items[e.Index];

            bool ajouter =
                e.NewValue == CheckState.Checked;

            ModifierRoleUtilisateur(
                role.IdRole,
                ajouter,
                e.Index,
                e.CurrentValue);
        }

        private void ModifierRoleUtilisateur(int idRole,bool ajouter,int index,CheckState ancienEtat)
        {
            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
    

                    if (ajouter)
                    {
                        // Vérifier si le rôle existe déjà
                        string sqlVerification = @"
                    SELECT COUNT(*)
                    FROM utilisateur_role
                    WHERE id_utilisateur = @id_utilisateur
                    AND id_role = @id_role";

                        int existe = 0;

                        using (MySqlCommand cmd =
                            new MySqlCommand(sqlVerification, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_utilisateur",
                                userID);

                            cmd.Parameters.AddWithValue(
                                "@id_role",
                                idRole);

                            existe =
                                Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Ajouter uniquement s'il n'existe pas
                        if (existe == 0)
                        {
                            string sqlAjout = @"
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

                            using (MySqlCommand cmd =
                                new MySqlCommand(sqlAjout, con))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_utilisateur",
                                    userID);

                                cmd.Parameters.AddWithValue(
                                    "@id_role",
                                    idRole);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // Supprimer le rôle
                        string sqlSuppression = @"
                    DELETE FROM utilisateur_role
                    WHERE id_utilisateur = @id_utilisateur
                    AND id_role = @id_role";

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                sqlSuppression,
                                con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@id_utilisateur",
                                userID);

                            cmd.Parameters.AddWithValue(
                                "@id_role",
                                idRole);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification du rôle :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Remettre la case dans son état précédent
                chargementRoles = true;

                check_list_role.SetItemCheckState(
                    index,
                    ancienEtat);

                chargementRoles = false;
            }
        }
        private void Update_user_Load(object sender, EventArgs e)
        {
         
            monCompte = userID == MesForms.SessionUtilisateur.idUser;
            administrateurConnecte = EstAdministrateurConnecte();

            ChargerUtilisateur();

            ChargerRoles();

            ConfigurerFormulaire();
        }
        private void ConfigurerFormulaire()
        {
            if (administrateurConnecte)
            {
                // ==============================
                // ADMINISTRATEUR
                // ==============================

                // Username et mot de passe en lecture seule
                tb_username.ReadOnly = true;
                tb_password.ReadOnly = true;

                // L'administrateur peut gérer les rôles
                check_list_role.Enabled = true;

                // Pas de bouton Enregistrer
                bt_save_user.Visible = false;
            }
            else
            {
                // ==============================
                // UTILISATEUR NORMAL
                // ==============================

                // Il peut modifier son username
                // et son mot de passe
                tb_username.ReadOnly = false;
                tb_password.ReadOnly = false;

                // Il ne peut pas modifier les rôles
                check_list_role.Enabled = false;

                // Bouton Enregistrer visible
                bt_save_user.Visible = true;
            }
        }
        private bool EstAdministrateurConnecte()
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    string query = @"
                SELECT COUNT(*)
                FROM utilisateur_role ur
                INNER JOIN role r
                    ON r.id_role = ur.id_role
                WHERE ur.id_utilisateur = @id_utilisateur
                AND r.nom_role = 'Administrateur'
                AND r.statut = 'actif'";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_utilisateur",
                            MesForms.SessionUtilisateur.idUser);

                        int resultat =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        return resultat > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void ChargerUtilisateur()
        {
            try
            {
                string query = @"
            SELECT username
            FROM utilisateurs
            WHERE id_utilisateurs = @id_utilisateur";

                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                   

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_utilisateur",
                            userID);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tb_username.Text =
                                    reader["username"].ToString();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Utilisateur introuvable.",
                                    "Utilisateur",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                this.Close();
                            }
                        }
                    }
                }

                // Un hash ne peut pas être récupéré
                tb_password.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors du chargement de l'utilisateur :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ChargerRoles()
        {
            try
            {
                chargementRoles = true;

                string query = @"
            SELECT 
                r.id_role,
                r.nom_role,
                CASE
                    WHEN ur.id_role IS NOT NULL THEN 1
                    ELSE 0
                END AS selectionne
            FROM role r
            LEFT JOIN utilisateur_role ur
                ON ur.id_role = r.id_role
                AND ur.id_utilisateur = @id_utilisateur
            WHERE r.statut = 'actif'
            ORDER BY r.nom_role ASC";

                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_utilisateur",
                            userID);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            check_list_role.Items.Clear();

                            while (reader.Read())
                            {
                                RoleItem role = new RoleItem
                                {
                                    IdRole =
                                        Convert.ToInt32(
                                            reader["id_role"]),

                                    NomRole =
                                        reader["nom_role"].ToString()
                                };

                                int index =
                                    check_list_role.Items.Add(role);

                                bool selectionne =
                                    Convert.ToInt32(
                                        reader["selectionne"]) == 1;

                                check_list_role.SetItemChecked(
                                    index,
                                    selectionne);
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
            finally
            {
                chargementRoles = false;
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
        private void ModifierUtilisateur()
        {
            string username = tb_username.Text.Trim();
            string password = tb_password.Text;

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

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    // Vérifier que le username n'appartient pas
                    // déjà à un autre utilisateur
                    string verification = @"
                SELECT COUNT(*)
                FROM utilisateurs
                WHERE username = @username
                AND id_utilisateurs <> @id_utilisateur";

                    using (MySqlCommand cmd =
                        new MySqlCommand(verification, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username);

                        cmd.Parameters.AddWithValue(
                            "@id_utilisateur",
                            userID);

                        int existe =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Ce nom d'utilisateur est déjà utilisé.",
                                "Utilisateur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            tb_username.Focus();
                            return;
                        }
                    }

                    // Si un nouveau mot de passe est saisi
                    if (!string.IsNullOrWhiteSpace(password))
                    {
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

                        string hash = HasherMotDePasse(password);

                        string sql = @"
                    UPDATE utilisateurs
                    SET username = @username,
                        password_hash = @password_hash
                    WHERE id_utilisateurs = @id_utilisateur";

                        using (MySqlCommand cmd =
                            new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@username",
                                username);

                            cmd.Parameters.AddWithValue(
                                "@password_hash",
                                hash);

                            cmd.Parameters.AddWithValue(
                                "@id_utilisateur",
                                userID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sql = @"
                    UPDATE utilisateurs
                    SET username = @username
                    WHERE id_utilisateurs = @id_utilisateur";

                        using (MySqlCommand cmd =
                            new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue(
                                "@username",
                                username);

                            cmd.Parameters.AddWithValue(
                                "@id_utilisateur",
                                userID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    "Le compte a été modifié avec succès.",
                    "Modification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la modification :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void bt_save_user_Click(object sender, EventArgs e)
        {
            ModifierUtilisateur();
        }
    }
}
