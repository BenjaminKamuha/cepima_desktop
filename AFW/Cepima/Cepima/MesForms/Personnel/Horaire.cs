//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using MySql.Data.MySqlClient;
//namespace Cepima.MesForms.Personnel
//{
//    public partial class Horaire : Form
//    {
//        private string personnelId;
//        private string  idHoraire;

//        private bool modeModification = false;

//        public Horaire(string id_personnel)
//        {
//            InitializeComponent();
//            this.personnelId = id_personnel;
//            this.modeModification = false;
//        }

//        public Horaire(string id_personnel,string  idHoraire)
//        {
//            InitializeComponent();
//            this.personnelId = id_personnel;
//            this.idHoraire = idHoraire;
//            this.modeModification = true;
//        }


//        private void Horaire_Load(object sender, EventArgs e)
//        {
//            LoadDataAdministratives();

//            cbx_jour.Items.Clear();

//            cbx_jour.Items.Add("Lundi");
//            cbx_jour.Items.Add("Mardi");
//            cbx_jour.Items.Add("Mercredi");
//            cbx_jour.Items.Add("Jeudi");
//            cbx_jour.Items.Add("Vendredi");
//            cbx_jour.Items.Add("Samedi");
//            cbx_jour.Items.Add("Dimanche");

//            cbx_jour.SelectedIndex = 0;
//        }

//        //méthode pour charger les informations administratives du patient
//        private void LoadDataAdministratives()
//        {
//            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
//            {
//                try
//                {
//                    string query = "SELECT  CONCAT(nom,' ',post_nom) AS nom,sexe,date_naissance,fonction FROM personnels WHERE id_personnel = @id";
//                    MesClasses.ManagerClasse.request_params.Clear();
//                    MesClasses.ManagerClasse.request_params.Add("@id", this.personnelId);
//                    using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, MesClasses.ManagerClasse.request_params, true))
//                    {
//                        if (reader.Read())
//                        {
//                            lblPersonnel.Text = reader["nom"].ToString();
//                            DateTime date = Convert.ToDateTime(reader["date_naissance"]);
//                            lbl_fonction.Text = reader["fonction"].ToString();
//                            int annee = MesClasses.ReceptionManager.CalculerAge(date);
//                            lbl_age.Text = annee.ToString() + " ans" + " - " + reader["sexe"];
//                        }
//                        reader.Close();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Erreur : " + ex.Message);
//                }
//            }
//        }

//        private void bt_start_Click(object sender, EventArgs e)
//        {
//            using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
//            {
//                try
//                {
//                    // ============================================
//                    // 1. VÉRIFICATION DU JOUR
//                    // ============================================

//                    if (cbx_jour.SelectedIndex == -1)
//                    {
//                        MessageBox.Show(
//                            "Veuillez sélectionner un jour de travail.",
//                            "Horaire",
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Warning);

//                        return;
//                    }

//                    // ============================================
//                    // 2. RÉCUPÉRER LES VALEURS
//                    // ============================================

//                    string jour = cbx_jour.Text;

//                    TimeSpan heureEntree = dtp_heure_entree.Value.TimeOfDay;

//                    TimeSpan heureSortie = dtp_heure_sortie.Value.TimeOfDay;


//                    // ============================================
//                    // 3. VÉRIFIER LES HEURES
//                    // ============================================

//                    if (heureSortie <= heureEntree)
//                    {
//                        MessageBox.Show(
//                            "L'heure de sortie doit être supérieure à l'heure d'entrée.",
//                            "Horaire incorrect",
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Warning);

//                        return;
//                    }

//                    string query = "INSERT INTO horaire(heure_entree_normal,heure_sortie_normal,jour_travail,id_personnel)VALUES(@heureEntree,@heureSortie,@jourTravail,@idPersonnel)";

//                    using (MySqlCommand cmd = new MySqlCommand(query, con))
//                    {
//                        cmd.Parameters.AddWithValue("@heureEntree", heureEntree);
//                        cmd.Parameters.AddWithValue("@heureSortie", heureSortie);
//                        cmd.Parameters.AddWithValue("@jourTravail", jour);
//                        cmd.Parameters.AddWithValue("@idPersonnel", this.personnelId);
//                    }

//                    // ============================================
//                    // 5. MESSAGE
//                    // ============================================

//                    MessageBox.Show(
//                        "L'horaire a été enregistré avec succès.",
//                        "Horaire",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Information);


//                    // Fermer le formulaire
//                    this.DialogResult = DialogResult.OK;
//                    this.Close();
//                }
//                catch (MySqlException ex)
//                {
//                    // ============================================
//                    // CAS D'UN JOUR DÉJÀ EXISTANT
//                    // ============================================

//                    if (ex.Number == 1062)
//                    {
//                        MessageBox.Show(
//                            "Un horaire existe déjà pour ce personnel le " +
//                            cbx_jour.Text + ".",
//                            "Horaire déjà existant",
//                            MessageBoxButtons.OK,
//                            MessageBoxIcon.Warning);

