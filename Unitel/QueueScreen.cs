using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unitel
{
    public partial class QueueScreen : Form
    {
        public QueueScreen()
        {
            InitializeComponent();

            //Line 5
            label9.Text = "";
            label14.Text = "";

            //Line 4
            label8.Text = "";
            label13.Text = "";

            //Line 3
            label6.Text = "";
            label12.Text = "";

            //Line 2
            label7.Text = "";
            label11.Text = "";

            //Line 1
            label5.Text = "";
            label10.Text = "";

            //Main Line
            label2.Text = "";
            label4.Text = "";
        }

        Timer timer = new Timer
        {
            Interval = (1 * 1000)
        };

        public void Call_Control(string token, string counter)
        {
            if (label2.Text == "" || label4.Text == "")
            {
                //Main Line
                label2.Text = token;
                label4.Text = counter;
            } else if (label2.Text != token)
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }
                
                
                //Line 5
                label9.Text = label8.Text;
                label14.Text = label13.Text;

                //Line 4
                label8.Text = label6.Text;
                label13.Text = label12.Text;

                //Line 3
                label6.Text = label7.Text;
                label12.Text = label11.Text;

                //Line 2
                label7.Text = label5.Text;
                label11.Text = label10.Text;

                //Line 1
                label5.Text = label2.Text;
                label10.Text = label4.Text;

                //Main Line
                label2.Text = token;
                label4.Text = counter;
            }else if(label2.Text == token)
            {
                timer = new Timer
                {
                    Interval = (1 * 1000)
                };
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }

                
            

        }

        private int countTimer = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            if(label2.ForeColor == Color.SeaGreen && countTimer < 6)
            {
                label2.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
                countTimer++;
            }else if(label2.ForeColor == Color.Red && countTimer < 6)
            {
                label2.ForeColor = Color.SeaGreen;
                label4.ForeColor = Color.SeaGreen;
                countTimer++;
            }

            if(countTimer >= 6)
            {
                timer.Stop();
                countTimer = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void QueueScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
