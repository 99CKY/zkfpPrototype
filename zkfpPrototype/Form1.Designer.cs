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
            this.btnCreateTb = new System.Windows.Forms.Button();
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
            this.labelNumOfFp = new System.Windows.Forms.Label();
            this.fpControl = new System.Windows.Forms.TabControl();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.mainControl = new System.Windows.Forms.TabControl();
            this.mainPage = new System.Windows.Forms.TabPage();
            this.secondPage = new System.Windows.Forms.TabPage();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.dbControl = new System.Windows.Forms.TabControl();
            this.secondMessageBox = new System.Windows.Forms.RichTextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.inputId = new System.Windows.Forms.TextBox();
            this.inputTmp = new System.Windows.Forms.TextBox();
            this.tabPageFp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFpImg)).BeginInit();
            this.tabPageDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpData)).BeginInit();
            this.fpControl.SuspendLayout();
            this.mainControl.SuspendLayout();
            this.mainPage.SuspendLayout();
            this.secondPage.SuspendLayout();
            this.dbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(22, 40);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 37);
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
            this.btnOpen.Size = new System.Drawing.Size(100, 37);
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
            this.btnClose.Size = new System.Drawing.Size(100, 37);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnMatch
            // 
            this.btnMatch.Enabled = false;
            this.btnMatch.Location = new System.Drawing.Point(175, 443);
            this.btnMatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(100, 37);
            this.btnMatch.TabIndex = 20;
            this.btnMatch.Text = "Match(1:1)";
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
            // btnCreateTb
            // 
            this.btnCreateTb.Enabled = false;
            this.btnCreateTb.Location = new System.Drawing.Point(51, 137);
            this.btnCreateTb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 5);
            this.btnCreateTb.Name = "btnCreateTb";
            this.btnCreateTb.Size = new System.Drawing.Size(150, 50);
            this.btnCreateTb.TabIndex = 0;
            this.btnCreateTb.Text = "Create table";
            this.btnCreateTb.UseVisualStyleBackColor = true;
            this.btnCreateTb.Click += new System.EventHandler(this.BtnCreateTb_Click);
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
            this.btnRegister.Location = new System.Drawing.Point(28, 443);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 37);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnConnectDb
            // 
            this.btnConnectDb.Location = new System.Drawing.Point(51, 41);
            this.btnConnectDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnectDb.Name = "btnConnectDb";
            this.btnConnectDb.Size = new System.Drawing.Size(150, 50);
            this.btnConnectDb.TabIndex = 18;
            this.btnConnectDb.Text = "Connect Database";
            this.btnConnectDb.UseVisualStyleBackColor = true;
            this.btnConnectDb.Click += new System.EventHandler(this.BtnConnectDb_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Location = new System.Drawing.Point(221, 43);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(100, 37);
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
            this.cmbIdx.Size = new System.Drawing.Size(52, 28);
            this.cmbIdx.TabIndex = 10;
            // 
            // tabPageFp
            // 
            this.tabPageFp.Controls.Add(this.btnVerify);
            this.tabPageFp.Controls.Add(this.btnMatch);
            this.tabPageFp.Controls.Add(this.btnRegister);
            this.tabPageFp.Controls.Add(this.picFpImg);
            this.tabPageFp.Location = new System.Drawing.Point(4, 29);
            this.tabPageFp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageFp.Name = "tabPageFp";
            this.tabPageFp.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageFp.Size = new System.Drawing.Size(479, 499);
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
            this.tabPageDb.Location = new System.Drawing.Point(4, 29);
            this.tabPageDb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageDb.Name = "tabPageDb";
            this.tabPageDb.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageDb.Size = new System.Drawing.Size(479, 499);
            this.tabPageDb.TabIndex = 0;
            this.tabPageDb.Text = "Data";
            this.tabPageDb.UseVisualStyleBackColor = true;
            // 
            // fpData
            // 
            this.fpData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fpData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fpId,
            this.fpTemplate});
            this.fpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpData.Location = new System.Drawing.Point(4, 5);
            this.fpData.Name = "fpData";
            this.fpData.RowHeadersWidth = 51;
            this.fpData.Size = new System.Drawing.Size(471, 489);
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
            this.fpTemplate.Width = 300;
            // 
            // labelNumOfFp
            // 
            this.labelNumOfFp.AutoSize = true;
            this.labelNumOfFp.Location = new System.Drawing.Point(350, 49);
            this.labelNumOfFp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumOfFp.Name = "labelNumOfFp";
            this.labelNumOfFp.Size = new System.Drawing.Size(241, 20);
            this.labelNumOfFp.TabIndex = 9;
            this.labelNumOfFp.Text = "Number of fingerprint registered: 0";
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
            // 
            // mainControl
            // 
            this.mainControl.Controls.Add(this.mainPage);
            this.mainControl.Controls.Add(this.secondPage);
            this.mainControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainControl.Location = new System.Drawing.Point(-3, 2);
            this.mainControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainControl.Name = "mainControl";
            this.mainControl.SelectedIndex = 0;
            this.mainControl.Size = new System.Drawing.Size(1103, 593);
            this.mainControl.TabIndex = 16;
            this.mainControl.Tag = "M";
            // 
            // mainPage
            // 
            this.mainPage.Controls.Add(this.btnInit);
            this.mainPage.Controls.Add(this.btnTerminate);
            this.mainPage.Controls.Add(this.btnOpen);
            this.mainPage.Controls.Add(this.btnClose);
            this.mainPage.Controls.Add(this.fpControl);
            this.mainPage.Controls.Add(this.cmbIdx);
            this.mainPage.Controls.Add(this.messageBox);
            this.mainPage.Controls.Add(this.labelNumOfFp);
            this.mainPage.Location = new System.Drawing.Point(4, 29);
            this.mainPage.Name = "mainPage";
            this.mainPage.Size = new System.Drawing.Size(1095, 560);
            this.mainPage.TabIndex = 0;
            this.mainPage.Text = "Default";
            // 
            // secondPage
            // 
            this.secondPage.Controls.Add(this.btnDisconnect);
            this.secondPage.Controls.Add(this.dbControl);
            this.secondPage.Controls.Add(this.btnConnectDb);
            this.secondPage.Controls.Add(this.btnCreateTb);
            this.secondPage.Controls.Add(this.secondMessageBox);
            this.secondPage.Location = new System.Drawing.Point(4, 29);
            this.secondPage.Name = "secondPage";
            this.secondPage.Size = new System.Drawing.Size(1095, 560);
            this.secondPage.TabIndex = 0;
            this.secondPage.Text = "Database";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(329, 41);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(170, 50);
            this.btnDisconnect.TabIndex = 19;
            this.btnDisconnect.Text = "Disconnect Database";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // dbControl
            // 
            this.dbControl.Controls.Add(this.tabPageDb);
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
            // inputId
            // 
            this.inputId.Location = new System.Drawing.Point(81, 124);
            this.inputId.Name = "inputId";
            this.inputId.Size = new System.Drawing.Size(100, 22);
            this.inputId.TabIndex = 20;
            // 
            // inputTmp
            // 
            this.inputTmp.Location = new System.Drawing.Point(81, 179);
            this.inputTmp.Name = "inputTmp";
            this.inputTmp.Size = new System.Drawing.Size(100, 22);
            this.inputTmp.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
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
            this.fpControl.ResumeLayout(false);
            this.mainControl.ResumeLayout(false);
            this.mainPage.ResumeLayout(false);
            this.mainPage.PerformLayout();
            this.secondPage.ResumeLayout(false);
            this.dbControl.ResumeLayout(false);
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
        private Button btnCreateTb;
        private TabControl fpControl;
        private TabControl mainControl;
        private TabControl dbControl;
        private TabPage tabPageFp;
        private TabPage tabPageDb;
        private TabPage mainPage;
        private TabPage secondPage;
        private PictureBox picFpImg;
        private ComboBox cmbIdx;
        private RichTextBox messageBox;
        private RichTextBox secondMessageBox;
        private DataGridView fpData;
        private DataGridViewTextBoxColumn fpTemplate;
        private DataGridViewTextBoxColumn fpId;
        private Label labelNumOfFp;
        private Button btnInsert;
        private TextBox inputTmp;
        private TextBox inputId;
        private Button btnDisconnect;
        
    }
}

