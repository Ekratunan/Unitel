using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class NewEmployee : Form
    {
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
            DatabaseFile databaseFile = new DatabaseFile("Employee");


            
            if (ValidField())
            {
                string employeeId = textBox1.Text.Trim();
                string firstName = textBox2.Text.Trim();
                string lastName = textBox3.Text.Trim();
                string phoneNumber = textBox4.Text.Trim();
                string designation = textBox5.Text.Trim();
                string salary = textBox6.Text.Trim();

                

                databaseFile.InsertRecord("Emp_Personal_Info", new EmployeeModel { 
                    EmployeeID = employeeId,
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
                        Country = "",

                    },
                    PermanentAddress = new AddressModel
                    {
                        Street = "",
                        State = "",
                        City = "",
                        PostCode = "",
                        Country = "",
                    }
                });

                databaseFile.InsertRecord("Emp_Account", new PassBook {
                EmployeeID = employeeId});;

                label8.Text = "Saved Successfully";
                this.Close();
            }
            
        }

        private bool ValidField()
        {
            bool noBlank = true;

            if(textBox1.Text.Trim() == "")
            {
                label8.Text = "Enter a valid Employee ID";
                noBlank = false;
            } else if (textBox2.Text.Trim() == "")
            {
                label8.Text = "Enter First Name";
                noBlank = false;
            }
            else if (textBox3.Text.Trim() == "")
            {
                label8.Text = "Enter Last Name";
                noBlank = false;
            }
            else if (textBox4.Text.Trim() == "")
            {
                label8.Text = "Enter Phone Number";
                noBlank = false;
            }
            else if (textBox5.Text.Trim() == "")
            {
                label8.Text = "Enter Designation";
                noBlank = false;
            }
            else if (textBox6.Text.Trim() == "")
            {
                label8.Text = "Enter Salary";
                noBlank = false;
            }

            return noBlank;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
