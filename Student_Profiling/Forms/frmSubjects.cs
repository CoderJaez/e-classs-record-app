using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Validations;
using Student_Profiling.Models;
using FluentValidation.Results;
using Student_Profiling.Objects;

namespace Student_Profiling
{
    public partial class frmSubjects : Form
    {
        Subject subj = new Subject();
        SubjectModel subjModel = new SubjectModel();
        private bool forUpdate;
        public frmSubjects(string CourseCode,bool update)
        {
            subj.CourseCode = CourseCode;
            forUpdate = update;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = null;
            subj.SubjectCode = SubjCodeText.Text;
            subj.Description = SubjectDescText.Text;
            subj.Lab = LabText.Text;
            subj.Lecture = LectureText.Text;
            subj.year = yearCB.Text;
            subj.sem = semCB.Text;
            var rules = new SubjectValidition(subj.SubjectID);
            var results = rules.Validate(subj);

            if (results.IsValid == false)
            {
                foreach (ValidationFailure error in results.Errors)
                    msg += $"{error.ErrorMessage}\n";
                MessageBox.Show(msg, "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (forUpdate)
            {
                if (subjModel.update(subj))
                    MessageBox.Show("Updated Successfully", "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                subj.SubjectID = $"{subj.CourseCode}{subjModel.GetSubjetID(subj.CourseCode)}";
                subj.SubjectID = subj.SubjectID.Replace(" ","");
                if(subjModel.insert(subj))
                    MessageBox.Show("Registered Successfully", "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SubjCodeText.Focus();
            }
            clearForm();
            LoadSubjectList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            SubjectBox.Enabled = true;
            SubjCodeText.Focus();
            btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SubjectBox.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            clearForm();
        }

        private void clearForm()
        {
            foreach (Control cntrl in SubjectBox.Controls)
            {
                if(cntrl.GetType() == typeof(TextBox))
                {
                    cntrl.Text = null;
                }
            }
            LectureText.Text = null;
            LabText.Text = null;
            forUpdate = false;

        }

        public void LoadSubjectList()
        {
            var util = new frmUtility();
            subjectList.Columns.Clear();
            subjectList.DataSource = subjModel.getListOfSubjects(subj.CourseCode, Search.Text);
            subjectList.Columns["SubjectID"].Visible = false;
            subjectList.Columns["CourseCode"].Visible = false;
            subjectList.Columns["Lecture"].Visible = false;
            subjectList.Columns["Lab"].Visible = false;
            subjectList.Columns["year"].Visible = false;
            subjectList.Columns["sem"].Visible = false;

            subjectList.Columns["SubjectCode"].HeaderText = "Subject Code";
            subjectList.Columns["SubjectCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            subjectList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            util.DataGridActionButtons(subjectList);

        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            LoadSubjectList();
        }

        private void subjectList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (subjectList.Columns[e.ColumnIndex].Name)
                {

                    case "checkbox":
                        if (Convert.ToBoolean(subjectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                            subjectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        else
                            subjectList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;

                        break;
                    case "edit":
                        forUpdate = true;
                        subj.SubjectID = subjectList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        SubjCodeText.Text = subjectList.Rows[e.RowIndex].Cells[1].Value.ToString(); ;
                        SubjectDescText.Text = subjectList.Rows[e.RowIndex].Cells[3].Value.ToString();
                        LectureText.Text = subjectList.Rows[e.RowIndex].Cells[4].Value.ToString();
                        LabText.Text = subjectList.Rows[e.RowIndex].Cells[5].Value.ToString();
                        yearCB.Text = subjectList.Rows[e.RowIndex].Cells[6].Value.ToString();
                        semCB.Text = subjectList.Rows[e.RowIndex].Cells[7].Value.ToString();
                        SubjectBox.Enabled = true;
                        btnNew.Enabled = false;
                        btnSave.Enabled = true;
                        break;
                    case "delete":
                        subj.SubjectID = subjectList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        DialogResult result = MessageBox.Show("Do want to delete selected row?", "WMSU-ESU PAGADIAN CITY", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                            if (subjModel.delete(subj.SubjectID))
                                MessageBox.Show("Selected Row deleted", "WMSU-ESU PAGADIAN");
                        LoadSubjectList();
                        break;

                }
            }
        }

        private void frmSubjects_Load(object sender, EventArgs e)
        {
            SubjectTxt.Text = $"Subject ({subj.CourseCode.ToUpper()})";
            LoadSubjectList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int toDelete = 0;
            for (int x = 0; x < subjectList.Rows.Count; x++)
            {
                if (Convert.ToBoolean(subjectList.Rows[x].Cells[8].Value) == true)
                    toDelete += 1;
            }

            if (toDelete > 0)
            {
                List<string> id = new List<string>();
                DialogResult result = MessageBox.Show("Do you want to delete selected row/s?", "WMSU-ESU PAGADIAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    for (int x = 0; x < subjectList.Rows.Count; x++)
                    {
                        if (Convert.ToBoolean(subjectList.Rows[x].Cells[8].Value) == true)
                        {
                            id.Add(subjectList.Rows[x].Cells[0].Value.ToString());
                        }
                    }

                    if (subjModel.deleteBatch(id))
                    {
                        MessageBox.Show("Selected row/s deleted.", "WMSU-ESU PAGADIAN");
                        LoadSubjectList();
                    }
                }
                else
                {
                    for (int x = 0; x < subjectList.Rows.Count; x++)
                    {
                        subjectList.Rows[x].Cells[7].Value = false;
                    }

                }
            }
        }
    }
}
