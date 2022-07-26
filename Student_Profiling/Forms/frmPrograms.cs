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
using FluentValidation.Results;

namespace Student_Profiling
{
    public partial class frmPrograms : Form
    {
        List<string> errorMsg = new List<string>();
        program newPrg = new program();
        Programs_m prg_m = new Programs_m();
        private string colCode;
        private bool forUpdate = false;
        ucPrograms programUC;

        public frmPrograms(ucPrograms prg,bool update,string colcode = null, string colDesc = null)
        {
            InitializeComponent();
            programUC = prg;
            forUpdate = update;
            colCode = (forUpdate) ? colcode : null;
            tbColDesc.Text = (forUpdate) ? colDesc : "";
        }


        //Validation
        private bool textField()
        {
            return (tbColDesc.Text != "") ? true : false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorMsg.Clear();
            string msg = "";
            newPrg.Programs = tbColDesc.Text;
            ProgramValidator rules = new ProgramValidator();
            var results = rules.Validate(newPrg);
            if(results.IsValid == false)
            {
                foreach(ValidationFailure error in results.Errors)
                    msg += $"{error.ErrorMessage}\n"; 
                MessageBox.Show(msg,"WMSU-ESU PAGADIAN",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            
             
            if (forUpdate)
                {
                    newPrg.ID = colCode;
                    if (prg_m.updateProgram(newPrg))
                    {
                        MessageBox.Show("Program Updated", "WMSU-ESU PAGADIAN");
                        tbColDesc.Text = "";
                        forUpdate = false;
                        programUC.loadProgramList();
                    }
                } else
                {
                    newPrg.ID = prg_m.getcolCode();
                    if (prg_m.addProgram(newPrg))
                    {
                        MessageBox.Show("New Program Added","WMSU-ESU PAGADIAN");
                        tbColDesc.Text = "";
                        programUC.loadProgramList();
                       
                    }
                }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
