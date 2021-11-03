using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Unitel
{
    public partial class Dashboard : Form
    {
        public Dashboard(string exeName, string counter)
        {
            InitializeComponent();

            this.label3.Text = exeName;
            this.label4.Text = counter;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string phoneNum = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            CustomerInformationPage cip = new CustomerInformationPage(customerName, phoneNum);

            cip.Show();
            this.Hide();


        }
    }
}
