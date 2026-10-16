using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cepima.Data;
using Cepima.MesClasses;
using Cepima.MesUserCases;
using MySql.Data.MySqlClient;


namespace Cepima.MesForms.Prescription
{
    public partial class Form_add_ligne : Form
    {
        private int PROD_ID;
        private int ID_PATIENT;
        private List<PrescriptionLigneData> LIGNES;

        public Form_add_ligne(int prod_id, int id_patient, List<PrescriptionLigneData> lignes)
        {
            InitializeComponent();
            PROD_ID = prod_id;
            ID_PATIENT = id_patient;
            LIGNES = lignes;

            loadProd();
        }

        private void loadProd()
        {
            Database db = new Database();
            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
                            m.dosage,
                            m.unite_gestion,
                            c.nom AS categorie,
                            c.couleur
                        FROM medicament m
                        INNER JOIN medicament_categorie c
                            ON m.categorie_id = c.id
                        WHERE m.id=@med_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@med_id", PROD_ID);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tb_dosage.Text = reader["dosage"].ToString();

                                item_medoc.Title = reader["nom"].ToString();
                                item_medoc.Subtitle = reader["categorie"].ToString() + " • " + reader["unite_gestion"].ToString();
                                bt_save_medoc.BackColor = UC_stock_pharmacie.ConvertirCouleur(reader["couleur"].ToString());
                                item_medoc.IndicatorColor = UC_stock_pharmacie.ConvertirCouleur(reader["couleur"].ToString());


                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement produit " + ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bt_save_medoc_Click(object sender, EventArgs e)
        {
            try
            {
                LIGNES.Add(new PrescriptionLigneData
                {
                    MedicamentId = PROD_ID,
                    Dose = tb_dosage.Text,
                    Frequence = tb_frequence.Text,
                    Duree = tb_duree.Text,
                    Quantite = Convert.ToInt32(upd_quantite.Value)

                });

                this.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show(
                "Erreur lors de l'enregistrement :\n\n" +
                ex.Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
             }
        }
    }
}
