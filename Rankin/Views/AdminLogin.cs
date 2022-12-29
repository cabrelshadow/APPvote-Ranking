using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rankin.Events;

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
            successMessage successMessage = new successMessage();
            successMessage.SuccesMessageLabel.Text = "vous etes connecter avec succes\n";
            userLogin userlogin = new userLogin();
            userlogin.Show();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(nomtxt.Text =="admin" && passwordTxt.Text == "admin")
            {
                menu HomeMenu = new menu();
                this.Close();
                HomeMenu.Show();
            }
            else
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = "votre login ou mot de passe\n est incorrect !";
                errorMessage.ShowDialog();
            }
        }
    }
}
