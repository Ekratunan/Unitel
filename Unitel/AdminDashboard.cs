using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Unitel
{
    public partial class AdminDashboard : Form
    {
        int numOfRec = 0;
        DatabaseFile tokenSync = new DatabaseFile("Tokens");
        Control ctr1;

        public AdminDashboard()
        {
            InitializeComponent();
            DataFetch();

        }

        private void CustomerWriteAccess(bool result)
        {
            if (result)
            {
                linkLabel2.Show();

                textBox19.ReadOnly = false;
                textBox18.ReadOnly = false;
                textBox17.ReadOnly = false;
                textBox16.ReadOnly = false;
                textBox15.ReadOnly = false;
                textBox13.ReadOnly = false;
                textBox48.ReadOnly = false;
                textBox48.Hide();

                textBox14.ReadOnly = false;
                textBox43.ReadOnly = false;
                textBox49.ReadOnly = false;
                textBox49.Hide();

                textBox56.Hide();

                //Present Address
                textBox41.ReadOnly = false;
                textBox38.ReadOnly = false;
                textBox40.ReadOnly = false;
                textBox50.ReadOnly = false;
                textBox50.Hide();
                textBox39.ReadOnly = false;
                textBox52.Hide();
                textBox53.Hide();
                textBox54.Hide();

                textBox25.ReadOnly = false;
                textBox21.ReadOnly = false;
                textBox26.ReadOnly = false;
                textBox27.ReadOnly = false;
                textBox9.ReadOnly = false;


                //Permanent Address
                textBox37.ReadOnly = false;
                textBox20.ReadOnly = false;
                textBox36.ReadOnly = false;
                textBox51.ReadOnly = false;
                textBox51.Hide();
                textBox35.ReadOnly = false;
            }else if (!result)
            {
                linkLabel2.Hide();

                textBox19.ReadOnly = true;
                textBox18.ReadOnly = true;
                textBox17.ReadOnly = true;
                textBox16.ReadOnly = true;
                textBox15.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox48.ReadOnly = true;
                textBox48.Text = comboBox11.Text.Trim();
                textBox48.Show();

                textBox14.ReadOnly = true;
                textBox43.ReadOnly = true;
                textBox49.ReadOnly = true;
                textBox49.Text = comboBox10.Text.Trim();
                textBox49.Show();
                textBox56.Text = dateTimePicker2.Text;
                textBox56.Show();

                //Present Address
                textBox41.ReadOnly = true;
                textBox38.ReadOnly = true;
                textBox40.ReadOnly = true;
                textBox50.ReadOnly = true;
                textBox50.Text = comboBox8.Text.Trim();
                textBox50.Show();
                textBox39.ReadOnly = true;

                //Permanent Address
                textBox37.ReadOnly = true;
                textBox20.ReadOnly = true;
                textBox36.ReadOnly = true;
                textBox51.ReadOnly = true;
                textBox51.Text = comboBox7.Text.Trim();
                textBox51.Show();
                textBox35.ReadOnly = true;

                textBox52.Text = comboBox2.Text.Trim();
                textBox52.Show();
                textBox53.Text = comboBox3.Text.Trim();
                textBox53.Show();
                textBox54.Text = comboBox4.Text.Trim();
                textBox54.Show();


                textBox25.ReadOnly = true;
                textBox21.ReadOnly = true;
                textBox26.ReadOnly = true;
                textBox27.ReadOnly = true;
                textBox9.ReadOnly = true;

                button10.Hide();
                button9.Hide();
            }
        }

        private void CustomerInfoRead(string phone)
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");
            var record = databaseFile.LoadRecords<PersonModel>("Personal_Info");
            bool recordFound = false;


            foreach(var rec in record)
            {
                if (rec.MobileNumber == phone)
                {
                    var simRecord = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", rec.MobileNumber);

                    if(rec.UserImage != null)
                    {
                        pictureBox3.Image = binToImage(rec.UserImage);
                    }
                    else
                    {
                        pictureBox3.Image = Properties.Resources.img_avatar;
                    }
                    textBox19.Text = rec.FirstName;
                    textBox18.Text = rec.LastName;
                    textBox17.Text = rec.FathersName;
                    textBox16.Text = rec.MothersName;
                    textBox15.Text = rec.Nationality;
                    comboBox10.Text = rec.Gender;
                    textBox49.Text = rec.Gender;
                    textBox14.Text = rec.NID_Number;
                    textBox43.Text = rec.DrivingLicenseNum;
                    textBox13.Text = rec.PhoneNumber; //Initial
                    comboBox11.Text = rec.MaritalStatus;
                    textBox48.Text = rec.MaritalStatus;
                    textBox56.Text = rec.DateOfBirth;
                    dateTimePicker2.Value = DateTime.ParseExact(rec.DateOfBirth, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);


                    //Present Address
                    textBox41.Text = rec.PresentAddress.Street;
                    textBox38.Text = rec.PresentAddress.State;
                    textBox40.Text = rec.PresentAddress.City;
                    comboBox8.Text = rec.PresentAddress.Country;
                    textBox50.Text = rec.PresentAddress.Country;
                    textBox39.Text = rec.PresentAddress.PostCode;

                    //Permanent Address
                    textBox37.Text = rec.PermanentAddress.Street;
                    textBox20.Text = rec.PermanentAddress.State;
                    textBox36.Text = rec.PermanentAddress.City;
                    comboBox7.Text = rec.PermanentAddress.Country;
                    textBox51.Text = rec.PermanentAddress.Country;
                    textBox35.Text = rec.PermanentAddress.PostCode;

                    textBox23.Text = simRecord.MobileNumber;
                    comboBox2.Text = simRecord.PackageType;
                    textBox52.Text = simRecord.PackageType;
                    comboBox3.Text = simRecord.NetworkVersion;
                    textBox53.Text = simRecord.NetworkVersion;
                    comboBox4.Text = simRecord.UserLevel;
                    textBox54.Text = simRecord.UserLevel;

                    //SIM Information
                    textBox25.Text = simRecord.SIM_Version;
                    textBox21.Text = simRecord.DateOfIssue;
                    textBox26.Text = simRecord.SerialNumber;
                    textBox27.Text = simRecord.Device_IMEI;
                    textBox9.Text = simRecord.Device_Model;

                    //User Package
                    balance.Text = simRecord.simPackage.Balance;
                    balaVal.Text = simRecord.simPackage.balanceValidity;
                    dataPack.Text = simRecord.simPackage.DataPack;
                    dataVal.Text = simRecord.simPackage.dataValidity;
                    smsPack.Text = simRecord.simPackage.SMS_Pack;
                    smsVal.Text = simRecord.simPackage.smsValidity;
                    ttPack.Text = simRecord.simPackage.Talk_Time;
                    ttValidity.Text = simRecord.simPackage.talkTimeValidity;

                    panel14.Hide();
                    panel15.Hide();
                    panel16.Hide();

                    button4.Show();
                    label74.Text = "";
                    label75.Text = "";
                    button11.Enabled = true;
                    recordFound = true;
                    break;
                }
            }

            if (!recordFound)
            {
                label74.Text = "No user found";
                button11.Enabled = true;
            }
        }

        private void EmployeeInfoRead(string empID)
        {
            DatabaseFile databaseFile = new DatabaseFile("Employee");
            var record = databaseFile.LoadRecords<EmployeeModel>("Emp_Personal_Info");

            bool validEmp = false;


            foreach (var rec in record)
            {
                if (rec.EmployeeID == empID)
                {
                    if(rec.UserImage != null)
                    {
                        pictureBox2.Image = binToImage(rec.UserImage);
                    }
                    else
                    {
                        pictureBox2.Image = Properties.Resources.img_avatar;
                    }
                    
                    
                    textBox2.Text = rec.FirstName;
                    textBox3.Text = rec.LastName;
                    textBox4.Text = rec.FathersName;
                    textBox5.Text = rec.MothersName;
                    textBox7.Text = rec.NID_Number;
                    textBox6.Text = rec.Nationality;
                    comboBox9.Text = rec.Gender;
                    textBox45.Text = rec.Gender;
                    textBox42.Text = rec.DrivingLicenseNum;
                    comboBox12.Text = rec.MaritalStatus;
                    textBox44.Text = rec.MaritalStatus;
                    textBox10.Text = rec.PhoneNumber;
                    textBox55.Text = rec.DateOfBirth;
                    if(rec.DateOfBirth != null)
                    {
                        dateTimePicker1.Value = DateTime.ParseExact(rec.DateOfBirth, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
                    }
                    


                    textBox22.Text = rec.PresentAddress.Street;
                    textBox30.Text = rec.PresentAddress.State;
                    textBox28.Text = rec.PresentAddress.City;
                    comboBox5.Text = rec.PresentAddress.Country;
                    textBox46.Text = rec.PresentAddress.Country;
                    textBox29.Text = rec.PresentAddress.PostCode;

                    textBox34.Text = rec.PermanentAddress.Street;
                    textBox31.Text = rec.PermanentAddress.State;
                    textBox33.Text = rec.PermanentAddress.City;
                    comboBox6.Text = rec.PermanentAddress.Country;
                    textBox47.Text = rec.PermanentAddress.Country;
                    textBox32.Text = rec.PermanentAddress.PostCode;

                    textBox8.Text = rec.EmployeeID;
                    textBox11.Text = rec.Designation;
                    textBox12.Text = rec.Salary;


                    panel13.Hide();
                    button3.Show();
                    validEmp = true;
                    label66.Text = "";
                    label67.Text = "";

                    button6.Enabled = true;
                    break;

                }
            }

            if (!validEmp)
            {
                label66.Text = "Employee not found";
                button6.Enabled = true;
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NewEmployee newEmployee = new NewEmployee();
            newEmployee.Show();
        }

        Home home = new Home();

        private void Button5_Click(object sender, EventArgs e)
        {
            home.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private Image binToImage(byte[] b)
        {
            var img = new MemoryStream(b);
            Image imgFromStream = Image.FromStream(img);
            return imgFromStream;
        }


        private void Button6_Click(object sender, EventArgs e)
        {
            
            string empID = textBox1.Text.Trim();
            if(empID != "")
            {
                label66.Text = "Searching Employee...";
                button6.Enabled = false;
                EmployeeInfoRead(empID);

            } else
            {
                label66.Text = "Please enter a valid Employee ID.";
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        { 
            if (textBox24.Text.Trim() == "")
            {
                label74.Text = "Please enter a mobile number";
            }
            else
            {
                button11.Enabled = false;
                label74.Text = "Searching User...";
                CustomerInfoRead(textBox24.Text.Trim());
                
            }
            
            

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save Changes?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DatabaseFile database = new DatabaseFile("Employee");
                var record = database.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", textBox8.Text);
                record.UserImage = pictureCovert(pictureBox2.Image);
                record.FirstName = textBox2.Text.Trim();
                record.LastName = textBox3.Text.Trim();
                record.FathersName = textBox4.Text.Trim();
                record.MothersName = textBox5.Text.Trim();
                record.Nationality = textBox6.Text.Trim();
                record.NID_Number = textBox7.Text.Trim();
                record.MaritalStatus = comboBox12.Text.Trim();
                record.Gender = comboBox9.Text.Trim();
                record.PhoneNumber = textBox10.Text.Trim();
                record.DrivingLicenseNum = textBox42.Text.Trim();
                record.DateOfBirth = dateTimePicker1.Text;
                record.Designation = textBox11.Text.Trim();
                record.Salary = textBox12.Text.Trim();
                record.EmployeeID = textBox8.Text.Trim();
                record.PresentAddress = new AddressModel
                {
                    Street = textBox22.Text.Trim(),
                    State = textBox30.Text.Trim(),
                    City = textBox28.Text.Trim(),
                    PostCode = textBox29.Text.Trim(),
                    Country = comboBox5.Text.Trim()
                };
                record.PermanentAddress = new AddressModel
                {
                    Street = textBox34.Text.Trim(),
                    State = textBox31.Text.Trim(),
                    City = textBox33.Text.Trim(),
                    PostCode = textBox32.Text.Trim(),
                    Country = comboBox6.Text.Trim()
                };

                database.UpsertRecord("Emp_Personal_Info", record.ID, record);
                label67.Text = "Saved Successfully!";

                EmpTabWriteAccess(false);

                button7.Hide();
                button8.Hide();

                button3.Text = "Edit";
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }

            
        }

        private void EmpTabWriteAccess(bool signal)
        {
            if (signal)
            {
                linkLabel1.Show();

                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox10.ReadOnly = false;
                textBox42.ReadOnly = false;
                textBox44.ReadOnly = false;
                textBox44.Hide();
                textBox55.Hide();
                textBox7.ReadOnly = false;
                textBox45.ReadOnly = false;
                textBox45.Hide();

                textBox11.ReadOnly = false;
                textBox12.ReadOnly = false;

                //Present Address
                textBox22.ReadOnly = false;
                textBox30.ReadOnly = false;
                textBox28.ReadOnly = false;
                textBox29.ReadOnly = false;
                textBox46.ReadOnly = false;
                textBox46.Hide();

                //Permanent Address
                textBox34.ReadOnly = false;
                textBox31.ReadOnly = false;
                textBox33.ReadOnly = false;
                textBox32.ReadOnly = false;
                textBox47.ReadOnly = false;
                textBox47.Hide();

                button7.Show();
                button8.Show();


            }
            else if (!signal)
            {
                linkLabel1.Hide();

                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox44.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox42.ReadOnly = true;
                textBox44.Text = comboBox12.Text.Trim();
                textBox44.Show();
                textBox55.Text = dateTimePicker1.Text;
                textBox55.Show();
                textBox7.ReadOnly = true;
                textBox45.ReadOnly = true;
                textBox45.Text = comboBox9.Text.Trim();
                textBox45.Show();

                textBox55.Text = dateTimePicker1.Text;
                textBox55.Show();

                //Present Address
                textBox22.ReadOnly = true;
                textBox30.ReadOnly = true;
                textBox28.ReadOnly = true;
                textBox29.ReadOnly = true;
                textBox46.ReadOnly = true;
                textBox46.Text = comboBox5.Text.Trim();
                textBox46.Show();

                //Permanent Address
                textBox34.ReadOnly = true;
                textBox31.ReadOnly = true;
                textBox33.ReadOnly = true;
                textBox32.ReadOnly = true;
                textBox47.ReadOnly = true;
                textBox47.Text = comboBox6.Text.Trim();
                textBox47.Show();

                textBox11.ReadOnly = true;
                textBox12.ReadOnly = true;

                button7.Hide();
                button8.Hide();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Edit" && textBox8.Text.Trim() != "")
            {
                EmpTabWriteAccess(true);
                label67.Text = "";

                button3.Text = "Cancel";
            }
            else if (button3.Text == "Cancel")
            {
                EmpTabWriteAccess(false);
                button3.Text = "Edit";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "Edit" && textBox23.Text.Trim() != "")
            {
                button10.Show();
                button9.Show();
                CustomerWriteAccess(true);

                button4.Text = "Cancel";

            }else if(button4.Text == "Cancel")
            {
                button10.Hide();
                button9.Hide();
                CustomerWriteAccess(false);

                button4.Text = "Edit";
            }
        }

        private void Refresher()
        {
            //Employee Tab
            pictureBox2.Image = Properties.Resources.img_avatar;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            comboBox9.Text = "";
            textBox45.Text = "";
            textBox42.Text = "";
            comboBox12.Text = "";
            textBox44.Text = "";
            textBox10.Text = "";
            textBox22.Text = "";
            textBox30.Text = "";
            textBox28.Text = "";
            comboBox5.Text = "";
            textBox46.Text = "";
            textBox29.Text = "";
            textBox34.Text = "";
            textBox31.Text = "";
            textBox33.Text = "";
            comboBox6.Text = "";
            textBox47.Text = "";
            textBox32.Text = "";
            textBox1.Text = "";
            textBox8.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            label66.Text = "";
            label67.Text = "";


            //Customer Tab
            pictureBox3.Image = Properties.Resources.img_avatar;
            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            comboBox10.Text = "";
            textBox49.Text = "";
            textBox14.Text = "";
            textBox43.Text = "";
            textBox13.Text = ""; //Initial
            comboBox11.Text = "";
            textBox48.Text = "";
            textBox56.Text = "";

            //Present Address
            textBox41.Text = "";
            textBox38.Text = "";
            textBox40.Text = "";
            comboBox8.Text = "";
            textBox50.Text = "";
            textBox39.Text = "";

            //Permanent Address
            textBox37.Text = "";
            textBox20.Text = "";
            textBox36.Text = "";
            comboBox7.Text = "";
            textBox51.Text = "";
            textBox35.Text = "";

            textBox23.Text = "";
            comboBox2.Text = "";
            textBox52.Text = "";
            comboBox3.Text = "";
            textBox53.Text = "";
            comboBox4.Text = "";
            textBox54.Text = "";

            //SIM Information
            textBox25.Text = "";
            textBox21.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox9.Text = "";

            //User Package
            balance.Text = "";
            balaVal.Text = "";
            dataPack.Text = "";
            dataVal.Text = "";
            smsPack.Text = "";
            smsVal.Text = "";
            ttPack.Text = "";
            ttValidity.Text = "";

        }

        private int AdminNumber(DatabaseFile databaseFile)
        {
           
            var numTot = databaseFile.LoadRecords<SecurityModel>("Emp_Account");
            int tot = 0;
            foreach(var rec in numTot)
            {
                if(rec.AdminStatus == "Admin")
                {
                    tot++;
                }
            }

            return tot;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            DatabaseFile databaseFile = new DatabaseFile("Employee");

            if (AdminNumber(databaseFile) > 1)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete the record?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    
                    var record = databaseFile.LoadRecordbyIdentity<EmployeeModel>("Emp_Personal_Info", "EmployeeID", textBox8.Text);
                    var passRecord = databaseFile.LoadRecordbyIdentity<SecurityModel>("Emp_Account", "EmployeeID", textBox8.Text);
                    databaseFile.DeleteRecord<EmployeeModel>("Emp_Personal_Info", record.ID);
                    databaseFile.DeleteRecord<SecurityModel>("Emp_Account", passRecord.ID);
                    EmpTabWriteAccess(false);
                    label67.Text = "Record Deleted";
                    Refresher();
                    panel13.Show();
                    button3.Text = "Edit";
                    button3.Hide();
                }
                else if (dr == DialogResult.No)
                {
                    //Nothing to do
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Cannot delete. Insufficient Admin", "Warning", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                { 
                    //Do nothing
                }
            }


            

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save changes?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                UpdateInfo();
                CustomerWriteAccess(false);
                button10.Hide();
                button9.Hide();
                button4.Text = "Edit";
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }

        }

        private void UpdateInfo()
        {
            DatabaseFile databaseFile = new DatabaseFile("Customer");
            var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", textBox23.Text.Trim());
            var recSim = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", textBox23.Text.Trim());

            record.UserImage = pictureCovert(pictureBox3.Image);
            record.FirstName = textBox19.Text.Trim();
            record.LastName = textBox18.Text.Trim();
            record.FathersName = textBox17.Text.Trim();
            record.MothersName = textBox16.Text.Trim();
            record.Nationality = textBox15.Text.Trim();
            record.Gender = comboBox10.Text.Trim();
            record.NID_Number = textBox14.Text.Trim();
            record.DrivingLicenseNum = textBox43.Text.Trim();
            record.PhoneNumber = textBox13.Text.Trim();
            record.MaritalStatus = comboBox11.Text.Trim();
            record.DateOfBirth = dateTimePicker2.Text;
            record.PresentAddress = new AddressModel
            {
                Street = textBox41.Text.Trim(),
                State = textBox38.Text.Trim(),
                City = textBox40.Text.Trim(),
                Country = comboBox8.Text.Trim(),
                PostCode = textBox39.Text.Trim()
            };
            record.PermanentAddress = new AddressModel
            {
                Street = textBox37.Text.Trim(),
                State = textBox20.Text.Trim(),
                City = textBox36.Text.Trim(),
                Country = comboBox7.Text.Trim(),
                PostCode = textBox35.Text.Trim()
            };

            recSim.SIM_Version = textBox25.Text.Trim();
            recSim.DateOfIssue = textBox21.Text.Trim();
            recSim.SerialNumber = textBox26.Text.Trim();
            recSim.Device_IMEI = textBox27.Text.Trim();
            recSim.Device_Model = textBox9.Text.Trim();
            recSim.PackageType = comboBox2.Text.Trim();
            recSim.NetworkVersion = comboBox3.Text.Trim();
            recSim.UserLevel = comboBox4.Text.Trim();

            recSim.simPackage = new SIM_Pack
            {
                Balance = balance.Text.Trim(),
                balanceValidity = balaVal.Text.Trim(),

                DataPack = dataPack.Text.Trim(),
                dataValidity = dataVal.Text.Trim(),

                SMS_Pack = smsPack.Text.Trim(),
                smsValidity = smsVal.Text.Trim(),

                Talk_Time = ttPack.Text.Trim(),
                talkTimeValidity = ttValidity.Text.Trim()
            };

            databaseFile.UpsertRecord("Personal_Info", record.ID, record);
            databaseFile.UpsertRecord("SIM_Info", recSim.ID, recSim);
        }

        private void TextBox24_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if(ctr1 is TextBox)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    button11.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    
                }
            }

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ctr1 = (Control)sender;
            if (ctr1 is TextBox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    button6.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete the record?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DatabaseFile databaseFile = new DatabaseFile("Customer");
                var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", textBox23.Text);
                var recSim = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", textBox23.Text);
                databaseFile.DeleteRecord<PersonModel>("Personal_Info", record.ID);
                databaseFile.DeleteRecord<SIM_Model>("SIM_Info", recSim.ID);

                CustomerWriteAccess(false);
                
                label75.Text = "Record Deleted";
                Refresher();
                panel14.Show();
                panel15.Show();
                panel16.Show();
                button4.Text = "Edit";
                button4.Hide();
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private byte[] pictureCovert(Image i)
        {
            var ms = new MemoryStream();

            i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var bytes = ms.ToArray();

            return bytes;

        }

        Image image;
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG)|*.BMP; *.JPG; *.PNG";


            DialogResult dr = openFileDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox3.Image = image;

            }

        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            label66.Text = "";
            label67.Text = "";
            label74.Text = "";
            label75.Text = "";

            EmpTabWriteAccess(false);
            CustomerWriteAccess(false);

            button4.Hide();
            button3.Hide();
            button10.Hide();
            button9.Hide();

            this.ActiveControl = textBox1;

            dataGridView1.Columns[1].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns[2].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns[3].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns[4].Width = (panel11.Width / 100) * 25;

            var counterLoad = tokenSync.LoadRecords<CounterModel>("Counters");
            counters = counterLoad;
            foreach (var rec in counters)
            {
                    CounterSelect.Items.Add(rec.CounterNumber);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["Users"])
            {
                this.ActiveControl = textBox24;
            }else if(tabControl1.SelectedTab == tabControl1.TabPages["Employee"])
            {
                this.ActiveControl = textBox1;
            }else if(tabControl1.SelectedTab == tabControl1.TabPages["Queue"])
            {
                var counterLoad = tokenSync.LoadRecords<CounterModel>("Counters");
                counters = counterLoad;
                DataFetch();
            }
        }
   
        private void DataFetch()
        {

            var record = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
            numOfRec = record.Count;

            dataGridView1.DataSource = record;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["TokenDigit"].Visible = false;

            //Modify Headers
            dataGridView1.Columns["CustomerName"].HeaderText = "Customer Name";
            dataGridView1.Columns["MobileNumber"].HeaderText = "Mobile Number";
            dataGridView1.Columns["TokenNumber"].HeaderText = "Token Number";
            dataGridView1.Columns["TypeOfService"].HeaderText = "Type of Service";

            //Modify Size
            dataGridView1.Columns["CustomerName"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["MobileNumber"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["TokenNumber"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["TypeOfService"].Width = (panel11.Width / 100) * 25;


        }

        private List<CounterModel> counters;

        private void timer1_Tick(object sender, EventArgs e)
        {
            var record = tokenSync.LoadRecords<TokenModel>("ActiveCounter");
            var counterLoad = tokenSync.LoadRecords<CounterModel>("Counters");
            
            
            if(counters.Count != counterLoad.Count)
            {
                counters = counterLoad;
                CounterSelect.Items.Clear();
                foreach (var rec in counters)
                {
                    if (!CounterSelect.Items.Contains(rec.CounterNumber))
                    {
                        CounterSelect.Items.Add(rec.CounterNumber);
                    }

                }
            }
            
           

            
            int newRec = record.Count;



            if (numOfRec != newRec)
            {
                DataFetch();
            }
        }

        private void AdminDashboard_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["CustomerName"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["MobileNumber"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["TokenNumber"].Width = (panel11.Width / 100) * 25;
            dataGridView1.Columns["TypeOfService"].Width = (panel11.Width / 100) * 25;
        }

        private void CounterSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rec = counters.Find(p => p.CounterNumber == CounterSelect.Text);
            textBoxExecutive.Text = rec.ExecutiveName;
            CounterSelect.Text = rec.CounterNumber;

        }

        private void AdminDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages["Employee"])
            {
                if (e.Control && e.KeyCode == Keys.E && button3.Visible)
                {
                    button3.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if (e.Control && e.KeyCode == Keys.S && button7.Visible)
                {
                    button7.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if(e.Control && e.KeyCode == Keys.D && button8.Visible)
                {
                    button8.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                
            }

            if (tabControl1.SelectedTab == tabControl1.TabPages["Users"])
            {
                if (e.Control && e.KeyCode == Keys.E && button4.Visible)
                {
                    button4.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if (e.Control && e.KeyCode == Keys.S && button10.Visible)
                {
                    button10.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if (e.Control && e.KeyCode == Keys.D && button9.Visible)
                {
                    button9.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

            }

            if (e.Control && e.KeyCode == Keys.N && e.Alt)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
            if(e.Control && e.KeyCode == Keys.M && e.Alt)
            {
                button2.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if(e.Alt && e.Shift && e.KeyCode == Keys.L)
            {
                button5.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }
    }
}
