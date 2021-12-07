using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Unitel
{
    public partial class PasswordResetPage : Form
    {
        DatabaseFile readEmployee = new DatabaseFile("Employee");
        List<EmployeeModel> employees;
        EmployeeModel existingUser;
        private string sampleTaken;

        public PasswordResetPage()
        {
            InitializeComponent();
            var rec = readEmployee.LoadRecords<EmployeeModel>("Emp_Personal_Info");
            employees = rec;
        }

        private void EmailSender(string recipient, string otp)
        {
            string hostEmail = "unitelnetworksup@gmail.com";

            try
            {
                var smtpCLient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(hostEmail, "unitel@5000"),
                    EnableSsl = true,

                };

                smtpCLient.Send(hostEmail, recipient, "Password Reset for Unitel Account", $"Your OTP for password reset is {otp}. Please enter this OTP to verify your identity");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to send OTP. Try Again)", "Error", MessageBoxButtons.OK);
                sendButton.Enabled = true;
                sendButton.Text = "Send OTP";
            }
            
        }

        private bool VerificationTask(string employeeID)
        {
            if (employees.Any(p => p.EmployeeID == employeeID))
            {
                existingUser = employees.Find(p => p.EmployeeID == employeeID);
                return true;
            }
            else
            {
                return false;
            }
        }

        private string OTPGenerator()
        {
            Random random = new Random();
            string sample = random.Next(3551, 9999).ToString();
            sampleTaken = sample;
            return sample;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (VerificationTask(textBox1.Text.Trim()))
            {
                sendButton.Text = "Sending...";
                sendButton.Enabled = false;
                EmailSender(existingUser.EmailAddress, OTPGenerator());
                
                otpPanel.Visible = true;
                otpPanel.BringToFront();
                this.ActiveControl = textBox2;
                this.AcceptButton = otpVerifierButton;
            }
            else
            {
                MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK);
            }
        }

        private void otpVerifierButton_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Trim() == sampleTaken)
            {
                var rec = readEmployee.LoadRecordbyIdentity<SecurityModel>("Emp_Account", "EmployeeID", existingUser.EmployeeID);
                rec.Password = null;
                readEmployee.UpsertRecord("Emp_Account", rec.ID, rec);

                DialogResult dr = MessageBox.Show("Password Reset Succesfully", "All Done!", MessageBoxButtons.OK);
                if(dr == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("OTP Does not match", "Error", MessageBoxButtons.OK);
                textBox2.Clear();
            }
        }
    }
}
