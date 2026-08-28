using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


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

    }
        
}
