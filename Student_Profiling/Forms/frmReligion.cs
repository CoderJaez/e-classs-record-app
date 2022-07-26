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
    public partial class frmReligion : Form
    {
        AdmissionModel admModel = new AdmissionModel();
        ucAdmission admUserControl;
        public frmReligion(ucAdmission uc)
        {
            admUserControl = uc;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReligion_Load(object sender, EventArgs e)
        {
            loadReligion();
        }

        private void loadReligion()
        {
            dgReligion.DataSource = admModel.getReligion(SearchTxt.Text);
            dgReligion.Columns["id"].Visible = false;
            dgReligion.Columns["Religion"].HeaderText = "Description";
            dgReligion.Columns["Religion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            loadReligion();
        }

        private void dgReligion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string id = dgReligion.Rows[e.RowIndex].Cells[0].Value.ToString();
                string religion = dgReligion.Rows[e.RowIndex].Cells[1].Value.ToString();
                admUserControl.getReligion(id, religion);
                this.Close();
            }
        }

        private void dgReligion_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgReligion.Cursor = Cursors.Hand;
                dgReligion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(184, 15, 10);
                dgReligion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            }
        }

        private void dgReligion_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgReligion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgReligion.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
