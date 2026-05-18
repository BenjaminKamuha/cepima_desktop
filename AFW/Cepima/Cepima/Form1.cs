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
using Cepima.MesClasses;

namespace Cepima
{
    public partial class Form1 : Form
    {
        public static Panel GlobalPanel_main { get; set; }
        public static ToolTip info = new ToolTip();
        private Button currentSubMenu = null;
        public Form1()
        {
            InitializeComponent();
            GlobalPanel_main = panel_center_main;
            bt_personnel.Click += bt_personnel_Click;
            LoadDataGrid();
            InfoBull();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
         // =========================== ajout des infoBull sur les menus principaux =================================
        private void InfoBull()
        {
            //bouton acceuil
            info.SetToolTip(bt_acceuil, "Acceuil");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            //
            info.SetToolTip(bt_comptability, "Comptabilité");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_personnel, "Personnel");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_EEG, "EEG");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_hospitalisation, "Hospitalisation");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_pharmacie, "Pharmacie");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_setting, "Paramètres");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_soin, "Soins médicaux");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;

            info.SetToolTip(bt_reception, "Reception");
            info.IsBalloon = false;
            info.AutoPopDelay = 2000;
        }

        private ModernDataGridView grid;

        private void LoadDataGrid()
        {
            // =========================
            // 1. Création du grid
            // =========================
            grid = new ModernDataGridView();
            grid.Dock = DockStyle.Fill;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;



            panel_center_main.Controls.Add(grid);

            // =========================
            // 2. Colonnes
            // =========================

            // Nom médicament
            grid.Columns.Add(
                "Medicament",
                "Médicament");

            // Stock (ProgressBar)
            var stockCol =
                new DataGridViewProgressBarColumn();

            stockCol.HeaderText = "Stock (%)";
            grid.Columns.Add(stockCol);


            // Service (ComboBox)
            var serviceCol =
                new DataGridViewComboBoxColumn();

            serviceCol.HeaderText = "Service";

            serviceCol.Items.Add("Ambulatoire");
            serviceCol.Items.Add("Hospitalisation");

            grid.Columns.Add(serviceCol);

            // Image (Photo)
            var imgCol =
                new DataGridViewImageColumn();

            imgCol.HeaderText = "Photo";
            imgCol.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            grid.Columns.Add(imgCol);

            // =========================
            // 3. Ajouter des données
            // =========================

            AddRow("Paracétamol", 80, true,
                "Ambulatoire",
                Properties.Resources.add_file_20px);

            AddRow("Diazépam", 35, true,
                "Hospitalisation",
                Properties.Resources.add_file_20px);

            AddRow("Morphine", 10, false,
                "Hospitalisation",
                Properties.Resources.add_file_20px);
        }

        // =========================
        // 4. Méthode propre d’ajout
        // =========================
        private void AddRow(
            string medicament,
            int stock,
            bool actif,
            string service,
            Image image)
        {
            int rowIndex = grid.Rows.Add();

            grid.Rows[rowIndex]
                .Cells["Medicament"]
                .Value = medicament;

            grid.Rows[rowIndex]
                .Cells[1].Value = stock;

            grid.Rows[rowIndex]
                .Cells[2].Value = service;

            grid.Rows[rowIndex]
                .Cells[3].Value = image;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_minus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void SetActiveSubMenu(Button btn)
        {
            // Reset ancien bouton
            if (currentSubMenu != null)
            {
                currentSubMenu.BackColor = Color.Transparent; // ou ta couleur normale
                currentSubMenu.ForeColor = Color.Black; // texte normal
            }

            // Appliquer nouveau style
            currentSubMenu = btn;
            currentSubMenu.BackColor = Color.FromArgb(80, 80, 80); // gris (effet focus)
            currentSubMenu.ForeColor = Color.White;
        }
        //méthode pour creer un sous menu
        private void Create_sous_menu(List<MenuItem> items)
        {
            panel_sous_menu.Controls.Clear();
            int top = 5;

            foreach (var item in items)
            {
                Button bt = new Button();
                bt.Text = item.Texte;
                bt.Size = new Size(140,40);

                //style du bouton
                bt.FlatStyle = FlatStyle.Flat;
                bt.FlatAppearance.BorderSize = 0;
                bt.Font = new Font("Calibri", 9, FontStyle.Bold);
                bt.BackColor = Color.FromArgb(245,246,242);
                bt.ForeColor = Color.Black;

                if (item.Image != null)
                {
                    bt.Image = item.Image;
                    bt.ImageAlign = ContentAlignment.MiddleLeft;
                    bt.TextImageRelation = TextImageRelation.ImageBeforeText;
                }

                //Event
                bt.Click += (s, ev) =>
                {
                    SetActiveSubMenu(bt); // focus visuel
                    item.ClickEvent.Invoke(s, ev);
                };

                MesClasses.ManagerClasse.AddControl(panel_sous_menu,bt,2,top);

                //top += 5;
                ProgressiveDisplay pd = new ProgressiveDisplay(panel_sous_menu,100);
                pd.Start();
            }
        }

        // info bul
        
        private void bt_acceuil_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.homework_90px;
            lb_sous_menu.Text = "DashBoard";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("    Infos Centres",Properties.Resources.location_20px,(s,ev) => 
                {
                    //instructions

                })
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_reception_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.reception_90px;
            lb_sous_menu.Text = "Reception";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;
            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>  
                {
                    //instructions
                }),
                new MenuItem("    Patients",Properties.Resources.being_sick_20px,(s,ev) =>
                {
                    //instructions
                    MesUserCases.User_display_patients display = new MesUserCases.User_display_patients();
                    display.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(display);
                }),
                new MenuItem("    Ajouter patient",Properties.Resources.add_user_male_20px,(s,ev) =>
                {
                    //instructions
                    MesUserCases.User_patient patient = new MesUserCases.User_patient();
                    patient.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(patient);
                }),
                new MenuItem("    Signes vitaux",Properties.Resources.heart_monitor_20px,(s,ev) => 
                {
                    //instructions
                    MesUserCases.User_signes_vitaux signes = new MesUserCases.User_signes_vitaux();
                    signes.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(signes);
                }),
                new MenuItem("    Affectation",Properties.Resources.send_hot_list_20px,(s,ev) =>
                {
                    //Instructions
                    MesUserCases.User_affectation affectation = new MesUserCases.User_affectation();
                    affectation.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(affectation);
                }),
                 new MenuItem("    Services",Properties.Resources.unit_20px,(s,ev) =>
                {
                    //Instructions
                    MesUserCases.User_service service = new MesUserCases.User_service();
                    service.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(service);
                }),
                 new MenuItem("    Chambres",Properties.Resources.waiting_room_20px,(s,ev) =>
                {
                    //Instructions
                    MesUserCases.User_chambres chambre = new MesUserCases.User_chambres();
                    chambre.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(chambre);
                }),
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7,51,131), Color.FromArgb(44, 123, 229));
        }
        private void bt_pharmacie_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.doctors_bag_90px;
            lb_sous_menu.Text = "Pharmacie";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {

                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>
                {
                    MesUserCases.User_DashBord_pharmacie dashbord_ph = new MesUserCases.User_DashBord_pharmacie();
                    dashbord_ph.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(dashbord_ph);
                }),
              
                new MenuItem("    Médicaments",Properties.Resources.pill_20px,(s,ev) => {

                    MesUserCases.User_medicament user_med = new MesUserCases.User_medicament();
                    panel_center_main.Controls.Clear();
                    user_med.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Add(user_med);
                
                }),
                new MenuItem("    Entreé stock",Properties.Resources.add_file_20px,(s,ev) => {}),
            
                new MenuItem("    Sortie stock",Properties.Resources.export_20px,(s,ev) => {
                    
                    MesUserCases.User_sortie_pharmacie sortie = new MesUserCases.User_sortie_pharmacie();
                    sortie.Dock = DockStyle.Fill;
                    Form1.GlobalPanel_main.Controls.Clear();
                    Form1.GlobalPanel_main.Controls.Add(sortie);
                }),

            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_EEG_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.brain_90px;
            lb_sous_menu.Text = "Test par EEG";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>
                {

                }),
                new MenuItem("    Examens EEG",Properties.Resources.brain_20px, (s,ev) =>
                {

                })

            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_soin_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.health_checkup_90px;
            lb_sous_menu.Text = "Soins Médicaux";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) => MessageBox.Show("Acceuil")),
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_comptability_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.paycheque_90px;
            lb_sous_menu.Text = "Comptabilité";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) => MessageBox.Show("Acceuil")),
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_personnel_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.staff_90px;
            lb_sous_menu.Text = "Personnels";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>
                    {
                        //control acceuil du personnel
                        MesUserCases.User_Dashboard_RH acceuil_rh = new MesUserCases.User_Dashboard_RH();
                        acceuil_rh.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(acceuil_rh);
                    }),
                new MenuItem("    Liste personnel",Properties.Resources.add_file_20px,(s,ev) =>
                    {
                        //control autre
                        MesUserCases.User_personnels_display personnel = new MesUserCases.User_personnels_display();
                        personnel.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(personnel);
                    }),
               
                new MenuItem("    Horaires",Properties.Resources.planner_20px,(s,ev) =>
                    {
                        //instructions
                        MesUserCases.User_horaires horaire = new MesUserCases.User_horaires();
                        horaire.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(horaire);
                    }),
                new MenuItem("    Salaires",Properties.Resources.us_dollar_20px,(s,ev) =>
                    {
                       //instructions
                        MesUserCases.User_add_salaire salaire = new MesUserCases.User_add_salaire();
                        salaire.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(salaire);
                    }),
                    new MenuItem("    Avance salaire",Properties.Resources.avance_salaire,(s,ev) =>
                    {
                        //instructions
                        MesUserCases.User_avance avance = new MesUserCases.User_avance();
                        avance.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(avance);
                        
                    }),
                new MenuItem("    Primes de risque",Properties.Resources.increase_20px,(s,ev) =>
                    {
                        //instructions
                        MesUserCases.User_prime prime = new MesUserCases.User_prime();
                        prime.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(prime);

                    }),
                new MenuItem("    Retenu",Properties.Resources.decrease_20px,(s,ev) =>
                    {
                       //instructions
                        MesUserCases.User_retenue retenue = new MesUserCases.User_retenue();
                        retenue.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(retenue);
                     
                    }),
                     new MenuItem("    Empreintes",Properties.Resources.fingerprint_20px,(s,ev) =>
                    {
                       //instructions
                    }),

            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
        private void bt_setting_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.settings_90px;
            lb_sous_menu.Text = "Paramètres";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            var items = new List<MenuItem>()
            {
                new MenuItem("   Géneraux",Properties.Resources.maintenance_20px,(s,ev) => {}),
                new MenuItem("   Apparence",Properties.Resources.eye_checked_20px,(s, ev) => {}),
                new MenuItem("   Sécurité",Properties.Resources.lock_20px, (s, ev) => {})
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_hospitalisation_Click(object sender, EventArgs e)
        {
             picture_image_menu.Image = Properties.Resources.reception_90px;
            lb_sous_menu.Text = "Hospitalisation";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;
            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>  
                {
                    //instructions
                   
                }),

                  new MenuItem("    Hospitalisation",Properties.Resources.hospital_bed_25px,(s,ev) =>  
                {
                   
                }),
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }

        private void bt_consultation_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.counselor_100px;
            lb_sous_menu.Text = "Consultation";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;
            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>  
                {
                    //instructions
                   
                }),

                  new MenuItem("    Consultation",Properties.Resources.counselor_25px,(s,ev) =>  
                {
                    MesUserCases.User_consultation consultation = new MesUserCases.User_consultation();
                    consultation.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(consultation);
                }),
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }
    }
    public class MenuItem
    {
        public string Texte { get; set; }
        public Image Image { get; set; }
        public EventHandler ClickEvent { get; set; }

        public MenuItem(string texte,Image image, EventHandler clickEvent)
        {
            Texte = texte;
            Image = image;
            ClickEvent = clickEvent;
        }
    }
}
