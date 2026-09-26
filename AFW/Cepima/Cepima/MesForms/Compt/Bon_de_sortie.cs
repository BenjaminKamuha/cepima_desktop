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

namespace Cepima.MesForms.Compt
{
    public partial class Bon_de_sortie : Form
    {
        public Bon_de_sortie()
        {
            InitializeComponent();
        }

        private void bt_add_bon_Click(object sender, EventArgs e)
        {
            EnregistrerBonSortie();
            tb_donneur.Text = "";
            tb_montant.Text = "";
            tb_responsable.Text = "";
        }

        private void EnregistrerBonSortie()
        {
            if (string.IsNullOrWhiteSpace(tb_responsable.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom du responsable.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_responsable.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_donneur.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom de la personne qui donne l'argent.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_donneur.Focus();
                return;
            }

            decimal montant;

            if (!decimal.TryParse(tb_montant.Text.Trim(), out montant) || montant <= 0)
            {
                MessageBox.Show(
                    "Veuillez saisir un montant valide.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tb_montant.Focus();
                return;
            }

            try
            {
                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {

                    string sql = @"
                INSERT INTO bon_sortie
                (nom_resp, montant, date, signature_donneur)
                VALUES
                (@nom_resp, @montant, @date, @signature_donneur)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@nom_resp", tb_responsable.Text.Trim());
                        cmd.Parameters.AddWithValue("@montant", montant);
                        cmd.Parameters.AddWithValue("@date", dt_date.Value);
                        cmd.Parameters.AddWithValue("@signature_donneur", tb_donneur.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Le bon de sortie a été enregistré avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
                MesUserCases.Comptabilité.Bon_de_sortie.btRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du bon de sortie :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
