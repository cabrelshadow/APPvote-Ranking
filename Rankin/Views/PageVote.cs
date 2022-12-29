using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Rankin.Views;
using Rankin.Events;
namespace Rankin.Views
{
    public partial class PageVote : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("RankinBd.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public PageVote()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public  void CloseFormVote()
        {
            this.Close();
        }
        private void PageVote_Load(object sender, EventArgs e)
        {
            LoadvotePannel();



        }

        private void prenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
           CloseFormVote();
            userLogin login = new userLogin();
           login.ShowDialog();
        }
        public void LoadvotePannel()
        {

            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();


                string sql = "select * from PARTICIPANT";
                SqlCommand s = new SqlCommand(sql, con);
                SqlDataReader r = s.ExecuteReader();

                while (r.Read())
                {
                    VoteParticipant voteParticipant = new VoteParticipant();
                    voteParticipant.idTxt.Text = r[0].ToString();
                    voteParticipant.nom.Text = r[1].ToString();
                    voteParticipant.prenomtxt.Text = r[2].ToString();
                    voteParticipant.slogantxt.Text = r[6].ToString();
                    voteParticipant.voteProgress.Value = int.Parse(r[5].ToString());
                    voteParticipant.Poucentage.Text = r[5].ToString();
                    voteParticipant.sexe.Text = r[7].ToString();
                    voteParticipant.agetxt.Text = r[3].ToString();
                    voteParticipant.Idusers.Text = iduser.Text;

                    byte[] img = (byte[])r["PHOTO"];
                    MemoryStream ms = new MemoryStream(img);
                    voteParticipant.PictureVote.Image = Image.FromStream(ms);

                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(voteParticipant);


                    }

                }
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = $"\n{ ex.Message}";
                errorMessage.ShowDialog();
            }
        }

        private void RefreshVoteur_Click(object sender, EventArgs e)
        {
            LoadvotePannel();
        }
    }
}
