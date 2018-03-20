using Ionic.Zip;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SkyBridgeProject.Domain;
using System.Collections;
using SkyBridgeProject.Forms;

namespace SkyBridgeProject
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void UnzipIt()
        {
            string zipFilePath = txtZipFilePath.Text;
            string password = txtPassword.Text;
            try
            {
                Utils.UnzipArchive(zipFilePath, password);
            }
            catch (BadPasswordException)
            {
                MessageBox.Show("Failed to open the .zip file, because of incorrect password.");
                return;
            }
            catch (ZipException)
            {
                MessageBox.Show("This file is not a valid .zip file.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to find a .zip file in the specified path.");
                return;
            }
            MessageBox.Show("Successfully unzipped the file.");
            this.Hide();
            Form detailsForm = new Details();
            detailsForm.Show();
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            if (txtZipFilePath.Text.Equals(string.Empty))
            {
                MessageBox.Show("Please fill in the path to the .zip file.");
            }
            else
            {
                UnzipIt();
            }
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = (chkPassword.Checked);
        }
    }
}
