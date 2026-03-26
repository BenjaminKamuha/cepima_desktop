using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AfridaLicenseManager.Models;
using AfridaLicenseManager.Services;
using AfridaLicenseManager.Core;
using AfridaLicenseManager.Utils;

namespace GenerateLicenceAfrida
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tb_gen_license_Click(object sender, EventArgs e)
        {
            try
            {
                License license = new License
                {
                    LicenseId = Guid.NewGuid().ToString(),
                    ClientName = client_name.Text,
                    ProductModel = product_model.Text,
                    MachineFingerprint = MachineFingerprint.Generate(), //machine_fingerprint.Text, 
                    PaidAmount = 250,
                    TotalPrice = 500,
                    IssueDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(1),
                    Activated = false
                };

                if (rd_temporary.Checked) 
                {
                    license.Type = LicenseType.Temporary;
                }

                if (rd_perpetual.Checked)
                {
                    license.Type = LicenseType.Perpetual;
                }

                LicenseGenerator gen = new LicenseGenerator();
                gen.GenerateAndSave(license, @"D:\Licenses\afrida.lic");

                MessageBox.Show("Licence générée avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur génération : " + ex.Message);
            }
        }

       

        //public License RegenerateLicense(License oldLicense, decimal newPayment)
        //{
        //    oldLicense.PaidAmount += newPayment;

        //    if (oldLicense.PaidAmount >= oldLicense.TotalPrice)
        //    {
        //        oldLicense.Type = LicenseType.Perpetual;
        //        oldLicense.ExpiryDate = null;
        //    }
        //    else
        //    {
        //        int daysToAdd = LicensePaymentManager.CalculateAddedDays(newPayment);
        //        oldLicense.ExpiryDate = oldLicense.ExpiryDate.HasValue
        //            ? oldLicense.ExpiryDate.Value.AddDays(daysToAdd)
        //            : DateTime.UtcNow.AddDays(daysToAdd);
        //    }

        //    oldLicense.IssueDate = DateTime.UtcNow;
        //    oldLicense.LicenseId = Guid.NewGuid().ToString();

            

        //    return oldLicense;
        //}

        private void bt_regen_liencese_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Sélectionner un fichier de license";
            dlg.Filter = "Fichier licence (*.lic)|*.lic";
            dlg.Multiselect = false;


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dlg.FileName;

                // Lire et valider la licence sélectionnée
                var reader = new LicenseFileReader();
                License old_license = reader.Read(selectedPath);
                int daysInOldLicense = LicensePaymentManager.GetRemainingDays(old_license);

                LicensePaymentManager.ApplyPayment(old_license, decimal.Parse(tb_new_payment.Text));

                LicenseGenerator gen = new LicenseGenerator();
                gen.GenerateAndSave(old_license, @"D:\Licenses\Afrida.lic");

                MessageBox.Show(
                    old_license.Type == LicenseType.Perpetual
                    ? "From " + daysInOldLicense.ToString() + "To License devenue PERPETUELLE"
                    : "From " + daysInOldLicense.ToString() + "To Nouvelle expiration: " + old_license.ExpiryDate.Value.ToShortDateString()
                    );
            }
        }

        private void SubPan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
