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
using Cepima.MesUserCases;
using Cepima.MesForms.Pharmacie;

namespace Cepima.MesForms
{
    public partial class Form_detail_produit : Form

    {
        Database db = new Database();
        int PROD_ID = UC_stock_pharmacie.PROD_ID;

        public static ModernListItem ITEM_PRODUCT;
        public static Button BT_REFRESH;

        public Form_detail_produit()
        {
            InitializeComponent();
            ITEM_PRODUCT = item_medoc;
            BT_REFRESH = btn_refresh;
        }

        public static void managerColor(Panel panel)
        {
            Color color = ITEM_PRODUCT.IndicatorColor;

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is RoundedButton)
                {
                    RoundedButton button = ctrl as RoundedButton;

                    if (button != null)
                    {
                        button.DefaultBackColor = color;
                    }
                }
                else if (ctrl is BunifuRoundedPanel)
                {
                    BunifuRoundedPanel b_pnl = ctrl as BunifuRoundedPanel;

                    if (b_pnl != null)
                    {
                        b_pnl.BackColor = color;
                        b_pnl.ForeColor = Color.White;
                    }
                }
                else if (ctrl is CustomRoundedPanel)
                {
                    CustomRoundedPanel c_pnl = ctrl as CustomRoundedPanel;

                    if (c_pnl != null)
                    {
                        c_pnl.BackColor = color;
                        c_pnl.ForeColor = Color.White;
                    }
                }
            }
        }

        private void loadProd()
        {
            try
            {
                using (MySqlConnection con = db.GetConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT
                            m.id,
                            m.nom,
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
                                item_medoc.Title = reader["nom"].ToString();
                                item_medoc.Subtitle = reader["categorie"].ToString() + " • " + reader["unite_gestion"].ToString();

                                item_medoc.IndicatorColor = UC_stock_pharmacie.ConvertirCouleur(reader["couleur"].ToString());

                                item_medoc.Click += item_product_Click;
                            }
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Erreur de chargement produit " + ex.Message); 
            }

        }

        void item_product_Click(object sender, EventArgs e)
        {
            main_pan.Controls.Clear();
            MesUserCases.Pharmacie.UC_detail_produit uc = new MesUserCases.Pharmacie.UC_detail_produit();
            uc.Dock = DockStyle.Fill;
            main_pan.Controls.Add(uc);

            
        }

        private void Form_detail_produit_Load(object sender, EventArgs e)
        {

            loadProd();
            managerColor(pnl_header);
            main_pan.Controls.Clear();

            // Dashboard produit
            MesUserCases.Pharmacie.UC_detail_produit uc = new MesUserCases.Pharmacie.UC_detail_produit();
            uc.Dock = DockStyle.Fill;
            main_pan.Controls.Add(uc);
        }

        private void btn_stock_plus_Click(object sender, EventArgs e)
        {
            Form_reception_stock frm_reception = new Form_reception_stock();
            frm_reception.ShowDialog();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            main_pan.Controls.Clear();
            MesUserCases.Pharmacie.UC_detail_produit uc = new MesUserCases.Pharmacie.UC_detail_produit();
            uc.Dock = DockStyle.Fill;
            main_pan.Controls.Add(uc);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Le médicament va être supprimé.",
                   "Suppression",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Suppression d'un produit
                string query = "UPDATE medicament SET actif = 0 WHERE id = @id_med";
                try
                {
                    using (MySqlConnection con = db.GetConnection())
                    {
                        con.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id_med", PROD_ID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Produit supprimé avec succès!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de suppression du produit" + ex.Message);
                }
            }

           
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Form_add_medoc frm_medoc = new Form_add_medoc();
            frm_medoc.ShowDialog();
        }

    }
}
