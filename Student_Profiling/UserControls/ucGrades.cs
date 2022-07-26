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

namespace Student_Profiling
{
    public partial class ucGrades : UserControl
    {
        StudentGradeModel gradeModel = new StudentGradeModel();
        private string[] AcceptableGradeRating = new string[] { "1.00", "1.25", "1.50", "1.75", "2.00", "1.25", "2.50", "2.75", "3.00","5.00", "INC", "DRP" };
        public ucGrades()
        {
            InitializeComponent();
        }

        private void YearCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(YearCB.Text))
                CourseCodeCB.Enabled = true;
        }

        private void CourseCodeCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CourseCodeCB.Text))
                SemCB.Enabled = true;
        }

       

        private void ucGrades_Load(object sender, EventArgs e)
        {
            LoadCourse();
        }

        private void btnLoadStudent_Click(object sender, EventArgs e)
        {
            LoadStudentList();
            btnSave.Enabled = true;
        }

        private void SemCB_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(SemCB.Text))
            {
                SubjectCodeCB.Enabled = true;
                LoadSubjectList();
            }
        }

        private void SubjectCode_SelectedValueChanged(object sender, EventArgs e)
        {
            btnLoadStudent.Enabled = true;
           // MessageBox.Show(SubjectCodeCB.SelectedValue.ToString());
        }


        //USER DEFINED METHODS
        private void LoadCourse()
        {
            foreach (var row in gradeModel.CourseList())
            {
                CourseCodeCB.Items.Add(row);
            }
        }

        //USER DEFINED METHODS
        private void AssessGrade(string _grade, DataGridView Cell)
        {
            if (Convert.ToDouble(_grade) <= 3.0 && Convert.ToDouble(_grade) >= 1.0)
            {
                Cell.CurrentRow.Cells["Remarks"].Value = "PASSED";
            }
            else
            {
                Cell.CurrentRow.Cells["Remarks"].Value = "FAILED";
            }
        }
        private void SubmitGrade()
        {
            List<string> GradeRatingList = new List<string>();
            List<string> Remarks = new List<string>();
            List<string> id = new List<string>();
            for (int i = 0; i < dgStudentList.Rows.Count; i++)
            {
                Remarks.Add($"WHEN {dgStudentList.Rows[i].Cells["id"].Value.ToString()} THEN '{dgStudentList.Rows[i].Cells["Remarks"].Value.ToString()}'");
                GradeRatingList.Add($"WHEN {dgStudentList.Rows[i].Cells["id"].Value.ToString()} THEN '{dgStudentList.Rows[i].Cells["Grade"].Value.ToString()}'");
                id.Add(dgStudentList.Rows[i].Cells["id"].Value.ToString());
            }
            if (gradeModel.SaveGradeRating(GradeRatingList, Remarks, id))
                MessageBox.Show("Grade successfully submitted");
        }

    

        private void LoadSubjectList()
        {
            SubjectCodeCB.DisplayMember = "Text";
            SubjectCodeCB.ValueMember = "Value";
            string _where = $"year = {YearCB.Text} AND courseCode = '{CourseCodeCB.Text}' AND sem = '{SemCB.Text}'";
            SubjectCodeCB.DataSource = gradeModel.LoadSubjectList(_where);

        }

        private void LoadStudentList()
        {

            SubjectDescLabel.Text = gradeModel.GetSubjectDescription(SubjectCodeCB.Text);
            dgStudentList.Rows.Clear();
            foreach(DataRow row in gradeModel.LoadStudentSubject(SubjectCodeCB.SelectedValue.ToString()).Rows)
            {
                dgStudentList.Rows.Add(row["id"].ToString(), row["studID"].ToString(), row["StudentName"].ToString(),row["grade"].ToString(), row["remark"].ToString());
            }
        }

        private void dgStudentList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dgStudentList_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgStudentList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Grade_KeyPress);
            if(dgStudentList.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if(tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Grade_KeyPress);
                }
                
            }
        }

      

        private void Grade_KeyPress(object sender, KeyPressEventArgs e)
        {

            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

       

        private void dgStudentList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string grade = null;
            try { grade = dgStudentList.CurrentCell.Value.ToString();} catch {  }
            if (!string.IsNullOrEmpty(grade))
            {
                try
                {
                    if (!AcceptableGradeRating.Contains(Convert.ToDouble(grade).ToString("N")))
                    {
                        MessageBox.Show("Not a valid Grade Rating");
                        dgStudentList.CurrentCell.Value = null;
                        dgStudentList.CurrentRow.Cells["Remarks"].Value = null;
                        return;
                    }
                }
                catch {
                    dgStudentList.CurrentCell.Value = null;
                    dgStudentList.CurrentRow.Cells["Remarks"].Value = null;
                }
            }
            dgStudentList.CurrentCell.Value = Convert.ToDouble(dgStudentList.CurrentCell.Value).ToString("N");
            AssessGrade(grade, dgStudentList);

        }


       

        private void dgStudentList_KeyDown(object sender, KeyEventArgs e)
        {
            if(dgStudentList.CurrentCell.ColumnIndex == 3)
            {
                if(e.Alt == true && e.KeyCode == Keys.C)
                {
                    dgStudentList.CurrentCell.Value = "INC";
                    dgStudentList.CurrentRow.Cells["Remarks"].Value = "LACK OF REQUIREMENTS";
                }
                if (e.Alt == true && e.KeyCode == Keys.V)
                {
                    dgStudentList.CurrentCell.Value = "DRP";
                    dgStudentList.CurrentRow.Cells["Remarks"].Value = "DROPPED";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           if(dgStudentList.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Please Click OK to proceed.","WMSU-ESU PAGADIAN", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                if(result == DialogResult.OK)
                    SubmitGrade();
            }
        }



    }
}
