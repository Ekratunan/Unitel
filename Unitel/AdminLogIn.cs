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
        public AdminLogIn()
        {
            InitializeComponent();
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

            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Invalid Admin ID or Password";
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
            bool initialVerify = false;
            
            if(adminID == "Ekra" && password == "1234")
            {
                initialVerify = true;
            }
            return initialVerify;
        }
    }
}
