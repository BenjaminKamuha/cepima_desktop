using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Cepima.Data
{
    class Database
    {
        private string connectionString;

        public Database() 
        {
            connectionString = "Server=localhost; Database=cepimadb; Uid=root; Pwd=;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Methode pour compter les données d'une table
        public int Count(string tableName) 
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM " + tableName;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Erreur Count()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return 0;
            }
        }

        // Vérifier si un element existe
        public bool Exists(string tableName, string columnName, object value)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT EXISTS(" +
                                   "SELECT 1 FROM " + tableName +
                                   " WHERE " + columnName + " = @value)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value", value);

                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur Exists()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // Récuperer la plus grande valeur
        public int GetMax(string tableName, string columnName)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT MAX(" + columnName + ") FROM " + tableName;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result == DBNull.Value || result == null)
                            return 0;

                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetMax()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // Récuperer la plus petite valeur
        public int GetMin(string tableName, string columnName)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT MIN(" + columnName + ") FROM " + tableName;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result == DBNull.Value || result == null)
                            return 0;

                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetMin()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // Calculer une somme
        public decimal GetSum(string tableName, string columnName)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = "SELECT COALESCE(SUM(" + columnName + "), 0) " +
                                   "FROM " + tableName;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToDecimal(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetSum()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // Récuperer une valeur précise
        public object GetValue(
    string tableName,
    string selectColumn,
    string whereColumn,
    object whereValue)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query =
                        "SELECT " + selectColumn +
                        " FROM " + tableName +
                        " WHERE " + whereColumn + " = @value " +
                        " LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@value", whereValue);

                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetValue()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }
        }

        // Insersion et récuperation de l'id
        public long InsertAndGetId(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        command.ExecuteNonQuery();

                        return command.LastInsertedId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur InsertAndGetId()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // ExecuteNonQuery générique
        public int ExecuteNonQuery(
            string query,
            params MySqlParameter[] parameters)
            {
                try
                {
                    using (MySqlConnection connection = GetConnection())
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddRange(parameters);

                            return command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Erreur ExecuteNonQuery()",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return 0;
                }
            }

        // Récuperer les données dans un DataGridView
        public DataTable GetDataTable(
            string query,
            params MySqlParameter[] parameters)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (MySqlDataAdapter adapter =
                               new MySqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetDataTable()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return null;
            }
        } 
        // Pharmacie

        // Vérifier un médicament
        public bool MedicamentExists(
    string nom,
    string dosage,
    string forme)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT EXISTS(
                    SELECT 1
                    FROM medicament
                    WHERE nom = @nom
                    AND dosage = @dosage
                    AND forme = @forme
                )";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nom", nom);
                        command.Parameters.AddWithValue("@dosage", dosage);
                        command.Parameters.AddWithValue("@forme", forme);

                        return Convert.ToBoolean(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur MedicamentExists()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }

        // Stock actuel d'un médicament:

        public int GetStockMedicament(int medicamentId)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT COALESCE(SUM(quantite), 0)
                FROM lot_medicament
                WHERE medicament_id = @medicamentId
                AND date_expiration >= CURDATE()";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@medicamentId",
                            medicamentId);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur GetStockMedicament()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // Stock faible 

        public DataTable GetMedicamentsStockFaible()
        {
            string query = @"
        SELECT
            m.id,
            m.nom,
            m.dosage,
            m.forme,
            m.seuil_minimum,
            COALESCE(SUM(l.quantite), 0) AS stock
        FROM medicament m
        LEFT JOIN lot_medicament l
            ON l.medicament_id = m.id
            AND l.date_expiration >= CURDATE()
        WHERE m.actif = 1
        GROUP BY
            m.id,
            m.nom,
            m.dosage,
            m.forme,
            m.seuil_minimum
        HAVING stock <= m.seuil_minimum
        ORDER BY stock ASC";

            return GetDataTable(query);
        }

        // Lot bientôt expirés

        public DataTable GetLotsExpirant(int nombreJours)
        {
            string query = @"
        SELECT
            l.id,
            m.nom,
            m.dosage,
            m.forme,
            l.numero_lot,
            l.quantite,
            l.date_expiration
        FROM lot_medicament l
        INNER JOIN medicament m
            ON m.id = l.medicament_id
        WHERE l.date_expiration
              BETWEEN CURDATE()
              AND DATE_ADD(CURDATE(), INTERVAL @jours DAY)
        ORDER BY l.date_expiration ASC";

            return GetDataTable(
                query,
                new MySqlParameter("@jours", nombreJours)
            );
        }

        // Méthode générique transactionnelle
        public long ExecuteTransaction(
    Func<MySqlConnection, MySqlTransaction, long> action)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (MySqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            long result = action(connection, transaction);

                            transaction.Commit();

                            return result;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur transaction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return 0;
            }
        }

        // Réception d'un médicament
        public bool AjouterStock(
    int medicamentId,
    string numeroLot,
    DateTime dateExpiration,
    int quantite,
    int utilisateurId)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();

                    using (MySqlTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Chercher le lot
                            string queryLot = @"
                        SELECT id
                        FROM lot_medicament
                        WHERE medicament_id = @medicamentId
                        AND numero_lot = @numeroLot
                        LIMIT 1";

                            long lotId = 0;

                            using (MySqlCommand command =
                                   new MySqlCommand(
                                       queryLot,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.AddWithValue(
                                    "@medicamentId",
                                    medicamentId);

                                command.Parameters.AddWithValue(
                                    "@numeroLot",
                                    numeroLot);

                                object result = command.ExecuteScalar();

                                if (result != null &&
                                    result != DBNull.Value)
                                {
                                    lotId = Convert.ToInt64(result);
                                }
                            }

                            // 2. Créer ou mettre à jour le lot
                            if (lotId == 0)
                            {
                                string insertLot = @"
                            INSERT INTO lot_medicament
                            (
                                medicament_id,
                                numero_lot,
                                date_expiration,
                                quantite
                            )
                            VALUES
                            (
                                @medicamentId,
                                @numeroLot,
                                @dateExpiration,
                                @quantite
                            )";

                                using (MySqlCommand command =
                                       new MySqlCommand(
                                           insertLot,
                                           connection,
                                           transaction))
                                {
                                    command.Parameters.AddWithValue(
                                        "@medicamentId",
                                        medicamentId);

                                    command.Parameters.AddWithValue(
                                        "@numeroLot",
                                        numeroLot);

                                    command.Parameters.AddWithValue(
                                        "@dateExpiration",
                                        dateExpiration);

                                    command.Parameters.AddWithValue(
                                        "@quantite",
                                        quantite);

                                    command.ExecuteNonQuery();

                                    lotId = command.LastInsertedId;
                                }
                            }
                            else
                            {
                                string updateLot = @"
                            UPDATE lot_medicament
                            SET quantite = quantite + @quantite
                            WHERE id = @lotId";

                                using (MySqlCommand command =
                                       new MySqlCommand(
                                           updateLot,
                                           connection,
                                           transaction))
                                {
                                    command.Parameters.AddWithValue(
                                        "@quantite",
                                        quantite);

                                    command.Parameters.AddWithValue(
                                        "@lotId",
                                        lotId);

                                    command.ExecuteNonQuery();
                                }
                            }

                            // 3. Enregistrer le mouvement
                            string mouvement = @"
                        INSERT INTO mouvement_stock
                        (
                            lot_id,
                            type,
                            quantite,
                            utilisateur_id,
                            observation
                        )
                        VALUES
                        (
                            @lotId,
                            'ENTREE',
                            @quantite,
                            @utilisateurId,
                            'Réception de stock'
                        )";

                            using (MySqlCommand command =
                                   new MySqlCommand(
                                       mouvement,
                                       connection,
                                       transaction))
                            {
                                command.Parameters.AddWithValue(
                                    "@lotId",
                                    lotId);

                                command.Parameters.AddWithValue(
                                    "@quantite",
                                    quantite);

                                command.Parameters.AddWithValue(
                                    "@utilisateurId",
                                    utilisateurId);

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erreur AjouterStock()",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }
    }


        
}
