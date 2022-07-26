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

    public partial class frmMain : Form
    {
        private bool isCollapsed;
        ucDashboard dashboard = new ucDashboard();
        ucSchoolYear sy = new ucSchoolYear();
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            timer1.Start();
            isButtonClicked(btnSettings);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnSettings.Image = Properties.Resources.icons8_collapse_arrow_16;
                collapsePanel.Height -= 10;
                if(collapsePanel.Size == collapsePanel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }

            } else
            {
                btnSettings.Image = Properties.Resources.icons8_expand_arrow_16;
                collapsePanel.Height += 10;
                if (collapsePanel.Size == collapsePanel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

       


        private void isButtonClicked(object btn)
        {
            foreach(Control obj in panelSidebar.Controls)
            {
                if(obj.GetType() == typeof(Button))
                {
                    if(obj == btn)
                    {
                        obj.BackColor = Color.Maroon;
                    } else
                    {
                        obj.BackColor = Color.Black;
                    }
                }
            }

            foreach(Control obj in collapsePanel.Controls)
            {
                if (obj.GetType() == typeof(Button))
                {
                    if (obj == btn)
                    {
                        obj.BackColor = Color.Maroon;
                    }
                    else
                    {
                        obj.BackColor = Color.Black;
                    }
                }
            }


        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            isButtonClicked(btnDashboard);
            isCollapsed = true;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(dashboard);
            dashboard.Dock = DockStyle.Fill;
        }

        private void btnAdmission_Click(object sender, EventArgs e)
        {
            ucAdmission admission = new ucAdmission();
            isButtonClicked(btnAdmission);
            isCollapsed = true;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(admission);
            admission.Dock = DockStyle.Fill;

        }

        private void btnEnlistment_Click(object sender, EventArgs e)
        {
            ucEnlistment enlistment = new ucEnlistment();
            isButtonClicked(btnEnlistment);
            isCollapsed = true;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(enlistment);
            enlistment.Dock = DockStyle.Fill;
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            ucGrades grades = new ucGrades();
            isButtonClicked(btnGrades);
            isCollapsed = true;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(grades);
            grades.Dock = DockStyle.Fill;

        }

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            ucCourse courses = new ucCourse();
            isButtonClicked(btnPrograms);
            isCollapsed = false;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(courses);
            courses.Dock = DockStyle.Fill;
            courses.loadProgramList();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ucUserAccount userAcc = new ucUserAccount();
            isButtonClicked(btnUser);
            isCollapsed = false;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userAcc);
            userAcc.Dock = DockStyle.Fill;
        }

        private void btnMsg_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.login.Visible = true;
            frmLogin.login.Show();
        }

        private void btnSY_Click(object sender, EventArgs e)
        {
            isButtonClicked(btnSY);
            isCollapsed = false;
            timer1.Start();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(sy);
            sy.Dock = DockStyle.Fill;
        }
    }
}
