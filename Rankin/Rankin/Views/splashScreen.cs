using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rankin.Views
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void splashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 100;
            ProgressBar1.Step = 10;
            timer1.Interval = 1000;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.PerformStep();
            if (ProgressBar1.Value == ProgressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
              AdminLogin adminLogin = new AdminLogin();
               adminLogin.Show();
                this.Hide();   

            }
        }
    }
}
