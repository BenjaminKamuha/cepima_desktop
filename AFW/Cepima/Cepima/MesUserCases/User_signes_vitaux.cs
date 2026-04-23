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
namespace Cepima.MesUserCases
{
    public partial class User_signes_vitaux : UserControl
    {
        public User_signes_vitaux()
        {
            InitializeComponent();
            MesClasses.ReceptionManager.MoveLabel(label1,panel1,2);
            LoadPatient();
        }
        //cgarger les client dans le flowLayoutPanel
        private void LoadPatient(params string[] args)
        {
            fl_patient.Controls.Clear();

                try
                {
                    string query = "SELECT id_patient, nom, post_nom FROM patients ORDER BY id_patient DESC";

                    MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, null, true);

                    while (reader.Read())
                    {
                        AjouterPanel(
                            reader["id_patient"].ToString(),
                            reader["nom"].ToString(),
                            reader["post_nom"].ToString()
                        );
                    }

                    reader.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur patient " + ex.Message);
                }
        }
        private void AjouterPanel(string id, string nom, string postNom)
        {
            Panel panelPatient = new Panel
            {
                Size = new Size(180, 60),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
            };

            PictureBox picture = new PictureBox
            {
                Location = new Point(10, 5),
                Size = new Size(35, 35),
                Image = Properties.Resources.round_user,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            panelPatient.Controls.Add(picture);

            Label labelNom = new Label
            {
                Text = nom + " " + postNom,
                Location = new Point(50, 20),
                AutoSize = true,
                Font = new Font("Consolas", 8, FontStyle.Bold)
            };

            panelPatient.Controls.Add(labelNom);

            CheckBox chk = new CheckBox
            {
                Tag = id,
                AutoSize = true,
                Location = new Point(160, 40)
            };

            chk.CheckedChanged += chkClient_CheckedChanged;

            panelPatient.Controls.Add(chk);

            fl_patient.Controls.Add(panelPatient);
        }

        int idPatient;
        void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                foreach (Panel p in fl_patient.Controls.OfType<Panel>())
                {
                    foreach (CheckBox c in p.Controls.OfType<CheckBox>())
                    {
                        if (c != chk)
                        {
                            c.Checked = false;
                        }
                    }
                }

                idPatient = Convert.ToInt32(chk.Tag);
            }
            else
            {
                idPatient = 0;
            }
        }
        private void bt_save_signes_Click(object sender, EventArgs e)
        {
            if (VerifierChampsSignesVitaux() == true)
            {
                //récuperation des différentes données
                decimal temperature = Convert.ToDecimal(tb_temperature.Text);
                string tensionArterielle = tb_tension.Text;
                int frequence_cardiaque = Convert.ToInt32(tb_frequence.Text);
                decimal poids = Convert.ToDecimal(tb_poids.Text);
                decimal taille = Convert.ToDecimal(tb_taille.Text);
                MesClasses.ReceptionManager.SaveSigneVitaux(idPatient.ToString(), temperature, tensionArterielle, frequence_cardiaque, poids, taille);
            }
            else
            {
                return;
            }
        }

        private bool VerifierChampsSignesVitaux()
        {

            // tb_temperature
            if (tb_temperature.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_temperature, "Ce champ est obligatoire");
                tb_temperature.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_temperature, "");
            }

            // tb_tension
            if (tb_tension.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_tension, "Ce champ est obligatoire");
                tb_tension.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_tension, "");
            }

            //  tb_fréquence
            if (tb_frequence.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_frequence, "Ce champ est obligatoire");
                tb_frequence.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_frequence, "");
            }

            //  tb_ poids
            if (tb_poids.Text.Trim() == "")
            {
                User_patient.erreur.SetError(tb_poids, "Ce champ est obligatoire");
                tb_poids.Focus();
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_poids, "");
            }

            // tb_ taille
            if (tb_taille.Text.Trim() == string.Empty)
            {
                User_patient.erreur.SetError(tb_taille, "Ce champs est obligatoire");
                return false;
            }
            else
            {
                User_patient.erreur.SetError(tb_taille, "");
            }
            return true;
        }

    }
}
