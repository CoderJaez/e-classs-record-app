namespace Student_Profiling
{
    partial class ucEnlistment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucEnlistment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalUnits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoadSubject = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgStudent = new System.Windows.Forms.DataGridView();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YearLevelTxt = new System.Windows.Forms.TextBox();
            this.CourseTxt = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.StudentNameTxt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SchoolYearTxt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SemTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StudIDTxt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StudentPicture = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudent)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Brown;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 42);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enlistment";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.TotalUnits);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.dgStudent);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.StudentPicture);
            this.panel2.Location = new System.Drawing.Point(17, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 673);
            this.panel2.TabIndex = 8;
            // 
            // TotalUnits
            // 
            this.TotalUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TotalUnits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalUnits.Location = new System.Drawing.Point(447, 558);
            this.TotalUnits.Name = "TotalUnits";
            this.TotalUnits.Size = new System.Drawing.Size(111, 19);
            this.TotalUnits.TabIndex = 13;
            this.TotalUnits.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total Units:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnLoadSubject);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(14, 600);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 56);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnModify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModify.Enabled = false;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnModify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnModify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.Location = new System.Drawing.Point(344, 20);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(88, 30);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "&Modify";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(438, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(26, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 30);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "S&earch";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnLoadSubject
            // 
            this.btnLoadSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnLoadSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadSubject.Enabled = false;
            this.btnLoadSubject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLoadSubject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnLoadSubject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLoadSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadSubject.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLoadSubject.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadSubject.Image")));
            this.btnLoadSubject.Location = new System.Drawing.Point(120, 20);
            this.btnLoadSubject.Name = "btnLoadSubject";
            this.btnLoadSubject.Size = new System.Drawing.Size(123, 30);
            this.btnLoadSubject.TabIndex = 13;
            this.btnLoadSubject.Text = "&Load Subjects";
            this.btnLoadSubject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadSubject.UseVisualStyleBackColor = false;
            this.btnLoadSubject.Click += new System.EventHandler(this.btnLoadSubject_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(47)))), ((int)(((byte)(71)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(249, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 30);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgStudent
            // 
            this.dgStudent.AllowUserToAddRows = false;
            this.dgStudent.AllowUserToResizeColumns = false;
            this.dgStudent.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgStudent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgStudent.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgStudent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgStudent.ColumnHeadersHeight = 30;
            this.dgStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectID,
            this.SubjectCode,
            this.SubjectDesc,
            this.Lab,
            this.Lecture,
            this.Delete});
            this.dgStudent.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStudent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgStudent.EnableHeadersVisualStyles = false;
            this.dgStudent.Location = new System.Drawing.Point(14, 170);
            this.dgStudent.Name = "dgStudent";
            this.dgStudent.ReadOnly = true;
            this.dgStudent.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgStudent.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStudent.Size = new System.Drawing.Size(550, 385);
            this.dgStudent.TabIndex = 10;
            this.dgStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStudent_CellContentClick);
            // 
            // SubjectID
            // 
            this.SubjectID.HeaderText = "SubjectID";
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.ReadOnly = true;
            this.SubjectID.Width = 90;
            // 
            // SubjectCode
            // 
            this.SubjectCode.HeaderText = "SubjectCode";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            // 
            // SubjectDesc
            // 
            this.SubjectDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.SubjectDesc.HeaderText = "Description";
            this.SubjectDesc.Name = "SubjectDesc";
            this.SubjectDesc.ReadOnly = true;
            this.SubjectDesc.Width = 5;
            // 
            // Lab
            // 
            this.Lab.HeaderText = "Lab";
            this.Lab.Name = "Lab";
            this.Lab.ReadOnly = true;
            this.Lab.Width = 50;
            // 
            // Lecture
            // 
            this.Lecture.HeaderText = "Lec";
            this.Lecture.Name = "Lecture";
            this.Lecture.ReadOnly = true;
            this.Lecture.Width = 50;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.ToolTipText = "Delete";
            this.Delete.Width = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YearLevelTxt);
            this.groupBox1.Controls.Add(this.CourseTxt);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.StudentNameTxt);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.SchoolYearTxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SemTxt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.StudIDTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(134, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // YearLevelTxt
            // 
            this.YearLevelTxt.Location = new System.Drawing.Point(374, 22);
            this.YearLevelTxt.Name = "YearLevelTxt";
            this.YearLevelTxt.Size = new System.Drawing.Size(32, 25);
            this.YearLevelTxt.TabIndex = 12;
            this.YearLevelTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.YearLevelTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YearLevelTxt_KeyPress);
            // 
            // CourseTxt
            // 
            this.CourseTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CourseTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CourseTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CourseTxt.Location = new System.Drawing.Point(9, 127);
            this.CourseTxt.Name = "CourseTxt";
            this.CourseTxt.Size = new System.Drawing.Size(359, 25);
            this.CourseTxt.TabIndex = 11;
            this.CourseTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Course:";
            // 
            // StudentNameTxt
            // 
            this.StudentNameTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StudentNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StudentNameTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudentNameTxt.Location = new System.Drawing.Point(9, 77);
            this.StudentNameTxt.Name = "StudentNameTxt";
            this.StudentNameTxt.Size = new System.Drawing.Size(316, 25);
            this.StudentNameTxt.TabIndex = 9;
            this.StudentNameTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Student Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Level";
            // 
            // SchoolYearTxt
            // 
            this.SchoolYearTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SchoolYearTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SchoolYearTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SchoolYearTxt.Location = new System.Drawing.Point(263, 21);
            this.SchoolYearTxt.Name = "SchoolYearTxt";
            this.SchoolYearTxt.Size = new System.Drawing.Size(105, 25);
            this.SchoolYearTxt.TabIndex = 5;
            this.SchoolYearTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "School Year";
            // 
            // SemTxt
            // 
            this.SemTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SemTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SemTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SemTxt.Location = new System.Drawing.Point(199, 21);
            this.SemTxt.Name = "SemTxt";
            this.SemTxt.Size = new System.Drawing.Size(58, 25);
            this.SemTxt.TabIndex = 3;
            this.SemTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sem";
            // 
            // StudIDTxt
            // 
            this.StudIDTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StudIDTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StudIDTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudIDTxt.Location = new System.Drawing.Point(6, 21);
            this.StudIDTxt.Name = "StudIDTxt";
            this.StudIDTxt.Size = new System.Drawing.Size(187, 25);
            this.StudIDTxt.TabIndex = 1;
            this.StudIDTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student ID";
            // 
            // StudentPicture
            // 
            this.StudentPicture.BackgroundImage = global::Student_Profiling.Properties.Resources.Manager_96px;
            this.StudentPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StudentPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.StudentPicture.Location = new System.Drawing.Point(14, 11);
            this.StudentPicture.Name = "StudentPicture";
            this.StudentPicture.Size = new System.Drawing.Size(114, 153);
            this.StudentPicture.TabIndex = 7;
            this.StudentPicture.TabStop = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Student_Profiling.Properties.Resources.icons8_Trash_16;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ToolTipText = "Delete";
            // 
            // ucEnlistment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucEnlistment";
            this.Size = new System.Drawing.Size(910, 762);
            this.Load += new System.EventHandler(this.ucEnlistment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStudent)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox StudentPicture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label SchoolYearTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SemTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StudIDTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CourseTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label StudentNameTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgStudent;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoadSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label TotalUnits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox YearLevelTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lecture;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}
