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
namespace Cepima.MesUserCases.Users
{
    public partial class Add_role : Form
    {
        public Add_role()
        {
            InitializeComponent();
        }

        private void Add_role_Load(object sender, EventArgs e)
        {

        }

        private void AjouterRole()
        {
            string nomRole = tb_role.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomRole))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom du rôle.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_role.Focus();
                return;
            }

            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {

                    // Vérifier si le rôle existe déjà
                    string sqlVerification = @"
                SELECT COUNT(*)
                FROM role
                WHERE nom_role = @nom_role";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sqlVerification, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nom_role",
                            nomRole);

                        int existe =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Ce rôle existe déjà.",
                                "Rôle",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            tb_role.Focus();
                            return;
                        }
                    }

                    // Ajouter le rôle
                    string sql = @"
                INSERT INTO role
                (
                    nom_role,
                    statut
                )
                VALUES
                (
                    @nom_role,
                    'actif'
                )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nom_role",
                            nomRole);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Le rôle a été ajouté avec succès.",
                    "Rôle",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                tb_role.Text = "";
                tb_role.Focus();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur MySQL lors de l'ajout du rôle :\n\n" +
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

        private void bt_add_role_Click(object sender, EventArgs e)
        {
            AjouterRole();
        }
    }
}
