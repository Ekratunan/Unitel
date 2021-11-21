using System;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Dashboard : Form
    {
        readonly TicketGen ticketGen = new TicketGen();
        readonly QueueScreen queueScreen = new QueueScreen();
        private int numOfRec = 0;

        public Dashboard(string empId, string counter)
        {
            InitializeComponent();
            DatabaseFile db = new DatabaseFile("Employee");
            var rec = db.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", empId);

            DataFetch();


            this.label3.Text = $"{ rec.FirstName} { rec.LastName}";
            this.label4.Text = counter;

            queueScreen.Show();
            ticketGen.Show();

            Timer timer = new Timer
            {
                Interval = (5 * 1000) // 10 secs
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        DatabaseFile tokenSync = new DatabaseFile("Tokens");
        private void timer_Tick(object sender, EventArgs e)
        {
            var record = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
            int newRec = record.Count;

            if (numOfRec != newRec)
            {
                DataFetch();
            }
            
            
        }

        private void DataFetch()
        {
            
            var record = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
            numOfRec = record.Count;

            dataGridView1.DataSource = record;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["TokenDigit"].Visible = false;

            //Modify Headers
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridView1.Columns["MobileNumber"].HeaderText = "Mobile Number";
            dataGridView1.Columns["TokenNumber"].HeaderText = "Token Number";
            dataGridView1.Columns["TypeOfService"].HeaderText = "Type of Service";
            
            //Modify Size
            dataGridView1.Columns["CustomerName"].Width = 220;
            dataGridView1.Columns["MobileNumber"].Width = 200;
            dataGridView1.Columns["TokenNumber"].Width = 200;
            dataGridView1.Columns["TypeOfService"].Width = 264;
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            

            queueScreen.Close();
            ticketGen.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string phoneNum = dataGridView1.CurrentRow.Cells["MobileNumber"].Value.ToString();

            if (phoneNum == "")
            {
                NewUser newUser = new NewUser();
                newUser.Show();
            }else if(phoneNum != "")
            {
                CustomerInformationPage cip = new CustomerInformationPage(phoneNum);
                cip.Show();
            }

            this.WindowState = FormWindowState.Minimized;
        }
    }
}
