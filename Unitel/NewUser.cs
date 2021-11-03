using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidField())
            {
                label3.Text = "Successfully Saved!";
            }
        }

        private bool ValidField()
        {
            bool noBlank = true;
            if(textBox19.Text.Trim() == "")
            {
                label3.Text = "Enter First Name";
                noBlank = false;
            }
            else if (textBox18.Text.Trim() == "")
            {
                label3.Text = "Enter Last Name";
                noBlank = false;
            } else if (textBox15.Text.Trim() == "")
            {
                label3.Text = "Enter Valid Nationality";
                noBlank = false;
            }
            else if (textBox17.Text.Trim() == "")
            {
                label3.Text = "Enter Father's Name";
                noBlank = false;
            }
            else if (dateTimePicker2.Text.Trim() == "")
            {
                label3.Text = "Enter Birth date";
                noBlank = false;
            }
            else if (textBox14.Text.Trim() == "")
            {
                label3.Text = "Enter NID/Passport Number";
                noBlank = false;
            }
            else if (textBox37.Text.Trim() == "")
            {
                label3.Text = "Invalid Permanent Address";
                noBlank = false;
            }
            else if (textBox20.Text.Trim() == "")
            {
                label3.Text = "Invalid Permanent Address";
                noBlank = false;
            }
            else if (textBox35.Text.Trim() == "")
            {
                label3.Text = "Invalid Permanent Address";
                noBlank = false;
            }
            else if (textBox36.Text.Trim() == "")
            {
                label3.Text = "Invalid Permanent Address";
                noBlank = false;
            }
            else if (comboBox7.Text.Trim() == "")
            {
                label3.Text = "Invalid Permanent Address";
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
