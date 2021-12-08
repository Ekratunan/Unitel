using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class NewUser : Form
    {
        public string numberPass { get; set; }
        public NewUser()
        {
            InitializeComponent();
            label3.Text = "";

            
            GenerateMobileNumber();
            numberPass = label2.Text;
        }

        private void GenerateMobileNumber()
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");
            var record = databaseFile.LoadRecords<SIM_Model>("SIM_Info");
            long sample = 1274351444;
            int numOfRec = record.Count;

            string uniqueNum = "N/A";

            for (int i = 0; i <= numOfRec; i++)
            {
                var smt = $"0{sample}";
                bool existance = record.Any(p => p.MobileNumber == smt);

                if (existance)
                {
                    sample++;
                }
                else
                {
                    uniqueNum = $"0{sample}";
                    break;
                }
            }

            label2.Text = uniqueNum;
        }

        public string number;
        private void CreateAUser()
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");
            number = label2.Text.Trim();
            byte[] img;

            if (pictureBox2.Image != null)
            {
                img = pictureCovert(pictureBox2.Image);
            }
            else
            {
                img = null;
            }

            databaseFile.InsertRecord("Personal_Info", new PersonModel {
                MobileNumber = label2.Text.Trim(),


                UserImage = img,
                PhoneNumber = textBox1.Text.Trim(),
                FirstName = textBox19.Text.Trim(),
                LastName = textBox18.Text.Trim(),
                Nationality = textBox15.Text.Trim(),
                FathersName = textBox17.Text.Trim(),
                MothersName = textBox16.Text.Trim(),
                DateOfBirth = dateTimePicker2.Text.Trim(),
                NID_Number = textBox14.Text.Trim(),
                Gender = comboBox2.Text.Trim(),
                DrivingLicenseNum = textBox13.Text.Trim(),
                MaritalStatus = comboBox1.Text.Trim(),
                PresentAddress = new AddressModel
                {
                    Street = preStreet.Text.Trim(),
                    State = preDivision.Text.Trim(),
                    PostCode = prePostcode.Text.Trim(),
                    City = preCity.Text.Trim(),
                    Country = preCountry.Text.Trim()
                },

                PermanentAddress = new AddressModel
                {
                    Street = permStreet.Text.Trim(),
                    State = permDivision.Text.Trim(),
                    PostCode = permPostcode.Text.Trim(),
                    City = permCity.Text.Trim(),
                    Country = permCountry.Text.Trim()
                }
            });

            databaseFile.InsertRecord("SIM_Info", new SIM_Model
            {
                MobileNumber = label2.Text.Trim(),
                PackageType = comboBox4.Text.Trim(),
                NetworkVersion = comboBox3.Text.Trim(),
                UserLevel = "Regular",
                SIM_Version = "N/A",
                DateOfIssue = DateTime.Today.ToString(),
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
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                CreateAUser();
                DialogResult dr = MessageBox.Show("Saved Successfully", "Confirmation", MessageBoxButtons.OK);

                label3.Text = "Successfully Saved!";

                if (dr == DialogResult.OK)
                {
                    this.Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        Image image;


        private byte[] pictureCovert(Image i)
        {
            var ms = new MemoryStream();

            i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var bytes = ms.ToArray();

            return bytes;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG)|*.BMP; *.JPG; *.PNG";

            DialogResult dr = openFileDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox2.Image = image;

            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox19_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox19, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox19, -20);

            if (string.IsNullOrEmpty(textBox19.Text.Trim()))
            {

                e.Cancel = true;
                errorProvider1.SetError(textBox19, "Please enter customer's first name");
            }
            else if (!textBox19.Text.All(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox19, "Must contain all characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox19, "");
            }
        }

        private void textBox18_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox18, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox18, -20);

            if (string.IsNullOrEmpty(textBox18.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox18, "Please enter customer's last name");
            }
            else if (!textBox18.Text.All(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox18, "Must contain all characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox18, "");
            }
        }

        private void textBox17_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox17, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox17, -20);
            if (string.IsNullOrEmpty(textBox17.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox17, "Please enter Father's name");
            }
            else if (textBox17.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox17, "Must contain all characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox17, "");
            }
        }

        private void textBox16_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox16, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox16, -20);
            if (string.IsNullOrEmpty(textBox16.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox16, "Please enter Mother's name");
            }
            else if (textBox16.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox16, "Must contain all characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox16, "");
            }
        }

        private void textBox15_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox15, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox15, -20);
            if (string.IsNullOrEmpty(textBox15.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox15, "Please enter Nationality");
            }
            else if (!textBox15.Text.All(char.IsLetter))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox15, "Must contain all characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox15, "");
            }
        }

        private void textBox14_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox14, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox14, -20);
            if (string.IsNullOrEmpty(textBox14.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox14, "Enter NID or Passport Number");
            }else if(textBox14.Text.Length < 10 || !textBox14.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox14, "Enter a valid NID or Passport Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox14, "");
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(comboBox2, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.comboBox2, -50);
            if (string.IsNullOrEmpty(comboBox2.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox2, "Select Gender");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(comboBox2, "");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(textBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.textBox1, -20);
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                if(textBox1.Text.Length < 11)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox1, "Phone Number must be contain 11 digits");
                }else if (!textBox1.Text.All(char.IsDigit))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(textBox1, "Phone Number must contain all numbers");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(textBox1, "");
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(dateTimePicker2, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.dateTimePicker2, -50);
            if (dateTimePicker2.Text.Trim() == "01/01/1920")
            {
                e.Cancel = true;
                errorProvider1.SetError(dateTimePicker2, "Enter Birth Date");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dateTimePicker2, "");
            }
        }

        private void textBox37_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(permStreet, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.permStreet, -20);
            if (string.IsNullOrEmpty(permStreet.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(permStreet, "Enter Street Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(permStreet, "");
            }
        }

        private void textBox20_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(permDivision, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.permDivision, -20);
            if (string.IsNullOrEmpty(permDivision.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(permDivision, "Enter State");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(permDivision, "");
            }
        }

        private void textBox36_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(permCity, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.permCity, -20);
            if (string.IsNullOrEmpty(permCity.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(permCity, "Enter City");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(permCity, "");
            }
        }

        private void comboBox7_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(permCountry, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.permCountry, -20);
            if (string.IsNullOrEmpty(permCountry.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(permCountry, "Enter Country");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(permCountry, "");
            }
        }

        private void textBox35_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(permPostcode, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.permPostcode, -20);
            if (string.IsNullOrEmpty(permPostcode.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(permPostcode, "Enter Postcode");
            }else if (!permPostcode.Text.Any(char.IsDigit))
            {
                e.Cancel = true;
                errorProvider1.SetError(permPostcode, "Enter Valid Postcode");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(permPostcode, "");
            }
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(comboBox3, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.comboBox3, -50);
            if (string.IsNullOrEmpty(comboBox3.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox3, "Select a network version");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(comboBox3, "");
            }
        }

        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(comboBox4, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.comboBox4, -50);
            if (string.IsNullOrEmpty(comboBox4.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox4, "Select a package");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(comboBox4, "");
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
           // textBox19.Select();
            this.ActiveControl = textBox19;
            textBox19.Focus();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.SetIconAlignment(comboBox1, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(this.comboBox1, -50);
            if (string.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox1, "Select a marital status");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(comboBox1, "");
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox7.Hide();
                preStreet.Text = permStreet.Text;
                preDivision.Text = permDivision.Text;
                preCity.Text = permCity.Text;
                preCountry.Text = permCountry.Text;
                prePostcode.Text = permPostcode.Text;
            }else if (!checkBox1.Checked)
            {
                groupBox7.Show();
                preStreet.Text = "";
                preDivision.Text = "";
                preCity.Text = "";
                preCountry.Text = "";
                prePostcode.Text = "";
            }
        }

        private void copyNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
