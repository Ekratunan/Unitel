using System;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Form1 : Form
    {
        DatabaseFile databaseFile;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();
            databaseFile = new DatabaseFile("Employee");
            label4.Text = "";
        }
        

        private bool VerificationTask()
        {
            
            var record = databaseFile.LoadRecords<PassBook>("Emp_Account");
            bool inVerify = false;
            bool exist = false;
            if (textBox1.Text.Trim() == "")
            {
                label4.Text = "Enter Employee ID";
            }
            else
            {
                foreach (var rec in record)
                {
                    if (rec.EmployeeID == textBox1.Text.Trim())
                    {
                        exist = true;
                        if (rec.Password == null)
                        {
                            PasswordGenerator password = new PasswordGenerator(rec.EmployeeID);
                            password.Show();
                        }
                        else if (rec.Password != null && textBox2.Text.Trim() == "")
                        {
                            label4.Text = "Enter your password";
                        } else if(rec.Password != null && rec.Password != "" && comboBox1.Text.Trim() == "")
                        {
                            label4.Text = "Select a Counter";
                        } else if(rec.Password != null && rec.Password != "" && comboBox1.Text.Trim() != "" && rec.Password == textBox2.Text.Trim())
                        {
                            inVerify = true;
                            break;
                        }
                    }
                }

                if (!exist)
                {
                    label4.Text = "Employee not found";
                }
            }
            
            
            
            return inVerify;
        }

        


       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        public void button1_Click(object sender, EventArgs e)
        {

            if (VerificationTask())
            {
                Dashboard dashboard = new Dashboard(textBox1.Text.Trim(), comboBox1.Text.Trim());
                dashboard.Show();

                this.Hide();
            }

            

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
