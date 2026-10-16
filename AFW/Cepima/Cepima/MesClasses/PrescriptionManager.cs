using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Cepima.Data;

namespace Cepima.MesClasses
{
    public class PrescriptionLigneData
    {
        public int MedicamentId { get; set; }
        public string Dose { get; set; }
        public string Frequence { get; set; }
        public string Duree { get; set; }
        public int Quantite { get; set; }
        public string Color { get; set; }
    }


    public static class PrescriptionManager
    {

        private static int GetPrescriptionActive(
            int patientId,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string sql = @"
        SELECT id
        FROM prescription
        WHERE patient_id = @patient_id
        AND statut = 'ACTIVE'
        ORDER BY id DESC
        LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(sql, con, tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient_id",
                    patientId);

                object result = cmd.ExecuteScalar();

                if (result == null ||
                    result == DBNull.Value)
                {
                    return 0;
                }

                return Convert.ToInt32(result);
            }
        }
        // ==========================================================
        // ENREGISTRER UNE PRESCRIPTION COMPLETE
        // ==========================================================

        public static int EnregistrerPrescription(
            int patientId,
            int medecinId,
            string observation,
            List<PrescriptionLigneData> lignes)
        {
            if (lignes == null || lignes.Count == 0)
                throw new Exception(
                    "La prescription doit contenir au moins un médicament.");

            Database db = new Database();

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();



                using (MySqlTransaction tr = con.BeginTransaction())
                {
                    int prescriptionExistante =
                        GetPrescriptionActive(
                            patientId,
                            con,
                            tr);

                    if (prescriptionExistante > 0)
                    {
                        throw new Exception(
                            "Ce patient possède déjà une prescription en cours.\n\n" +
                            "Vous devez terminer ou annuler cette prescription " +
                            "avant d'en créer une nouvelle.");
                            
                    }



                    try
                    {

                        // ==================================================
                        // 1. CREER LA PRESCRIPTION
                        // ==================================================

                        string sqlPrescription = @"
                            INSERT INTO prescription
                            (
                                patient_id,
                                medecin_id,
                                date_prescription,
                                statut,
                                observation
                            )
                            VALUES
                            (
                                @patient_id,
                                @medecin_id,
                                NOW(),
                                'ACTIVE',
                                @observation
                            )";

                        int idPrescription;

                        using (MySqlCommand cmd =
                            new MySqlCommand(
                                sqlPrescription,
                                con,
                                tr))
                        {
                            cmd.Parameters.AddWithValue(
                                "@patient_id",
                                patientId);

                            cmd.Parameters.AddWithValue(
                                "@medecin_id",
                                medecinId);

                            cmd.Parameters.AddWithValue(
                                "@observation",
                                string.IsNullOrEmpty(observation)
                                    ? (object)DBNull.Value
                                    : observation);

                            cmd.ExecuteNonQuery();

                            idPrescription =
                                Convert.ToInt32(
                                    cmd.LastInsertedId);
                        }


                        // ==================================================
                        // 2. VARIABLES POUR LA FACTURATION
                        // ==================================================

                        decimal montantMedicaments = 0;


                        // ==================================================
                        // 3. INSERER LES LIGNES
                        // ==================================================

                        foreach (PrescriptionLigneData ligne in lignes)
                        {
                            if (ligne.MedicamentId <= 0)
                                throw new Exception(
                                    "Un médicament sélectionné est invalide.");

                            if (ligne.Quantite <= 0)
                                throw new Exception(
                                    "La quantité doit être supérieure à zéro.");


                            // ==============================================
                            // RECUPERER LE PRIX DE VENTE
                            // ==============================================

                            decimal prixVente = 0;

                            string sqlPrix = @"
                                SELECT prix_vente
                                FROM medicament
                                WHERE id = @id
                                LIMIT 1";

                            using (MySqlCommand cmdPrix =
                                new MySqlCommand(
                                    sqlPrix,
                                    con,
                                    tr))
                            {
                                cmdPrix.Parameters.AddWithValue(
                                    "@id",
                                    ligne.MedicamentId);

                                object result =
                                    cmdPrix.ExecuteScalar();

                                if (result == null ||
                                    result == DBNull.Value)
                                {
                                    throw new Exception(
                                        "Le prix de vente du médicament est introuvable.");
                                }

                                prixVente =
                                    Convert.ToDecimal(result);
                            }


                            // ================================
                            // Recuperer la couleur categorie
                            // ===============================




                            // ==============================================
                            // CALCUL
                            // ==============================================

                            decimal montantLigne =
                                prixVente *
                                ligne.Quantite;

                            montantMedicaments +=
                                montantLigne;


                            // ==============================================
                            // INSERT PRESCRIPTION_LIGNE
                            // ==============================================

                            string sqlLigne = @"
                                INSERT INTO prescription_ligne
                                (
                                    prescription_id,
                                    medicament_id,
                                    dose,
                                    frequence,
                                    duree,
                                    quantite_prescrite
                                )
                                VALUES
                                (
                                    @prescription_id,
                                    @medicament_id,
                                    @dose,
                                    @frequence,
                                    @duree,
                                    @quantite
                                )";

                            using (MySqlCommand cmdLigne =
                                new MySqlCommand(
                                    sqlLigne,
                                    con,
                                    tr))
                            {
                                cmdLigne.Parameters.AddWithValue(
                                    "@prescription_id",
                                    idPrescription);

                                cmdLigne.Parameters.AddWithValue(
                                    "@medicament_id",
                                    ligne.MedicamentId);

                                cmdLigne.Parameters.AddWithValue(
                                    "@dose",
                                    ligne.Dose ?? "");

                                cmdLigne.Parameters.AddWithValue(
                                    "@frequence",
                                    ligne.Frequence ?? "");

                                cmdLigne.Parameters.AddWithValue(
                                    "@duree",
                                    string.IsNullOrEmpty(ligne.Duree)
                                        ? (object)DBNull.Value
                                        : ligne.Duree);

                                cmdLigne.Parameters.AddWithValue(
                                    "@quantite",
                                    ligne.Quantite);

                                cmdLigne.ExecuteNonQuery();
                            }
                        }


                        // ==================================================
                        // 4. RECUPERER / CREER LA FACTURE
                        // ==================================================

                        int idFacture =
                            RecupererOuCreerFacture(
                                patientId,
                                con,
                                tr);


                        // ==================================================
                        // 5. AJOUTER / AUGMENTER LA RUBRIQUE MEDICAMENTS
                        // ==================================================

                        AjouterMontantMedicaments(
                            idFacture,
                            montantMedicaments,
                            con,
                            tr);


                        // ==================================================
                        // 6. RECALCULER LE TOTAL DE LA FACTURE
                        // ==================================================

                        RecalculerTotalFacture(
                            idFacture,
                            con,
                            tr);


                        // ==================================================
                        // 7. COMMIT
                        // ==================================================

                        tr.Commit();

                        return idPrescription;
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }
            }
        }


