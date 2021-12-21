using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Unitel
{
    public partial class AdminLogIn : Form
    {
        DatabaseFile databaseFile = new DatabaseFile("Employee");
        protected List<SecurityModel> record;
        public AdminLogIn()
        {
            InitializeComponent();
            label3.Text = "";
            var passBook = databaseFile.LoadRecords<SecurityModel>("Emp_Account");
            record = passBook;
        }


        private string decodePassword(byte[] sample)
        {
            MemoryStream ms = new MemoryStream(sample);
            StreamReader reader = new StreamReader(ms);
            return reader.ReadToEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminName = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (AdminVerification(adminName, password))
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Successfully Log in";

                AdminDashboard adminDashboard = new AdminDashboard();
                Properties.Settings.Default.AdminLoggedIn = true;
                Properties.Settings.Default.AdminUserId = adminName;
                Properties.Settings.Default.AdminPassword = password;
                Properties.Settings.Default.Save();

                adminDashboard.Show();
                this.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home form1 = new Home();
            form1.Show();
            this.Close();
        }

        private bool AdminVerification(string adminID, string password)
        {

            bool initialVerify = false;
            bool exist = false;

            foreach (var rec in record)
            {
                if (rec.EmployeeID == adminID)
                {
                    string pass = null;
                    if (rec.Password != null)
                    {
                        pass = decodePassword(rec.Password);
                    }
                    exist = true;
                    if (rec.AdminStatus == "Admin" && rec.Password != null && textBox2.Text.Trim() == "")
                    {
                        label3.Text = "Please enter password";
                    }
                    else if (rec.AdminStatus == "Admin" && pass == password)
                    {
                        initialVerify = true;
                    }
                    else if (rec.Password == null)
                    {
                        PasswordGenerator passwordGenerator = new PasswordGenerator(rec.EmployeeID);
                        passwordGenerator.Show();
                    }
                    else if (rec.AdminStatus == "Not Admin" && pass == password && rec.Password != null)
                    {
                        label3.Text = "You dont have admin access";
                    }
                    else if (rec.AdminStatus == "Admin" && rec.Password != null && pass != password)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (record.Any(p => p.EmployeeID == textBox1.Text.Trim()))
            {
                this.ActiveControl = textBox2;
                textBox2.Focus();
            }
        }
    }
}
