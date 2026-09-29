using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cepima.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Cepima.Services
{
    class PermManager
    {
        public static Database db = new Database();

        // Get role
        public static List<Int32> get_role(int user_id)
        {
            string query = "SELECT r.id_role FROM utilisateur_role ur JOIN utilisateurs u ON u.id_utilisateurs = ur.id_utilisateur JOIN                                role r ON r.id_role = ur.id_role WHERE id_utilisateurs=@user_id;";

            List<int> list_id_role = new List<int>();

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@user_id", user_id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list_id_role.Add(Convert.ToInt32(reader["id_role"].ToString()));
                        }
                    }
                }
            }

            return list_id_role;
        }
        // 
        public static bool has_permission(int user_id, string perm_code)
        {

            List<int> id_roles = get_role(user_id);

            string query = "SELECT EXISTS(SELECT r.nom_role, p.name FROM role_permission rp JOIN role r ON rp.id_role=r.id_role JOIN permission p ON                                rp.id_permission = p.id_perm WHERE p.code = @perm_code AND r.id_role=@id_role);";

            using (MySqlConnection con = db.GetConnection())
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    foreach (int id_role in id_roles)
                    {
                        MessageBox.Show(id_role.ToString());
                        cmd.Parameters.AddWithValue("@perm_code", perm_code);
                        cmd.Parameters.AddWithValue("@id_role", id_role);

                        if (Convert.ToBoolean(cmd.ExecuteScalar()))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
