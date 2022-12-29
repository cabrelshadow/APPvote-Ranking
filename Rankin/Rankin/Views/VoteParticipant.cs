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
using Rankin.Events;

namespace Rankin.Views
{
    public partial class VoteParticipant : UserControl
    {
        PageVote pagedevote = new PageVote();

        public int voted=0;
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("EsayVote.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        int nombreVois=0;
        public VoteParticipant()
        {
            InitializeComponent();
        }

        public void UpdateVoteuser()
        { 
            try
            {
                int idusers = int.Parse(Idusers.Text);
                string query2 = $"UPDATE ELECTEUR SET VOTER=1 WHERE ID_ELECTEUR='" + idusers + "';";
                SqlCommand cmd;
                con = new SqlConnection(ConnectionString);
                con.Open();

                cmd = new SqlCommand(query2, con);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }   
        private void voteBtn_Click(object sender, EventArgs e)
        {
          
            if (voted<1)
            {
                try
                {
                    nombreVois = 1;
                    int id = int.Parse(idTxt.Text);


                    SqlCommand cmd;
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                    string query = $"UPDATE PARTICIPANT SET NOMBREVOIE=NOMBREVOIE + { nombreVois} WHERE ID_PARTICIPANT='" + id + "';";

                    cmd = new SqlCommand(query, con);

                    int n = cmd.ExecuteNonQuery();
                    UpdateVoteuser();
                    con.Close();
                    MessageBox.Show("vous avez voter pour ce partico*ipant  avec succes\n", "vote", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    voted = voted+1;
                    pagedevote.Close();

                }
                catch (Exception ex)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.errorMessageLabel.Text = ex.Message;
                    errorMessage.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("vous avez deja effectuer un vote", "vote", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }
         
      

        }
    }

