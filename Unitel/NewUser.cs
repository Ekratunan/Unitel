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

            GenerateMobileNumber();
            
        }

        private void GenerateMobileNumber()
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");

            var record = databaseFile.LoadRecords<PersonModel>("Personal_Info");
            int count = record.Count, max = 1;
            long sampleNumber;
            long iniNumber = 0;


            if (count == 0)
            {
                label2.Text = "01200000000";
            }
            else
            {
                foreach (var rec in record)
                {
                    string sampleText = rec.MobileNumber;
                    sampleNumber = StriToInt(sampleText);
                    if (120000000 < sampleNumber && max == count)
                    {
                        iniNumber = sampleNumber + 1;
                        label2.Text = $"{"0" + iniNumber}";
                    }
                    else
                    {
                        max++;
                    }

                }
            }
        }

        private long StriToInt(string sample)
        {
            int result = 0;
            try
            {
                result = Int32.Parse(sample);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{sample}'");
            }

            return result;
        }

        private void CreateAUser()
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");


            databaseFile.InsertRecord("Personal_Info", new PersonModel {
                MobileNumber = label2.Text.Trim(),

                PhoneNumber = textBox1.Text.Trim(),
                FirstName = textBox19.Text.Trim(),
                LastName = textBox18.Text.Trim(),
                Nationality = textBox15.Text.Trim(),
                FathersName = textBox17.Text.Trim(),
                MothersName = textBox16.Text.Trim(),
                NID_Number = textBox14.Text.Trim(),
                Gender = comboBox2.Text.Trim(),
                DrivingLicenseNum = textBox13.Text.Trim(),
                MaritalStatus = comboBox1.Text.Trim(),
                PresentAddress = new AddressModel
                {
                    Street = textBox41.Text.Trim(),
                    State = textBox38.Text.Trim(),
                    PostCode = textBox39.Text.Trim(),
                    City = textBox40.Text.Trim(),
                    Country = comboBox8.Text.Trim()
                },

                PermanentAddress = new AddressModel
                {
                    Street = textBox37.Text.Trim(),
                    State = textBox20.Text.Trim(),
                    PostCode = textBox35.Text.Trim(),
                    City = textBox36.Text.Trim(),
                    Country = comboBox7.Text.Trim()
                }
            });

            databaseFile.InsertRecord("SIM_Info", new SIM_Model
            {
                MobileNumber = label2.Text.Trim(),
                PackageType = comboBox4.Text.Trim(),
                NetworkVersion = comboBox3.Text.Trim(),
                UserLevel = "Regular",
                SIM_Version = "N/A",
                DateOfIssue = "Date will be added",
                SerialNumber = "N/A",
                Device_IMEI = "No Device Detected",
                Device_Model = "No Device Found",
                simPackage = new SIM_Pack
                {
                    Balance = "0.00",
                    balanceValidity = "N/A",
                    DataPack = "0 MB",
                    dataValidity = "N/A",
                    SMS_Pack = "0 SMS",
                    smsValidity = "N/A",
                    Talk_Time = "0 Minutes",
                    talkTimeValidity = "N/A"
                }
            }) ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidField())
            {
                CreateAUser();
                label3.Text = "Successfully Saved!";
                

                this.Close();
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
            }else if(comboBox2.Text.Trim() == "")
            {
                label3.Text = "Select a gender";
                noBlank = false;
            }else if(comboBox3.Text.Trim() == "")
            {
                label3.Text = "Select Network Version";
                noBlank = false;
            }
            else if (comboBox4.Text.Trim() == "")
            {
                label3.Text = "Select Package Type";
                noBlank = false;
            }

            return noBlank;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
