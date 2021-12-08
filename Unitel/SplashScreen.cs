using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Unitel
{

    public partial class SplashScreen : Form
    {
        readonly Home home = new Home();
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reserved);
        public SplashScreen()
        {
            InitializeComponent();
            label2.Text = Application.ProductVersion.ToString();

            if (InternetGetConnectedState(out _,0))
            {
                panel2.Width += 2;
                timer1.Start();
                label1.Text = "";
            }
            else
            {
                panel2.Width += 2;
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
        private void Timer1_Tick(object sender, EventArgs e)
        {
            while(InternetGetConnectedState(out _, 0) && panel2.Width < panel1.Width - 350)
            {
                panel2.Width += 1;
            }


            if(InternetGetConnectedState(out _,0) && panel2.Width < panel1.Width)
            {
                panel2.Width += 2;
                if (label1.Text == "Trying to connect")
                {
                    label1.Text = "";
                }
                
            }else if(!InternetGetConnectedState(out _, 0))
            {
                if(label1.Text != "Trying to connect")
                {
                    label1.Text = "Trying to connect";
                }
                
            }

            if (panel2.Width >= panel1.Width)
            {
                timer1.Stop();
                home.Show();
                this.Hide();
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            tryCon:
            if (CheckForInternetConnection())
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                label1.Text = "Trying to connect";
                int waiting = 0;
                while (!CheckForInternetConnection())
                {
                    waiting++;
                }

                goto tryCon;
            }
        }
    }
}
