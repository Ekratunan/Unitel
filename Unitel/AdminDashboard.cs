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
            string empID = textBox1.Text.Trim();
            if(empID != "")
            {   
                EmployeeInfoRead(empID);
                panel13.Hide();
            }
        }

        private void EmployeeInfoRead(string empID)
        {
            DatabaseFile databaseFile = new DatabaseFile("Employee");
            var record = databaseFile.LoadRecords<EmployeeModel>("Emp_Personal_Info");

            

            foreach(var rec in record)
            {
                if(rec.EmployeeID == empID)
                {
                    textBox2.Text = rec.FirstName;
                    textBox3.Text = rec.LastName;
                    textBox4.Text = rec.FathersName;
                    textBox5.Text = rec.MothersName;
                    textBox7.Text = rec.NID_Number;

                    textBox8.Text = rec.EmployeeID;
                    textBox11.Text = rec.Designation;
                    textBox12.Text = rec.Salary;

                    break;
                }
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
    }
}
