using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases.Users
{
    public partial class Utilisateurs_user : UserControl
    {
        
        public Utilisateurs_user()
        {
            InitializeComponent();
            ChargerUtilisateurs();
            dgv_utilisateurs.CellContentClick += dgv_utilisateurs_CellContentClick;
        }

        void dgv_utilisateurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgv_utilisateurs.Columns[e.ColumnIndex].Name =="colUpdate")
            {
                string idUtilisateur = dgv_utilisateurs.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                //appeler le formulaire de modification de l'utilisateur
                MesUserCases.Users.Update_user user = new Update_user(Convert.ToInt32(idUtilisateur));
                user.ShowDialog();
                ChargerUtilisateurs();
            }
        }

        private void StyleDataGridViewUtilisateurs()
        {
            // Empêcher le DataGridView de redimensionner
            // automatiquement les colonnes
            dgv_utilisateurs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            // Hauteur des lignes
            dgv_utilisateurs.RowTemplate.Height = 38;

            // Colonne ID
            dgv_utilisateurs.Columns["colID"].Width = 60;

            // Nom utilisateur
            dgv_utilisateurs.Columns["colUser"].Width = 220;

            // Rôle
            dgv_utilisateurs.Columns["colRole"].Width = 300;

            // Date
            dgv_utilisateurs.Columns["colDate"].Width = 130;

            // Bouton Modifier
            dgv_utilisateurs.Columns["colUpdate"].Width = 90;

            // Ne pas sélectionner toute la ligne avec le bouton
            dgv_utilisateurs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv_utilisateurs.AllowUserToResizeRows = false;
        }
        private void StyleBoutonModifier()
        {
            DataGridViewButtonColumn colonne =
                dgv_utilisateurs.Columns["colUpdate"]
                as DataGridViewButtonColumn;

            if (colonne != null)
            {
                colonne.Width = 100;
                colonne.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.None;

                colonne.HeaderText = "Action";
                colonne.Text = "Modifier";
                colonne.UseColumnTextForButtonValue = true;
            }

            foreach (DataGridViewRow row in dgv_utilisateurs.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataGridViewCellStyle style = row.Cells["colUpdate"].Style;

                    style.Font = new Font("Calibri", 9F, FontStyle.Bold);

                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void ChargerUtilisateurs()
        {
            try
            {
                string recherche = tb_search_user.Text.Trim();

                string query = @"
            SELECT 
                u.id_utilisateurs,
                u.username,
                GROUP_CONCAT(
                    r.nom_role 
                    ORDER BY r.nom_role 
                    SEPARATOR ', '
                ) AS nom_role,
                u.date_creation
            FROM utilisateurs u

            LEFT JOIN utilisateur_role ur
                ON ur.id_utilisateur = u.id_utilisateurs

            LEFT JOIN role r
                ON r.id_role = ur.id_role

            WHERE u.username LIKE @recherche

            GROUP BY 
                u.id_utilisateurs,
                u.username,
                u.date_creation

            ORDER BY u.username ASC";

                MesClasses.ManagerClasse.request_params.Clear();

                MesClasses.ManagerClasse.request_params.Add(
                    "@recherche",
                    "%" + recherche + "%"
                );

                using (MySqlDataReader reader =
                    MesClasses.ManagerClasse.CRUD(
                        query,
                        MesClasses.ManagerClasse.request_params,
                        true))
                {
                    dgv_utilisateurs.Rows.Clear();

                    while (reader.Read())
                    {
                        int ligne = dgv_utilisateurs.Rows.Add();

                        // ID
                        dgv_utilisateurs.Rows[ligne]
                            .Cells["colID"]
                            .Value = reader["id_utilisateurs"].ToString();

                        // Nom utilisateur
                        dgv_utilisateurs.Rows[ligne]
                            .Cells["colUSer"]
                            .Value = reader["username"].ToString();

                        // Rôles
                        dgv_utilisateurs.Rows[ligne]
                            .Cells["colRole"]
                            .Value =
                            reader["nom_role"] == DBNull.Value
                            ? ""
                            : reader["nom_role"].ToString();

                        // Date
                        if (reader["date_creation"] != DBNull.Value)
                        {
                            DateTime date =
                                Convert.ToDateTime(reader["date_creation"]);

                            dgv_utilisateurs.Rows[ligne]
                                .Cells["colDate"]
                                .Value = date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            dgv_utilisateurs.Rows[ligne]
                                .Cells["colDate"]
                                .Value = "";
                        }
                    }

                    reader.Close();

                    StyleDataGridViewUtilisateurs();
                    StyleBoutonModifier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tb_search_user_TextChanged(object sender, EventArgs e)
        {
            ChargerUtilisateurs();
        }

        private void bt_add_user_Click(object sender, EventArgs e)
        {
            MesUserCases.Users.User_Add add = new User_Add();
            add.ShowDialog();
        }

        private void bt_add_role_Click(object sender, EventArgs e)
        {
            MesUserCases.Users.Add_role role = new Add_role();
            role.ShowDialog();
        }
    }
}
