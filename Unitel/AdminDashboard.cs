using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            label66.Text = "";
            label67.Text = "";
            
        }

        private void balance_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee();

            newEmployee.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label67.Text = "";
            string empID = textBox1.Text.Trim();
            if(empID != "")
            {   
                EmployeeInfoRead(empID);
            } else
            {
                label66.Text = "Please enter a valid Employee ID.";
            }
        }

        private void EmployeeInfoRead(string empID)
        {
            DatabaseFile databaseFile = new DatabaseFile("Employee");
            var record = databaseFile.LoadRecords<PersonModel>("Emp_Personal_Info");

            bool validEmp = false;


            foreach (var rec in record)
            {
                if (rec.EmployeeID == empID)
                {
                    textBox2.Text = rec.FirstName;
                    textBox3.Text = rec.LastName;
                    textBox4.Text = rec.FathersName;
                    textBox5.Text = rec.MothersName;
                    textBox7.Text = rec.NID_Number;

                    textBox8.Text = rec.EmployeeID;
                    textBox11.Text = rec.Designation;
                    textBox12.Text = rec.Salary;

                    label66.Text = "";
                    panel13.Hide();
                    validEmp = true;
                    break;
                }
            }

            if (!validEmp)
            {
                label66.Text = "Employee not found";
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(textBox24.Text.Trim() != "")
            {
                panel14.Hide();
                panel15.Hide();
                panel16.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DatabaseFile database = new DatabaseFile("Employee");
            var record = database.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", textBox8.Text);
            record.FirstName = textBox2.Text;
            record.LastName = textBox3.Text;
            record.FathersName = textBox4.Text;
            record.MothersName = textBox5.Text;
            record.Nationality = textBox6.Text;
            record.NID_Number = textBox7.Text;
            record.Designation = textBox11.Text;
            record.Salary = textBox12.Text;
            record.PresentAddress = new AddressModel
            {
                Street = textBox22.Text,
                State = textBox30.Text,
                City = textBox28.Text,
                PostCode = textBox29.Text,
                Country = comboBox5.Text
            };
            record.PermanentAddress = new AddressModel
            {
                Street = textBox34.Text,
                State = textBox31.Text,
                City = textBox33.Text,
                PostCode = textBox32.Text,
                Country = comboBox6.Text
            };

            database.UpsertRecord("Emp_Personal_Info", record.ID, record);
            label67.Text = "Saved Successfully!";
        }
    }
}
