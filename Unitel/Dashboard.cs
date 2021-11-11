using System;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Dashboard : Form
    {
        TicketGen ticketGen;
        QueueScreen queueScreen;

        public Dashboard(string empId, string counter)
        {
            InitializeComponent();
            DatabaseFile db = new DatabaseFile("Employee");
            var rec = db.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", empId);


            this.label3.Text = $"{ rec.FirstName} { rec.LastName}";
            this.label4.Text = counter;

            ticketGen = new TicketGen();
            queueScreen = new QueueScreen();
            queueScreen.Show();
            ticketGen.Show();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            

            queueScreen.Close();
            ticketGen.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string phoneNum = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            CustomerInformationPage cip = new CustomerInformationPage(customerName, phoneNum);

            cip.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
