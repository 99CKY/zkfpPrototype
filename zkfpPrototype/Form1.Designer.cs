using System.Windows.Forms;

namespace zkfpPrototype
{
    partial class Form1
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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.btnUploadFp = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnConnectDb = new System.Windows.Forms.Button();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.cmbIdx = new System.Windows.Forms.ComboBox();
            this.tabPageFp = new System.Windows.Forms.TabPage();
            this.picFpImg = new System.Windows.Forms.PictureBox();
            this.tabPageDb = new System.Windows.Forms.TabPage();
            this.fpData = new System.Windows.Forms.DataGridView();
            this.fpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_registered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageEmp = new System.Windows.Forms.TabPage();
            this.empData = new System.Windows.Forms.DataGridView();
            this.empId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpControl = new System.Windows.Forms.TabControl();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.mainControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.labelNumOfFp = new System.Windows.Forms.Label();
            this.secondPage = new System.Windows.Forms.TabPage();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbDataSource = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbDbName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.dbControl = new System.Windows.Forms.TabControl();
            this.secondMessageBox = new System.Windows.Forms.RichTextBox();
            this.thirdPage = new System.Windows.Forms.TabPage();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.inputName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.inputTmp = new System.Windows.Forms.TextBox();
            this.lblUserInput = new System.Windows.Forms.Label();
            this.tbUserInputId = new System.Windows.Forms.TextBox();
            this.tabPageFp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFpImg)).BeginInit();
            this.tabPageDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).BeginInit();
            this.tabPageEmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empData)).BeginInit();
            this.fpControl.SuspendLayout();
            this.mainControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.secondPage.SuspendLayout();
            this.dbControl.SuspendLayout();
            this.thirdPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(22, 40);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 40);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Initialize";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(22, 109);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 40);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(221, 109);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnMatch
            // 
            this.btnMatch.Enabled = false;
            this.btnMatch.Location = new System.Drawing.Point(251, 439);
            this.btnMatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(220, 50);
            this.btnMatch.TabIndex = 20;
            this.btnMatch.Text = "Verify";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.BtnMatch_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Enabled = false;
            this.btnVerify.Location = new System.Drawing.Point(329, 443);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(100, 37);
            this.btnVerify.TabIndex = 19;
            this.btnVerify.Text = "Verify(1:N)";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(143, 122);
            this.btnAddEmp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 5);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(103, 49);
            this.btnAddEmp.TabIndex = 0;
            this.btnAddEmp.Text = "Add Employee";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.BtnAddEmp_Click);
            // 
            // btnUploadFp
            // 
            this.btnUploadFp.Location = new System.Drawing.Point(0, 0);
            this.btnUploadFp.Name = "btnUploadFp";
            this.btnUploadFp.Size = new System.Drawing.Size(75, 23);
            this.btnUploadFp.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.Enabled = false;
            this.btnRegister.Location = new System.Drawing.Point(10, 439);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(220, 50);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Location = new System.Drawing.Point(25, 35);
            this.btnConnectDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnectDb.Name = "btnConnectDb";
            this.btnConnectDb.Size = new System.Drawing.Size(100, 50);
            this.btnConnectDb.TabIndex = 18;
            this.btnConnectDb.Text = "Connect";
            this.btnConnectDb.UseVisualStyleBackColor = true;
            this.btnConnectDb.Click += new System.EventHandler(this.BtnConnectDb_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Location = new System.Drawing.Point(221, 43);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(100, 40);
            this.btnTerminate.TabIndex = 0;
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.BtnTerminate_Click);
            // 
            // cmbIdx
            // 
            this.cmbIdx.FormattingEnabled = true;
            this.cmbIdx.Location = new System.Drawing.Point(142, 115);
            this.cmbIdx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbIdx.Name = "cmbIdx";
            this.cmbIdx.Size = new System.Drawing.Size(52, 23);
            this.cmbIdx.TabIndex = 10;
            // 
            // tabPageFp
            // 
            this.tabPageFp.Controls.Add(this.btnMatch);
            this.tabPageFp.Controls.Add(this.btnRegister);
            this.tabPageFp.Controls.Add(this.picFpImg);
            this.tabPageFp.Location = new System.Drawing.Point(4, 24);
            this.tabPageFp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageFp.Name = "tabPageFp";
            this.tabPageFp.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageFp.Size = new System.Drawing.Size(479, 504);
            this.tabPageFp.TabIndex = 0;
            this.tabPageFp.Text = "Fingerprint image";
            this.tabPageFp.UseVisualStyleBackColor = true;
            // 
            // picFpImg
            // 
            this.picFpImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picFpImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picFpImg.Location = new System.Drawing.Point(10, 3);
            this.picFpImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picFpImg.Name = "picFpImg";
            this.picFpImg.Size = new System.Drawing.Size(461, 430);
            this.picFpImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFpImg.TabIndex = 1;
            this.picFpImg.TabStop = false;
            // 
            // tabPageDb
            // 
            this.tabPageDb.Controls.Add(this.fpData);
            this.tabPageDb.Location = new System.Drawing.Point(4, 24);
            this.tabPageDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageDb.Name = "tabPageDb";
            this.tabPageDb.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageDb.Size = new System.Drawing.Size(479, 504);
            this.tabPageDb.TabIndex = 0;
            this.tabPageDb.Text = "Fingerprint Data";
            this.tabPageDb.UseVisualStyleBackColor = true;
            // 
            // fpData
            // 
            this.fpData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fpData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fpId,
            this.fpTemplate,
            this.time_registered, this.empId1});
            this.fpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpData.Location = new System.Drawing.Point(4, 5);
            this.fpData.Name = "fpData";
            this.fpData.RowHeadersWidth = 51;
            this.fpData.Size = new System.Drawing.Size(471, 494);
            this.fpData.TabIndex = 883;
            // 
            // fpId
            // 
            this.fpId.HeaderText = "fpId";
            this.fpId.MinimumWidth = 6;
            this.fpId.Name = "fpId";
            this.fpId.Width = 50;
            // 
            // fpTemplate
            // 
            this.fpTemplate.HeaderText = "fpTemplate";
            this.fpTemplate.MinimumWidth = 6;
            this.fpTemplate.Name = "fpTemplate";
            this.fpTemplate.Width = 250;
            // 
            // time_registered
            // 
            this.time_registered.HeaderText = "timeRegister";
            this.time_registered.MinimumWidth = 6;
            this.time_registered.Name = "time_registered";
            // 
            // empId1
            // 
            this.empId1.HeaderText = "Emp_Id";
            this.empId1.MinimumWidth = 6;
            this.empId1.Name = "empId1";
            this.empId1.Width = 150;
            // 
            // tabPageEmp
            // 
            this.tabPageEmp.Controls.Add(this.empData);
            this.tabPageEmp.Location = new System.Drawing.Point(4, 24);
            this.tabPageEmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageEmp.Name = "tabPageEmp";
            this.tabPageEmp.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageEmp.Size = new System.Drawing.Size(479, 504);
            this.tabPageEmp.TabIndex = 0;
            this.tabPageEmp.Text = "Employee Data";
            this.tabPageEmp.UseVisualStyleBackColor = true;
            // 
            // empData
            // 
            this.empData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empId,
            this.empName});
            this.empData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.empData.Location = new System.Drawing.Point(4, 5);
            this.empData.Name = "empData";
            this.empData.RowHeadersWidth = 51;
            this.empData.Size = new System.Drawing.Size(471, 494);
            this.empData.TabIndex = 883;
            // 
            // empId
            // 
            this.empId.HeaderText = "Emp_Id";
            this.empId.MinimumWidth = 6;
            this.empId.Name = "empId";
            this.empId.Width = 150;
            // 
            // empName
            // 
            this.empName.HeaderText = "Emp_Name";
            this.empName.MinimumWidth = 6;
            this.empName.Name = "empName";
            this.empName.Width = 150;
            // 
            // fpControl
            // 
            this.fpControl.Controls.Add(this.tabPageFp);
            this.fpControl.Location = new System.Drawing.Point(613, 7);
            this.fpControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fpControl.Name = "fpControl";
            this.fpControl.SelectedIndex = 0;
            this.fpControl.Size = new System.Drawing.Size(487, 532);
            this.fpControl.TabIndex = 16;
            this.fpControl.Tag = "F";
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(-3, 226);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(612, 327);
            this.messageBox.TabIndex = 17;
            this.messageBox.Text = "Please plugin your reader and initialize your reader first.";
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            // 
            // mainControl
            // 
            this.mainControl.Controls.Add(this.mainPage);
            this.mainControl.Controls.Add(this.secondPage);
            this.mainControl.Controls.Add(this.thirdPage);
            this.mainControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainControl.Location = new System.Drawing.Point(4, 2);
            this.mainControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainControl.Name = "mainControl";
            this.mainControl.SelectedIndex = 0;
            this.mainControl.Size = new System.Drawing.Size(1103, 593);
            this.mainControl.TabIndex = 16;
            this.mainControl.Tag = "M";
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.tbUserInputId);
            this.mainPage.Controls.Add(this.lblUserInput);
            this.mainPage.Controls.Add(this.btnInit);
            this.mainPage.Controls.Add(this.btnTerminate);
            this.mainPage.Controls.Add(this.btnOpen);
            this.mainPage.Controls.Add(this.btnClose);
            this.mainPage.Controls.Add(this.fpControl);
            this.mainPage.Controls.Add(this.cmbIdx);
            this.mainPage.Controls.Add(this.messageBox);
            this.mainPage.Controls.Add(this.labelNumOfFp);
            this.mainPage.Location = new System.Drawing.Point(4, 24);
            this.mainPage.Name = "mainPage";
            this.mainPage.Size = new System.Drawing.Size(1095, 565);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Fingerprint";
            // 
            // labelNumOfFp
            // 
            this.labelNumOfFp.AutoSize = true;
            this.labelNumOfFp.Location = new System.Drawing.Point(347, 43);
            this.labelNumOfFp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumOfFp.Name = "labelNumOfFp";
            this.labelNumOfFp.Size = new System.Drawing.Size(191, 15);
            this.labelNumOfFp.TabIndex = 9;
            this.labelNumOfFp.Text = "Number of fingerprint registered: 0";
            // 
            // secondPage
            // 
            this.secondPage.Controls.Add(this.btnTestConnection);
            this.secondPage.Controls.Add(this.tbDataSource);
            this.secondPage.Controls.Add(this.tbUserName);
            this.secondPage.Controls.Add(this.tbDbName);
            this.secondPage.Controls.Add(this.tbPassword);
            this.secondPage.Controls.Add(this.lblPassword);
            this.secondPage.Controls.Add(this.lblUserName);
            this.secondPage.Controls.Add(this.lblDbName);
            this.secondPage.Controls.Add(this.lblDataSource);
            this.secondPage.Controls.Add(this.btnDisconnect);
            this.secondPage.Controls.Add(this.dbControl);
            this.secondPage.Controls.Add(this.btnConnectDb);
            this.secondPage.Controls.Add(this.secondMessageBox);
            this.secondPage.Controls.Add(this.btnAddEmp);
            this.secondPage.Location = new System.Drawing.Point(4, 24);
            this.secondPage.Name = "secondPage";
            this.secondPage.Size = new System.Drawing.Size(1095, 565);
            this.secondPage.TabIndex = 0;
            this.secondPage.Text = "Database";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(146, 35);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(100, 50);
            this.btnTestConnection.TabIndex = 28;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Visible = false;
            this.btnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // tbDataSource
            // 
            this.tbDataSource.Location = new System.Drawing.Point(426, 19);
            this.tbDataSource.Name = "tbDataSource";
            this.tbDataSource.Size = new System.Drawing.Size(165, 23);
            this.tbDataSource.TabIndex = 27;
            this.tbDataSource.Text = "DBSERV\\SQL2K8";
            this.tbDataSource.Visible = false;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(426, 118);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(165, 23);
            this.tbUserName.TabIndex = 26;
            this.tbUserName.Text = "fis";
            this.tbUserName.Visible = false;
            // 
            // tbDbName
            // 
            this.tbDbName.Location = new System.Drawing.Point(426, 69);
            this.tbDbName.Name = "tbDbName";
            this.tbDbName.Size = new System.Drawing.Size(165, 23);
            this.tbDbName.TabIndex = 25;
            this.tbDbName.Text = "testScan";
            this.tbDbName.Visible = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(426, 162);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(165, 23);
            this.tbPassword.TabIndex = 24;
            this.tbPassword.Text = "fis";
            this.tbPassword.Visible = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(300, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 23;
            this.lblPassword.Text = "Password";
            this.lblPassword.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(300, 122);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 15);
            this.lblUserName.TabIndex = 22;
            this.lblUserName.Text = "Username";
            this.lblUserName.Visible = false;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(300, 73);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(88, 15);
            this.lblDbName.TabIndex = 21;
            this.lblDbName.Text = "Database name";
            this.lblDbName.Visible = false;
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(300, 20);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(69, 15);
            this.lblDataSource.TabIndex = 20;
            this.lblDataSource.Text = "Data source";
            this.lblDataSource.Visible = false;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(25, 121);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(100, 50);
            this.btnDisconnect.TabIndex = 19;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // dbControl
            // 
            this.dbControl.Controls.Add(this.tabPageDb);
            this.dbControl.Controls.Add(this.tabPageEmp);
            this.dbControl.Location = new System.Drawing.Point(613, 7);
            this.dbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dbControl.Name = "dbControl";
            this.dbControl.SelectedIndex = 0;
            this.dbControl.Size = new System.Drawing.Size(487, 532);
            this.dbControl.TabIndex = 16;
            this.dbControl.Tag = "D";
            // 
            // secondMessageBox
            // 
            this.secondMessageBox.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondMessageBox.Location = new System.Drawing.Point(-3, 226);
            this.secondMessageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.secondMessageBox.Name = "secondMessageBox";
            this.secondMessageBox.Size = new System.Drawing.Size(612, 327);
            this.secondMessageBox.TabIndex = 17;
            this.secondMessageBox.Text = "Please connect to your database.";
            // 
            // thirdPage
            // 
            this.thirdPage.Controls.Add(this.save);
            this.thirdPage.Controls.Add(this.cancel);
            this.thirdPage.Controls.Add(this.lbName);
            this.thirdPage.Controls.Add(this.lbId);
            this.thirdPage.Controls.Add(this.tbName);
            this.thirdPage.Controls.Add(this.tbId);
            this.thirdPage.Location = new System.Drawing.Point(4, 24);
            this.thirdPage.Name = "thirdPage";
            this.thirdPage.Size = new System.Drawing.Size(1095, 565);
            this.thirdPage.TabIndex = 0;
            this.thirdPage.Text = "Employee";
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(69, 208);
            this.save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(150, 50);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(279, 208);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(150, 50);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(117, 123);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(113, 19);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Employee name: ";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(143, 61);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(91, 19);
            this.lbId.TabIndex = 3;
            this.lbId.Text = "Employee Id: ";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(256, 117);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(119, 25);
            this.tbName.TabIndex = 4;
            // 
            // tbId
            // 
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(256, 58);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(119, 25);
            this.tbId.TabIndex = 5;
            // 
            // inputName
            // 
            this.inputName.Location = new System.Drawing.Point(410, 115);
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(144, 20);
            this.inputName.TabIndex = 20;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(347, 118);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(331, 124);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(150, 50);
            this.btnInsert.TabIndex = 19;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // inputTmp
            // 
            this.inputTmp.Location = new System.Drawing.Point(81, 179);
            this.inputTmp.Name = "inputTmp";
            this.inputTmp.Size = new System.Drawing.Size(100, 20);
            this.inputTmp.TabIndex = 21;
            // 
            // lblUserInput
            // 
            this.lblUserInput.AutoSize = true;
            this.lblUserInput.Location = new System.Drawing.Point(347, 118);
            this.lblUserInput.Name = "lblUserInput";
            this.lblUserInput.Size = new System.Drawing.Size(154, 15);
            this.lblUserInput.TabIndex = 18;
            this.lblUserInput.Text = "Register fingerprint for ID = ";
            // 
            // tbUserInputId
            // 
            this.tbUserInputId.Location = new System.Drawing.Point(507, 115);
            this.tbUserInputId.Name = "tbUserInputId";
            this.tbUserInputId.Size = new System.Drawing.Size(51, 23);
            this.tbUserInputId.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1113, 597);
            this.Controls.Add(this.mainControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 496);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C# zkfinger prototype";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPageFp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFpImg)).EndInit();
            this.tabPageDb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).EndInit();
            this.tabPageEmp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.empData)).EndInit();
            this.fpControl.ResumeLayout(false);
            this.mainControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.secondPage.ResumeLayout(false);
            this.secondPage.PerformLayout();
            this.dbControl.ResumeLayout(false);
            this.thirdPage.ResumeLayout(false);
            this.thirdPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnInit;
        private Button btnTerminate;
        private Button btnOpen;
        private Button btnClose;
        private Button btnVerify;
        private Button btnMatch;
        private Button btnRegister;
        private Button btnConnectDb;
        private Button btnUploadFp;
        private Button btnAddEmp;
        private TabControl fpControl;
        private TabControl mainControl;
        private TabControl dbControl;
        private TabPage tabPageFp;
        private TabPage tabPageDb;
        private TabPage mainPage;
        private TabPage secondPage;
        private TabPage tabPageEmp;
        private PictureBox picFpImg;
        private ComboBox cmbIdx;
        public RichTextBox messageBox;
        public RichTextBox secondMessageBox;
        private DataGridView fpData;
        private DataGridViewTextBoxColumn fpTemplate;
        private DataGridViewTextBoxColumn fpId;
        private DataGridViewTextBoxColumn timeRegister;
        private DataGridViewTextBoxColumn empId1;
        private DataGridView empData;
        private DataGridViewTextBoxColumn empId;
        private DataGridViewTextBoxColumn empName;
        private Button btnInsert;
        private TextBox inputTmp;
        private TextBox inputName;
        private Button btnDisconnect;
        private Label lblName;
        private Label labelNumOfFp;
        private TextBox tbDataSource;
        private TextBox tbUserName;
        private TextBox tbDbName;
        private TextBox tbPassword;
        private Label lblPassword;
        private Label lblUserName;
        private Label lblDbName;
        private Label lblDataSource;
        private Button btnTestConnection;
        private DataGridViewTextBoxColumn time_registered;
        private TabPage thirdPage;
        private Button save;
        private Button cancel;
        private Label lbName;
        private Label lbId;
        private TextBox tbName;
        private TextBox tbId;
        private TextBox tbUserInputId;
        private Label lblUserInput;
    }
}

