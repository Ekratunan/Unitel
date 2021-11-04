using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class TicketGen : Form
    {
        public TicketGen()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private bool MobileValidator()
        {
            bool isValid = true;

            if(textBox1.Text.Trim() == "")
            {
                label3.Text = "Please enter a mobile number";
            }
            else
            {
                string mobileNumber = textBox1.Text;
                int convNumber = Convert.ToInt32(mobileNumber);
                if (convNumber > 01000000000)
                {
                    isValid = false;
                }
                else
                {
                    label3.Text = "Enter a valid Mobile Number";
                }

            }

            return isValid;
        }

        private void TokenGenerator(string service)
        {
            DatabaseFile database = new DatabaseFile("Tokens");
            DatabaseFile personInfo = new DatabaseFile("Customer");

            bool recordNotFound = true;

            var record = personInfo.LoadRecords<PersonModel>("Personal_Info");

            foreach(var rec in record)
            {
                if(rec.PhoneNumber == textBox1.Text)
                {
                    database.InsertRecord("ActiveCounter", new TokenModel {
                        MobileNumber = textBox1.Text,
                        TypeOfService = service,
                        Customer = new PersonModel
                        {
                            FirstName = rec.FirstName,
                            LastName = rec.LastName,
                            Nationality = rec.Nationality,
                            NID_Number = rec.NID_Number,
                            PresentAddress = new AddressModel
                            {
                                Street = rec.PresentAddress.Street,
                                State = rec.PresentAddress.State,
                                PostCode = rec.PresentAddress.PostCode,
                                City = rec.PresentAddress.City,
                                Country = rec.PresentAddress.Country
                            }
                        }
                    });

                    recordNotFound = false;
                }
                
            }

            if (recordNotFound)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "User does not exist";
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button3.Text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button4.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button6.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button5.Text);
            }
        }
    }
}
