using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unitel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();

        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            string exName = textBox1.Text.Trim();
            string cnNum = textBox2.Text.Trim();




            if (exName != "" && cnNum != "")
            {
                this.Hide();
                Form2 form2 = new Form2(exName, cnNum);
                form2.Show();


                string exeName = textBox1.Text;
                string counter = textBox2.Text;

                DatabaseFile databaseFile = new DatabaseFile();

                databaseFile.LogInDataInsert(exeName, counter);

            }
            else
            {
                label4.Text = "Invalid Name or Counter Number!";
            }

        }
    }
}
