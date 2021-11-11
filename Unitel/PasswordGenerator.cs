using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Unitel
{
    public partial class PasswordGenerator : Form
    {
        private readonly string empId;

        public PasswordGenerator(string empId)
        {
            InitializeComponent();
            this.empId = empId;
            label4.Text = "";

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool isBlank = textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "";
            bool firstBlank = textBox1.Text.Trim() == "";
            bool notComfirm = textBox2.Text.Trim() == "" && textBox1.Text.Trim() != "";
            bool passMatch = textBox1.Text == textBox2.Text;

            if(!isBlank && passMatch)
            {
                DatabaseFile databaseFile = new DatabaseFile("Employee");

                if (PasswordValidator())
                {
                    var record = databaseFile.LoadRecordbyIdentity<PassBook>("Emp_Account", "EmployeeID", empId);
                    record.Password = textBox1.Text;
                    databaseFile.UpsertRecord("Emp_Account", record.ID, record);

                    this.Close();
                }
            }else if (isBlank || firstBlank)
            {
                label4.Text = "Please enter a password!";

            } else if (notComfirm)
            {
                label4.Text = "Please confirm your password!";
            }
            else if (!passMatch)

            {
                label4.Text = "Password does not matched";
            }

            
        }

        private bool PasswordValidator()
        {
            bool valid = false;
            string sample = textBox1.Text;
            
            Regex rgx = new Regex("[^A-Za-z0-9]+$");
            bool hasSpeChar = rgx.IsMatch(sample);
            bool passMatch = textBox1.Text == textBox2.Text;

   
            if (hasSpeChar && passMatch)
            {
                valid = true;

            }
            else if (!hasSpeChar)
            {
                label4.Text = "Must contains special characters and numbers";
            }
            


            return valid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
