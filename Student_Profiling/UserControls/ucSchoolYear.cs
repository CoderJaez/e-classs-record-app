using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Models;
using FluentValidation.Results;
using Student_Profiling.Validations;

namespace Student_Profiling
{
    public partial class ucSchoolYear : UserControl
    {
        SchoolYearObj sy = new SchoolYearObj();
        SchoolYearModel syModel = new SchoolYearModel();
        private bool forUpdate = false;

        public ucSchoolYear()
        {
            InitializeComponent();
        }

        public void LoadSchoolYear()
        {
            int n = 0;
            syList.Rows.Clear();
            foreach(DataRow row in syModel.GetSchoolerYearList().Rows)
            {   
                
                syList.Rows.Add(row["syID"].ToString(), row["status"], row["description"].ToString(),row["sem"].ToString());
                if ((bool)row["status"])
                    syList.Rows[n].Cells["setStatus"].Value = Properties.Resources.icons8_open_sign_32;
                n++;
            }
        }

        private void ucSchoolYear_Load(object sender, EventArgs e)
        {
            LoadSchoolYear();
        }

        private void syList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (e.ColumnIndex >= 2)
                    syList.Cursor = Cursors.Hand;
                else
                    syList.Cursor = Cursors.Default;
        }

        private void btnSaveAdmission_Click(object sender, EventArgs e)
        {
            string msg = null;
            sy.SchoolYear = SchoolYearTxt.Text;
            sy.Sem = SemCB.Text;
            SchoolYearValidation rules = new SchoolYearValidation();
            var results = rules.Validate(sy);
            if (results.IsValid == false)
            {
                foreach (ValidationFailure error in results.Errors)
                    msg += $"{error.ErrorMessage}\n";
                MessageBox.Show(msg, "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!forUpdate)
            {
                if (syModel.insert(sy))
                    MessageBox.Show("New School Year recorded.", "WMSU-ESU PAGADIAN");
            } else
            {
                if (syModel.update(sy))
                    MessageBox.Show("School Year updated.", "WMSU-ESU PAGADIAN");
                forUpdate = false;
            }
                

            LoadSchoolYear();
        }

        private void syList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = new DialogResult();
            if (e.RowIndex >= 0)
            {
                switch(syList.Columns[e.ColumnIndex].Name)
                {
                    case "setStatus":
                        bool status = (bool)syList.Rows[e.RowIndex].Cells["status"].Value;
                        result = MessageBox.Show((status) ? "Close School Year?" : "Open School Year?" ,"WMSU-ESU PAGADIAN",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(result == DialogResult.Yes)
                        {
                            if (!status)
                            {
                                if (syModel.SetActiveSY(syList.Rows[e.RowIndex].Cells["syID"].Value.ToString()))
                                    MessageBox.Show("The School Year is now Open");
                            }
                           else
                            {
                                if (syModel.SetDeativeSY(syList.Rows[e.RowIndex].Cells["syID"].Value.ToString()))
                                    MessageBox.Show("The School Year is now Close");
                            }
                                
                            LoadSchoolYear();
                        }
                        break;

                    case "edit":
                        SchoolYearTxt.Text = syList.Rows[e.RowIndex].Cells["SchoolYear"].Value.ToString();
                        SemCB.Text = syList.Rows[e.RowIndex].Cells["Sem"].Value.ToString();
                        sy.syID = syList.Rows[e.RowIndex].Cells["syID"].Value.ToString();
                        forUpdate = true;
                        break;
                    case "delete":
                         result = MessageBox.Show("Do you to delete selected row?", "WMSU-ESU PAGADIAN", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                            if(syModel.delete(syList.Rows[e.RowIndex].Cells["syID"].Value.ToString()))
                            {
                                MessageBox.Show("Selected Row deleted.");
                                syList.Rows.RemoveAt(e.RowIndex); 
                            }
                        }
                        break;

                }
            }
        }

        private void ClearForm()
        {
            SchoolYearTxt.Text = null;
            SemCB.Text = "";
        }
    }
}
