using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using System.IO;
using Rankin.Events;


namespace Rankin.Views
{
    public partial class menu : MaterialForm
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("EsayVote.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public menu()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue900, Primary.BlueGrey500, Accent.Blue700, TextShade.WHITE);
        }

        private void menu_Load(object sender, EventArgs e)
        {
        
            countParcipant();
            refreshgrid();
            //refeshGrid();

            try
            {
                string RequeteSelection = "SELECT count(ID_ELECTEUR) FROM ELECTEUR";
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(RequeteSelection, con);
                var count = cmd.ExecuteScalar();

                NbElector.Text = count.ToString();
                con.Close();

                int progresValue = int.Parse(NbElector.Text);
                progressbarNbELector.Value = progresValue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        public void RefreshALl()
        {
            
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userMenu_Click(object sender, EventArgs e)
        {

          
        }

        private void AjouterPesonne_Click(object sender, EventArgs e)
        {
          AddElector addElector = new AddElector();
            addElector.Show();
        }
        //recuperation des image
        public void RetriveImage()
        {
            using( var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var cmd= new SqlCommand())
                {     cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM ELECTEUR";
                  var reader=cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] img = (byte[])reader["PHOTO"];
                        MemoryStream ms = new MemoryStream(img);
                      //electorPicture.Image=Image.FromStream(ms);
                    }
                }
            }

        }
        public void refreshParticipant()
        {
          
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
                      //  .Image = Image.FromStream(ms);
                    }
                }
            }

        }
        public void refreshgrid()
        {
  
        
            // guna2DataGridView1.Columns.Add(Action);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            refreshParticipant();
        }



        private void userMenu_ParentChanged(object sender, EventArgs e)
        {


        }
        public void countParcipant()
        {
            try
            {
                string RequeteSelection = "SELECT count(ID_PARTICIPANT) FROM PARTICIPANT";
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(RequeteSelection, con);
                var count = cmd.ExecuteScalar();

              ParticipantTxtpro.Text = count.ToString();
                con.Close();

                int progresValue = int.Parse(ParticipantTxtpro.Text);
              progressParicipant.Value = progresValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userMenu_Selected(object sender, TabControlEventArgs e)
        {
            countParcipant();

            try
            {
                string RequeteSelection = "SELECT count(ID_ELECTEUR) FROM ELECTEUR";
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(RequeteSelection, con);
                var count = cmd.ExecuteScalar();

                NbElector.Text = count.ToString();
                con.Close();

                int progresValue = int.Parse(NbElector.Text);
                progressbarNbELector.Value = progresValue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddParticpant_Click(object sender, EventArgs e)
        {
            AddParticipant addParticipant = new AddParticipant();
            addParticipant.Show();
        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        //datagrid pour les information du paricipants 

        private void datagridParticipant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void RefreshParticipant_Click(object sender, EventArgs e)
        {
        }

        private void datagridParticipant_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    AddParticipant addParticipant = new AddParticipant();
                    addParticipant.idtxt.Visible = true;
                    addParticipant.titleParticipant.Text = "editer ou supprimer ce participant ?";
                    addParticipant.idtxt.Text = datagridParticipant.SelectedRows[0].Cells[0].Value.ToString();
                    addParticipant.nomtxt.Text = datagridParticipant.SelectedRows[0].Cells[1].Value.ToString();
                    addParticipant.prenomtxt.Text = datagridParticipant.SelectedRows[0].Cells[2].Value.ToString();
                    addParticipant.slogan.Text = datagridParticipant.SelectedRows[0].Cells[5].Value.ToString();

                    DataGridViewImageColumn image2 = new DataGridViewImageColumn();

                    image2 = (DataGridViewImageColumn)datagridParticipant.Columns[4];
                    image2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    MemoryStream memoryStream = new MemoryStream((byte[])datagridParticipant.SelectedRows[0].Cells[4].Value);

                    addParticipant.pictureBoxParticipant.Image = Image.FromStream(memoryStream);
                    addParticipant.SaveParticipant.Visible = false;
                    addParticipant.edite.Visible = true;
                    addParticipant.delete.Visible = true;




                    addParticipant.Show();
                }
            }catch (Exception ex)
            {

                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = ex.Message;
                errorMessage.ShowDialog();
            }
         

        }

        private void DataGridViewElector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {

                AddElector addElector = new AddElector();
                addElector.edite.Visible=true;
                addElector.idtxt.Visible = false;
                addElector.SaveElector.Visible = false;
                addElector.delete.Visible=true;
                addElector.ElectorPicture.Text = "Editer ou supprimer  ce participant";
                addElector.idtxt.Text = DataGridViewElector.SelectedRows[0].Cells[0].Value.ToString();
                addElector.nomTxt.Text = DataGridViewElector.SelectedRows[0].Cells[1].Value.ToString();
                addElector.prenomtxt.Text = DataGridViewElector.SelectedRows[0].Cells[2].Value.ToString();
                addElector.matriculetxt.Text = DataGridViewElector.SelectedRows[0].Cells[3].Value.ToString();

                DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                DataGridViewImageColumn image2 = new DataGridViewImageColumn();

                pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
                image2 = (DataGridViewImageColumn)DataGridViewElector.Columns[4];
                image2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                MemoryStream memoryStream = new MemoryStream((byte[])DataGridViewElector.SelectedRows[0].Cells[4].Value);

                addElector.pictureElector.Image = Image.FromStream(memoryStream);
                addElector.Show();
            }
        }



        //public void refeshGrid()
        //{
        //    string query = "SELECT * FROM ELECTEUR";
        //    SqlDataAdapter adapter = new SqlDataAdapter(query,ConnectionString);
        //    DataSet ds = new System.Data.DataSet();
        //    adapter.Fill(ds,"ELECTEUR") ;
        //    DataGridElecteur.DataSource = ds.Tables[0];
        //}


    }
}
