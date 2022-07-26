using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Student_Profiling
{
    class frmUtility
    {
        public void DataGridActionButtons(DataGridView dg)
        {
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "";
            checkbox.Name = "checkbox";
            checkbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            checkbox.DisplayIndex = 0;
            dg.Columns.Add(checkbox);
            DataGridViewImageColumn Edit = new DataGridViewImageColumn();
            Edit.HeaderText = "";
            Edit.Name = "edit";
            Edit.ToolTipText = "EDIT";
            Edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Edit.Image = Properties.Resources.icons8_edit_16;
            DataGridViewImageColumn Delete = new DataGridViewImageColumn();
            Delete.HeaderText = "";
            Delete.Name = "delete";
            Delete.ToolTipText = "DELETE";
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Delete.Image = Properties.Resources.icons8_Trash_16;
            dg.Columns.Add(Edit);
            dg.Columns.Add(Delete);
        }
    }
}
