using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Unitel
{
    public partial class TicketGen : Form
    {
        private int tokenNumber = 0;
        DatabaseFile database = new DatabaseFile("Tokens");
        DatabaseFile personInfo = new DatabaseFile("Customer");

        public TicketGen()
        {
            InitializeComponent();
            label3.Text = "";

            DatabaseFile databaseFile = new DatabaseFile("Tokens");
            var record = databaseFile.LoadRecords<TokenModel>("ActiveCounter");
            int size = record.Count;
            try
            {
                tokenNumber = record.Max(p => p.TokenDigit +1);
            }
            catch (Exception)
            {
                tokenNumber++;
                label3.Text = "Unable to fetch data";
            }

        }

        private bool MobileValidator()
        {
            string mobNumberInput = textBox1.Text.Trim();

            if (mobNumberInput == "")
            {
                label3.Text = "Enter a mobile number";
                timer1.Enabled = true;
                return false;
            }
            else if(mobNumberInput.Length < 11)
            {
                label3.Text = "Please enter a valid mobile number";
                timer1.Enabled = true;
                return false;

            }
            else
            {
                return true;
            }
        }

        private void TokenGenerator(string service, string tokenNum)
        {
            var record = personInfo.LoadRecords<PersonModel>("Personal_Info");
            if (service == "Buy New SIM")
            {
                database.InsertRecord("ActiveCounter", new TokenModel
                {
                    CustomerName = "New User",
                    MobileNumber = textBox1.Text,
                    TypeOfService = service,
                    TokenNumber = tokenNum,
                    TokenDigit = tokenNumber
                });

                tokenNumber++;


                label3.Text = "Token Created";
                textBox1.Text = "";
                timer1.Enabled = true;
            }
            else if(record.Count > 0)
            {
                bool exists = record.Any(r => r.MobileNumber == textBox1.Text.Trim());
                
                if (exists)
                {
                    var rec = personInfo.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", textBox1.Text.Trim());
                    database.InsertRecord("ActiveCounter", new TokenModel
                    {
                        CustomerName = $"{rec.FirstName} {rec.LastName}",
                        MobileNumber = rec.MobileNumber,
                        TypeOfService = service,
                        TokenNumber = tokenNum,
                        TokenDigit = tokenNumber
                    });

                    tokenNumber++;


                    label3.Text = "Token Created";
                    timer1.Enabled = true;
                    textBox1.Text = "";
                }
                else
                {
                    label3.Text = "User does not exist";
                    timer1.Enabled = true;
                }
            }
            else
            {
                label3.Text = "No user record found";
                timer1.Enabled = true;
            }
            

            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(replaceSim.Text, $"SR{tokenNumber}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(roaming.Text, $"IR{tokenNumber}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            TokenGenerator(newSim.Text, $"New{tokenNumber}");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(infoDesk.Text, $"Info{tokenNumber}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(offerPack.Text, $"OP{tokenNumber}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(changeSubs.Text, $"CS{tokenNumber}");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = "";
            timer1.Stop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
