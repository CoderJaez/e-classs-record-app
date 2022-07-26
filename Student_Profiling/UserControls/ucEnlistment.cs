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
using Student_Profiling.Objects;
using System.IO;

namespace Student_Profiling
{
    public partial class ucEnlistment : UserControl
    {
        internal static ucEnlistment enlistment; //UserControl
        StudentEnlistment studEnlist = new StudentEnlistment(); //OBJECT;
        EnlistmentModel enlistModel = new EnlistmentModel(); //MODEL
        SchoolYearModel syModel = new SchoolYearModel(); 
        private string syID = null;
        private int _TotalUnits = 0;
        private bool ForUpdate = false;

        public ucEnlistment()
        {
            enlistment = this;
            InitializeComponent();
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmSearchStudent search = new frmSearchStudent("Enlistment"))
                {
                    Form FormBackground = new Form();
                    FormBackground.StartPosition = FormStartPosition.Manual;
                    FormBackground.FormBorderStyle = FormBorderStyle.None;
                    FormBackground.Opacity = .70d;
                    FormBackground.BackColor = Color.Black;
                    FormBackground.WindowState = FormWindowState.Maximized;
                    FormBackground.TopMost = false;
                    FormBackground.Location = this.Location;
                    FormBackground.ShowInTaskbar = false;
                    FormBackground.Show();
                    search.Owner = FormBackground;
                    search.ShowDialog();
                    FormBackground.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getStudentInfo(string StudID)
        {
            studEnlist = enlistModel.GetStudentEnlistedInfo(StudID);
            if (!string.IsNullOrWhiteSpace(studEnlist.StudentID))
            {
                btnModify.Enabled = true;
                ForUpdate = true;
                StudIDTxt.Text = studEnlist.StudentID;
                StudentNameTxt.Text = studEnlist.StudentName;
                CourseTxt.Text = studEnlist.Course;
                YearLevelTxt.Text = studEnlist.Level;
                CourseTxt.Text = studEnlist.Course;
                try
                {
                    MemoryStream ms = new MemoryStream(studEnlist.img);
                    StudentPicture.BackgroundImage = Image.FromStream(ms);
                }
                catch (Exception)
                {

                }
                dgStudent.Rows.Clear();
                foreach (DataRow row in studEnlist.SubjectList.Rows)
                {
                    dgStudent.Rows.Add(row["subjID"].ToString(), row["subjCode"].ToString(), row["subjDesc"].ToString(), row["lab"].ToString(), row["lec"].ToString());
                    if ((bool)row["posted"])
                    {
                        btnModify.Enabled = false;
                        continue;
                    }
                }
                CountTotalUnits();
                btnLoadSubject.Enabled = false;
                Delete.Visible = false;
            } else
            {
                ForUpdate = false;
                studEnlist = enlistModel.GetNewStudentInfoForEnlistment(StudID);
                StudIDTxt.Text = studEnlist.StudentID;
                StudentNameTxt.Text = studEnlist.StudentName;
                CourseTxt.Text = studEnlist.Course;
                YearLevelTxt.Text = null;
                dgStudent.Rows.Clear();

                try
                {
                    MemoryStream ms = new MemoryStream(studEnlist.img);
                    StudentPicture.BackgroundImage = Image.FromStream(ms);
                }
                catch (Exception)
                {

                }
            }
            btnLoadSubject.Enabled = true;
        }

        private void LoadSchoolYear()
        {
            var sy = syModel.GetCurSchoolYear();
            SchoolYearTxt.Text = sy.SchoolYear;
            SemTxt.Text = sy.Sem;
            syID = sy.syID;
        }

        private void btnLoadSubject_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmSubjectList subj = new frmSubjectList(SemTxt.Text))
                {
                    Form FormBackground = new Form();
                    FormBackground.StartPosition = FormStartPosition.Manual;
                    FormBackground.FormBorderStyle = FormBorderStyle.None;
                    FormBackground.Opacity = .70d;
                    FormBackground.BackColor = Color.Black;
                    FormBackground.WindowState = FormWindowState.Maximized;
                    FormBackground.TopMost = false;
                    FormBackground.Location = this.Location;
                    FormBackground.ShowInTaskbar = false;
                    FormBackground.Show();
                    subj.Owner = FormBackground;
                    subj.ShowDialog();
                    FormBackground.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSubjectList(IList<Subject> SubjList)
        {
            foreach (var subj in SubjList)
            {
                dgStudent.Rows.Add(subj.SubjectID, subj.SubjectCode, subj.Description, subj.Lab, subj.Lecture);
            }

            //REMOVE THE DUPLICATE ROWS
            for (int currentRow = 0; currentRow < dgStudent.Rows.Count; currentRow++)
            {
                var rowToCompare = dgStudent.Rows[currentRow];

                foreach (DataGridViewRow row in dgStudent.Rows)
                {
                    if (rowToCompare.Equals(row))
                        continue;

                    bool duplicate = true;
                    if (rowToCompare.Cells["SubjectID"].Value.ToString() != row.Cells["SubjectID"].Value.ToString())
                        duplicate = false;

                    if (duplicate)
                        dgStudent.Rows.Remove(row);
                }
            }
            CountTotalUnits();
        }

        //Get the total Units
        private void CountTotalUnits()
        {
            _TotalUnits = 0;
            foreach (DataGridViewRow row in dgStudent.Rows)
            {
                _TotalUnits += Convert.ToInt32(row.Cells["Lab"].Value.ToString()) + Convert.ToInt32(row.Cells["Lecture"].Value.ToString());
            }

            TotalUnits.Text = _TotalUnits.ToString();

        }

        //Delete Rows if the Delete Icon is Clicked
        private void dgStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgStudent.Columns[e.ColumnIndex].Name == "Delete")
                {
                    dgStudent.Rows.RemoveAt(e.RowIndex);
                    CountTotalUnits();
                }
            }
        }

        public void EnableSaveEnlist()
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgStudent.Rows.Count == 0 || string.IsNullOrEmpty(YearLevelTxt.Text))
            {
                MessageBox.Show("Subject Load and Year Level required.");
                return;
            }
            EnlistStudent();
        }


        private void EnlistStudent()
        {
            DataTable SubjectList = new DataTable();
            SubjectList.Columns.Add("SubjectID");
            SubjectList.Columns.Add("StudentID");
            foreach (DataGridViewRow row in dgStudent.Rows)
            {
                SubjectList.Rows.Add(row.Cells["SubjectID"].Value.ToString(), studEnlist.StudentID);
            }
            studEnlist.YearLevel = YearLevelTxt.Text;
            studEnlist.Sem = SemTxt.Text;
            studEnlist.TotalCredits = TotalUnits.Text;
            studEnlist.SubjectList = SubjectList;
            studEnlist.syID = syID;
           if(ForUpdate)
            {
                if(enlistModel.UpdateEnlistStudent(studEnlist))
                    MessageBox.Show("Student updated.", "WMSU-ESU PAGADIAN");
            } else
            {
                if (enlistModel.EnlistNewStudent(studEnlist))
                    MessageBox.Show("New Student enlisted.", "WMSU-ESU PAGADIAN");
            }
            ClearForm();
        }

        private void YearLevelTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void ClearForm()
        {
            dgStudent.Rows.Clear();
            StudIDTxt.Text = null;
            StudentNameTxt.Text = null;
            YearLevelTxt.Text = null;
            StudentPicture.BackgroundImage = Properties.Resources.Manager_96px;
            btnLoadSubject.Enabled = false;
            btnSave.Enabled = false;
            ForUpdate = false;
        }

        private void ucEnlistment_Load(object sender, EventArgs e)
        {
            LoadSchoolYear();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Delete.Visible = true;
            btnSave.Enabled = true;
            btnLoadSubject.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
