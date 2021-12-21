using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class PassConfirmation : Form
    {
        protected string password;
        public PassConfirmation()
        {
            InitializeComponent();
            label1.Text = Properties.Settings.Default.AdminUserId;
            password = Properties.Settings.Default.AdminPassword;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (password == textBox1.Text.Trim())
                {
                    AdminDashboard ad = new AdminDashboard();
                    ad.Show();
                    this.Close();
                }
            }
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Enter Your Password");
            }
            else if(textBox1.Text != password)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Incorrect Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Home().Show();
            Properties.Settings.Default.AdminLoggedIn = false;
            Properties.Settings.Default.AdminUserId = null;
            Properties.Settings.Default.AdminPassword = null;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
