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
    public partial class AddParticipant : Form
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ System.IO.Path.GetFullPath("EsayVote.mdf")+";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;

        string[] sexeTable={"homme","femme"};
        public AddParticipant()
        {
            InitializeComponent();
        }
            menu load = new menu();
              
        string ImageLocation = "";

        private void pictureBoxParticipant_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image File|*.jpg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageLocation = fileDialog.FileName.ToString();
                    pictureBoxParticipant.ImageLocation = ImageLocation;
                }
            }
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (nomtxt.Text == "" || prenomtxt.Text == "" || slogan.Text == "")
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = "veiller remplire tout les champs";
                errorMessage.ShowDialog();
            }
            else if (agetxt.Value < 17)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = "l'age doit etre supperieur a 17";
                errorMessage.ShowDialog();
            }
            else
            {



                SqlCommand cmd;
                con = new SqlConnection(ConnectionString);
                string nom = nomtxt.Text;
                string prenom = prenomtxt.Text;
                string age = agetxt.Value.ToString();
                string slogans = slogan.Text;
                string sexeBox = sexeCb.Text;
              
                try
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);
                    images = brs.ReadBytes((int)stream.Length);
                    brs.Close();

                    con.Open();
                    string query = "INSERT INTO PARTICIPANT(NOM,PRENOM,AGE,PHOTO,NOMBREVOIE,SLOGAN,SEXE)" +
                   "VALUES('" + nom + "','" + prenom + "','" + age + "',@images,'"+ 0 +"','"+ slogans+"','"+sexeBox+"')";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@images", images));
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
               
                    menu load = new menu();
                    load.refreshgrid();
                    successMessage successMessage = new successMessage();
                    successMessage.SuccesMessageLabel.Text = "insertion effectuer avec succes\n";
                    successMessage.Show();
                 
                    this.Close();
                    clearBoxs();
                    successMessage.ShowDialog();
                    load.RefreshALl();
            

                }

                catch (Exception ex)
                {

                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.errorMessageLabel.Text =$"\n{ ex.Message}";
                    errorMessage.ShowDialog();
                }
            }

           
            //
        }
        public void RetriveImageParticipant()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM PARTICIPANT";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] img = (byte[])reader["PHOTO"];
                        MemoryStream ms = new MemoryStream(img);
                        pictureBoxParticipant.Image=Image.FromStream(ms);
                    }
                }
            }

        }
        private void close_Click(object sender, EventArgs e)
        {
          
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void AddParticipant_Load(object sender, EventArgs e)
        {
         
        }
        public void clearBoxs()
        {
            nomtxt.Text = "";
            prenomtxt.Text = "";
            slogan.Text = "";
            agetxt.Value = 1;

        }
        private void edite_Click(object sender, EventArgs e)
        {
            int idP = int.Parse(idtxt.Text);
            string nomP = nomtxt.Text;
            string prenomP = prenomtxt.Text;
            string ageP = agetxt.Value.ToString();
            string slogansP = slogan.Text;
            string sexeBoxP = sexeCb.Text;
           
          
            try
            {
                byte[] images = null;
                FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                brs.Close();

                SqlCommand cmd;
                con = new SqlConnection(ConnectionString);
                con.Open();
                string query = $"UPDATE PARTICIPANT SET NOM='" + nomP + "', PRENOM='" + prenomP + "',AGE='" + ageP + "'," +
                    "PHOTO=@images, SLOGAN='" + slogansP+"',SEXE='"+ sexeBoxP+ "' WHERE ID_PARTICIPANT='" + idP + "';";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "modiffication effectuer avec succes\n";
           
                successMessage.ShowDialog();
                load.RefreshALl();
                clearBoxs();
            
                

            }
            catch (Exception ex)
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
                string query = $"DELETE FROM PARTICIPANT WHERE ID_PARTICIPANT='" + id + "';";

                cmd = new SqlCommand(query, con);
                int n = cmd.ExecuteNonQuery();
                con.Close();
                clearBoxs();
                menu load = new menu();
                load.refreshgrid();

                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "participant supprimer avec succes\n";
                this.Close();
            
                successMessage.ShowDialog();
                load.RefreshALl();
            }
            catch (Exception ex)
            {

                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = ex.Message;
                errorMessage.ShowDialog();
            }
        }
    }
}
