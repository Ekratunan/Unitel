using System;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();

            label4.Text = "";

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private bool newAccount = false;

        public void button1_Click(object sender, EventArgs e)
        {
            string empId = textBox1.Text.Trim();
            string counter = comboBox1.Text.Trim();

            bool blankEmpId = empId == "";
            bool blankCounter = counter == "";
            bool blankPassword = textBox2.Text.Trim() == "";

            if (blankEmpId)
            {
                label4.Text = "Enter Employee ID";
            }
            else if(VerificationTask() && blankCounter)
            {
                label4.Text = "Select Counter";
            }
            else if(blankPassword && !newAccount)
            {
                label4.Text = "Enter Password";
            }
            else if(VerificationTask() && !blankCounter)
            {
                this.Hide();
                Dashboard dashboard = new Dashboard(empId, counter);
                TicketGen ticketGen = new TicketGen();
                QueueScreen queueScreen = new QueueScreen();

                queueScreen.Show();
                ticketGen.Show();
                dashboard.Show();
            }
            else if (!VerificationTask() && !blankEmpId && !blankPassword && !blankCounter)
            {
                label4.Text = "Invalid Employee ID or Password";
            }

        }

        private bool VerificationTask()
        {
            bool inVarify = false;

            DatabaseFile databaseFile = new DatabaseFile("Employee");

            var record = databaseFile.LoadRecords<PassBook>("Emp_Account");

            foreach(var rec in record)
            {
                if(rec.EmployeeID == textBox1.Text.Trim())
                {
                    if(rec.Password == null)
                    {
                        newAccount = true;
                        PasswordGenerator pass = new PasswordGenerator(rec.EmployeeID);
                        pass.Show();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.Text = "";
                        label4.Text = "";

                    }else if(rec.Password == textBox2.Text)
                    {
                        inVarify = true;
                    }
                }
            }

            return inVarify;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLogIn adminLogIn = new AdminLogIn();

            adminLogIn.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
