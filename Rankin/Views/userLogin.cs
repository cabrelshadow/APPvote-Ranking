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
using System.Data.SqlClient;
using System.IO;
namespace Rankin.Views
{
    public partial class userLogin : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("RankinBd.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public userLogin()
        {
            InitializeComponent();
        }

        private void ChoseAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            this.Close();
               adminLogin.Show();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connect_Click(object sender, EventArgs e)
        {
             
        }

        private void userLogin_Load(object sender, EventArgs e)
        {

        }

        private void connect_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (nomtxt.Text == "" || matriculeTxt.Text == "")
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.errorMessageLabel.Text = "veillez remplire tout les champs";
                    errorMessage.ShowDialog();
                }
                else
                {
                    try
                    {
                      
                        con = new SqlConnection(ConnectionString);
                        SqlCommand cmd = new SqlCommand("SELECT * FROM ELECTEUR WHERE NOM=@NOM AND MATRICULE=@MATRICULE AND VOTER=0", con);
                        cmd.Parameters.AddWithValue("@NOM",nomtxt.Text);
                        cmd.Parameters.AddWithValue("@MATRICULE", matriculeTxt.Text);
               
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                       DataTable dt = new DataTable();
                        adapter.Fill(dt);
                       
                        if (dt.Rows.Count > 0)
                        {
                            successMessage successMessage = new successMessage();
                            successMessage.SuccesMessageLabel.Text = "vous etes connecter avec succes\n";
                            successMessage.ShowDialog();
                            PageVote pageVote = new PageVote();
                            DataRow userRow= dt.Rows[0];
                            DataRow matriculeuser= dt.Rows[0];
                            DataRow photo = dt.Rows[0];
                            byte[] img = (byte[])photo["PHOTO"];
                            MemoryStream ms = new MemoryStream(img);
                            pageVote.username.Text = userRow["NOM"].ToString();
                            pageVote.iduser.Text=userRow["ID_ELECTEUR"].ToString();
                           // PageVote.particpantPictureBox.Image = Image.FromStream(ms);
                           pageVote.PictureBox1.Image = Image.FromStream(ms);
                            pageVote.matrucleTxt.Text = matriculeuser["MATRICULE"].ToString();
                          
                            this.Close();
                            pageVote.Show();

                        } 
                        else
                        {
                            ErrorMessage errorMessage = new ErrorMessage();
                            errorMessage.errorMessageLabel.Text = "votre nom ou matricule est incorrect !";
                            errorMessage.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage errorMessage = new ErrorMessage();
                        errorMessage.errorMessageLabel.Text = ex.Message;
                        errorMessage.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = ex.Message;
                errorMessage.ShowDialog();
            }
         
           
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
