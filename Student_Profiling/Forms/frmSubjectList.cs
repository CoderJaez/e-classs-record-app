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
using Student_Profiling.Objects;

namespace Student_Profiling
{
    public partial class frmSubjectList : Form
    {
        private string sem = null;
        private string where = null;
        SubjectModel subjModel = new SubjectModel();
        StudentGradeModel studModel = new StudentGradeModel();

        public frmSubjectList(string _sem)
        {
            sem = _sem;
            InitializeComponent();
        }

        private void subjectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(subjectList.Rows[e.RowIndex].Cells["checkbox"].Value))
                    subjectList.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                else
                    subjectList.Rows[e.RowIndex].Cells["checkbox"].Value = true;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubjectList_Load(object sender, EventArgs e)
        {
            LoadSubjectList();
            LoadCourseList();
        }

        private void LoadCourseList()
        {
            CourseCodeCB.Items.Add("");
            foreach (var course in studModel.CourseList())
                CourseCodeCB.Items.Add(course);
        }

        private string _where()
        {
            string _where = "";
            if (CourseCodeCB.Text != "" && YearLevelCB.Text != "" )
                _where = $"AND courseCode = '{CourseCodeCB.Text}' AND year = {YearLevelCB.Text}";
            else if (CourseCodeCB.Text != "")
                _where = $"AND courseCode = '{CourseCodeCB.Text}'";
            else if (YearLevelCB.Text != "")
                _where = $"AND year = {YearLevelCB.Text}";

            return _where;
        }
        private void LoadSubjectList()
        {
            subjectList.Columns.Clear();
            where = _where();
            subjectList.DataSource = subjModel.getSlistOfSubjectsForEnlistment(SearchTxt.Text, where, sem);
            subjectList.Columns["CourseCode"].Visible = false;
            subjectList.Columns["sem"].Visible = false;
            subjectList.Columns["SubjectID"].Visible = false;
            subjectList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            subjectList.Columns["Lab"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            subjectList.Columns["year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            subjectList.Columns["Lecture"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
            cb.Name = "checkbox";
            cb.HeaderText = "";
            cb.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cb.DisplayIndex = 0;
            subjectList.Columns.Add(cb);
        }

        private void SearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadSubjectList();
        }

        private IList<Subject> SubjectList()
        {
            var subjList = new List<Subject>();
            for (int i = 0; i < subjectList.Rows.Count; i++)
            {
                if(Convert.ToBoolean(subjectList.Rows[i].Cells["checkbox"].Value))
                {
                    var subj = new Subject();
                    subj.SubjectID = subjectList.Rows[i].Cells["SubjectID"].Value.ToString();
                    subj.SubjectCode = subjectList.Rows[i].Cells["SubjectCode"].Value.ToString();
                    subj.Description = subjectList.Rows[i].Cells["Description"].Value.ToString();
                    subj.Lab = subjectList.Rows[i].Cells["Lab"].Value.ToString();
                    subj.Lecture = subjectList.Rows[i].Cells["Lecture"].Value.ToString();
                    subjList.Add(subj);
                }
            }

            return subjList;
        }

        private void btnInsertSubj_Click(object sender, EventArgs e)
        {
            ucEnlistment.enlistment.GetSubjectList(SubjectList());
            ucEnlistment.enlistment.EnableSaveEnlist();
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadSubjectList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in subjectList.Rows)
                row.Cells["checkbox"].Value = true;
        }
    }
}
