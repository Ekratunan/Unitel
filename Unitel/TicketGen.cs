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

        Timer timer = new Timer
        {
            Interval = (8 * 1000)
        };

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

            
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label3.Text = "";
        }

        private bool MobileValidator()
        {
            bool isValid = false;
            string mobNumberInput = textBox1.Text.Trim();

            if (mobNumberInput == "")
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Please enter a mobile number";
            }
            else
            {
                int convNumber = Convert.ToInt32(mobNumberInput);
                if (convNumber >= 1200000000)
                {
                    isValid = true;
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Enter a valid Mobile Number";
                }

            }

            return isValid;
        }

        private void TokenGenerator(string service, string tokenNum)
        {
            DatabaseFile database = new DatabaseFile("Tokens");
            DatabaseFile personInfo = new DatabaseFile("Customer");

            var record = personInfo.LoadRecords<PersonModel>("Personal_Info");
            bool searching = record.Any(r => r.MobileNumber == textBox1.Text.Trim());

            if(service == "Buy New SIM")
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
                label3.ForeColor = Color.Green;
                timer.Start();
                label3.Text = "Token Created";
                textBox1.Text = "";
            }
            else if (searching && service != "Buy New SIM")
            {

                var rec = personInfo.LoadRecordbyIdentity<PersonModel>("Personal_Info", "MobileNumber", textBox1.Text.Trim());
                database.InsertRecord("ActiveCounter", new TokenModel {
                     CustomerName = $"{rec.FirstName} {rec.LastName}",
                     MobileNumber = rec.MobileNumber,
                     TypeOfService = service,
                     TokenNumber = tokenNum,
                     TokenDigit = tokenNumber
                });

                tokenNumber++;
                label3.ForeColor = Color.Green;
                timer.Start();
                label3.Text = "Token Created";
                textBox1.Text = "";
            }
            else if (!searching)
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
                TokenGenerator(button2.Text, $"SR{tokenNumber}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button3.Text, $"IR{tokenNumber}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            TokenGenerator(button1.Text, $"New{tokenNumber}");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button4.Text, $"Info{tokenNumber}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button6.Text, $"OP{tokenNumber}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MobileValidator())
            {
                TokenGenerator(button5.Text, $"CS{tokenNumber}");
            }
        }
    }
}
