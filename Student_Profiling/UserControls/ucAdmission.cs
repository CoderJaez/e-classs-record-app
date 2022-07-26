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
using Student_Profiling.Validations;
using FluentValidation.Results;
using System.IO;
using Student_Profiling.Objects;
namespace Student_Profiling
{
    public partial class ucAdmission : UserControl
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
        Student stud = new Student();
        AdmissionModel adm = new AdmissionModel();
        public string brgyCode { get { return lblbrgyCode.Tag.ToString(); } set { lblbrgyCode.Tag = value; } }
        public string citymunCode { get { return lblcitymunCode.Tag.ToString(); } set { lblcitymunCode.Tag = value; } }
        public string provCode { get { return lblprovCode.Tag.ToString(); } set { lblprovCode.Tag = value; } }
        public string CourseCode { set { CourseCodeTxt.Tag = value; } }

        public string brgyDesc {  set { lblbrgyCode.Text = value; } }
        public string citymunDesc {  set { lblcitymunCode.Text = value; } }
        public string provDesc {  set { lblprovCode.Text = value; } }

        public string CourseDesc { set { CourseCodeTxt.Text = value; } }
        public bool forUpdate = false;
        internal static ucAdmission admission;
        public ucAdmission()
        {
            InitializeComponent();
            admission = this;
        }

      



