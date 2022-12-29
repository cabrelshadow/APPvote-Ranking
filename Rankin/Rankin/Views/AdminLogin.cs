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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
        Application.Exit();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            menu HomeMenu= new menu();
            this.Close();
            HomeMenu.Show();
        }

        private void ChoseAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userLogin userlogin = new userLogin();
            userlogin.Show();
            this.Close();
        }
    }
}
