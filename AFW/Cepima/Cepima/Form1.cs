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
using Cepima.MesUserCases;
using Cepima.MesForms;
using Cepima.Data;
using Cepima.Services;




namespace Cepima
{
    public partial class Form1 : Form
    {
        public static Int32 PATIENT_ID { get; set; }
        public static Int32 DEMANDE_ID { get; set; }
        public static Panel GlobalPanel_main { get; set; }
        public static ToolTip info = new ToolTip();
        private Button currentSubMenu = null;
     

        public Form1()
        {
            InitializeComponent();
            GlobalPanel_main = panel_center_main;
            //LoadDataGrid();
            InfoBull();
            LoadUserConnect(lb_username,"Connecté",lb_statut);
            PATIENT_ID = 0;
            DEMANDE_ID = 0;


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
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

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
            currentSubMenu.BackColor = Color.FromArgb(180, 220,235); // gris (effet focus) 80,80,80
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

            panel_center_main.Controls.Clear();
            UC_logo_cepima uc_lg = new UC_logo_cepima();
            uc_lg.Dock = DockStyle.Fill;
            panel_center_main.Controls.Add(uc_lg);

           
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

            // Affichage du dashboard reception
            MesUserCases.User_Dash_patient patient = new MesUserCases.User_Dash_patient();
            patient.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(patient);

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.Home,(s,ev) =>  
                {
                    MesUserCases.User_Dash_patient dash = new MesUserCases.User_Dash_patient();
                    dash.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(dash);
                }),

                new MenuItem("    Patients",Properties.Resources.nurse_call_30px,(s,ev) =>
                {
                    //instructions
                    MesUserCases.User_display_patients display = new MesUserCases.User_display_patients();
                    display.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(display);
                }),

