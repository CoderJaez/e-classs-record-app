namespace Student_Profiling
{
    partial class ucGrades
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGrades));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SubjectDescLabel = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SubjectCodeCB = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadStudent = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SemCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CourseCodeCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.YearCB = new System.Windows.Forms.ComboBox();
            this.dgStudentList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.SubjectDescLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 42);
            this.panel1.TabIndex = 8;
            // 
            // SubjectDescLabel
            // 
            this.SubjectDescLabel.AutoSize = true;
            this.SubjectDescLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectDescLabel.Location = new System.Drawing.Point(3, 9);
            this.SubjectDescLabel.Name = "SubjectDescLabel";
            this.SubjectDescLabel.Size = new System.Drawing.Size(0, 25);
            this.SubjectDescLabel.TabIndex = 1;
            this.SubjectDescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.SubjectCodeCB);
            this.GroupBox1.Controls.Add(this.btnSave);
            this.GroupBox1.Controls.Add(this.btnLoadStudent);
            this.GroupBox1.Controls.Add(this.label5);
            this.GroupBox1.Controls.Add(this.SemCB);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.CourseCodeCB);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.YearCB);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.GroupBox1.Location = new System.Drawing.Point(613, 42);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(161, 437);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Filter Subject";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Subject:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubjectCodeCB
            // 
            this.SubjectCodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectCodeCB.Enabled = false;
            this.SubjectCodeCB.FormattingEnabled = true;
            this.SubjectCodeCB.Location = new System.Drawing.Point(23, 192);
            this.SubjectCodeCB.Name = "SubjectCodeCB";
            this.SubjectCodeCB.Size = new System.Drawing.Size(121, 24);
            this.SubjectCodeCB.TabIndex = 10;
            this.SubjectCodeCB.SelectedValueChanged += new System.EventHandler(this.SubjectCode_SelectedValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(76, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadStudent
            // 
            this.btnLoadStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnLoadStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadStudent.Enabled = false;
            this.btnLoadStudent.FlatAppearance.BorderSize = 0;
            this.btnLoadStudent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnLoadStudent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLoadStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadStudent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoadStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadStudent.Image")));
            this.btnLoadStudent.Location = new System.Drawing.Point(76, 234);
            this.btnLoadStudent.Name = "btnLoadStudent";
            this.btnLoadStudent.Size = new System.Drawing.Size(61, 25);
            this.btnLoadStudent.TabIndex = 8;
            this.btnLoadStudent.Text = "&Load";
            this.btnLoadStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadStudent.UseVisualStyleBackColor = false;
            this.btnLoadStudent.Click += new System.EventHandler(this.btnLoadStudent_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sem:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SemCB
            // 
            this.SemCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemCB.Enabled = false;
            this.SemCB.FormattingEnabled = true;
            this.SemCB.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "summer"});
            this.SemCB.Location = new System.Drawing.Point(23, 139);
            this.SemCB.Name = "SemCB";
            this.SemCB.Size = new System.Drawing.Size(121, 24);
            this.SemCB.TabIndex = 6;
            this.SemCB.SelectedValueChanged += new System.EventHandler(this.SemCB_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Course:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CourseCodeCB
            // 
            this.CourseCodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CourseCodeCB.Enabled = false;
            this.CourseCodeCB.FormattingEnabled = true;
            this.CourseCodeCB.Location = new System.Drawing.Point(23, 88);
            this.CourseCodeCB.Name = "CourseCodeCB";
            this.CourseCodeCB.Size = new System.Drawing.Size(121, 24);
            this.CourseCodeCB.TabIndex = 4;
            this.CourseCodeCB.SelectedValueChanged += new System.EventHandler(this.CourseCodeCB_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Year Level";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearCB
            // 
            this.YearCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearCB.FormattingEnabled = true;
            this.YearCB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.YearCB.Location = new System.Drawing.Point(23, 36);
            this.YearCB.Name = "YearCB";
            this.YearCB.Size = new System.Drawing.Size(121, 24);
            this.YearCB.TabIndex = 2;
            this.YearCB.SelectedValueChanged += new System.EventHandler(this.YearCB_SelectedValueChanged);
            // 
            // dgStudentList
            // 
            this.dgStudentList.AllowUserToAddRows = false;
            this.dgStudentList.AllowUserToResizeColumns = false;
            this.dgStudentList.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgStudentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgStudentList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgStudentList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStudentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgStudentList.ColumnHeadersHeight = 30;
            this.dgStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgStudentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.StudentID,
            this.StudentName,
            this.Grade,
            this.Remarks});
            this.dgStudentList.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudentList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgStudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStudentList.EnableHeadersVisualStyles = false;
            this.dgStudentList.Location = new System.Drawing.Point(0, 42);
            this.dgStudentList.Name = "dgStudentList";
            this.dgStudentList.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgStudentList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgStudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgStudentList.Size = new System.Drawing.Size(613, 437);
            this.dgStudentList.TabIndex = 15;
            this.dgStudentList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudentList_CellEndEdit);
            this.dgStudentList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgStudentList_EditingControlShowing);
            this.dgStudentList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgStudentList_KeyDown);
            // 
            // id
            // 
            this.id.HeaderText = "";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.MinimumWidth = 150;
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            this.StudentID.Width = 150;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.MinimumWidth = 150;
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 150;
            // 
            // Grade
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grade.DefaultCellStyle = dataGridViewCellStyle8;
            this.Grade.HeaderText = "Final Grade";
            this.Grade.Name = "Grade";
            this.Grade.Width = 50;
            // 
            // Remarks
            // 
            this.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Remarks.HeaderText = "Remark";
            this.Remarks.MinimumWidth = 150;
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            this.Remarks.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Note:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(16, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 75);
            this.label2.TabIndex = 13;
            this.label2.Text = "For \"INC\" and \"DRP\", please hold\r\n (ALT + C ) for INC \r\n (ALT + V) for DRP";
            // 
            // ucGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgStudentList);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucGrades";
            this.Size = new System.Drawing.Size(774, 479);
            this.Load += new System.EventHandler(this.ucGrades_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SubjectDescLabel;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SemCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CourseCodeCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox YearCB;
        private System.Windows.Forms.DataGridView dgStudentList;
        private System.Windows.Forms.Button btnLoadStudent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SubjectCodeCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
