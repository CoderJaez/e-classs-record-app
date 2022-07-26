namespace Student_Profiling
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblPosition = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnAdmission = new System.Windows.Forms.Button();
            this.btnEnlistment = new System.Windows.Forms.Button();
            this.btnGrades = new System.Windows.Forms.Button();
            this.collapsePanel = new System.Windows.Forms.Panel();
            this.btnSY = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnPrograms = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.collapsePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.panel1.Size = new System.Drawing.Size(1069, 37);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1036, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 17);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblPosition);
            this.panel2.Controls.Add(this.LblUsername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 156);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Student_Profiling.Properties.Resources._1491864870_malecostume;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(53, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(104, 100);
            this.panel3.TabIndex = 2;
            // 
            // LblPosition
            // 
            this.LblPosition.AutoSize = true;
            this.LblPosition.Location = new System.Drawing.Point(59, 135);
            this.LblPosition.Name = "LblPosition";
            this.LblPosition.Size = new System.Drawing.Size(87, 17);
            this.LblPosition.TabIndex = 4;
            this.LblPosition.Text = "Administrator";
            this.LblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUsername
            // 
            this.LblUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.LblUsername.ForeColor = System.Drawing.Color.DarkRed;
            this.LblUsername.Location = new System.Drawing.Point(31, 108);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(148, 27);
            this.LblUsername.TabIndex = 3;
            this.LblUsername.Text = "Username";
            this.LblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.btnAdmission);
            this.panelSidebar.Controls.Add(this.btnEnlistment);
            this.panelSidebar.Controls.Add(this.btnGrades);
            this.panelSidebar.Controls.Add(this.collapsePanel);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Location = new System.Drawing.Point(3, 165);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(208, 367);
            this.panelSidebar.TabIndex = 5;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Maroon;
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 3);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(193, 26);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnAdmission
            // 
            this.btnAdmission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmission.FlatAppearance.BorderSize = 0;
            this.btnAdmission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAdmission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdmission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmission.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdmission.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmission.Image")));
            this.btnAdmission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmission.Location = new System.Drawing.Point(3, 32);
            this.btnAdmission.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnAdmission.Name = "btnAdmission";
            this.btnAdmission.Size = new System.Drawing.Size(193, 26);
            this.btnAdmission.TabIndex = 6;
            this.btnAdmission.Text = "Admission";
            this.btnAdmission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmission.UseVisualStyleBackColor = true;
            this.btnAdmission.Click += new System.EventHandler(this.btnAdmission_Click);
            // 
            // btnEnlistment
            // 
            this.btnEnlistment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnlistment.FlatAppearance.BorderSize = 0;
            this.btnEnlistment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEnlistment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnlistment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnlistment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnlistment.Image = ((System.Drawing.Image)(resources.GetObject("btnEnlistment.Image")));
            this.btnEnlistment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnlistment.Location = new System.Drawing.Point(3, 61);
            this.btnEnlistment.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnEnlistment.Name = "btnEnlistment";
            this.btnEnlistment.Size = new System.Drawing.Size(193, 26);
            this.btnEnlistment.TabIndex = 7;
            this.btnEnlistment.Text = "Enlistment";
            this.btnEnlistment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnlistment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnlistment.UseVisualStyleBackColor = true;
            this.btnEnlistment.Click += new System.EventHandler(this.btnEnlistment_Click);
            // 
            // btnGrades
            // 
            this.btnGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrades.FlatAppearance.BorderSize = 0;
            this.btnGrades.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnGrades.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrades.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGrades.Image = ((System.Drawing.Image)(resources.GetObject("btnGrades.Image")));
            this.btnGrades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrades.Location = new System.Drawing.Point(3, 90);
            this.btnGrades.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnGrades.Name = "btnGrades";
            this.btnGrades.Size = new System.Drawing.Size(193, 26);
            this.btnGrades.TabIndex = 8;
            this.btnGrades.Text = "Grades";
            this.btnGrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrades.UseVisualStyleBackColor = true;
            this.btnGrades.Click += new System.EventHandler(this.btnGrades_Click);
            // 
            // collapsePanel
            // 
            this.collapsePanel.BackColor = System.Drawing.Color.Black;
            this.collapsePanel.Controls.Add(this.btnSY);
            this.collapsePanel.Controls.Add(this.btnUser);
            this.collapsePanel.Controls.Add(this.btnPrograms);
            this.collapsePanel.Controls.Add(this.btnSettings);
            this.collapsePanel.Location = new System.Drawing.Point(3, 119);
            this.collapsePanel.MaximumSize = new System.Drawing.Size(195, 131);
            this.collapsePanel.MinimumSize = new System.Drawing.Size(195, 30);
            this.collapsePanel.Name = "collapsePanel";
            this.collapsePanel.Size = new System.Drawing.Size(195, 30);
            this.collapsePanel.TabIndex = 0;
            // 
            // btnSY
            // 
            this.btnSY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnSY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSY.FlatAppearance.BorderSize = 0;
            this.btnSY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSY.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSY.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSY.Location = new System.Drawing.Point(0, 99);
            this.btnSY.Name = "btnSY";
            this.btnSY.Size = new System.Drawing.Size(193, 26);
            this.btnSY.TabIndex = 14;
            this.btnSY.Text = "School Year";
            this.btnSY.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSY.UseVisualStyleBackColor = false;
            this.btnSY.Click += new System.EventHandler(this.btnSY_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUser.Location = new System.Drawing.Point(-1, 67);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(193, 26);
            this.btnUser.TabIndex = 12;
            this.btnUser.Text = "User Account";
            this.btnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnPrograms
            // 
            this.btnPrograms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnPrograms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrograms.FlatAppearance.BorderSize = 0;
            this.btnPrograms.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnPrograms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrograms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrograms.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrograms.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrograms.Location = new System.Drawing.Point(0, 35);
            this.btnPrograms.Name = "btnPrograms";
            this.btnPrograms.Size = new System.Drawing.Size(193, 26);
            this.btnPrograms.TabIndex = 10;
            this.btnPrograms.Text = "Courses";
            this.btnPrograms.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrograms.UseVisualStyleBackColor = false;
            this.btnPrograms.Click += new System.EventHandler(this.btnPrograms_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSettings.Image = global::Student_Profiling.Properties.Resources.icons8_collapse_arrow_16;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.Location = new System.Drawing.Point(0, 3);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(193, 26);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 155);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(193, 26);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(220, 45);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(839, 524);
            this.mainPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelSidebar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(214, 538);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 575);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.collapsePanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblPosition;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel panelSidebar;
        private System.Windows.Forms.Button btnAdmission;
        private System.Windows.Forms.Button btnEnlistment;
        private System.Windows.Forms.Button btnGrades;
        private System.Windows.Forms.Panel collapsePanel;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnPrograms;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSY;
    }
}