                new MenuItem("    Nouveau",Properties.Resources.add_user_male_30px,(s,ev) =>
                {
                    //instructions
                    MesForms.Form_add_patient add = new MesForms.Form_add_patient();
                    add.ShowDialog();
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


            // Affichage du dashboard
            MesUserCases.User_DashBord_pharmacie dashbord_ph1 = new MesUserCases.User_DashBord_pharmacie();
            dashbord_ph1.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(dashbord_ph1);

            var items = new List<MenuItem>()
            {

                new MenuItem("    Acceuil",Properties.Resources.home_30px,(s,ev) =>
                {
                    MesUserCases.User_DashBord_pharmacie dashbord_ph = new MesUserCases.User_DashBord_pharmacie();
                    dashbord_ph.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(dashbord_ph);
                }),
              
                new MenuItem("    Stock",Properties.Resources.capsule_30px,(s,ev) => {

                    MesUserCases.UC_stock_pharmacie user_med = new MesUserCases.UC_stock_pharmacie();
                    panel_center_main.Controls.Clear();
                    user_med.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Add(user_med);
                
                }),
                new MenuItem("    Invetaire",Properties.Resources.adjust_30px,(s,ev) => {

                    MesUserCases.Pharmacie.UC_inventory uc_inventory = new MesUserCases.Pharmacie.UC_inventory();
                    panel_center_main.Controls.Clear();
                    uc_inventory.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Add(uc_inventory);

                }),
            
                new MenuItem("    Prescriptions",Properties.Resources.hand_with_a_pill_30px,(s,ev) => {

                    MesUserCases.Pharmacie.UC_prescription prescription = new MesUserCases.Pharmacie.UC_prescription();
                    panel_center_main.Controls.Clear();
                    prescription.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Add(prescription);

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

            //affichage du dashboard pour eeg
            MesUserCases.EEG.User_DashBoard dash = new MesUserCases.EEG.User_DashBoard();
            dash.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(dash);

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.Home,(s,ev) =>
                {
                    MesUserCases.EEG.User_DashBoard dash_ = new MesUserCases.EEG.User_DashBoard();
                    dash_.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(dash_);
                }),
                new MenuItem("    Examens",Properties.Resources.finish_flag_30px, (s,ev) =>
                {
                    MesUserCases.EEG.User_examens finish = new MesUserCases.EEG.User_examens();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
                }),

                new MenuItem("    Caisse",Properties.Resources.add_dollar_30px, (s,ev) =>
                {
                    MesUserCases.EEG.User_caisse finish = new MesUserCases.EEG.User_caisse();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
                }),

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
                    new MenuItem("    Acceuil",Properties.Resources.home_20px,(s,ev) =>
                    {
                        
                    }),

                    new MenuItem("  Facturation",Properties.Resources.facture,(s,ev) =>
                    {
                        MesUserCases.User_facture_all facturation = new MesUserCases.User_facture_all();
                        facturation.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(facturation);
                    }),

                    new MenuItem("  Paiements",Properties.Resources.cost_25px, (s,ev) =>
                    {
                        MesUserCases.User_paiement_facture paiement = new MesUserCases.User_paiement_facture();
                        paiement.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(paiement);
                    }),

                     new MenuItem(" Caisse du jour",Properties.Resources.wallet_25px, (s,ev) =>
                    {
                        MesUserCases.User_livre_caisse caisse = new MesUserCases.User_livre_caisse();
                        caisse.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(caisse);
                    }),

                    new MenuItem("  Bon de sortie",Properties.Resources.export_20px, (s,ev) =>
                    {
                        
                    }),
                     new MenuItem(" Rapport financier",Properties.Resources.analytics_25px, (s,ev) =>
                    {

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
                new MenuItem("   Sécurité",Properties.Resources.lock_20px, (s, ev) => {}),
                new MenuItem("   Services",Properties.Resources.gift_30px, (s, ev) => {
                    MesUserCases.Services.User_services uc_service = new MesUserCases.Services.User_services();
                    panel_center_main.Controls.Clear();
                    uc_service.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Add(uc_service);
                })
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            bt_acceuil.PerformClick();

            UpdateManager manager = new UpdateManager();
            lb_version.Text = manager.GetCurrentVersion();
        }

        private void bt_hospitalisation_Click(object sender, EventArgs e)
        {
             picture_image_menu.Image = Properties.Resources.reception_90px;
            lb_sous_menu.Text = "Hospitalisation";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            //Acceuil 
            MesUserCases.Hospitalisation.User_DashBoard_Hospi hospi = new MesUserCases.Hospitalisation.User_DashBoard_Hospi();
            hospi.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(hospi);

            var items = new List<MenuItem>()
            {
                new MenuItem("    Acceuil",Properties.Resources.Home,(s,ev) =>  
                {
                    //instructions
                   MesUserCases.Hospitalisation.User_DashBoard_Hospi h = new MesUserCases.Hospitalisation.User_DashBoard_Hospi();
                   h.Dock = DockStyle.Fill;
                   panel_center_main.Controls.Clear();
                   panel_center_main.Controls.Add(h);
                }),

                new MenuItem("    Demandés",Properties.Resources.finish_flag_30px,(s,ev) =>  
                {
                    //instructions
                    MesUserCases.Hospitalisation.User_Termine_hospi finish = new MesUserCases.Hospitalisation.User_Termine_hospi();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
                }),

                new MenuItem("    Chambres",Properties.Resources.chambre,(s,ev) =>  
                {
                    //instructions
                    MesUserCases.Hospitalisation.User_chambre finish = new MesUserCases.Hospitalisation.User_chambre();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
                }),

                 new MenuItem("    Hospitalisés",Properties.Resources.bed_black,(s,ev) =>  
                {
                    //instructions
                    MesUserCases.Hospitalisation.User_patient_hospitalise finish = new MesUserCases.Hospitalisation.User_patient_hospitalise();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
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

            MesUserCases.User_DashBoard_consultation dash = new MesUserCases.User_DashBoard_consultation();
            dash.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(dash);

            var items = new List<MenuItem>()
            {
                new MenuItem("      Acceuil",Properties.Resources.Home,(s,ev) =>  
                {
                    //instructions
                   MesUserCases.User_DashBoard_consultation dash_ = new MesUserCases.User_DashBoard_consultation();
                    dash_.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(dash_);
                }),

                     new MenuItem("     Terminées",Properties.Resources.finish_flag_30px,(s,ev) =>  
                {
                    MesUserCases.User_finish_consultation finish = new MesUserCases.User_finish_consultation();
                    finish.Dock = DockStyle.Fill;
                    panel_center_main.Controls.Clear();
                    panel_center_main.Controls.Add(finish);
                }),
                  
            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }

        private void panel_center_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadUserConnect(Label lbl1,string message,Label lbl2)
        {
            lbl1.Text = MesForms.SessionUtilisateur.Nom;
            if (MesForms.SessionUtilisateur.EstConnecte)
            {
                lbl2.Text = message;
            }
        }

        private void bt_presc_Click(object sender, EventArgs e)
        {

        }


        private void bt_personnel_Click(object sender, EventArgs e)
        {
            picture_image_menu.Image = Properties.Resources.staff_90px;
            lb_sous_menu.Text = "Personnels";
            lb_sous_menu.Visible = true;
            panel11.Visible = true;

            MesUserCases.Personnels.User_DashBord_Personnel acceuil_rh = new MesUserCases.Personnels.User_DashBord_Personnel();
            acceuil_rh.Dock = DockStyle.Fill;
            panel_center_main.Controls.Clear();
            panel_center_main.Controls.Add(acceuil_rh);

            var items = new List<MenuItem>()
            {
                new MenuItem("      Acceuil",Properties.Resources.Home,(s,ev) =>
                    {
                        //control acceuil du personnel
                        MesUserCases.Personnels.User_DashBord_Personnel acceuil = new MesUserCases.Personnels.User_DashBord_Personnel();
                        acceuil.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(acceuil);
                    }),

                new MenuItem("      Personnel",Properties.Resources.users_30px,(s,ev) =>
                    {
                        //control autre
                        MesUserCases.User_personnels_display personnel = new MesUserCases.User_personnels_display();
                        personnel.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(personnel);
                    }),

                     //Troisième sous menu
                     new MenuItem("     Présences",Properties.Resources.attendance_30px,(s,ev) =>
                    {
                        MesUserCases.Personnels.User_Presence presence = new MesUserCases.Personnels.User_Presence();
                        presence.Dock = DockStyle.Fill;
                        panel_center_main.Controls.Clear();
                        panel_center_main.Controls.Add(presence);
                    }),

            };
            Create_sous_menu(items);
            Button bt = sender as Button;
            MesClasses.ManagerClasse.focused_child(panel8, bt, Color.FromArgb(7, 51, 131), Color.FromArgb(44, 123, 229));
        }


        private async void btn_update_Click(object sender, EventArgs e)
        {
            UpdateManager manager = new UpdateManager();
            await manager.CheckForUpdateAsync();
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