        private void btnSaveAdmission_Click(object sender, EventArgs e)
        {
            stud.StudID = (!forUpdate)? adm.getStudID():stud.StudID;
            stud.FirstName = tbFname.Text;
            stud.LastName = tbLname.Text;
            stud.MI = tbmi.Text;
            stud.DateOfBirth = dpDob.Value;
            stud.Gender = cbGender.Text;
            stud.PlaceOfBirth = tbPob.Text;
            stud.ContactNo = tbContactNo.Text;
            stud.Course = CourseCodeTxt.Text;
            stud.Religion = lblReligion.Text;
            stud.Email = tbEmail.Text;
            stud.Address = tbAddress.Text;
            stud.CourseMajor = MajorTxt.Text;
            stud.Barangay = lblbrgyCode.Text;
            stud.CityMunicipality = lblcitymunCode.Text;
            stud.Province = lblprovCode.Text;
            stud.year = YearCB.Text;
            stud.Course = CourseCodeTxt.Text;
            stud.CourseMajor = MajorTxt.Text;
            stud.FatherName = FatherNameTxt.Text;
            stud.FatherEducAttain = FatherEduAttainTxt.Text;
            stud.FatherOccupation = FatherOccupation.Text;
            stud.MotherName = MotherNameTxt.Text;
            stud.MotherEducAttain = MotherEducAttainTxt.Text;
            stud.MotherOccupation = MotherOccupation.Text;
            stud.GuardianName = GuardianNameTxt.Text;
            stud.GuardianRelation = GuardianRelation.Text;
            stud.ParentsAddress = ParentAddress.Text;
            stud.ParentsContactNo = ParentContactNo.Text;
            MemoryStream mstream = new MemoryStream();
            StudentPictureBox.BackgroundImage.Save(mstream, StudentPictureBox.BackgroundImage.RawFormat);
            stud.image = mstream.GetBuffer();
            mstream.Close();

            AdmissionValidition validator = new AdmissionValidition();
            var result = validator.Validate(stud);
            if(result.IsValid == false)
            {
                string msg = null;
                foreach (ValidationFailure error in result.Errors)
                    msg += $"{error.ErrorMessage} \n";
                MessageBox.Show(msg, "WMSU-ESU PAGADIAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            stud.CourseCode = CourseCodeTxt.Tag.ToString();
            stud.brgyCode = brgyCode;
            stud.citymunCode = citymunCode;
            stud.provCode = provCode;

            if (forUpdate)
            {
                if(adm.update(stud))
                    MessageBox.Show("Student Information updated.", "WMSU-ESU PAGADIAN!");
            }
            else
                if(adm.insert(stud))
                MessageBox.Show("New student registered.", "WMSU-ESU PAGADIAN!");
            clearForm();
        }



        private void tbnProvCode_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                using (frmAddress addr = new frmAddress(this))
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
                    addr.Owner = FormBackground;
                    addr.loadLocation("prov");
                    addr.ShowDialog();
                    FormBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCitymunCode_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                if (string.IsNullOrWhiteSpace(lblprovCode.Text))
                {
                    MessageBox.Show("No Province is selected.", "WMSU-ESU PAGADIAN");
                }
                else
                {
                    using (frmAddress addr = new frmAddress(this))
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
                        addr.Owner = FormBackground;
                        addr.loadLocation("citymun", provCode);
                        addr.ShowDialog();
                        FormBackground.Dispose();
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnBrgy_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                if (string.IsNullOrWhiteSpace(lblcitymunCode.Text))
                {
                    MessageBox.Show("No City/Municipality is selected.", "WMSU-ESU PAGADIAN");
                }
                else
                {
                    using (frmAddress addr = new frmAddress(this))
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
                        addr.Owner = FormBackground;
                        addr.loadLocation("brgy", citymunCode);
                        addr.ShowDialog();
                        FormBackground.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSaveAdmission.Enabled = false;
            btnNewAdmission.Enabled = true;
            lblStudID.Text = null;
            clearForm();
        }

        private void btnReligion_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                using (frmReligion rel = new frmReligion(this))
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
                    rel.Owner = FormBackground;
                    rel.ShowDialog();
                    FormBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        public void getReligion(string id,string religion)
        {
            stud.religionID = id;
            lblReligion.Text = religion;
        }

        private void btnNewAdmission_Click(object sender, EventArgs e)
        {
            forUpdate = false;
            btnSaveAdmission.Enabled = true;
           
            btnNewAdmission.Enabled = false;
            tbLname.Focus();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            frmAddress addr = new frmAddress(this);
            addr.loadLocation("course");
            addr.ShowDialog();
        }

        private void clearForm()
        {
            forUpdate = false;
            btnNewAdmission.Enabled = true;
            btnSaveAdmission.Enabled = false;
            StudentPictureBox.BackgroundImage = Properties.Resources.Manager_96px;
            foreach (Control ctrl in groupBox1.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;

            foreach (Control ctrl in groupBox3.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;

            foreach (Control ctrl in groupBox4.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;

            foreach (Control ctrl in groupBox7.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;

            foreach (Control ctrl in groupBox8.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;
            foreach (Control ctrl in groupBox9.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;

            foreach (Control ctrl in groupBox10.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Text = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form FormBackground = new Form();
            try
            {
                using(frmSearchStudent search = new frmSearchStudent("Admission"))
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
                    search.Owner = FormBackground;
                    search.ShowDialog();
                    FormBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void DisplayStudentInfo(string StudentID)
        {
            stud = adm.getStudent(StudentID);
            lblStudID.Text = stud.StudID;
            tbFname.Text = stud.FirstName;
            tbLname.Text =  stud.LastName;
            tbmi.Text = stud.MI;
            dpDob.Value = stud.DateOfBirth;
            cbGender.Text = stud.Gender;
            tbPob.Text = stud.PlaceOfBirth;
            tbContactNo.Text = stud.ContactNo;
            CourseCodeTxt.Text = stud.Course;
            lblReligion.Text = stud.Religion;
            tbEmail.Text = stud.Email;
            tbAddress.Text = stud.Address;
            MajorTxt.Text = stud.CourseMajor;
            lblbrgyCode.Text = stud.Barangay;
            lblcitymunCode.Text = stud.CityMunicipality;
            lblprovCode.Text = stud.Province;
            YearCB.Text = stud.year;
            CourseCodeTxt.Text = stud.Course;
            MajorTxt.Text = stud.CourseMajor;
            FatherNameTxt.Text = stud.FatherName;
            FatherEduAttainTxt.Text = stud.FatherEducAttain;
            FatherOccupation.Text = stud.FatherOccupation;
            MotherNameTxt.Text = stud.MotherName;
            MotherEducAttainTxt.Text = stud.MotherEducAttain;
            MotherOccupation.Text = stud.MotherOccupation;
            GuardianNameTxt.Text = stud.GuardianName;
            GuardianRelation.Text = stud.GuardianRelation;
            ParentAddress.Text = stud.ParentsAddress;
            ParentContactNo.Text = stud.ParentsContactNo;
            CourseCodeTxt.Tag = stud.CourseCode;
            brgyCode = stud.brgyCode;
            citymunCode = stud.citymunCode;
            provCode = stud.provCode;
            MemoryStream ms = new MemoryStream(stud.image);
            StudentPictureBox.BackgroundImage = Image.FromStream(ms);
            forUpdate = true ;
            btnNewAdmission.Enabled = false;
            btnSaveAdmission.Enabled = true;

        }

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            PictureFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png) | *.jpg; *.jpeg; *.bmp; *.png";

            if(PictureFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(PictureFileDialog.FileName);
                if (img.Height <= 600 && img.Width <= 600)
                {
                    StudentPictureBox.BackgroundImage = img;
                } else
                {
                    MessageBox.Show("Required Image Size Under (600 x 600) Pixels", "WMSU-ESU PAGADIAN");
                    StudentPictureBox.BackgroundImage = Properties.Resources.Manager_96px;
                }
            }
        }
    }
}
