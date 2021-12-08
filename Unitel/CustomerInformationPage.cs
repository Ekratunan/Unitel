using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Unitel
{
    public partial class CustomerInformationPage : Form
    {
        Form dashboard { get; set; }
        private string Token { get; set; }
        DatabaseFile findData = new DatabaseFile("Customer");
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);

        public CustomerInformationPage(string phoneNum, string token, string typeOfSer, Form dash)
        {
            InitializeComponent();
            ValuePicker(phoneNum);
            button5.Hide();
            label28.Text = "";
            label29.Text = token;
            label31.Text = typeOfSer;
            label16.Text = phoneNum;
            WriteAccess(true);
            button1.Hide();
            panel9.Hide();
            panel6.Hide();
            panel7.Hide();

            dashboard = dash;
            Token = token;
        }

        
        public CustomerInformationPage(string token, string typeOfSer, Form dash)
        {
            InitializeComponent();
            label16.Text = "";
            button4.Hide();
            button1.Hide();
            label28.Text = "";
            WriteAccess(false);
            label29.Text = token;
            label31.Text = typeOfSer;
            Token = token;
            dashboard = dash;
        }

        public CustomerInformationPage()
        {
            InitializeComponent();
        }

        

        private Image BinToImage(byte[] b)
        {
            var img = new MemoryStream(b);
            Image imgFromStream = Image.FromStream(img);
            return imgFromStream;
        }


        private void ValuePicker(string phoneNum)
        {
               
            DatabaseFile databaseFile = new DatabaseFile("Customer");    
            var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", phoneNum);
            var simRecord = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", phoneNum);

               

            if (record.UserImage != null)
            {
                pictureBox2.Image = BinToImage(record.UserImage);
            }
            else
            {
                pictureBox2.Image = Properties.Resources.img_avatar;
            }

            mobile.Text = record.MobileNumber;
            textBox1.Text = record.FirstName; //First Name
            textBox4.Text = record.LastName; //Last Name
            textBox2.Text = record.FathersName; //Fathers Name
            textBox3.Text = record.MothersName; //Mothers Name
            textBox6.Text = record.Nationality; //Nationality
            textBox7.Text = record.NID_Number; //NID or Passport Number
            textBox13.Text = record.DrivingLicenseNum; //Driving License Number
            dateTimePicker1.Value = DateTime.ParseExact(record.DateOfBirth, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
            comboBox4.Text = record.Gender;
            comboBox7.Text = record.MaritalStatus;
            textBox15.Text = record.PhoneNumber;


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



            //Customer-SIM Info (Left)
            textBox11.Text = simRecord.simPackage.Balance;
            textBox12.Text = simRecord.simPackage.DataPack;
            textBox17.Text = simRecord.simPackage.balanceValidity;
            comboBox2.Text = simRecord.NetworkVersion;
            comboBox3.Text = simRecord.UserLevel;


                
            //SIM Information tab
            
            comboBox1.Text = simRecord.PackageType;   
            textBox5.Text = simRecord.Device_IMEI; 
            textBox9.Text = simRecord.Device_Model;       
            textBox8.Text = simRecord.SIM_Version;
            textBox16.Text = simRecord.DateOfIssue;

            button4.Show();
            button1.Hide();
            this.AcceptButton = null;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WriteAccess(bool writable)
        {
            if (writable)
            {
                textBox1.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox13.ReadOnly = false;
                textBox15.ReadOnly = false;


                //Present Address
                textBox22.ReadOnly = false;
                textBox30.ReadOnly = false;
                textBox29.ReadOnly = false;
                textBox28.ReadOnly = false;

                //Permanent Address
                textBox34.ReadOnly = false;
                textBox31.ReadOnly = false;
                textBox32.ReadOnly = false;
                textBox33.ReadOnly = false;


                //SIM Information tab
                textBox5.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox14.ReadOnly = false;
            }
            else if(!writable)
            {
                textBox1.ReadOnly = true;
                textBox4.ReadOnly = true; 
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox15.ReadOnly = true;


                //Present Address
                textBox22.ReadOnly = true;
                textBox30.ReadOnly = true;
                textBox29.ReadOnly = true;
                textBox28.ReadOnly = true;
       

                //Permanent Address
                textBox34.ReadOnly = true;
                textBox31.ReadOnly = true;
                textBox32.ReadOnly = true;
                textBox33.ReadOnly = true;

                //SIM Information tab

                textBox5.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox14.ReadOnly = true;
            }
        }

        private byte[] pictureCovert(Image i)
        {
            var ms = new MemoryStream();

            i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            var bytes = ms.ToArray();

            return bytes;

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Save Changes?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    DatabaseFile databaseFile = new DatabaseFile("Customer");
                    var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", label16.Text.Trim());
                    var sim = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", label16.Text.Trim());


                    record.UserImage = pictureCovert(pictureBox2.Image);
                    record.FirstName = textBox1.Text.Trim();
                    record.LastName = textBox4.Text.Trim();
                    record.FathersName = textBox2.Text.Trim();
                    record.MothersName = textBox3.Text.Trim();
                    record.Nationality = textBox6.Text.Trim();
                    record.Gender = comboBox4.Text.Trim();
                    record.MaritalStatus = comboBox7.Text.Trim();
                    record.NID_Number = textBox7.Text.Trim();
                    record.DrivingLicenseNum = textBox13.Text.Trim();
                    record.DateOfBirth = dateTimePicker1.Text.Trim();
                    record.PhoneNumber = textBox15.Text.Trim();

                    record.PresentAddress = new AddressModel
                    {
                        Street = textBox22.Text.Trim(),
                        State = textBox30.Text.Trim(),
                        PostCode = textBox29.Text.Trim(),
                        City = textBox28.Text.Trim(),
                        Country = comboBox5.Text.Trim()
                    };
                    record.PermanentAddress = new AddressModel
                    {
                        Street = textBox34.Text.Trim(),
                        State = textBox31.Text.Trim(),
                        PostCode = textBox32.Text.Trim(),
                        City = textBox33.Text.Trim(),
                        Country = comboBox6.Text.Trim()
                    };

                    sim.simPackage.Balance = textBox11.Text.Trim();
                    sim.simPackage.DataPack = textBox12.Text.Trim();
                    sim.simPackage.balanceValidity = textBox11.Text;
                    sim.NetworkVersion = comboBox2.Text;
                    sim.UserLevel = comboBox3.Text;

                    sim.PackageType = comboBox1.Text;
                    sim.Device_IMEI = textBox5.Text;
                    sim.Device_Model = textBox9.Text;
                    sim.SIM_Version = textBox8.Text;
                    sim.SerialNumber = textBox14.Text;

                    databaseFile.UpsertRecord("Personal_Info", record.ID, record);
                    databaseFile.UpsertRecord("SIM_Info", sim.ID, sim);

                    button1.Hide();
                }
                catch(NullReferenceException)
                {
                    MessageBox.Show("This user does not exists!", "Error", MessageBoxButtons.OK);
                }

                
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox10.Text.Trim() == "")
            {
                label28.Text = "Please enter a Mobile Number";
            }
            else
            {
                label28.Text = "Searching for user....";
                WriteAccess(false);

                
                var records = findData.LoadRecords<PersonModel>("Personal_Info");
                bool exists = records.Any(p => p.MobileNumber == textBox10.Text.Trim());

                if (exists)
                {
                    ValuePicker(textBox10.Text.Trim()); //This assign the datas at the fields.
                    label28.Text = "";
                    WriteAccess(true);
                    panel9.Hide();
                    panel6.Hide();
                    panel7.Hide();
                }
                else
                {
                    label28.Text = "Record Not found";
                }
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Show();
        }

        private void Mark_As_Solved()
        {
            DatabaseFile tokenDb = new DatabaseFile("Tokens");
            var recToken = tokenDb.LoadRecordbyIdentity<TokenModel>("ActiveCounter", "TokenNumber", Token);
            tokenDb.DeleteRecord<TokenModel>("ActiveCounter", recToken.Id);
        }

        private void Mark_As_Solved(string phone)
        {
            //Loading database
            DatabaseFile tokenDb = new DatabaseFile("Tokens");
            DatabaseFile customerDB = new DatabaseFile("Customer");
            
            //Loading records
            var recToken = tokenDb.LoadRecordbyIdentity<TokenModel>("ActiveCounter", "TokenNumber", Token);
            var personLoad = customerDB.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", phone);
            var simLoad = customerDB.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", phone);

            tokenDb.InsertRecord("Service_Log", new ServiceRecord_Model
            {
                CustomerName = recToken.CustomerName,
                MobileNumber = recToken.MobileNumber,
                TokenNumber = recToken.TokenNumber,
                TypeOfService = recToken.TypeOfService,
                CustomerInfo = new PersonRecord
                {
                    FathersName = personLoad.FathersName,
                    MothersName = personLoad.MothersName,
                    PhoneNumber = personLoad.PhoneNumber,
                    DateOfBirth = personLoad.DateOfBirth,
                    Nationality = personLoad.Nationality,
                    NID_Number = personLoad.NID_Number,
                    DrivingLicenseNum = personLoad.DrivingLicenseNum,
                    Gender = personLoad.Gender,
                    MaritalStatus = personLoad.MaritalStatus,
                    PresentAddress = new AddressModel
                    {
                        State = personLoad.PresentAddress.State,
                        Street = personLoad.PresentAddress.Street,
                        City = personLoad.PresentAddress.City,
                        Country = personLoad.PresentAddress.Country,
                        PostCode = personLoad.PresentAddress.PostCode
                    },
                    PermanentAddress = new AddressModel
                    {
                        State = personLoad.PermanentAddress.State,
                        Street = personLoad.PermanentAddress.Street,
                        City = personLoad.PermanentAddress.City,
                        Country = personLoad.PermanentAddress.Country,
                        PostCode = personLoad.PermanentAddress.PostCode
                    }

                },
                UserSim = new SIM_Model
                {
                    MobileNumber = personLoad.MobileNumber,
                    PackageType = simLoad.PackageType,
                    NetworkVersion = simLoad.NetworkVersion,
                    UserLevel = simLoad.UserLevel,
                    SIM_Version = simLoad.SIM_Version,
                    DateOfIssue = simLoad.DateOfIssue,
                    SerialNumber = simLoad.SerialNumber,
                    Device_IMEI = simLoad.Device_IMEI,
                    Device_Model = simLoad.Device_Model,
                    simPackage = new SIM_Pack
                    {
                        Balance = simLoad.simPackage.Balance,
                        balanceValidity = simLoad.simPackage.balanceValidity,
                        DataPack = simLoad.simPackage.DataPack,
                        dataValidity = simLoad.simPackage.dataValidity,
                        Talk_Time = simLoad.simPackage.Talk_Time,
                        talkTimeValidity = simLoad.simPackage.talkTimeValidity,
                        SMS_Pack = simLoad.simPackage.SMS_Pack,
                        smsValidity = simLoad.simPackage.smsValidity
                    }
                }

            });

            tokenDb.DeleteRecord<TokenModel>("ActiveCounter", recToken.Id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(InternetGetConnectedState(out _, 0))
            {
                DialogResult dr = MessageBox.Show("Are you sure this ticket has been solved?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (label16.Text == "")
                    {
                        Mark_As_Solved();
                    }
                    else
                    {
                        Mark_As_Solved(label16.Text);
                    }



                    this.Close();


                }
                else if (dr == DialogResult.No)
                {
                    //Do nothing
                }
            }
            else
            {
                MessageBox.Show("No internet. Make sure you are connected to the internet", "Network Disconnected", MessageBoxButtons.OK);
            }
            
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

                button1.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure tou want to deactivate this account?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DatabaseFile databaseFile = new DatabaseFile("Customer");
                var record = databaseFile.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", label16.Text);
                var recSim = databaseFile.LoadRecordbyIdentity<SIM_Model>("SIM_Info", "MobileNumber", label16.Text);
                databaseFile.DeleteRecord<PersonModel>("Personal_Info", record.ID);
                databaseFile.DeleteRecord<SIM_Model>("SIM_Info", recSim.ID);


                label28.Text = "Record Deleted";
          
                panel7.Show();
                panel9.Show();
                panel6.Show();
                button4.Hide();
                button1.Hide();
                label16.Text = "";
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerInformationPage_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox10;
            textBox10.Focus();
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button6.PerformClick();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button6;
        }

        private void CustomerInformationPage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.N && e.Alt)
            {
                button5.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.F)
            {
                this.ActiveControl = textBox10;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if(e.Control && e.KeyCode == Keys.S && button1.Visible)
            {
                button1.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if(e.Control && e.KeyCode == Keys.D && button4.Visible)
            {
                button4.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if(e.Control && e.KeyCode == Keys.K)
            {
                button2.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }else if(e.Control && e.KeyCode == Keys.J)
            {
                button3.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            
        }

        private void CustomerInformationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            dashboard.ShowInTaskbar = true;
            dashboard.WindowState = FormWindowState.Normal;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(button5, "Ctrl+Alt+N");
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(button6, "Enter");
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!panel7.Visible)
            {
                toolTip1.SetToolTip(button1, "Save(Ctrl+S)");
            }
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            if (!panel7.Visible)
            {
                toolTip1.SetToolTip(button4, "Remove(Ctrl+D)");
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(button2, "Ctrl+K");
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(button3, "Ctrl+J");
        }
    }
}