//                        return;
//                    }


//                    // ============================================
//                    // AUTRE ERREUR MYSQL
//                    // ============================================

//                    MessageBox.Show(
//                        "Erreur lors de l'enregistrement de l'horaire :\n\n" +
//                        ex.Message,
//                        "Erreur",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(
//                        "Une erreur est survenue :\n\n" +
//                        ex.Message,
//                        "Erreur",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error);
//                }
//            }
//        }
//    }
//}


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

namespace Cepima.MesForms.Personnel
{
    public partial class Horaire : Form
    {
        private string personnelId;
        private string idHoraire;

        private bool modeModification = false;


        // =========================================================
        // CONSTRUCTEUR : AJOUT
        // =========================================================

        public Horaire(string id_personnel)
        {
            InitializeComponent();
            this.personnelId = id_personnel;
            this.modeModification = false;
            this.Text = "Ajouter une horaire";
            label1.Text = this.Text;
            bt_start.Text = this.Text;
        }


        // =========================================================
        // CONSTRUCTEUR : MODIFICATION
        // =========================================================

        public Horaire(string id_personnel, string idHoraire)
        {
            InitializeComponent();

            this.personnelId = id_personnel;
            this.idHoraire = idHoraire;
            this.modeModification = true;
            this.Text = "Modifier l'horaire";
            label1.Text = this.Text;
            bt_start.Text = this.Text;
        }


        // =========================================================
        // LOAD DU FORMULAIRE
        // =========================================================

        private void Horaire_Load(object sender, EventArgs e)
        {
            LoadDataAdministratives();

            // Charger les jours
            cbx_jour.Items.Clear();

            cbx_jour.Items.Add("Lundi");
            cbx_jour.Items.Add("Mardi");
            cbx_jour.Items.Add("Mercredi");
            cbx_jour.Items.Add("Jeudi");
            cbx_jour.Items.Add("Vendredi");
            cbx_jour.Items.Add("Samedi");
            cbx_jour.Items.Add("Dimanche");

            cbx_jour.SelectedIndex = 0;


            // =====================================================
            // MODE MODIFICATION
            // =====================================================

            if (modeModification)
            {
                bt_start.Text = "Modifier horaire";

                ChargerHoraire();
            }
            else
            {
                bt_start.Text = "Enregistrer horaire";
            }
        }


        // =========================================================
        // CHARGER LES INFORMATIONS DU PERSONNEL
        // =========================================================

