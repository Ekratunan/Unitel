using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Form1 : Form
    {
        readonly DatabaseFile databaseFile = new DatabaseFile("Employee");
        private List<PassBook> record{ get; set; }
        
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            if (CheckForInternetConnection())
            {
                textBox1.Focus();
                label4.Text = "";
                var passRecord = databaseFile.LoadRecords<PassBook>("Emp_Account");
                record = passRecord;
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
            bool inVerify = false;
            bool existance = record.Any(p => p.EmployeeID == textBox1.Text.Trim());

            if (CheckForInternetConnection())
            {
                if (existance)
                {
                    var rec = record.Find(p => p.EmployeeID == textBox1.Text.Trim());


                    if (rec.EmployeeID == textBox1.Text.Trim())
                    {
                        if (rec.Password != null && rec.Password != "" && comboBox1.Text.Trim() != "" && rec.Password == textBox2.Text.Trim())
                        {
                            inVerify = true;
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show($"Incorrect Password for E-ID: {rec.EmployeeID}", "Error", MessageBoxButtons.OK);
                            if(dr == DialogResult.OK)
                            {
                                label4.Text = "";
                            }
                        }
                    }

                }
            }
            else
            {
                label4.ForeColor = Color.Red;
                label4.Text = "No Internet";
            }








            return inVerify;

        }

        


       

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        public void Button1_Click(object sender, EventArgs e)
        {
            
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                label4.Text = "Logging in...";
                if (VerificationTask())
                {
                    Dashboard dashboard = new Dashboard(textBox1.Text.Trim(), comboBox1.Text.Trim());
                    dashboard.Show();

                    this.Hide();
                }
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

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please Enter Employee ID");
            }else if(!record.Any(p => p.EmployeeID == textBox1.Text.Trim()))
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

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                bool exist = record.Any(p => p.EmployeeID == textBox1.Text.Trim());

                if (exist)
                {
                    var rec = record.Find(p => p.EmployeeID == textBox1.Text.Trim());
                    if (rec.Password == null || rec.Password == "")
                    {
                        PasswordGenerator pass = new PasswordGenerator(rec.EmployeeID);
                        pass.ShowDialog();
                    }
                    else if (textBox2.Text.Trim() == "" && rec.Password != null)
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
            
            
        }

        private void comboBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
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
    }
}
