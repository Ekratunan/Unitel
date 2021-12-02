using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Unitel
{
    public partial class SplashScreen : Form
    { 
        public SplashScreen()
        {
            InitializeComponent();
            if (CheckForInternetConnection())
            {
                timer1.Start();
                label1.Text = "";
            }
            else
            {
                timer2.Start();
                label1.Text = "No internet Connection";
            }

        }


        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.mongodb.com/"))
                    return true;
            }
            catch
            {

                return false;
            }
        }


        Home home = new Home();
        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;
            

            if (panel2.Width >= panel1.Width)
            {
                
                timer1.Stop();
                home.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                timer1.Start();
            }
            else
            {
                timer2.Stop();
                label1.Text = "Trying to connect";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