        private void LoadDataAdministratives()
        {
            using (MySqlConnection con =
                MesClasses.ManagerClasse.GetConnexion())
            {
                try
                {
                    string query = @"
                        SELECT
                            CONCAT(nom, ' ', post_nom) AS nom,
                            sexe,
                            date_naissance,
                            fonction
                        FROM personnels
                        WHERE id_personnel = @id";

                    MesClasses.ManagerClasse.request_params.Clear();

                    MesClasses.ManagerClasse.request_params.Add(
                        "@id",
                        this.personnelId);

                    using (MySqlDataReader reader =
                        MesClasses.ManagerClasse.CRUD(
                            query,
                            MesClasses.ManagerClasse.request_params,
                            true))
                    {
                        if (reader.Read())
                        {
                            lblPersonnel.Text =
                                reader["nom"].ToString();

                            lbl_fonction.Text =
                                reader["fonction"].ToString();

                            // Vérification date de naissance
                            if (reader["date_naissance"] != DBNull.Value)
                            {
                                DateTime date =
                                    Convert.ToDateTime(
                                        reader["date_naissance"]);

                                int annee =
                                    MesClasses.ReceptionManager
                                    .CalculerAge(date);

                                lbl_age.Text =
                                    annee.ToString() +
                                    " ans - " +
                                    reader["sexe"].ToString();
                            }
                            else
                            {
                                lbl_age.Text =
                                    "Âge non renseigné - " +
                                    reader["sexe"].ToString();
                            }
                        }

                        reader.Close();
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
        }


        // =========================================================
        // CHARGER L'HORAIRE EN MODE MODIFICATION
        // =========================================================

        private void ChargerHoraire()
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    

                    string query = @"
                        SELECT
                            heure_entree_normal,
                            heure_sortie_normal,
                            jour_travail
                        FROM horaire
                        WHERE id_horaire = @idHoraire
                        AND id_personnel = @idPersonnel
                        LIMIT 1";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idHoraire",
                            this.idHoraire);

                        cmd.Parameters.AddWithValue(
                            "@idPersonnel",
                            this.personnelId);

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // =================================
                                // JOUR
                                // =================================

                                if (reader["jour_travail"] != DBNull.Value)
                                {
                                    string jour =
                                        reader["jour_travail"].ToString();

                                    cbx_jour.SelectedItem = jour;
                                }


                                // =================================
                                // HEURE D'ENTRÉE
                                // =================================

                                if (reader["heure_entree_normal"] != DBNull.Value)
                                {
                                    TimeSpan heureEntree =
                                        (TimeSpan)reader[
                                            "heure_entree_normal"];

                                    dtp_heure_entree.Value =
                                        DateTime.Today.Add(
                                            heureEntree);
                                }


                                // =================================
                                // HEURE DE SORTIE
                                // =================================

                                if (reader["heure_sortie_normal"] != DBNull.Value)
                                {
                                    TimeSpan heureSortie =
                                        (TimeSpan)reader[
                                            "heure_sortie_normal"];

                                    dtp_heure_sortie.Value =
                                        DateTime.Today.Add(
                                            heureSortie);
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "L'horaire demandé n'existe plus.",
                                    "Horaire",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible de charger l'horaire.\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // BOUTON ENREGISTRER / MODIFIER
        // =========================================================

        private void bt_start_Click(object sender, EventArgs e)
        {
            try
            {
                // =================================================
                // 1. VÉRIFIER LE JOUR
                // =================================================

                if (cbx_jour.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Veuillez sélectionner un jour de travail.",
                        "Horaire",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // =================================================
                // 2. RÉCUPÉRER LES VALEURS
                // =================================================

                string jour = cbx_jour.Text;

                TimeSpan heureEntree =
                    dtp_heure_entree.Value.TimeOfDay;

                TimeSpan heureSortie =
                    dtp_heure_sortie.Value.TimeOfDay;


                // =================================================
                // 3. VÉRIFIER LES HEURES
                // =================================================

                if (heureSortie <= heureEntree)
                {
                    MessageBox.Show(
                        "L'heure de sortie doit être supérieure " +
                        "à l'heure d'entrée.",
                        "Horaire incorrect",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // =================================================
                // 4. CHOISIR LE MODE
                // =================================================

                if (modeModification)
                {
                    ModifierHoraire(
                        jour,
                        heureEntree,
                        heureSortie);
                }
                else
                {
                    AjouterHoraire(
                        jour,
                        heureEntree,
                        heureSortie);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // AJOUTER UN HORAIRE
        // =========================================================

        private void AjouterHoraire(
            string jour,
            TimeSpan heureEntree,
            TimeSpan heureSortie)
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
                    

                    string query = @"
                        INSERT INTO horaire
                        (
                            heure_entree_normal,
                            heure_sortie_normal,
                            jour_travail,
                            id_personnel
                        )
                        VALUES
                        (
                            @heureEntree,
                            @heureSortie,
                            @jourTravail,
                            @idPersonnel
                        )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@heureEntree",
                            heureEntree);

                        cmd.Parameters.AddWithValue(
                            "@heureSortie",
                            heureSortie);

                        cmd.Parameters.AddWithValue(
                            "@jourTravail",
                            jour);

                        cmd.Parameters.AddWithValue(
                            "@idPersonnel",
                            this.personnelId);

                        // IMPORTANT :
                        // exécuter réellement l'INSERT
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "L'horaire a été enregistré avec succès.",
                    "Horaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "Un horaire existe déjà pour ce personnel le " +
                        jour + ".",
                        "Horaire déjà existant",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "Erreur lors de l'enregistrement de l'horaire :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================================================
        // MODIFIER UN HORAIRE
        // =========================================================

        private void ModifierHoraire(
            string jour,
            TimeSpan heureEntree,
            TimeSpan heureSortie)
        {
            try
            {
                using (MySqlConnection con =
                    MesClasses.ManagerClasse.GetConnexion())
                {
               
                    string query = @"
                        UPDATE horaire
                        SET
                            heure_entree_normal = @heureEntree,
                            heure_sortie_normal = @heureSortie,
                            jour_travail = @jourTravail
                        WHERE id_horaire = @idHoraire
                        AND id_personnel = @idPersonnel";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@heureEntree",
                            heureEntree);

                        cmd.Parameters.AddWithValue(
                            "@heureSortie",
                            heureSortie);

                        cmd.Parameters.AddWithValue(
                            "@jourTravail",
                            jour);

                        cmd.Parameters.AddWithValue(
                            "@idHoraire",
                            this.idHoraire);

                        cmd.Parameters.AddWithValue(
                            "@idPersonnel",
                            this.personnelId);

                        int resultat =
                            cmd.ExecuteNonQuery();

                        if (resultat == 0)
                        {
                            MessageBox.Show(
                                "Aucun horaire n'a été modifié.",
                                "Horaire",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "L'horaire a été modifié avec succès.",
                    "Horaire",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(
                        "Un autre horaire existe déjà pour ce personnel le " +
                        jour + ".",
                        "Horaire déjà existant",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "Erreur lors de la modification de l'horaire :\n\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
