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
using System.IO;
namespace Rankin.Views
{
    public partial class AddElector : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("EsayVote.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public AddElector()
        {
            InitializeComponent();
        }
       
        string ImageLocation = "";

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void ElectorPicture_Click(object sender, EventArgs e)
        {
           
        }
        private void pictureElector_Click(object sender, EventArgs e)
        {

          
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image File|*.jpg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageLocation = fileDialog.FileName.ToString();
                    pictureElector.ImageLocation = ImageLocation;
                }
            }
        }
        private void SaveElector_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            string nom = nomTxt.Text;
            string prenom = prenomtxt.Text;
            string matricule = matriculetxt.Text;
            string sexelect = sexeCbx.Text;
            int voter = 0;
          
         
            try
            {
                byte[] images = null;
                FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                brs.Close();
                con.Open();
                string query = "INSERT INTO ELECTEUR(NOM,PRENOM,MATRICULE,PHOTO,VOTER,SEXE)VALUES('" + nom + "','" + prenom + "','" + matricule + "',@images,'"+ voter +"','" + sexelect + "')";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
               
                menu load = new menu();
                load.refreshgrid();
                load.refreshgrid();
                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "insertion effectuer avec succes\n";
                successMessage.Show();
                this.Close();
                load.RefreshALl();
            }
            catch (Exception ex)
            {
            //    ErrorMessage errorMessage = new ErrorMessage();
            //    errorMessage.errorMessageLabel.Text = ex.Message;
            //    errorMessage.ShowDialog();
            MessageBox.Show(ex.Message);
            }




        }

        private void edite_Click(object sender, EventArgs e)
        {
            try
            {

          

            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            int id = int.Parse(idtxt.Text);
            string nom = nomTxt.Text;
            string prenom = prenomtxt.Text;
            string matricule = matriculetxt.Text;
            string sexelect = sexeCbx.Text;
            byte[] images = null;
            FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
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
          
                menu load = new menu();
                load.refreshgrid();
                    successMessage successMessage = new successMessage();
                    successMessage.SuccesMessageLabel.Text = "modiffication effectuer avec succes\n";
                    successMessage.Show();
                    this.Close();
                    load.RefreshALl();

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = ex.Message;
                errorMessage.ShowDialog();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            int id = int.Parse(idtxt.Text);
            try
            {
                con.Open();
                string query = $"DELETE FROM ELECTEUR  WHERE ID_ELECTEUR='" + id + "';";

                cmd = new SqlCommand(query, con);
                int n = cmd.ExecuteNonQuery();
                con.Close();
                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "suppression effectuer avec succes\n";
                successMessage.Show();
                this.Close();
                menu load = new menu();
                load.RefreshALl();
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
