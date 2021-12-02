
namespace Unitel
{
    partial class QueueScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.line1CN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.line1TN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.line6CN = new System.Windows.Forms.Label();
            this.line5CN = new System.Windows.Forms.Label();
            this.line4CN = new System.Windows.Forms.Label();
            this.line3CN = new System.Windows.Forms.Label();
            this.line2CN = new System.Windows.Forms.Label();
            this.line6TN = new System.Windows.Forms.Label();
            this.line5TN = new System.Windows.Forms.Label();
            this.line3TN = new System.Windows.Forms.Label();
            this.line4TN = new System.Windows.Forms.Label();
            this.line2TN = new System.Windows.Forms.Label();
            this.blinkerTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.line1CN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.line1TN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 142);
            this.panel1.TabIndex = 0;
            // 
            // line1CN
            // 
            this.line1CN.AutoSize = true;
            this.line1CN.BackColor = System.Drawing.Color.Transparent;
            this.line1CN.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line1CN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.line1CN.Location = new System.Drawing.Point(505, 52);
            this.line1CN.Name = "line1CN";
            this.line1CN.Size = new System.Drawing.Size(121, 32);
            this.line1CN.TabIndex = 3;
            this.line1CN.Text = "Counter#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(505, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Counter Number";
            // 
            // line1TN
            // 
            this.line1TN.AutoSize = true;
            this.line1TN.BackColor = System.Drawing.Color.Transparent;
            this.line1TN.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line1TN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.line1TN.Location = new System.Drawing.Point(242, 24);
            this.line1TN.Name = "line1TN";
            this.line1TN.Size = new System.Drawing.Size(257, 86);
            this.line1TN.TabIndex = 1;
            this.line1TN.Text = "Ticket#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Currently Calling :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 364);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.panel3.BackgroundImage = global::Unitel.Properties.Resources.tC_back;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(648, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 364);
            this.panel3.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(6, 47);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(187, 105);
            this.label17.TabIndex = 12;
            this.label17.Text = "Please check your\r\nticket and visit the\r\ncorresponding counter.\r\nThanks for your\r" +
    "\npatience :)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Unitel.Properties.Resources.logo_Unitel_02;
            this.pictureBox1.Location = new System.Drawing.Point(12, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 63);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(2)))), ((int)(((byte)(54)))));
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.line6CN);
            this.groupBox1.Controls.Add(this.line5CN);
            this.groupBox1.Controls.Add(this.line4CN);
            this.groupBox1.Controls.Add(this.line3CN);
            this.groupBox1.Controls.Add(this.line2CN);
            this.groupBox1.Controls.Add(this.line6TN);
            this.groupBox1.Controls.Add(this.line5TN);
            this.groupBox1.Controls.Add(this.line3TN);
            this.groupBox1.Controls.Add(this.line4TN);
            this.groupBox1.Controls.Add(this.line2TN);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(571, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 364);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counters";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(344, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(209, 32);
            this.label15.TabIndex = 11;
            this.label15.Text = "Counter Number";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(64, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(187, 32);
            this.label16.TabIndex = 10;
            this.label16.Text = "Ticket Number";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line6CN
            // 
            this.line6CN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line6CN.AutoSize = true;
            this.line6CN.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line6CN.ForeColor = System.Drawing.Color.Yellow;
            this.line6CN.Location = new System.Drawing.Point(461, 304);
            this.line6CN.Name = "line6CN";
            this.line6CN.Size = new System.Drawing.Size(90, 32);
            this.line6CN.TabIndex = 9;
            this.line6CN.Text = "label14";
            this.line6CN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line5CN
            // 
            this.line5CN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line5CN.AutoSize = true;
            this.line5CN.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line5CN.ForeColor = System.Drawing.Color.Yellow;
            this.line5CN.Location = new System.Drawing.Point(462, 261);
            this.line5CN.Name = "line5CN";
            this.line5CN.Size = new System.Drawing.Size(89, 32);
            this.line5CN.TabIndex = 8;
            this.line5CN.Text = "label13";
            this.line5CN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line4CN
            // 
            this.line4CN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line4CN.AutoSize = true;
            this.line4CN.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line4CN.ForeColor = System.Drawing.Color.Yellow;
            this.line4CN.Location = new System.Drawing.Point(462, 213);
            this.line4CN.Name = "line4CN";
            this.line4CN.Size = new System.Drawing.Size(89, 32);
            this.line4CN.TabIndex = 7;
            this.line4CN.Text = "label12";
            this.line4CN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line3CN
            // 
            this.line3CN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line3CN.AutoSize = true;
            this.line3CN.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line3CN.ForeColor = System.Drawing.Color.Yellow;
            this.line3CN.Location = new System.Drawing.Point(465, 166);
            this.line3CN.Name = "line3CN";
            this.line3CN.Size = new System.Drawing.Size(86, 32);
            this.line3CN.TabIndex = 6;
            this.line3CN.Text = "label11";
            this.line3CN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line2CN
            // 
            this.line2CN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line2CN.AutoSize = true;
            this.line2CN.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line2CN.ForeColor = System.Drawing.Color.Yellow;
            this.line2CN.Location = new System.Drawing.Point(462, 120);
            this.line2CN.Name = "line2CN";
            this.line2CN.Size = new System.Drawing.Size(89, 32);
            this.line2CN.TabIndex = 5;
            this.line2CN.Text = "label10";
            this.line2CN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line6TN
            // 
            this.line6TN.AutoSize = true;
            this.line6TN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line6TN.ForeColor = System.Drawing.Color.Gold;
            this.line6TN.Location = new System.Drawing.Point(69, 304);
            this.line6TN.Name = "line6TN";
            this.line6TN.Size = new System.Drawing.Size(83, 32);
            this.line6TN.TabIndex = 4;
            this.line6TN.Text = "label9";
            this.line6TN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line5TN
            // 
            this.line5TN.AutoSize = true;
            this.line5TN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line5TN.ForeColor = System.Drawing.Color.Gold;
            this.line5TN.Location = new System.Drawing.Point(69, 261);
            this.line5TN.Name = "line5TN";
            this.line5TN.Size = new System.Drawing.Size(83, 32);
            this.line5TN.TabIndex = 3;
            this.line5TN.Text = "label8";
            this.line5TN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line3TN
            // 
            this.line3TN.AutoSize = true;
            this.line3TN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line3TN.ForeColor = System.Drawing.Color.Gold;
            this.line3TN.Location = new System.Drawing.Point(69, 166);
            this.line3TN.Name = "line3TN";
            this.line3TN.Size = new System.Drawing.Size(83, 32);
            this.line3TN.TabIndex = 2;
            this.line3TN.Text = "label7";
            this.line3TN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line4TN
            // 
            this.line4TN.AutoSize = true;
            this.line4TN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line4TN.ForeColor = System.Drawing.Color.Gold;
            this.line4TN.Location = new System.Drawing.Point(69, 213);
            this.line4TN.Name = "line4TN";
            this.line4TN.Size = new System.Drawing.Size(83, 32);
            this.line4TN.TabIndex = 1;
            this.line4TN.Text = "label6";
            this.line4TN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // line2TN
            // 
            this.line2TN.AutoSize = true;
            this.line2TN.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line2TN.ForeColor = System.Drawing.Color.Gold;
            this.line2TN.Location = new System.Drawing.Point(69, 120);
            this.line2TN.Name = "line2TN";
            this.line2TN.Size = new System.Drawing.Size(82, 32);
            this.line2TN.TabIndex = 0;
            this.line2TN.Text = "Line 2";
            this.line2TN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blinkerTimer
            // 
            this.blinkerTimer.Tick += new System.EventHandler(this.BlinkerTimer_Tick);
            // 
            // QueueScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(863, 545);
            this.Name = "QueueScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unitel- Customer Queue";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label line1CN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label line1TN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label line6CN;
        private System.Windows.Forms.Label line5CN;
        private System.Windows.Forms.Label line4CN;
        private System.Windows.Forms.Label line3CN;
        private System.Windows.Forms.Label line2CN;
        private System.Windows.Forms.Label line6TN;
        private System.Windows.Forms.Label line5TN;
        private System.Windows.Forms.Label line3TN;
        private System.Windows.Forms.Label line4TN;
        private System.Windows.Forms.Label line2TN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer blinkerTimer;
    }
}