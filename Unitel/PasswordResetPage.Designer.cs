﻿
namespace Unitel
{
    partial class PasswordResetPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordResetPage));
            this.backPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.otpPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.otpVerifierButton = new System.Windows.Forms.Button();
            this.emailPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backPanel.SuspendLayout();
            this.otpPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.emailPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backPanel
            // 
            this.backPanel.BackgroundImage = global::Unitel.Properties.Resources.admin_log_in_screen_04;
            this.backPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.backPanel.Controls.Add(this.button1);
            this.backPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.backPanel.Location = new System.Drawing.Point(0, 0);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(263, 77);
            this.backPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(240, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // otpPanel
            // 
            this.otpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.otpPanel.Controls.Add(this.tableLayoutPanel2);
            this.otpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otpPanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.otpPanel.Location = new System.Drawing.Point(0, 0);
            this.otpPanel.MaximumSize = new System.Drawing.Size(264, 109);
            this.otpPanel.MinimumSize = new System.Drawing.Size(264, 109);
            this.otpPanel.Name = "otpPanel";
            this.otpPanel.Size = new System.Drawing.Size(264, 109);
            this.otpPanel.TabIndex = 5;
            this.otpPanel.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.otpVerifierButton, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(264, 109);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 51);
            this.label2.TabIndex = 0;
            this.label2.Text = "OTP is sent to your email. Please check your OTP and Enter the code here:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(11)))), ((int)(((byte)(108)))));
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Location = new System.Drawing.Point(3, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Enter 4 digit OTP code";
            this.textBox2.Size = new System.Drawing.Size(258, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // otpVerifierButton
            // 
            this.otpVerifierButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(211)))), ((int)(((byte)(80)))));
            this.otpVerifierButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otpVerifierButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.otpVerifierButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.otpVerifierButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.otpVerifierButton.Location = new System.Drawing.Point(3, 83);
            this.otpVerifierButton.Name = "otpVerifierButton";
            this.otpVerifierButton.Size = new System.Drawing.Size(258, 23);
            this.otpVerifierButton.TabIndex = 2;
            this.otpVerifierButton.Text = "Verify";
            this.otpVerifierButton.UseVisualStyleBackColor = false;
            this.otpVerifierButton.Click += new System.EventHandler(this.otpVerifierButton_Click);
            // 
            // emailPanel
            // 
            this.emailPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.emailPanel.Controls.Add(this.tableLayoutPanel1);
            this.emailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailPanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.emailPanel.Location = new System.Drawing.Point(0, 77);
            this.emailPanel.MaximumSize = new System.Drawing.Size(264, 109);
            this.emailPanel.MinimumSize = new System.Drawing.Size(264, 109);
            this.emailPanel.Name = "emailPanel";
            this.emailPanel.Size = new System.Drawing.Size(264, 109);
            this.emailPanel.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sendButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.92064F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.07937F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 109);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your Employee ID";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(11)))), ((int)(((byte)(108)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(3, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Your Employee ID";
            this.textBox1.Size = new System.Drawing.Size(260, 23);
            this.textBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBox1, "Enter the Employee ID that you want to reset password.");
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(211)))), ((int)(((byte)(80)))));
            this.sendButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sendButton.Location = new System.Drawing.Point(3, 52);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(260, 33);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send OTP";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // PasswordResetPage
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(263, 186);
            this.Controls.Add(this.emailPanel);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.otpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(263, 186);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(263, 186);
            this.Name = "PasswordResetPage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Password";
            this.TopMost = true;
            this.backPanel.ResumeLayout(false);
            this.otpPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.emailPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel emailPanel;
        private System.Windows.Forms.Panel otpPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button otpVerifierButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}