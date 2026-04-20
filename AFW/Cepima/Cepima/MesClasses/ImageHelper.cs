using System;
using System.Drawing;
using System.IO;
using MySql.Data.MySqlClient;
using Cepima.MesClasses;
using System.Windows.Forms;

namespace Cepima.MesClasses  // <-- ici le namespace du sous-dossier
{
    public static class ImageHelper
    {

        public static byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public static void SaveImageToDatabase(int id_value, string id_columnName, string tableName, string columnName, Image img)
        {
            byte[] bytes = ImageToBytes(img);

            using (MySqlConnection conn = ManagerClasse.GetConnexion())
            {

                string query = "UPDATE " + tableName + " SET " + columnName + "=@img WHERE + " + id_columnName + "=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@img", bytes);
                    cmd.Parameters.AddWithValue("@id", id_value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Image LoadImageFromDatabase(int id_value, string id_columnName, string tableName, string columnName)
        {
            using (MySqlConnection conn = ManagerClasse.GetConnexion())
            {
                string query = "SELECT " + columnName + " FROM " + tableName + " WHERE " + id_columnName + "=@id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id_value);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        byte[] bytes = (byte[])result;
                        return BytesToImage(bytes);
                    }
                }
            }

            return null;
        }

        public static void ChoisirImage(int id, Button btn)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog()
                == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(ofd.FileName);

                    byte[] bytes = ImageHelper.ImageToBytes(img);

                    AvatarControl avatar = btn.Parent.Controls[0] as AvatarControl;
                    avatar.Avatar = ImageHelper.BytesToImage(bytes);

                    // Enregistrement de l'image
                    ImageHelper.SaveImageToDatabase(id, "id_medicament", "medicament", "photo", avatar.Avatar);

                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erreur image." + Ex.Message);
                }
            }

            ofd.Dispose();
        }
    }
}