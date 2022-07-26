using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Models;
namespace Student_Profiling
{
    public partial class frmLogin : Form
    {
        UseAuthenticationModel user = new UseAuthenticationModel();
        internal static frmLogin login;
        public frmLogin()
        {
            login = this;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserNameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
              UserAuth();
        }

        private void PassworTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UserAuth();
        }

        private void UserAuth()
        {
            if(UserNameTxt.Text == "" || PassworTxt.Text == "")
            {
                MessageBox.Show("Username / Password is empty.");
                return;
            }

            if(user.ChechUserAcc(UserNameTxt.Text, PassworTxt.Text))
            {
                MessageBox.Show("Login Successful");
                frmMain main = new frmMain();
                main.Show();
                this.Visible = false;
                this.Hide();
                UserNameTxt.Text = null;
                PassworTxt.Text = null;
            } else
            {
                MessageBox.Show("Incorrect Username/Password");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserAuth();
        }

        private void btnSetupDB_Click(object sender, EventArgs e)
        {
            frmDatabaseSetup db = new frmDatabaseSetup();
            db.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DBConnection db = new DBConnection();
            if(!db.isConnected())
            {
                frmDatabaseSetup frmdb = new frmDatabaseSetup();
                frmdb.ShowDialog();
            }
        }
    }
}
