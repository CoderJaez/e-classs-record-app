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
using Student_Profiling.Validations;
using FluentValidation.Results;

namespace Student_Profiling
{
    public partial class frmCourse : Form
    {
        List<string> errorMsg = new List<string>();
        private bool forUpdate = false;
        private ucCourse crs;
        private CourseModel crsModel = new CourseModel();
        private Course obj = new Course();

        public frmCourse(ucCourse course, bool isUpdate,Course _obj)
        {
            InitializeComponent();
            crs = course;
            if (isUpdate)
            {
                forUpdate = isUpdate;
                obj.CourseID = _obj.CourseID;
                CourseCodeText.Text = _obj.CourseCode;
                DescriptionText.Text = _obj.Description;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorMsg.Clear();
            string msg = null;
            obj.CourseCode = CourseCodeText.Text;
            obj.Description = DescriptionText.Text;
            CourseValidation rules = new CourseValidation(obj.CourseID);
            var results = rules.Validate(obj);
            if (results.IsValid == false)
            {
                foreach (ValidationFailure error in results.Errors)
                    msg += $"{error.ErrorMessage}\n";
                MessageBox.Show(msg, "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (forUpdate)
            {
                if (crsModel.update(obj))
                    MessageBox.Show("Update Successful.", "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                if (crsModel.insert(obj))
                    MessageBox.Show("Registered Successfully.", "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            crs.loadProgramList();
            clearForm();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearForm()
        {
            CourseCodeText.Text = null;
            DescriptionText.Text = null;
            forUpdate = false;
        }
    }
}
