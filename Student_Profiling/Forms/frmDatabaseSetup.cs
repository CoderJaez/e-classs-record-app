using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling
{
    public partial class frmDatabaseSetup : Form
    {
        public frmDatabaseSetup()
        {
            InitializeComponent();
        }

        private void btnTestCon_Click(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            string conString = $"server= {ServerTxt.Text};user={UserNameTxt.Text};password={PasswordTxt.Text};database={DatabaseTxt.Text};port={PortTxt.Text};";

            if (db.testConnectionDB(conString))
                MessageBox.Show("Database connected.");
            else
                MessageBox.Show("Database not connected.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validate_field())
            {
                Properties.Settings.Default.Server = ServerTxt.Text;
                Properties.Settings.Default.User = UserNameTxt.Text;
                Properties.Settings.Default.Password = PasswordTxt.Text;
                Properties.Settings.Default.Database = DatabaseTxt.Text;
                Properties.Settings.Default.Port = PortTxt.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Database Configuration Saved");
                this.Close();
                //login.Show();
            }
        }

        private bool validate_field()
        {
            if (ServerTxt.Text != "" || UserNameTxt.Text != "" || DatabaseTxt.Text != "" && PortTxt.Text != "")
                return true;
            MessageBox.Show("Please fill up all the required fields.");
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
