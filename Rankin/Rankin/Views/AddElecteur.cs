using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Rankin.Events;
using Rankin.DAL;
namespace Rankin.Views
{
    public partial class AddElecteur : Form
    {
        String ConnectionString = @"Data Source=DESKTOP-2GPND6O\SQLEXPRESS;Initial Catalog=EsayVote;Integrated Security=True";
        SqlConnection con = null;
        public AddElecteur()
        {
            InitializeComponent();
        }
        string ImageLocation = "";

     

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

   
        public void clearTextBox()
        {
            nomtxt.Text="";
            prenomtxt.Text = "";
            matriculeTxt.Text="";
            pictureBoxParticipant.Refresh();
        }
   

        private void SavePersonne_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            string nom = nomtxt.Text;
            string prenom = prenomtxt.Text;
            string matricule = matriculeTxt.Text;
            string sexelect = SexeElect.Text;
            byte[] images = null;
            FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            brs.Close();
            try
            {
                con.Open();
                string query = "INSERT INTO ELECTEUR(NOM,PRENOM,MATRICULE,PHOTO,SEXE)VALUES('" + nom + "','" + prenom + "','" + matricule + "',@images,'"+sexelect+"')";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
                clearTextBox();
                menu load = new menu();
                load.refreshgrid();
                successMessage successMessage = new successMessage();
                successMessage.SuccesMessageLabel.Text = "insertion effectuer avec succes\n";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                clearTextBox();
                menu load = new menu();
                load.refreshgrid();
                MessageBox.Show("mddification avec success", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void update_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            con = new SqlConnection(ConnectionString);
            int id=int.Parse(idtxt.Text);
            string nom = nomtxt.Text;
            string prenom = prenomtxt.Text;
            string matricule = matriculeTxt.Text;
            byte[] images = null;
            FileStream stream = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            brs.Close();
            try
            {
                con.Open();
                string query =$"UPDATE ELECTEUR SET NOM='"+nom+"', PRENOM='"+ prenom +"',MATRICULE='"+matricule+"',PHOTO=@images WHERE ID_ELECTEUR='"+id+"';";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                int n = cmd.ExecuteNonQuery();
                con.Close();
                clearTextBox();
                menu load = new menu();
                load.refreshgrid();
                MessageBox.Show("mddification avec success", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ElecteurPictureBox_Click(object sender, EventArgs e)

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
    }
}
