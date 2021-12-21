using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace Unitel
{
    public partial class Dashboard : Form
    {
        readonly DatabaseFile tokenSync = new DatabaseFile("Tokens");
        readonly TicketGen ticketGen = new TicketGen();
        readonly QueueScreen queueScreen = new QueueScreen();
        private TokenModel calledToken { get; set; }
        private List<TokenModel> tokens = null;
        readonly DatabaseFile db = new DatabaseFile("Employee");
        CustomerInformationPage cip = new CustomerInformationPage();
        private bool New_SignIn = false;

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);
        public Dashboard(string empId, string counter, int num, bool NewSignIn)
        {
            InitializeComponent();
            New_SignIn = NewSignIn;
            DataFetch();

            var rec = db.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", empId);
            this.label3.Text = $"{ rec.FirstName} { rec.LastName}";
            this.label4.Text = counter;

            if (num == 1)
            {
                ticketGen.Show();
            }
            else if (num == 2)
            {
                queueScreen.Show();
            }
            else if (num == 3)
            {
                queueScreen.Show();
                ticketGen.Show();
            }

        }





        private void DataFetch()
        {

            var records = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
            tokens = records;
            var ActiveRecords = records.FindAll(r => r.ActiveToken);

            dataGridView1.DataSource = ActiveRecords;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["TokenDigit"].Visible = false;
            dataGridView1.Columns["ActiveToken"].Visible = false;

            //Modify Headers
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridView1.Columns["MobileNumber"].HeaderText = "Mobile Number";
            dataGridView1.Columns["TokenNumber"].HeaderText = "Token Number";
            dataGridView1.Columns["TypeOfService"].HeaderText = "Type of Service";

            //Modify Size
            dataGridView1.Columns["CustomerName"].Width = (panel2.Width / 100) * 30;
            dataGridView1.Columns["MobileNumber"].Width = (panel2.Width / 100) * 30;
            dataGridView1.Columns["TokenNumber"].Width = (panel2.Width / 100) * 18;
            dataGridView1.Columns["TypeOfService"].Width = (panel2.Width / 100) * 30;
        }

        private void LogOut()
        {
            var record = tokenSync.LoadRecordbyIdentity<CounterModel>("Counters", "CounterNumber", label4.Text);
            tokenSync.DeleteRecord<CounterModel>("Counters", record.Id);
            queueScreen.Close();
            ticketGen.Close();

            Properties.Settings.Default.LoggedIn = false;
            Properties.Settings.Default.EmployeeID_Active = null;
            Properties.Settings.Default.Counter = null;
            Properties.Settings.Default.Number = 0;
            Properties.Settings.Default.Save();

            Home form1 = new Home();
            form1.Show();

            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (cip.Visible)
            {
                
                cip.Close();
            }
            button3.Enabled = false;
            LogOut();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string typeOfSer = dataGridView1.CurrentRow.Cells["TypeOfService"].Value.ToString();
                string phoneNum = dataGridView1.CurrentRow.Cells["MobileNumber"].Value.ToString();
                string token = dataGridView1.CurrentRow.Cells["TokenNumber"].Value.ToString();



                calledToken = tokenSync.LoadRecordbyIdentity<TokenModel>("ActiveCounter", "TokenNumber", token);
                calledToken.ActiveToken = false;
                tokenSync.UpsertRecord<TokenModel>("ActiveCounter", calledToken.Id, calledToken);

                DataFetch();
                this.WindowState = FormWindowState.Minimized;
                    
                cip = new CustomerInformationPage(calledToken, this);
                cip.Show();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string token = dataGridView1.CurrentRow.Cells["TokenNumber"].Value.ToString();
                string counter = label4.Text.Trim();

                queueScreen.Call_Control(token, counter);
            }


        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                BringToMinimize();
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                BringToNormalState();
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            BringToNormalState();
        }

        private void BringToMinimize()
        {
            DataFetch();
            this.WindowState = FormWindowState.Maximized;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(5);
            this.ShowInTaskbar = false;
        }

        private void BringToNormalState()
        {
            DataFetch();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }

        ConnectAgain:
            try
            {
                if (InternetGetConnectedState(out _, 0))
                {
                    if (!timer1.Enabled)
                    {
                        timer1.Start();
                    }

                    var record = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
                  
                    

                    if (!tokens.Count.Equals(record.Count))
                    {
                        DataFetch();
                    }
                }
                else
                {
                    timer1.Stop();
                    DialogResult dr = MessageBox.Show("No internet connection", "Error", MessageBoxButtons.OK);
                    int waitingTime = 0;

                    if (dr == DialogResult.OK)
                    {
                        UseWaitCursor = true;
                        while (!InternetGetConnectedState(out _, 0))
                        {
                            waitingTime++;
                        }

                        Console.WriteLine(waitingTime);

                        UseWaitCursor = false;
                        goto ConnectAgain;
                    }

                }

            }
            catch (NullReferenceException n)
            {
                Console.WriteLine(n);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (New_SignIn)
            {
                tokenSync.InsertRecord("Counters", new CounterModel
                {
                    ExecutiveName = label3.Text,
                    CounterNumber = label4.Text
                });
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to log out of this session?", "Confirmation", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                if (cip.Visible)
                {
                    cip.Close();
                }
                LogOut();
            }
        }

        private void openDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BringToNormalState();
        }

        private void Dashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Alt && e.KeyCode == Keys.L)
            {
                button3.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            if(InternetGetConnectedState(out _, 0))
            {
                DataFetch();
            }
        }
    }
}
