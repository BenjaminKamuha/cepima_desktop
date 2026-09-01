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
using Cepima.Data;

namespace Cepima.MesForms
{
    public partial class Form_add_unity : Form
    {
        public Form_add_unity()
        {
            InitializeComponent();
        }

        private void EnregistrerUnite()
        {
            string nom = tb_unity_name.Text.Trim();
            string abreviation = tb_unity_abr.Text.Trim();
            string description = tb_unity_desc.Text.Trim();

            if (string.IsNullOrEmpty(nom))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom de l'unité.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_unity_name.Focus();
                return;
            }

            try
            {
                Database database = new Database();

                using (MySqlConnection connection = database.GetConnection())
                {
                    connection.Open();

                    // Vérifier si l'unité existe déjà
                    string checkQuery = @"
                SELECT COUNT(*)
                FROM unite_gestion
                WHERE nom = @nom";

                    using (MySqlCommand checkCommand =
                           new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@nom", nom);

                        int existe =
                            Convert.ToInt32(
                                checkCommand.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show(
                                "Cette unité existe déjà.",
                                "Doublon",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            tb_unity_name.Focus();
                            return;
                        }
                    }

                    // Enregistrer
                    string query = @"
                INSERT INTO unite_gestion
                (
                    nom,
                    abreviation,
                    description,
                    actif
                )
                VALUES
                (
                    @nom,
                    @abreviation,
                    @description,
                    1
                )";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@nom",
                            nom);

                        command.Parameters.AddWithValue(
                            "@abreviation",
                            string.IsNullOrEmpty(abreviation)
                                ? (object)DBNull.Value
                                : abreviation);

                        command.Parameters.AddWithValue(
                            "@description",
                            string.IsNullOrEmpty(description)
                                ? (object)DBNull.Value
                                : description);

                        command.ExecuteNonQuery();
                    }
                }

                //MessageBox.Show(
                //    "Unité enregistrée avec succès.",
                //    "Enregistrement",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);

                // Vider les champs
                tb_unity_name.Text = "";
                tb_unity_abr.Text = "";
                tb_unity_desc.Text = "";

                tb_unity_name.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_save_unity_Click(object sender, EventArgs e)
        {
            EnregistrerUnite();
            Form_add_medoc.ChargerUnites();
            this.Close();

        }

    }
}
