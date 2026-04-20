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
using Cepima.MesClasses;

namespace Cepima.MesUserCases
{
    public partial class User_sortie_pharmacie : UserControl
    {
        public User_sortie_pharmacie()
        {
            InitializeComponent();
            load_med(User_medicament.SELECTEDMED_ID);
        }

        private void load_med(string id_med)
        {
            string query = "SELECT nom_medicament, categorie, unite, photo FROM medicament WHERE id_medicament=@id_med";
            Dictionary<string, string> request_params = MesClasses.ManagerClasse.request_params;
            request_params.Clear();
            request_params.Add("id_med", id_med);
            using (MySqlDataReader reader = MesClasses.ManagerClasse.CRUD(query, request_params, true))
            {
                if (reader.HasRows)
                {
                    // Traitement de l'image
                    Image img_med = ImageHelper.LoadImageFromDatabase(int.Parse(id_med), "id_medicament", "medicament", "photo");
                    picture_med_img.Image = img_med;
                }
            }
        }
    }
}
