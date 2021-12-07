using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Unitel
{
    public partial class Home : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);

        DatabaseFile databaseFile = null;
        protected List<SecurityModel> Record{ get; set; }
        readonly AdminLogIn adminLogIn = new AdminLogIn();
        TicketGen ticketGen = new TicketGen();
        QueueScreen queueScreen = new QueueScreen();
        PasswordResetPage ps = new PasswordResetPage();
        PasswordGenerator pass = new PasswordGenerator();
        AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();

        public Home()
        {
            InitializeComponent();
            if (InternetGetConnectedState(out _, 0))
            {
                label4.Text = "";
                Db_Load();
                CounterUpdate();
            }
            else
            {
                label2.Hide();
                textBox1.Hide();
                label4.Text = "No Internet Connection";
                timer1.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StepTwo(false);
            button1.Enabled = false;
            this.ActiveControl = textBox1;
        }


        private void Db_Load()
        {
            databaseFile = new DatabaseFile("Employee");
            var passRecord = databaseFile.LoadRecords<SecurityModel>("Emp_Account");
            Record = passRecord;
            acsc.AddRange(Record.Select(p => p.EmployeeID).ToArray());
            textBox1.AutoCompleteCustomSource = acsc;
        }

        private void CounterUpdate()
        {
            DatabaseFile databaseFile = new DatabaseFile("Tokens");
            var rec = databaseFile.LoadRecords<CounterModel>("Counters");

            foreach(var r in rec)
            {
                if (comboBox1.Items.Contains(r.CounterNumber))
                {
                    comboBox1.Items.Remove(r.CounterNumber);
                }

            }

            
        }


        private string DecodePassword(byte[] sample)
        {
            MemoryStream ms = new MemoryStream(sample);
            StreamReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        private bool VerificationTask()
        {
            bool inVerify = false;
            bool existance = Record.Any(p => p.EmployeeID == textBox1.Text.Trim());

            if (InternetGetConnectedState(out _, 0))
            {
                if (existance)
                {
                    var rec = Record.Find(p => p.EmployeeID == textBox1.Text.Trim());


                    if (rec.EmployeeID == textBox1.Text.Trim())
                    {
                        if (rec.Password != null && DecodePassword(rec.Password) != "" && comboBox1.Text.Trim() != "" && DecodePassword(rec.Password) == textBox2.Text.Trim())
                        {
                            inVerify = true;
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show($"Incorrect Password for E-ID: {rec.EmployeeID}", "Error", MessageBoxButtons.OK);
                            if(dr == DialogResult.OK)
                            {
                                label4.Text = "";
                                textBox2.Text = "";
                                comboBox1.Text = "";
                            }
                        }
                    }

                }
            }
            else
            {
                label4.Text = "No Internet";
            }

            return inVerify;

        }
        

        public void Button1_Click(object sender, EventArgs e)
        {
            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int x;

                if (checkBox1.Checked && checkBox2.Checked)
                {
                    x = 3;
                }else if (checkBox2.Checked)
                {
                    x = 2;
                }else if (checkBox1.Checked)
                {
                    x = 1;
                }
                else
                {
                    x = 0;
                }

                button1.Text = "Signing in..";
                if (VerificationTask())
                {
                    Dashboard dashboard = new Dashboard(textBox1.Text.Trim(), comboBox1.Text.Trim(), x);
                    
                    dashboard.Show();

                    this.Hide();
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            adminLogIn.Show();
            this.Hide();
        }

        

        private void TextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox1, -20);

            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please Enter Employee ID");
            }else if(!Record.Any(p => p.EmployeeID == textBox1.Text.Trim()))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Employee ID is not valid");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void StepTwo(bool vis)
        {
            if (vis)
            {
                textBox2.Show();
                comboBox1.Show();
                label3.Show();
                label5.Show();
                button1.Show();
                pictureBox1.Hide();
                linkLabel4.Hide();
                forgotPassButton.Show();
                this.ActiveControl = textBox2;
                this.AcceptButton = null;
                
            }
            else
            {
                textBox2.Hide();
                comboBox1.Hide();
                label3.Hide();
                label5.Hide();
                button1.Hide();
                linkLabel4.Show();
                pictureBox1.Show();
                forgotPassButton.Hide();
                this.AcceptButton = linkLabel4;
            }
            
        }



        private void TextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox2, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox2, -20);
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                

                  var rec = Record.Find(p => p.EmployeeID == textBox1.Text.Trim());
                    if (textBox2.Text.Trim() == "" && rec.Password != null)
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(textBox2, "Enter Password");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(textBox2, null);
                    }

                
                
                

            }
            
            
        }

        private void ComboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(comboBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.comboBox1, -50);
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    e.Cancel = true;
                    comboBox1.Focus();
                    errorProvider1.SetError(comboBox1, "Enter Counter Number");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(comboBox1, null);

                }
            }            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out _, 0))
            {
                timer1.Stop();
                label4.Text = "";
                Db_Load();
                textBox1.Show();
                label2.Show();
                textBox1.Focus();
            }
        }

        private void EID_Verifier()
        {
            try
            {
                bool exists = Record.Any(p => p.EmployeeID == textBox1.Text.Trim());

                if (exists)
                {
                    var user = Record.Find(p => p.EmployeeID == textBox1.Text.Trim());
                    bool newUser = user.Password == null || DecodePassword(user.Password) == "";

                    if (newUser)
                    {
                        pass = new PasswordGenerator(user.EmployeeID);
                        pass.Show();
                        syncTimer.Enabled = true;
                    }
                    else if (!newUser)
                    {
                        errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
                        errorProvider1.SetIconPadding(this.textBox1, -20);
                        errorProvider1.SetError(textBox1, "");
                        StepTwo(true);
                    }
                }
                else
                {
                    errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
                    errorProvider1.SetIconPadding(this.textBox1, -20);
                    errorProvider1.SetError(textBox1, "Employee ID is not valid");
                    StepTwo(false);
                }
            }
            catch (Exception)
            {
                label4.Text = "No Internet Connection";
            }
        }

        Control ctr1;
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if (ctr1 is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EID_Verifier();
                }
            }
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(comboBox1.Text.Trim())){
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                button1.Enabled = true;
                this.AcceptButton = button1;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if (ctr1 is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    comboBox1.DroppedDown = true;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ticketGen.IsDisposed)
            {
                ticketGen = new TicketGen();
            }

            if (!ticketGen.Visible)
            {
                ticketGen.Show();
                
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000);
            }
            else
            {
                MessageBox.Show("Ticket Generator is already opened", "Unable to open TG", MessageBoxButtons.OK);
            }
            
        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (queueScreen.IsDisposed)
            {
                queueScreen = new QueueScreen();
            }


            if (!queueScreen.Visible)
            {
                queueScreen.Show();
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000);
            }
            else
            {
                MessageBox.Show("Queue Screen is already opened", "Unable to open QS", MessageBoxButtons.OK);
            }
            
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Appender();
        }

        private void Appender()
        {
            this.Show();
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            EID_Verifier();
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EID_Verifier();
        }

        private void openQueueGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ticketGen.IsDisposed)
            {
                ticketGen = new TicketGen();
            }

            if (!ticketGen.Visible)
            {
                ticketGen.Show();
            }
        }

        private void openQueueDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (queueScreen.IsDisposed)
            {
                queueScreen = new QueueScreen();
            }

            if (!queueScreen.Visible)
            {
                queueScreen.Show();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appender();
        }

        private void closeToolStripMenuItem_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if(!ps.Visible)
            {
                ps.Show();
                textBox1.Clear();
                textBox2.Clear();
                StepTwo(false);
                syncTimer.Enabled = true;
            }
        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out _, 0))
            {
                if (ps.IsDisposed)
                {
                    label4.Text = "";
                    var passRecord = databaseFile.LoadRecords<SecurityModel>("Emp_Account");
                    Record = passRecord;
                    ps = new PasswordResetPage();
                    this.ActiveControl = textBox1;
                    syncTimer.Stop();
                }

                if (pass.IsDisposed)
                {
                    var passRecord = databaseFile.LoadRecords<SecurityModel>("Emp_Account");
                    Record = passRecord;
                    pass = new PasswordGenerator();
                    StepTwo(true);
                    syncTimer.Stop();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (queueScreen.Visible)
            {
                contextMenuStrip1.Items[3].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[3].Enabled = true;
            }

            if (ticketGen.Visible)
            {
                contextMenuStrip1.Items[2].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[2].Enabled = true;
            }
        }
    }
}
