using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Form1 : Form
    {
        readonly DatabaseFile databaseFile;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            if (CheckForInternetConnection())
            {
                textBox1.Focus();
                databaseFile = new DatabaseFile("Employee");
                label4.Text = "";

            }
            else
            {
                label4.Text = "No Internet Connection";
            }
            
            

            
        }

        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.mongodb.com/"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private bool VerificationTask()
        {
            var record = databaseFile.LoadRecords<PassBook>("Emp_Account");

            bool inVerify = false;
            bool existance = record.Any(p => p.EmployeeID == textBox1.Text.Trim());
            try
            {
                if (CheckForInternetConnection())
                {

                    if (textBox1.Text.Trim() == "")
                    {
                        label4.ForeColor = Color.Red;
                        label4.Text = "Enter Employee ID";
                    }
                    else
                    {
                        if (existance)
                        {
                            var rec = databaseFile.LoadRecordbyIdentity<PassBook>("Emp_Account", "EmployeeID", textBox1.Text.Trim());
                            if (rec.EmployeeID == textBox1.Text.Trim())
                            {
                                if (rec.Password == null)
                                {
                                    PasswordGenerator password = new PasswordGenerator(rec.EmployeeID);
                                    password.Show();
                                }
                                else if (rec.Password != null && textBox2.Text.Trim() == "")

                                {
                                    label4.ForeColor = Color.Red;
                                    label4.Text = "Enter your password";
                                }
                                else if (rec.Password != null && rec.Password != "" && comboBox1.Text.Trim() == "")

                                {
                                    label4.ForeColor = Color.Red;
                                    label4.Text = "Select a Counter";
                                }
                                else if (rec.Password != null && rec.Password != "" && comboBox1.Text.Trim() != "" && rec.Password == textBox2.Text.Trim())
                                {
                                    inVerify = true;
                                }
                            }

                        }
                        else if (!existance)
                        {
                            label4.ForeColor = Color.Red;
                            label4.Text = "Employee not found";
                        }
                    }
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label4.Text = "No Internet";
                }
                
                



                
            }
            catch
            {
                //keep empty
            }

            return inVerify;

        }

        


       

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        public void Button1_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Green;
            label4.Text = "Logging In...";

            if (VerificationTask())
            {
                Dashboard dashboard = new Dashboard(textBox1.Text.Trim(), comboBox1.Text.Trim());
                dashboard.Show();

                this.Hide();
            }

            

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
