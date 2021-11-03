using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class CustomerInformationPage : Form
    {
        public CustomerInformationPage(string cusName, string phoneNum)
        {
            InitializeComponent();
            ValuePicker(cusName, phoneNum);
            
        }

        private void ValuePicker(string cusName, string phoneNum)
        {
            textBox1.Text = cusName; //First Name
            textBox4.Text = "Hossain"; //Last Name
            textBox2.Text = "Altaf Hossain"; //Fathers Name
            textBox3.Text = "Nehar Sultana"; //Mothers Name
            textBox6.Text = "Bangladeshi"; //Nationality
            textBox7.Text = "600 520 7532"; //NID or Passport Number
            textBox13.Text = "NA"; //Driving License Number

            //Present Address
            textBox22.Text = "Street"; //Street
            textBox30.Text = "Dhaka"; //State
            textBox29.Text = "1211"; //PostCode
            textBox28.Text = "Dhaka"; //City
            comboBox5.Text = "Bangladesh"; //Country

            //Permanent Address
            textBox34.Text = "Street"; //Street
            textBox31.Text = "Dhaka"; //State
            textBox32.Text = "1211"; //PostCode
            textBox33.Text = "Dhaka"; //City
            comboBox6.Text = "Bangladesh"; //Country

            textBox10.Text = phoneNum; //Mobile Number

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CustomerInformationPage_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
