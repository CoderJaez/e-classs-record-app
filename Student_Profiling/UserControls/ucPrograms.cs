using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling
{
    public partial class ucPrograms : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        Programs_m prg = new Programs_m();
        program pr = new program();
        private int totalRows = 0;
        private int filteredRow = 0;
        private int start = 0;
        private int limit = 15;
        private int page = 1;
        public ucPrograms()
        {
            InitializeComponent();
            btnPrev.Enabled = false;
            lblPage.Text = page.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                using (frmPrograms prg = new frmPrograms(this, false))
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
                    prg.Owner = FormBackground;
                    prg.ShowDialog();
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
            totalRows = prg.totalRows();
            var utils = new frmUtility();
            if(tbSearch.Text == "")
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
            } else
            {
                filteredRow = prg.filtered_data();
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
            dgProgramList.DataSource = prg.getProgramlist(limit,start,tbSearch.Text);
            dgProgramList.Columns["ID"].Visible = false;
            dgProgramList.Columns["Programs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            utils.DataGridActionButtons(dgProgramList);
            
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            start -= limit;
            page -= 1;
            btnNext.Enabled = true;
            if(start <= 0)
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

        private void dgProgramList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {

                    case 2:
                        if (Convert.ToBoolean(dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                            dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                        else
                            dgProgramList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        break;
                    case 3://EDIT
                        pr.Programs = dgProgramList.Rows[e.RowIndex].Cells[1].Value.ToString();
                        pr.ID = dgProgramList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmPrograms prg = new frmPrograms(this,true,pr.ID, pr.Programs);
                        prg.ShowDialog();
                        break;
                    case 4://DELETE
                        pr.ID = dgProgramList.Rows[e.RowIndex].Cells[0].Value.ToString();
                        deleteProgram(pr.ID);
                        checkTotalRows();
                        break;
                    default:
                        break;

                }
            }
        }

        private void deleteProgram(string colCode)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected Program?","WMSU-ESU PAGADIAN",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (prg.deleteProgram(colCode))
                    MessageBox.Show("Selected Program deleted.", "WMSU-ESU PAGADIAN");
            }
        }
        private void checkTotalRows()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int toDelete = 0;
            for(int x = 0;x < dgProgramList.Rows.Count; x++)
            {
                if (Convert.ToBoolean(dgProgramList.Rows[x].Cells[2].Value) == true)
                    toDelete += 1;
            }

            if (toDelete > 0)
            {
                 List<string> id = new List<string>();
                DialogResult result = MessageBox.Show("Do you want to delete selected Program?", "WMSU-ESU PAGADIAN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ;

                if(result == DialogResult.Yes)
                {
                    for (int x = 0; x < dgProgramList.Rows.Count; x++)
                    {
                        if (Convert.ToBoolean(dgProgramList.Rows[x].Cells[2].Value) == true)
                        {
                            id.Add(dgProgramList.Rows[x].Cells[0].Value.ToString());
                        }
                    }

                    if (prg.deleteProgramBatch(id))
                    {
                        MessageBox.Show("Selected Programs deleted.", "WMSU-ESU PAGADIAN");
                        checkTotalRows();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            loadProgramList();
        }
    }
}
