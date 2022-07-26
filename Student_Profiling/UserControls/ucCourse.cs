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
    public partial class ucCourse : UserControl
    {
        CourseModel courseModel = new CourseModel();
        Course obj = new Course();
        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 15;
        private int page = 1;
        public ucCourse()
        {
            InitializeComponent();
            btnPrev.Enabled = false;
            lblPage.Text = $"{page}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                using (frmCourse course = new frmCourse(this, false, obj))
                {
                    FormBackground.StartPosition = FormStartPosition.Manual;
                    FormBackground.FormBorderStyle = FormBorderStyle.None;
                    FormBackground.Opacity = .70d;
                    FormBackground.BackColor = Color.Black;
                    FormBackground.WindowState = FormWindowState.Maximized;
                    FormBackground.TopMost = true;
                    FormBackground.Location = this.Location;
                    FormBackground.ShowInTaskbar = false;
                    FormBackground.Show();
                    course.Owner = FormBackground;
                    course.ShowDialog();
                    FormBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        public void loadProgramList()
        {
            totalRows = courseModel.totalRows();
            var utils = new frmUtility();
            if (tbSearch.Text == "")
            {

                if (totalRows - start < limit)
                {
                    btnNext.Enabled = false;
                    lblEntries.Text = $"Showing {start + 1} to {totalRows} of {totalRows} entries";
                }
                else {
                    lblEntries.Text = $"Showing {start + 1} to {start + limit} of {totalRows} entries";
                    btnNext.Enabled = true;
                }
            }
            else
            {

                filteredRow = courseModel.filtered_data();
                if (filteredRow - start < limit)
                {
                    btnNext.Enabled = false;
                    lblEntries.Text = $"Showing {start + 1} to {filteredRow} of {filteredRow} entries (Filtered from {totalRows} total entries)";
                }
                else
                {
                    btnNext.Enabled = true;
                    lblEntries.Text = $"Showing {start + 1} to {start + limit} of  {filteredRow} entries (Filtered from {totalRows} total entries)";
                }

            }

            dgProgramList.Columns.Clear();
            dgProgramList.DataSource = courseModel.getCourseList(start,limit, tbSearch.Text);
            dgProgramList.Columns["CourseID"].Visible = false;
            dgProgramList.Columns["CourseCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgProgramList.Columns["CourseCode"].HeaderText = "Course Code";
            dgProgramList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            utils.DataGridActionButtons(dgProgramList);

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            start -= limit;
            page -= 1;
            btnNext.Enabled = true;
            if (start <= 0)
            {
                start = 0;
                page = 1;
                btnPrev.Enabled = false;
            }
            lblPage.Text = page.ToString();
            loadProgramList();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            start += limit;
            page += 1;
            btnPrev.Enabled = true;
            if ((totalRows - start) <= limit)
            {
                btnNext.Enabled = false;
            }
            lblPage.Text = page.ToString();
            loadProgramList();
        }

        public void checkTotalRows()
        {
            loadProgramList();
            if (dgProgramList.Rows.Count <= 0)
            {
                start -= limit;
                page -= 1;
                lblPage.Text = page.ToString();
                loadProgramList();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadProgramList();
        }

      

        private void dgProgramList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

              Form FormBackground = new Form();
            switch(dgProgramList.Columns[e.ColumnIndex].Name)
            {
                case "checkbox":
                    if (Convert.ToBoolean(dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    else
                        dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;

                    break;
                case "edit":
                    obj.CourseID = Convert.ToInt32(dgProgramList.Rows[e.RowIndex].Cells[0].Value);
                    obj.CourseCode = dgProgramList.Rows[e.RowIndex].Cells[1].Value.ToString();
                    obj.Description = dgProgramList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    try
                    {
                        using (frmCourse course = new frmCourse(this, true, obj))
                        {
                            FormBackground.StartPosition = FormStartPosition.Manual;
                            FormBackground.FormBorderStyle = FormBorderStyle.None;
                            FormBackground.Opacity = .70d;
                            FormBackground.BackColor = Color.Black;
                            FormBackground.WindowState = FormWindowState.Maximized;
                            FormBackground.TopMost = true;
                            FormBackground.Location = this.Location;
                            FormBackground.ShowInTaskbar = false;
                            FormBackground.Show();
                            course.Owner = FormBackground;
                            course.ShowDialog();
                            FormBackground.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "delete":
                    obj.CourseID = Convert.ToInt32(dgProgramList.Rows[e.RowIndex].Cells[0].Value);
                    DialogResult result = MessageBox.Show("Do want to delete selected row?","WMSU-ESU PAGADIAN CITY",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                        if (courseModel.delete(obj.CourseID))
                            MessageBox.Show("Selected Row deleted", "WMSU-ESU PAGADIAN");
                    loadProgramList();
                    break;
                case "CourseCode":
                    try
                    {
                        using (frmSubjects subj = new frmSubjects(dgProgramList.Rows[e.RowIndex].Cells["CourseCode"].Value.ToString(), false))
                        {
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
                            FormBackground.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int toDelete = 0;
            for (int x = 0; x < dgProgramList.Rows.Count; x++)
            {
                if (Convert.ToBoolean(dgProgramList.Rows[x].Cells[3].Value) == true)
                    toDelete += 1;
            }

            if (toDelete > 0)
            {
                List<string> id = new List<string>();
                DialogResult result = MessageBox.Show("Do you want to delete selected row/s?", "WMSU-ESU PAGADIAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    for (int x = 0; x < dgProgramList.Rows.Count; x++)
                    {
                        if (Convert.ToBoolean(dgProgramList.Rows[x].Cells[3].Value) == true)
                        {
                            id.Add(dgProgramList.Rows[x].Cells[0].Value.ToString());
                        }
                    }

                    if (courseModel.delete_batch(id))
                    {
                        MessageBox.Show("Selected row/s deleted.", "WMSU-ESU PAGADIAN");
                        checkTotalRows();
                    }
                } else
                {
                    for (int x = 0; x < dgProgramList.Rows.Count; x++)
                    {
                        dgProgramList.Rows[x].Cells[3].Value = false;
                    }

                }
            }
        }

        private void dgProgramList_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgProgramList.Columns[e.ColumnIndex].Name == "CourseCode")
                dgProgramList.Cursor = Cursors.Hand;
            else
                dgProgramList.Cursor = Cursors.Default;

        }
    }
}
