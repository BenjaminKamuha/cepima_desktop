using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Cepima.MesUserCases
{
    public partial class UC_add_medoc : UserControl
    {
        public UC_add_medoc()
        {
            InitializeComponent();
        }



        private void bt_add_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg;*.png;*.webp)|*.jpg;*png;*.webp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (picture_image.Image != null)
                    {
                        picture_image.Image.Dispose();
                        picture_image.Image = null;
                    }

                    byte[] imgBytes = File.ReadAllBytes(ofd.FileName);
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        picture_image.Image = Image.FromStream(ms);
                    }
                    picture_image.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void bt_save_medoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (picture_image.Image == null)
                {
                    MessageBox.Show("Charger une image"); return;
                }
                byte[] photo = null;
                //convertion image en byte
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(picture_image.Image))
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    photo = ms.ToArray();
                }

                // Unité de mésure
                string unity = "";
                string id_medicament = "";

                foreach (RadioButton rd in panel_unity.Controls)
                {
                    if (rd.Checked)
                    {
                        unity = rd.Text;
                    }
                }

                using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
                {
                    string query = "INSERT INTO medicament(nom_medicament, photo, categorie, prix_achat, prix_vente)VALUES(@nom, @photo, @cat, @achat,@vente)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nom", tb_medoc.Text);
                        cmd.Parameters.AddWithValue("@photo", photo);
                        cmd.Parameters.AddWithValue("@cat", tb_categorie.Text);
                        cmd.Parameters.AddWithValue("@achat", decimal.Parse(tb_prix_achat.Text));
                        cmd.Parameters.AddWithValue("@vente", decimal.Parse(tb_prix_vente.Text));
                        cmd.ExecuteNonQuery();

                        // Récuperataion de l'id du médicament
                        id_medicament = cmd.LastInsertedId.ToString();
                    }

                    string query_stock = "INSERT INTO stock_pharmacie(id_centre, id_medicament, quantite, unite, stock_minimum) VALUES(@id_centre, @id_medicament, @quantite, @unite, @stock_minimum)";

                    using (MySqlCommand cmd = new MySqlCommand(query_stock, con))
                    {
                        cmd.Parameters.AddWithValue("id_centre", MesForms.SessionUtilisateur.idCentre);
                        cmd.Parameters.AddWithValue("id_medicament", id_medicament);
                        cmd.Parameters.AddWithValue("quantite", num_qty.Value);
                        cmd.Parameters.AddWithValue("unite", unity);
                        cmd.Parameters.AddWithValue("stock_minimum", num_stock_min.Value);

                        // Execution de la requêtte
                        cmd.ExecuteNonQuery();
                    }



                }
                MessageBox.Show("Médicament enregistré !!");
                tb_medoc.Clear();
                tb_categorie.Clear();
                tb_prix_vente.Clear();
                tb_prix_achat.Clear();
                picture_image.Image.Dispose();
                picture_image.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void UC_add_medoc_Load(object sender, EventArgs e)
        {

        }

        private void customRoundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rd_plaquettte_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
