using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class AdminLogIn : Form
    {
        DatabaseFile databaseFile;
        public AdminLogIn()
        {
            InitializeComponent();
            label3.Text = "";

            databaseFile = new DatabaseFile("Employee");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminName = textBox1.Text.Trim().ToString();
            string password = textBox2.Text.Trim().ToString();

            if(AdminVerification(adminName, password))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Successfully Log in";

                AdminDashboard adminDashboard = new AdminDashboard();

                adminDashboard.Show();
                this.Close();

            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private bool AdminVerification(string adminID, string password)
        {
            var record = databaseFile.LoadRecords<PassBook>("Emp_Account");
            bool initialVerify = false;
            bool exist = false;

            foreach(var rec in record)
            {
                if(rec.EmployeeID == adminID)
                {
                    exist = true;
                    if(rec.AdminStatus == "Admin" && rec.Password != null && textBox2.Text.Trim() == "")
                    {
                        label3.Text = "Please enter password";
                    }
                    else if (rec.AdminStatus == "Admin" && rec.Password == password)
                    {
                        initialVerify = true;
                    }  else if (rec.Password == null)
                    {
                        PasswordGenerator passwordGenerator = new PasswordGenerator(rec.EmployeeID);
                        passwordGenerator.Show();
                    }
                    else if (rec.AdminStatus == "Not Admin" && rec.Password == password && rec.Password != null)
                    {
                        label3.Text = "You dont have admin access";
                    }
                    else if (rec.AdminStatus == "Admin" && rec.Password != null && rec.Password != password)
                    {
                        label3.Text = "Incorrect Admin ID or Password";

                        DialogResult dr = MessageBox.Show("Invalid Admin ID or Password", "Warning", MessageBoxButtons.OK);
                        if (dr == DialogResult.OK)
                        {
                            label3.Text = "";
                        }
                    } 
                }
            }

            if (!exist)
            {
                label3.Text = "Invalid Employee ID";
            }
            return initialVerify;
        }
    }
}
