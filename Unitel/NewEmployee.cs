using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Unitel
{
    public partial class NewEmployee : Form
    {
        DatabaseFile passBook = new DatabaseFile("Employee");
        private List<EmployeeModel> persons;

        public NewEmployee()
        {
            InitializeComponent();
            label8.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                string employeeId = textBox1.Text.Trim();
                string firstName = textBox2.Text.Trim();
                string lastName = textBox3.Text.Trim();
                string phoneNumber = textBox4.Text.Trim();
                string designation = textBox5.Text.Trim();
                string salary = textBox6.Text.Trim();


                string adminStat;
                if (checkBox1.Checked)
                {
                    adminStat = "Admin";
                }
                else
                {
                    adminStat = "Not Admin";
                }

                passBook.InsertRecord("Emp_Personal_Info", new EmployeeModel
                {
                    UserImage = null,

                    EmployeeID = employeeId,
                    EmailAddress = emailTextBox.Text.Trim(),
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Designation = designation,
                    Salary = salary,
                    PresentAddress = new AddressModel
                    {
                        Street = "",
                        State = "",
                        City = "",
                        PostCode = "",
                        Country = ""
                    },
                    PermanentAddress = new AddressModel
                    {
                        Street = "",
                        State = "",
                        City = "",
                        PostCode = "",
                        Country = ""
                    },
                    AdminStatus = adminStat

                });

                passBook.InsertRecord("Emp_Account", new SecurityModel
                {
                    AdminStatus = adminStat,
                    EmployeeID = employeeId
                });


                label8.Text = "Saved Successfully";

                DialogResult dr = MessageBox.Show("Saved Successfully", "Confirmation", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox1, -20);
            if (persons.Any(p => p.EmployeeID == textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "This employee ID already exist");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox2, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox2, -20);
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Please Enter First Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox3, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox3, -20);
            if (string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Please Enter Last Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");
            }

        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox4, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox4, -20);
            
            
            if (string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Please Enter Phone Number");
            }
            else if (!textBox4.Text.All(char.IsDigit) || textBox4.Text.Length < 11)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Enter a valid phone number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");
            }
        }

        private void textBox6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox6, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox6, -20);
            if (string.IsNullOrEmpty(textBox6.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Please Enter Salary");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox6, "");
            }
        }

        private void textBox5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox5, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox5, -20);
            if (string.IsNullOrEmpty(textBox5.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Please Enter Designation");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox5, "");
            }
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            var record = passBook.LoadRecords<EmployeeModel>("Emp_Personal_Info");
            persons = record;
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox1, -20);
            if (persons.Any(p => p.EmployeeID == textBox1.Text.Trim()))
            {  
                errorProvider1.SetError(textBox1, "This employee ID already exist");
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void emailTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(emailTextBox, "Enter an email address");
            }else if(!emailTextBox.Text.Contains("@") || !emailTextBox.Text.Contains("."))
            {
                e.Cancel = true;
                errorProvider1.SetError(emailTextBox, "Please enter a valid email address");
            }else if(persons.Any(p => p.EmailAddress == emailTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(emailTextBox, "An account with this email address is already exists");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(emailTextBox, "");
            }
        }
    }
}
