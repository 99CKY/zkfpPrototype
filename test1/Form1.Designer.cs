using System;
using System.Windows.Forms;
using test1.Properties;

namespace test1
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnInit = new System.Windows.Forms.Button();
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnEnroll = new System.Windows.Forms.Button();
            this.bnVerify = new System.Windows.Forms.Button();
            this.bnFree = new System.Windows.Forms.Button();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnIdentify = new System.Windows.Forms.Button();
            this.picFPImg = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbIdx = new System.Windows.Forms.ComboBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtTemplate1 = new System.Windows.Forms.TextBox();
            this.txtTemplate2 = new System.Windows.Forms.TextBox();
            this.btMatch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImport = new System.Windows.Forms.Button();
            this.textRes = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP address";
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AllowUserToDeleteRows = false;
            this.dgvRecords.AllowUserToOrderColumns = true;
            this.dgvRecords.AllowUserToResizeColumns = false;
            this.dgvRecords.AllowUserToResizeRows = false;
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecords.Location = new System.Drawing.Point(0, 0);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.RowHeadersWidth = 51;
            this.dgvRecords.Size = new System.Drawing.Size(791, 414);
            this.dgvRecords.TabIndex = 883;
          
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvRecords);
            this.panel1.Location = new System.Drawing.Point(12, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 414);
            this.panel1.TabIndex = 891;
            // 
            // bnInit
            // 
            this.bnInit.Location = new System.Drawing.Point(19, 11);
            this.bnInit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnInit.Name = "bnInit";
            this.bnInit.Size = new System.Drawing.Size(100, 37);
            this.bnInit.TabIndex = 0;
            this.bnInit.Text = "Initialize";
            this.bnInit.UseVisualStyleBackColor = true;
            this.bnInit.Click += new System.EventHandler(this.bnInit_Click);
            // 
            // bnOpen
            // 
            this.bnOpen.Enabled = false;
            this.bnOpen.Location = new System.Drawing.Point(19, 81);
            this.bnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(100, 37);
            this.bnOpen.TabIndex = 1;
            this.bnOpen.Text = "Open";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnEnroll
            // 
            this.bnEnroll.Enabled = false;
            this.bnEnroll.Location = new System.Drawing.Point(79, 158);
            this.bnEnroll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnEnroll.Name = "bnEnroll";
            this.bnEnroll.Size = new System.Drawing.Size(257, 37);
            this.bnEnroll.TabIndex = 2;
            this.bnEnroll.Text = "Enroll(Add To DataBase)";
            this.bnEnroll.UseVisualStyleBackColor = true;
            this.bnEnroll.Click += new System.EventHandler(this.bnEnroll_Click);
            // 
            // bnVerify
            // 
            this.bnVerify.Enabled = false;
            this.bnVerify.Location = new System.Drawing.Point(79, 272);
            this.bnVerify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnVerify.Name = "bnVerify";
            this.bnVerify.Size = new System.Drawing.Size(257, 37);
            this.bnVerify.TabIndex = 3;
            this.bnVerify.Text = "Match Mode(1:1)";
            this.bnVerify.UseVisualStyleBackColor = true;
            this.bnVerify.Click += new System.EventHandler(this.bnVerify_Click);
            // 
            // bnFree
            // 
            this.bnFree.Enabled = false;
            this.bnFree.Location = new System.Drawing.Point(288, 81);
            this.bnFree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnFree.Name = "bnFree";
            this.bnFree.Size = new System.Drawing.Size(100, 37);
            this.bnFree.TabIndex = 4;
            this.bnFree.Text = "Finalize";
            this.bnFree.UseVisualStyleBackColor = true;
            this.bnFree.Click += new System.EventHandler(this.bnFree_Click);
            // 
            // bnClose
            // 
            this.bnClose.Enabled = false;
            this.bnClose.Location = new System.Drawing.Point(288, 19);
            this.bnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(100, 37);
            this.bnClose.TabIndex = 5;
            this.bnClose.Text = "Close";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // bnIdentify
            // 
            this.bnIdentify.Enabled = false;
            this.bnIdentify.Location = new System.Drawing.Point(79, 227);
            this.bnIdentify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnIdentify.Name = "bnIdentify";
            this.bnIdentify.Size = new System.Drawing.Size(257, 37);
            this.bnIdentify.TabIndex = 6;
            this.bnIdentify.Text = "Identiy Mode(1:N)";
            this.bnIdentify.UseVisualStyleBackColor = true;
            this.bnIdentify.Click += new System.EventHandler(this.bnIdentify_Click);
            // 
            // picFPImg
            // 
            this.picFPImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picFPImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picFPImg.Location = new System.Drawing.Point(12, 9);
            this.picFPImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picFPImg.Name = "picFPImg";
            this.picFPImg.Size = new System.Drawing.Size(355, 426);
            this.picFPImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFPImg.TabIndex = 8;
            this.picFPImg.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Index:";
            // 
            // cmbIdx
            // 
            this.cmbIdx.FormattingEnabled = true;
            this.cmbIdx.Location = new System.Drawing.Point(189, 81);
            this.cmbIdx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbIdx.Name = "cmbIdx";
            this.cmbIdx.Size = new System.Drawing.Size(52, 27);
            this.cmbIdx.TabIndex = 10;
            // 
            // btnOutput
            // 
            this.btnOutput.Enabled = false;
            this.btnOutput.Location = new System.Drawing.Point(193, 445);
            this.btnOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(175, 37);
            this.btnOutput.TabIndex = 12;
            this.btnOutput.Text = "Output BMP";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btCaptureBmp_Click);
            // 
            // txtTemplate1
            // 
            this.txtTemplate1.Location = new System.Drawing.Point(19, 369);
            this.txtTemplate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTemplate1.Name = "txtTemplate1";
            this.txtTemplate1.Size = new System.Drawing.Size(356, 26);
            this.txtTemplate1.TabIndex = 13;
            // 
            // txtTemplate2
            // 
            this.txtTemplate2.Location = new System.Drawing.Point(19, 429);
            this.txtTemplate2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTemplate2.Name = "txtTemplate2";
            this.txtTemplate2.Size = new System.Drawing.Size(356, 26);
            this.txtTemplate2.TabIndex = 14;
            // 
            // btMatch
            // 
            this.btMatch.Enabled = false;
            this.btMatch.Location = new System.Drawing.Point(79, 486);
            this.btMatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btMatch.Name = "btMatch";
            this.btMatch.Size = new System.Drawing.Size(237, 37);
            this.btMatch.TabIndex = 15;
            this.btMatch.Text = "Match Finger Template Data";
            this.btMatch.UseVisualStyleBackColor = true;
            this.btMatch.Click += new System.EventHandler(this.btMatch_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(424, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 532);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.Tag = "S";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImport);
            this.tabPage1.Controls.Add(this.picFPImg);
            this.tabPage1.Controls.Add(this.btnOutput);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(375, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fingerprint image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(11, 445);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(175, 37);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "Import BMP";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // textRes
            // 
            this.textRes.Location = new System.Drawing.Point(0, 538);
            this.textRes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textRes.Name = "textRes";
            this.textRes.Size = new System.Drawing.Size(799, 197);
            this.textRes.TabIndex = 17;
            this.textRes.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 733);
            this.Controls.Add(this.textRes);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btMatch);
            this.Controls.Add(this.txtTemplate2);
            this.Controls.Add(this.txtTemplate1);
            this.Controls.Add(this.cmbIdx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnIdentify);
            this.Controls.Add(this.bnClose);
            this.Controls.Add(this.bnFree);
            this.Controls.Add(this.bnVerify);
            this.Controls.Add(this.bnEnroll);
            this.Controls.Add(this.bnOpen);
            this.Controls.Add(this.bnInit);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 496);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C# ZKFinger Demo v0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        
        
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Panel panel1;
        
        /*
        private Button button3;
        private System.Windows.Forms.Button button2; 
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1; 
        private Label label6; 
        private System.Windows.Forms.Label label5; 
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label result;
        */
        

        // Code from zkfinger sdk windows zk10
        private System.Windows.Forms.Button bnInit;
        private System.Windows.Forms.Button bnOpen;
        private System.Windows.Forms.Button bnEnroll;
        private System.Windows.Forms.Button bnVerify;
        private System.Windows.Forms.Button bnFree;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnIdentify;
        private System.Windows.Forms.PictureBox picFPImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbIdx;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtTemplate1;
        private System.Windows.Forms.TextBox txtTemplate2;
        private System.Windows.Forms.Button btMatch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.RichTextBox textRes;
        //

    }
}

