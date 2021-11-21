using System;
using System.Linq;
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
            bool passMatch = PasswordValidator();

            if(!isBlank && passMatch)
            {
                DatabaseFile databaseFile = new DatabaseFile("Employee");

                if (passMatch)
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
            

            
        }

        private bool PasswordValidator()
        {
            bool valid = false;
            string sample = textBox1.Text;
            
            bool hasSpeChar = sample.Any(p => !char.IsLetterOrDigit(p));
            bool passMatch = textBox1.Text == textBox2.Text;
            bool containNumber = sample.Any(char.IsDigit);

   
            if (containNumber && hasSpeChar && passMatch)
            {
                valid = true;

            }
            else if (!hasSpeChar)
            {
                label4.Text = "Must contains atleast one special characters";
            }else if (!containNumber)
            {
                label4.Text = "Must contains atleast one number";
            }
            else if (!passMatch)

            {
                label4.Text = "Password does not matched";
            }



            return valid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
