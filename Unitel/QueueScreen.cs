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
            line6TN.Text = "";
            line6CN.Text = "";

            //Line 4
            line5TN.Text = "";
            line5CN.Text = "";

            //Line 3
            line4TN.Text = "";
            line4CN.Text = "";

            //Line 2
            line3TN.Text = "";
            line3CN.Text = "";

            //Line 1
            line2TN.Text = "";
            line2CN.Text = "";

            //Main Line
            line1TN.Text = "";
            line1CN.Text = "";
        }


        public void Call_Control(string token, string counter)
        {
            if (line1TN.Text == "" || line1CN.Text == "")
            {
                //Main Line
                line1TN.Text = token;
                line1CN.Text = counter;
            }
            else if (line1TN.Text != token)
            {
                if (blinkerTimer.Enabled)
                {
                    blinkerTimer.Stop();
                }


                //Line 6
                line6TN.Text = line5TN.Text;
                line6CN.Text = line5CN.Text;

                //Line 5
                line5TN.Text = line4TN.Text;
                line5CN.Text = line4CN.Text;

                //Line 4
                line4TN.Text = line3TN.Text;
                line4CN.Text = line3CN.Text;

                //Line 3
                line3TN.Text = line2TN.Text;
                line3CN.Text = line2CN.Text;

                //Line 2
                line2TN.Text = line1TN.Text;
                line2CN.Text = line1CN.Text;

                //Main Line
                line1TN.Text = token;
                line1CN.Text = counter;
            }
            else if (line1TN.Text == token)
            {
                blinkerTimer.Enabled = true;
            }




        }

        private int countTimer = 0;

        private void BlinkerTimer_Tick(object sender, EventArgs e)
        {
            if (line1TN.ForeColor == Color.FromArgb(21, 2, 54) && countTimer < 6)
            {
                line1TN.ForeColor = Color.Red;
                line1CN.ForeColor = Color.Red;
                countTimer++;
            }
            else if (line1TN.ForeColor == Color.Red && countTimer < 6)
            {
                line1TN.ForeColor = Color.FromArgb(21, 2, 54);
                line1CN.ForeColor = Color.FromArgb(21, 2, 54);
                countTimer++;
            }

            if (countTimer >= 6)
            {
                blinkerTimer.Stop();
                countTimer = 0;
            }

        }
    }
}
