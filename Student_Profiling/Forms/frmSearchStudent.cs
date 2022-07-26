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
    public partial class frmSearchStudent : Form
    {
        //ucAdmission adm;
        AdmissionModel admissionModel = new AdmissionModel();

        string UserControl;
        //public frmSearchStudent(ucAdmission _adm)
        //{
        //    adm = _adm;
        //    InitializeComponent();
        //}

        public frmSearchStudent(string _UserControl)
        {
            UserControl = _UserControl;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgStudent_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgStudent.Cursor = Cursors.Hand;
                dgStudent.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(184, 15, 10);
                dgStudent.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }
        }

        private void dgStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loadStudentList();
            }
        }

        private void loadStudentList()
        {
            dgStudent.DataSource = admissionModel.getStudentList(SearchStudentTxt.Text);
            dgStudent.Columns["StudID"].Visible = false;
            dgStudent.Columns["StudentName"].HeaderText = "Student List";
            dgStudent.Columns["StudentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgStudent_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgStudent.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgStudent.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string StudID = dgStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                switch (UserControl)
                {
                    case "Admission":
                        ucAdmission.admission.DisplayStudentInfo(StudID);
                        break;
                    case "Enlistment":
                        ucEnlistment.enlistment.getStudentInfo(StudID);
                        break;
                }
               
                this.Close();
            }
        }
    }
}
