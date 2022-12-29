using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rankin.DAL;
using Rankin.Entity;
using Rankin.Events;
using System.IO;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace Rankin.Services
{
   
    public class ServiceElecteur
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("RankinBd.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public void addElecteur( string nom, string prenom,int age, string matricule ,int voted, int IsVoted,string image)
        {
            byte[] images = null;
            FileStream stream = new FileStream(image, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            brs.Close();

            con = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            try
            {
                con.Open();
                string query = "INSERT INTO ELECTEUR(NOM,PRENOM,MATRICULE,PHOTO,SEXE)VALUES('" + nom + "','" + prenom + "','" + matricule + "',@images)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
        
             
                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "insertion effectuer avec succes\n";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateElecteur(int id, string nom, string prenom, string matricule,string image)
        {


            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
      
        
            byte[] images = null;
            FileStream stream = new FileStream(image, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            brs.Close();
            try
            {
                con.Open();
                string query = $"UPDATE ELECTEUR SET NOM='" + nom + "', PRENOM='" + prenom + "',MATRICULE='" + matricule + "',PHOTO=@images WHERE ID_ELECTEUR='" + id + "';";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
               
             
                MessageBox.Show("mddification avec success", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
