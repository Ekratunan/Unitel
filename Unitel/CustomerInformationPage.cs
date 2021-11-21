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
        public CustomerInformationPage(string phoneNum)
        {
            InitializeComponent();
            ValuePicker(phoneNum);
            button4.Hide();
            
        }

        private void ValuePicker(string phoneNum)
        {
           if(phoneNum == "")
            {

            }
            else
            {
                DatabaseFile databaseFile = new DatabaseFile("Customer");
                var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", phoneNum);

                textBox1.Text = record.FirstName; //First Name
                textBox4.Text = record.LastName; //Last Name
                textBox2.Text = record.FathersName; //Fathers Name
                textBox3.Text = record.MothersName; //Mothers Name
                textBox6.Text = record.Nationality; //Nationality
                textBox7.Text = record.NID_Number; //NID or Passport Number
                textBox13.Text = record.DrivingLicenseNum; //Driving License Number

                //Present Address
                textBox22.Text = record.PresentAddress.Street; //Street
                textBox30.Text = record.PresentAddress.State; //State
                textBox29.Text = record.PresentAddress.PostCode; //PostCode
                textBox28.Text = record.PresentAddress.City; //City
                comboBox5.Text = record.PresentAddress.Country; //Country

                //Permanent Address
                textBox34.Text = record.PermanentAddress.Street; //Street
                textBox31.Text = record.PermanentAddress.State; //State
                textBox32.Text = record.PermanentAddress.PostCode; //PostCode
                textBox33.Text = record.PermanentAddress.City; //City
                comboBox6.Text = record.PermanentAddress.Country; //Country

                textBox10.Text = record.PhoneNumber; //Mobile Number
            }
            
            
           

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CustomerInformationPage_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if(button1.Text == "Edit")
            {
                button4.Show();
            } else if(button1.Text == "Save")
            {
                DatabaseFile databaseFile = new DatabaseFile("Customer");
                var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "PhoneNumber", textBox10.Text);

                record.FirstName = textBox1.Text;
                record.LastName = textBox4.Text;
                record.FathersName = textBox2.Text;
                record.MothersName = textBox3.Text;
                record.Nationality = textBox6.Text;
                record.NID_Number = textBox7.Text;
                record.DrivingLicenseNum = textBox13.Text;
                record.PresentAddress = new AddressModel
                {
                    Street = textBox22.Text,
                    State = textBox30.Text,
                    PostCode = textBox29.Text,
                    City = textBox28.Text,
                    Country = comboBox5.Text               
                };
                record.PermanentAddress = new AddressModel
                {
                    Street = textBox34.Text,
                    State = textBox31.Text,
                    PostCode = textBox32.Text,
                    City = textBox33.Text,
                    Country = comboBox6.Text
                };

                databaseFile.UpsertRecord("Personal_Info", record.ID, record);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
