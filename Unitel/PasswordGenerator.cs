using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Unitel
{
    public partial class PasswordGenerator : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);

        private readonly string empId;

        DatabaseFile databaseFile = new DatabaseFile("Employee");
        public PasswordGenerator(string empId)
        {
            InitializeComponent();
            this.empId = empId;
            label4.Text = "";
        }

        public PasswordGenerator()
        {
            InitializeComponent();
        }

        private byte[] encodePassword(string sample)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(sample);
            var ms = new MemoryStream(byteArray);
            var bytes = ms.ToArray();
            return bytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(InternetGetConnectedState(out _, 0))
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    label4.Text = "Updating Password...";
                    var record = databaseFile.LoadRecordbyIdentity<SecurityModel>("Emp_Account", "EmployeeID", empId);
                    record.Password = encodePassword(textBox1.Text);
                    databaseFile.UpsertRecord("Emp_Account", record.ID, record);
                    this.Close();
                }
            }
            else
            {
                label4.Text = "No internet!";
            }
            
        }



        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasLetter = textBox1.Text.Any(char.IsLetter);
            bool hasNumber = textBox1.Text.Any(char.IsDigit);
            bool hasSpeChar = textBox1.Text.Any(p => !char.IsLetterOrDigit(p));

            if (textBox1.Text.Trim() == "" || string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Please enter a password");
            }
            else if (!hasLetter)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Must contain a letter");
            }else if (!hasNumber)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Must contain at laest one number");
            }else if (!hasSpeChar)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Must contain a special character");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Please confirm your password");
            }
            else if(textBox1.Text != textBox2.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Password does not match");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, null);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text.Trim()) && !string.IsNullOrEmpty(textBox2.Text.Trim())){
                if(textBox1.Text == textBox2.Text)
                {
                    this.AcceptButton = button1;
                    button1.Enabled = true;
                    errorProvider1.SetError(textBox2, "");
                    label4.Text = "";
                }
                else if(textBox2.Text.Length < 4 || textBox1.Text != textBox2.Text)
                { 
                    label4.Text = "Password does not match!";
                    button1.Enabled = false;
                }
            }
        }

        Control ctr1;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if (ctr1 is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.ActiveControl = textBox2;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if (ctr1 is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(textBox1.Text != textBox2.Text)
                    {
                        errorProvider1.SetIconAlignment(textBox2, ErrorIconAlignment.MiddleRight);
                        errorProvider1.SetIconPadding(this.textBox2, -20);
                        errorProvider1.SetError(textBox2, "Password does not match!");
                    }
                }
            }
        }
    }
}
