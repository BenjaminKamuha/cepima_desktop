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

namespace Cepima.MesUserCases.Hospitalisation
{
    public partial class User_chambre : UserControl
    {
        public User_chambre()
        {
            InitializeComponent();
            LoadChambres();
            rb_tous.Checked = true;
        }

        private void LoadChambres(string recherche = "", string statut = "")
        {
            flow_chambres.Controls.Clear();

            try
            {
                string query = "SELECT id_chambre,numero_chambre,nombre_lit,tarif_journalier,statut FROM chambre WHERE 1 = 1";

                MesClasses.ManagerClasse.request_params.Clear();
                // =====================================================
                // RECHERCHE
                // =====================================================

                if (!string.IsNullOrWhiteSpace(recherche))
                {
                    query += " AND numero_chambre LIKE @recherche";

                    MesClasses.ManagerClasse.request_params.Add("@recherche","%" + recherche + "%");
                }
 
                // =====================================================
                // FILTRE STATUT
                // =====================================================

                if (!string.IsNullOrWhiteSpace(statut))
                {
                    if (statut == "Disponible")
                    {
                        query += " AND statut = 'Disponible'";
                    }
                    else if (statut == "Occupée")
                    {
                        query += " AND statut = 'Occupée'";
                    }
                    else if (statut == "Suspendue")
                    {
                        query += " AND statut IN ('Maintenance', 'Hos service')";
                    }
                }

                query += " ORDER BY numero_chambre ASC";

                using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params,true))
                {
                    int i = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string idChambre = reader["id_chambre"].ToString();

                            string numero = reader["numero_chambre"].ToString();

                            string nombre = reader["nombre_lit"].ToString();

                            string tarif = Convert.ToDecimal(reader["tarif_journalier"]).ToString("N0");

                            string statutChambre = reader["statut"].ToString();

                            //création des cartes 
                            CreerCarteChambre(
                                idChambre,
                                numero,
                                nombre,
                                tarif,
                                statutChambre
                            );

                            i++;
                        }

                        lb_nombres_chambres.Text = i + " chambre(s)";
                    }
                    else
                    {
                        lb_not_found.Text = "Aucune chambre trouvée";
                        flow_chambres.Controls.Add(lb_not_found);
                        lb_not_found.Visible = true;
                        lb_nombres_chambres.Text = "0 chambre";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private void CreerCarteChambre(string idChambre,string numero,string type,string tarif,string statut)
        {
            BunifuRoundedPanel panChambre = new BunifuRoundedPanel();
            panChambre.Size = new Size(290, 130);
            panChambre.Margin = new Padding(10, 10, 20, 10);
            panChambre.BorderRadius = 8;
            panChambre.BorderColor = Color.Silver;
            panChambre.BorderSize = 1;
            panChambre.ShadowColor = Color.Gray;
            panChambre.ShadowDepth = 10;
            panChambre.Tag = idChambre;


            panChambre.Click += (s, e) =>
                {
                    MesForms.Hospitalisation.Detail_Chambre add = new MesForms.Hospitalisation.Detail_Chambre(idChambre);
                    add.ShowDialog();
                };
            PictureBox picture = MesClasses.ManagerClasse.AddPicture(
                Properties.Resources.icone_chambre,
                new Point(15, 15),
                new Size(60, 60)
            );

            panChambre.Controls.Add(picture);

            Label lbNumero = MesClasses.ManagerClasse.CustomLabel(
                "Chambre N° " + numero,
                new Point(90, 15)
            );

            lbNumero.AutoSize = true;
            lbNumero.Font = new Font(
                "Calibri",
                11,
                FontStyle.Bold
            );

            panChambre.Controls.Add(lbNumero);


            Label lbType = MesClasses.ManagerClasse.CustomLabel("Lit(s) : "+type,new Point(90, 40));

            lbType.AutoSize = true;

            lbType.Font = new Font(
                "Calibri",
                10,
                FontStyle.Regular
            );

            panChambre.Controls.Add(lbType);


            Label lbTarif = MesClasses.ManagerClasse.CustomLabel(
                "Tarif : " + tarif + "$/Jours",
                new Point(90, 65)
            );

            lbTarif.AutoSize = true;

            lbTarif.Font = new Font(
                "Calibri",
                10,
                FontStyle.Regular
            );

            panChambre.Controls.Add(lbTarif);


            Label lbStatut = MesClasses.ManagerClasse.CustomLabel(
                "Statut :",
                new Point(15, 95)
            );

            lbStatut.AutoSize = true;

            lbStatut.Font = new Font(
                "Calibri",
                10,
                FontStyle.Bold
            );

            panChambre.Controls.Add(lbStatut);


            Label lbValeurStatut = MesClasses.ManagerClasse.CustomLabel(
                statut,
                new Point(75, 95)
            );

            lbValeurStatut.AutoSize = true;

            lbValeurStatut.Font = new Font("Calibri",10,FontStyle.Bold
            );


            if (statut == "Disponible")
            {
                lbValeurStatut.ForeColor = Color.FromArgb(0,180,80);
            }
            else if (statut == "Occupée")
            {
                lbValeurStatut.ForeColor = Color.Red;
            }
            else if (statut == "Reservée")
            {
                lbValeurStatut.ForeColor = Color.Orange;
            }
            else
            {
                lbValeurStatut.ForeColor = Color.Gray;
            }

            panChambre.Controls.Add(lbValeurStatut);

            flow_chambres.Controls.Add(panChambre);
        }

        private void rb_tous_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tous.Checked)
            {
                LoadChambres(
                    tb_recherche_chambre.Text,
                    ""
                );
            }
        }

        private void rb_occupe_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_occupe.Checked)
            {
                LoadChambres(
                    tb_recherche_chambre.Text,
                    "Occupée"
                );
            }
        }

        private void rb_libre_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_libre.Checked)
            {
                LoadChambres(
                    tb_recherche_chambre.Text,
                    "Disponible"
                );
            }
        }

        private void rb_suspendu_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_suspendu.Checked)
            {
                LoadChambres(
                    tb_recherche_chambre.Text,
                    "Suspendue"
                );
            }
        }

        private void tb_recherche_chambre_TextChanged(object sender, EventArgs e)
        {
            string statut = "";

            if (rb_occupe.Checked)
            {
                statut = "Occupée";
            }
            else if (rb_libre.Checked)
            {
                statut = "Disponible";
            }
            else if (rb_suspendu.Checked)
            {
                statut = "Suspendue";
            }

            LoadChambres(
                tb_recherche_chambre.Text,
                statut
            );
        }

        private void bt_add_chambre_Click(object sender, EventArgs e)
        {
            MesForms.Hospitalisation.Add_chambre chambre = new MesForms.Hospitalisation.Add_chambre();
            chambre.ShowDialog();
        }
    }
}