        // ==========================================================
        // RECUPERER OU CREER LA FACTURE
        // ==========================================================

        private static int RecupererOuCreerFacture(
            int patientId,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            int idFacture = 0;


            // ==========================================================
            // CHERCHER UNE FACTURE OUVERTE
            // ==========================================================

            string sqlRecherche = @"
                SELECT id_facture
                FROM facture
                WHERE id_patient = @patient_id
                AND statut <> 'Payé'
                ORDER BY id_facture DESC
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sqlRecherche,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient_id",
                    patientId);

                object result =
                    cmd.ExecuteScalar();

                if (result != null &&
                    result != DBNull.Value)
                {
                    idFacture =
                        Convert.ToInt32(result);

                    return idFacture;
                }
            }


            // ==========================================================
            // RECUPERER LE CENTRE DU PATIENT
            // ==========================================================

            int idCentre = 0;

            string sqlCentre = @"
                SELECT id_centre
                FROM patients
                WHERE id_patient = @patient_id
                LIMIT 1";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sqlCentre,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient_id",
                    patientId);

                object result =
                    cmd.ExecuteScalar();

                if (result == null ||
                    result == DBNull.Value)
                {
                    throw new Exception(
                        "Le centre du patient est introuvable.");
                }

                idCentre =
                    Convert.ToInt32(result);
            }


            // ==========================================================
            // CREER UNE NOUVELLE FACTURE
            // ==========================================================

            string sqlFacture = @"
                INSERT INTO facture
                (
                    id_patient,
                    id_consultation,
                    id_centre,
                    type_facture,
                    date_facture,
                    montant_total,
                    statut
                )
                VALUES
                (
                    @patient_id,
                    NULL,
                    @centre,
                    'Ambulatoire',
                    CURDATE(),
                    0,
                    'Non payé'
                )";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sqlFacture,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@patient_id",
                    patientId);

                cmd.Parameters.AddWithValue(
                    "@centre",
                    idCentre);

                cmd.ExecuteNonQuery();

                idFacture =
                    Convert.ToInt32(
                        cmd.LastInsertedId);
            }


            return idFacture;
        }


        // ==========================================================
        // AJOUTER / AUGMENTER MEDICAMENTS DANS DETAIL_FACTURE
        // ==========================================================

        private static void AjouterMontantMedicaments(
            int idFacture,
            decimal montant,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            // ==========================================================
            // CHERCHER LA RUBRIQUE "Médicaments"
            // ==========================================================

            string sqlRecherche = @"
                SELECT id_detail_facture
                FROM detail_facture
                WHERE id_facture = @id_facture
                AND description = 'Médicaments'
                LIMIT 1";

            object result;

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sqlRecherche,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_facture",
                    idFacture);

                result =
                    cmd.ExecuteScalar();
            }


            // ==========================================================
            // LA RUBRIQUE EXISTE
            // ==========================================================

            if (result != null &&
                result != DBNull.Value)
            {
                string sqlUpdate = @"
                    UPDATE detail_facture
                    SET montant =
                        COALESCE(montant, 0) + @montant
                    WHERE id_detail_facture = @id_detail";

                using (MySqlCommand cmd =
                    new MySqlCommand(
                        sqlUpdate,
                        con,
                        tr))
                {
                    cmd.Parameters.AddWithValue(
                        "@montant",
                        montant);

                    cmd.Parameters.AddWithValue(
                        "@id_detail",
                        Convert.ToInt32(result));

                    cmd.ExecuteNonQuery();
                }

                return;
            }


            // ==========================================================
            // LA RUBRIQUE N'EXISTE PAS
            // ==========================================================

            string sqlInsert = @"
                INSERT INTO detail_facture
                (
                    id_facture,
                    id_prestation,
                    description,
                    quantite,
                    prix_unitaire,
                    montant
                )
                VALUES
                (
                    @id_facture,
                    NULL,
                    'Médicaments',
                    NULL,
                    NULL,
                    @montant
                )";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sqlInsert,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_facture",
                    idFacture);

                cmd.Parameters.AddWithValue(
                    "@montant",
                    montant);

                cmd.ExecuteNonQuery();
            }
        }


        // ==========================================================
        // RECALCULER LE TOTAL DE LA FACTURE
        // ==========================================================

        private static void RecalculerTotalFacture(
            int idFacture,
            MySqlConnection con,
            MySqlTransaction tr)
        {
            string sql = @"
                UPDATE facture
                SET montant_total =
                (
                    SELECT COALESCE(
                        SUM(COALESCE(montant, 0)),
                        0
                    )
                    FROM detail_facture
                    WHERE id_facture = @id_facture
                )
                WHERE id_facture = @id_facture";

            using (MySqlCommand cmd =
                new MySqlCommand(
                    sql,
                    con,
                    tr))
            {
                cmd.Parameters.AddWithValue(
                    "@id_facture",
                    idFacture);

                cmd.ExecuteNonQuery();
            }
        }
    }
}