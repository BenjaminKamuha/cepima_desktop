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
namespace Cepima.MesClasses
{
     public class RH_manager
    {
         /////////////////////////////////////  Salaire en marche *************
         // =================================== save salaire ======================================
         public  static void  EnregistrerSalaire(string id_personnel,string periode,decimal salaire_base,string statut)
         {
             string query = "INSERT INTO salaires (id_personnel,mois,salaire_base,date_paiement,statut) VALUES(@personnel,@mois,@base,CURDATE(),@statut)";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@personnel",id_personnel);
             MesClasses.ManagerClasse.request_params.Add("@mois",periode);
             MesClasses.ManagerClasse.request_params.Add("@base",salaire_base.ToString());
             MesClasses.ManagerClasse.request_params.Add("@statut",statut);
             MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
         }

         // ==================================== save avance_salaire ========================================
         public static void Save_Avance_salaires(int id_salaire, decimal montant_avance_paye, decimal reste_avance_salaire)
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 string queryInsert = "INSERT INTO avances_salaire(id_salaire,date_avance,montant,reste)VALUES(@salaire,CURDATE(),@montant,@reste)";
                 using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                 {
                     cmd.Parameters.AddWithValue("@salaire",id_salaire);
                     cmd.Parameters.AddWithValue("@montant",montant_avance_paye);
                     cmd.Parameters.AddWithValue("@reste",reste_avance_salaire);
                     cmd.ExecuteNonQuery();
                 }
                 MessageBox.Show("Avance crée avec succès");
             }
         }
         
         // ================================= Charger la liste des salaires dans le datagridview ==========================
         public static void LoadSalaryInDgv(DataGridView dgv)
         {
             using (MySqlConnection connection = MesClasses.ManagerClasse.GetConnexion())
             {
                 try
                 {
                     string querySelect = "SELECT s.id_salaire AS ID,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Personnel,p.fonction AS Fonction,s.mois,s.salaire_base,(s.salaire_base + (SELECT IFNULL(SUM(montant),0) FROM prime WHERE id_salaire = s.id_salaire) - (SELECT IFNULL(SUM(montant),0) FROM retenue WHERE id_salaire = s.id_salaire) - (SELECT IFNULL(SUM(montant),0) FROM avances_salaire WHERE id_salaire = s.id_salaire)) AS salaire_net,s.date_paiement,s.statut FROM salaires s  JOIN personnels p ON p.id_personnel = s.id_personnel ORDER BY s.date_paiement DESC;";
                     MySqlDataAdapter da = new MySqlDataAdapter(querySelect, connection);
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     dgv.DataSource = dt;
                     dgv.Columns["ID"].Visible = false;
                     //Ajuster les cellules par rapport aux données
                     dgv.EnableHeadersVisualStyles = false;
                     dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);  //7, 51, 131
                     dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                     dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                     dgv.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
                   
                 }
                 catch (MySqlException ex)
                 {
                     MessageBox.Show("Erreur de chargement des salaires : " + ex.Message);
                 }
             }
         }

         // ======================== supprimer le salaire ==========================================================
         public static void DeleteSalary(int id_salaire)
         {

             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 MySqlTransaction tr = con.BeginTransaction();
                 string query = "DELETE FROM salaires WHERE id_salaire = @id";
                 try
                 {
                     using (MySqlCommand cmdDelete = new MySqlCommand(query, con, tr))
                     {
                         cmdDelete.Parameters.AddWithValue("@id", id_salaire);
                         cmdDelete.ExecuteNonQuery();
                     }
                     tr.Commit();
                     MessageBox.Show("Données supprimeés avec succès!!");
                 }

                 catch (Exception ex)
                 {
                     tr.Rollback();
                     MessageBox.Show("Erreur lors de la suppression du salaire : " + ex.Message);
                 }
             }

            
         }

         // =================================== modifier le salaire ===============================================
         public static void UpdateSalary(int id_salaire,decimal salaire)
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 MySqlTransaction tr = con.BeginTransaction();
                 try
                 {
                     string queryUpdate = "UPDATE salaires SET salaire_base = @base WHERE id_salaire = @id";
                     using (MySqlCommand cmd = new MySqlCommand(queryUpdate,con,tr))
                     {
                         cmd.Parameters.AddWithValue("@base",salaire);
                         cmd.Parameters.AddWithValue("@id",id_salaire);
                         cmd.ExecuteNonQuery();
                     }
                     tr.Commit();
                     MessageBox.Show("Données modifiées avec succès !!");

                 }
                 catch (Exception ex)
                 {
                     tr.Rollback();
                     MessageBox.Show("Erreur de modification" +ex.Message);
                 }
             }
         }

         // ======================= charger la liste des avances =================================================
         public static void LoadAvances_salaire(DataGridView dgv_avance, string search = "")
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 string query = "SELECT a.id_avance,s.id_salaire,CONCAT(p.nom, ' ', p.post_nom,' ',p.prenom) AS Personnel,p.fonction AS Fonction,s.mois AS Mois,s.salaire_base AS Salaire_base,a.montant AS Montant_avance,a.reste AS Reste_salaire,a.date_avance AS Date FROM avances_salaire a INNER JOIN salaires s ON s.id_salaire = a.id_salaire INNER JOIN personnels p ON p.id_personnel = s.id_personnel WHERE CONCAT(p.nom, ' ', p.post_nom, ' ',p.prenom) LIKE @search OR p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search";
                 MySqlCommand cmd = new MySqlCommand(query, con);
                 cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);

                 dgv_avance.DataSource = dt;
                 dgv_avance.Columns["id_avance"].Visible = false;
                 dgv_avance.Columns["id_salaire"].Visible = false;
                 //Ajuster les cellules par rapport aux données
                 dgv_avance.EnableHeadersVisualStyles = false;
                 dgv_avance.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);
                 dgv_avance.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                 dgv_avance.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                 dgv_avance.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
             }
         }

         // ======================== Supprimer les avances ====================================================
         public static void Delete_avance_salaire(int id_avance)
         {
             try
             {
                 string query = "DELETE FROM avances_salaire WHERE id_avance = @id";
                 MesClasses.ManagerClasse.request_params.Clear();
                 MesClasses.ManagerClasse.request_params.Add("@id",id_avance.ToString());
                 MesClasses.ManagerClasse.CRUD(query,MesClasses.ManagerClasse.request_params);
                 MessageBox.Show("Avance supprimée avec succès");
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erreur : " +ex.Message);
             }
         }

         // =================================== Modifier une avance ===========================================
         public static void Update_avance_salaire(int id_avance,decimal montant)
         {
             try
             {
                 string queryUpdate = "UPDATE avances_salaire SET montant = @montant WHERE id_avance = @id";
                 MesClasses.ManagerClasse.request_params.Clear();
                 MesClasses.ManagerClasse.request_params.Add("@montant",montant.ToString());
                 MesClasses.ManagerClasse.request_params.Add("@id",id_avance.ToString());
                 MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
                 MessageBox.Show("Données modifiées avec succès !");
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erreur de modification de données : " +ex.Message);
             }
         }

         // ........................................ fin pour les avances .....................................

         // ============================================= Gestion de primes ===================================
         public  static void ChargerPrimes(DataGridView dgv)
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {

                 string query = "SELECT pr.id_prime,CONCAT(p.nom, ' ', p.post_nom,' ',p.prenom) AS Personnel,p.fonction AS Fonction,s.mois AS Mois,s.salaire_base AS Salaire,pr.montant AS Prime,pr.motif AS Motif,pr.date_prime AS Date FROM prime pr INNER JOIN salaires s ON s.id_salaire = pr.id_salaire INNER JOIN personnels p ON p.id_personnel = s.id_personnel ORDER BY pr.date_prime DESC";
                 MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dgv.DataSource = dt;
                 dgv.Columns["id_prime"].Visible = false;
                 //Ajuster les cellules par rapport aux données
                 dgv.EnableHeadersVisualStyles = false;
                 dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);  //7, 51, 131
                 dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                 dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                 dgv.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
             }
         }

         // ================================== Save primes =======================================
         public static void Save_primes(int idsalaire, string motif, decimal montant)
         {
             string queryInsert = "INSERT INTO prime(id_salaire,date_prime,motif,montant)VALUES(@salaire,CURDATE(),@motif,@montant)";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@salaire",idsalaire.ToString());
             MesClasses.ManagerClasse.request_params.Add("@motif",motif);
             MesClasses.ManagerClasse.request_params.Add("@montant",montant.ToString());
             MesClasses.ManagerClasse.CRUD(queryInsert,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("Ajout du prime !","Information");
         }

         // ================================Modification du prime =======================================
         public static void Update_prime(int id_prime, decimal montant_prime,decimal ancienne_valeur)
         {
             string queryUpdate = "UPDATE prime SET montant = @m WHERE id_prime = @id";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@m",montant_prime.ToString());
             MesClasses.ManagerClasse.request_params.Add("@id",id_prime.ToString());
             MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("L'ancièn montant : "+ancienne_valeur+" à été modifié au nouveau montant : " +montant_prime,"Modification");
         }

         // ================================== Supprimer une prime ====================================================
         public static void Delete_prime(int id)
         {
             string queryDelete = "DELETE FROM prime WHERE id_prime = @id";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@id",id.ToString());
             MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("la prime à été supprimée !");
         }

         // ........................ Fin pour les primes .................................................

         // ================================= Gestion de retenues =========================================
         public static void ChargerRetenues(DataGridView dgv,string searchText = "")
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 string query = "SELECT r.id_retenue,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Personnel,p.fonction AS Fonction,s.mois AS Mois,s.salaire_base AS Salaire,r.montant AS Montant_retenu,r.motif,r.date_retenue AS Date FROM retenue r INNER JOIN salaires s ON s.id_salaire = r.id_salaire INNER JOIN personnels p ON p.id_personnel = s.id_personnel WHERE CONCAT(p.nom, ' ', p.post_nom, ' ',p.prenom) LIKE @search OR p.nom LIKE @search OR p.post_nom LIKE @search OR p.prenom LIKE @search GROUP BY s.id_salaire";
                 MySqlCommand cmd = new MySqlCommand(query,con);
                 cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                 using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                 {
                     DataTable dt = new DataTable();
                     da.Fill(dt);
                     dgv.DataSource = dt;
                     dgv.Columns["id_retenue"].Visible = false;
                     //Ajuster les cellules par rapport aux données
                     dgv.EnableHeadersVisualStyles = false;
                     dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);
                     dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                     dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                     dgv.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
                 }
             }
         }

         // ============================ save retenues ==============================================
         public static void Save_retenues(int salaire,string motif,decimal montantretenu)
         {
             string queryInsert = "INSERT INTO retenue(id_salaire,date_retenue,motif,montant)VALUES(@salaire,CURDATE(),@motif,@montant)";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@salaire",salaire.ToString());
             MesClasses.ManagerClasse.request_params.Add("@motif",motif);
             MesClasses.ManagerClasse.request_params.Add("@montant",montantretenu.ToString());
             MesClasses.ManagerClasse.CRUD(queryInsert,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("Retenue ajouté !!");
         }

         // ================================= update retenue =============================================
         public static void Update_retenue(int idRetenue, decimal montantRetenue,decimal ancienne_valeur)
         {
             string queryUpdate = "UPDATE retenue SET montant =@montant WHERE id_retenue = @id";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@montant",montantRetenue.ToString());
             MesClasses.ManagerClasse.request_params.Add("@id",idRetenue.ToString());
             MesClasses.ManagerClasse.CRUD(queryUpdate,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("L'ancien montant retenue " +ancienne_valeur+ " à été modifié au nouveau "+montantRetenue,"Modification",MessageBoxButtons.OK,MessageBoxIcon.Information);
         }
         // ======================================= delete retenue =======================================
         public static void Delete_retenue(int retenueId)
         {
             
             string queryDelete = "DELETE FROM retenue WHERE id_retenue = @id";
             MesClasses.ManagerClasse.request_params.Clear();
             MesClasses.ManagerClasse.request_params.Add("@id",retenueId.ToString());
             MesClasses.ManagerClasse.CRUD(queryDelete,MesClasses.ManagerClasse.request_params);
             MessageBox.Show("Retenue supprimée avec succès !!");
         }
         //===================================== horaire ===========================
         public static void LoadHoraireForPersonnel(DataGridView dgv_horaire)
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 string query = "SELECT id_horaire AS ID,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Personnel,p.fonction,pr.heure_entree_normal AS Entree,pr.heure_sortie_normal AS Sortie,pr.jour_travail FROM horaire pr JOIN personnels p ON p.id_personnel = pr.id_personnel ";
                 MySqlCommand cmd = new MySqlCommand(query, con);
                 DataTable dt = new DataTable();
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 da.Fill(dt);
                 dgv_horaire.DataSource = dt;

                 dgv_horaire.Columns["ID"].Visible = false;
                 dgv_horaire.EnableHeadersVisualStyles = false;
                 dgv_horaire.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);  //7, 51, 131
                 dgv_horaire.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                 dgv_horaire.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                 dgv_horaire.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
                 dgv_horaire.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
             }
         }
         // ===================== charger les présences dans le datagridview ==================================
         public  static void LoadPresencesForPersonnel(DataGridView dgv)
         {
             using (MySqlConnection con = MesClasses.ManagerClasse.GetConnexion())
             {
                 string query = "SELECT id_presence AS ID,CONCAT(p.nom,' ',p.post_nom,' ',p.prenom) AS Personnel,p.fonction,pr.date_presence,pr.heure_entree,pr.heure_sortie,pr.statut FROM presences pr JOIN personnels p ON p.id_personnel = pr.id_personnel ";
                 MySqlCommand cmd = new MySqlCommand(query, con);
                 DataTable dt = new DataTable();
                 MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                 da.Fill(dt);
                 dgv.DataSource = dt;

                 dgv.Columns["ID"].Visible = false;
                 dgv.EnableHeadersVisualStyles = false;
                 dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 123, 229);  //7, 51, 131
                 dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(247, 252, 250);
                 dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Bold);
                 dgv.DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
                 dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
             }
         }
    }
}
