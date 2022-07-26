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
    public partial class frmAddress : Form
    {
        ucAdmission admission;
         AdmissionModel adm = new AdmissionModel();
        private string locType;
        public frmAddress(ucAdmission adm)
        {
            InitializeComponent();
            admission = adm;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void loadLocation(string _locType,string code = null)
        {
            dgLocation.Columns.Clear();
            locType = _locType;
            switch (locType)
            {
                case "brgy":
                    lblDescription.Text = "Barangay";
                    dgLocation.DataSource = adm.getBrgy(code);
                    break;
                case "citymun":
                    lblDescription.Text = "City/Municipality";
                    dgLocation.DataSource = adm.getCityMun(code);
                    break;
                case "prov":
                    lblDescription.Text = "Province";
                    dgLocation.DataSource = adm.getProvince();
                    break;
                case "course":
                    lblDescription.Text = "Course Available";
                    dgLocation.DataSource = adm.getCourse();
                    break;
            }
            if(locType == "course")
            {
                dgLocation.Columns["CourseCode"].HeaderText = "Code";
                dgLocation.Columns["CourseCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                dgLocation.Columns["Course"].HeaderText = "Description";
                dgLocation.Columns["Course"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            } else
            {
                dgLocation.Columns["code"].Visible = false;
                dgLocation.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                switch (locType)
                {
                    case "brgy":
                        admission.brgyCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        admission.brgyDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case "citymun":
                        admission.citymunCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        admission.citymunDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case "prov":
                        admission.provCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        admission.provDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                    case "course":
                        admission.CourseCode = dgLocation.Rows[e.RowIndex].Cells[0].Value.ToString();
                        admission.CourseDesc = dgLocation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        break;
                }
                this.Close();
            }
        }

        private void dgLocation_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgLocation.Cursor = Cursors.Hand;
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(184, 15, 10);
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }
        }

        private void dgLocation_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgLocation.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
