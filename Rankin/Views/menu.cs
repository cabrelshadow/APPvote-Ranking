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
using Rankin.Views;


namespace Rankin.Views
{
    public partial class menu : MaterialForm
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath("RankinBd.mdf") + ";Integrated Security=True;Connect Timeout=30";
        SqlConnection con = null;
        public menu()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Blue900, Primary.BlueGrey500, Accent.Blue700, TextShade.WHITE);
            AfficherElector();
        }
        public void AfficherElector()
        {


            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection = "SELECT * FROM ELECTEUR";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            DataGridViewElector.DataSource = dataSet.Tables[0];
            var imageColumn = (DataGridViewImageColumn)DataGridViewElector.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }


        public void AfficherParticipant()
        {


            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection = "SELECT * FROM PARTICIPANT";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            DataTable dt = new DataTable();
         
            datagridParticipant.DataSource = dataSet.Tables[0];
            var imageColumn = (DataGridViewImageColumn)datagridParticipant.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
         
        }
        private void menu_Load(object sender, EventArgs e)
           {
            // TODO: cette ligne de code charge les données dans la table 'esayVoteDataSetPARTICIPANT.PARTICIPANT'. Vous pouvez la déplacer ou la supprimer selon les besoins.
           
            // TODO: cette ligne de code charge les données dans la table 'esayVoteDataSet.PARTICIPANT'. Vous pouvez la déplacer ou la supprimer selon les besoins.

            AfficherElector();
            AfficherParticipant();
            countParcipant();
            CountVois();
            Pronostique();
            ResultVote();
            ShowFloypannelResult();
            //refeshGrid();


            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection1 = "SELECT NOM,NOMBREVOIE FROM PARTICIPANT";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection1, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            chartParticipant.DataSource = dataSet;
            chartParticipant.Series["NOMBREVOIE"].XValueMember = "NOM";
            chartParticipant.Series["NOMBREVOIE"].YValueMembers = "NOMBREVOIE";
            chartParticipant.Titles.Add("vois des participant");


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
            AfficherElector();
            AfficherParticipant();
        }
        public void ResultVote()
        {

            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection1 = "SELECT NOM,NOMBREVOIE FROM PARTICIPANT ORDER BY NOMBREVOIE DESC";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection1, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            chartResult.DataSource = dataSet;
            chartResult.Series["RESULTAT"].XValueMember = "NOM";
            chartResult.Series["RESULTAT"].YValueMembers = "NOMBREVOIE";
            chartResult.Titles.Add("Resultat des votes");

        }

        public void ShowFloypannelResult()
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();


                string sql = "select * from PARTICIPANT ORDER BY NOMBREVOIE DESC ";
                SqlCommand s = new SqlCommand(sql, con);
                SqlDataReader r = s.ExecuteReader();

                while (r.Read())
                {
                    ResultVote VoteResult = new ResultVote();
                 
                    VoteResult.NomR.Text = r[1].ToString();
                   
                    VoteResult.sloganResult.Text = r[6].ToString();
                    VoteResult.progressBarResult.Value = int.Parse(r[5].ToString());
                    VoteResult.numR.Text = r[5].ToString();
                    VoteResult.SexeR.Text = r[7].ToString();
                    VoteResult.AgeResult.Text = r[3].ToString();
                 

                    byte[] img = (byte[])r["PHOTO"];
                    MemoryStream ms = new MemoryStream(img);
                    VoteResult.pictureBoxresult.Image = Image.FromStream(ms);

                    if (ResultFloyLayoutpanel.Controls.Count < 0)
                    {
                        ResultFloyLayoutpanel.Controls.Clear();
                    }
                    else
                    {
                        ResultFloyLayoutpanel.Controls.Add(VoteResult);


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



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
            AfficherElector();
        }



        private void userMenu_ParentChanged(object sender, EventArgs e)
        {


        }
        public void CountVois()
        {
            try
            {
                string RequeteSelection = "SELECT SUM(NOMBREVOIE) FROM PARTICIPANT";
                con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(RequeteSelection, con);
                var count = cmd.ExecuteScalar();

                voietxt.Text = count.ToString();
                con.Close();

                int progresValue = int.Parse(voietxt.Text);
                progressvois.Value = progresValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection = "SELECT * FROM PARTICIPANT";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            DataTable dt = new DataTable();

            datagridParticipant.DataSource = dataSet.Tables[0];
            var imageColumn = (DataGridViewImageColumn)datagridParticipant.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void datagridParticipant_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              
                    AddParticipant addParticipant = new AddParticipant();
                    addParticipant.idtxt.Visible = false;
                    addParticipant.titleParticipant.Text = "editer ou supprimer ce participant ?";
                    addParticipant.idtxt.Text = datagridParticipant.SelectedRows[0].Cells[0].Value.ToString();
                    addParticipant.nomtxt.Text = datagridParticipant.SelectedRows[0].Cells[1].Value.ToString();
                    addParticipant.prenomtxt.Text = datagridParticipant.SelectedRows[0].Cells[2].Value.ToString();
                    addParticipant.slogan.Text = datagridParticipant.SelectedRows[0].Cells[6].Value.ToString();

                    DataGridViewImageColumn image2 = new DataGridViewImageColumn();

                    image2 = (DataGridViewImageColumn)datagridParticipant.Columns[4];
                    image2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    MemoryStream memoryStream = new MemoryStream((byte[])datagridParticipant.SelectedRows[0].Cells[4].Value);

                    addParticipant.pictureBoxParticipant.Image = Image.FromStream(memoryStream);
                    addParticipant.SaveParticipant.Visible = false;
                    addParticipant.edite.Visible = true;
                    addParticipant.delete.Visible = true;




                    addParticipant.ShowDialog();
              
            }catch (Exception ex)
            {

                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessageLabel.Text = ex.Message;
                errorMessage.ShowDialog();
            }
         

        }

        private void DataGridViewElector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

                AddElector addElector = new AddElector();
                addElector.edite.Visible=true;
                addElector.idtxt.Visible = false;
                addElector.SaveElector.Visible = false;
                addElector.delete.Visible=true;
                addElector.ElectorPicture.Text = "Editer ou supprimer  cet electeur";
                addElector.idtxt.Text = DataGridViewElector.SelectedRows[0].Cells[0].Value.ToString();
                addElector.nomTxt.Text = DataGridViewElector.SelectedRows[0].Cells[1].Value.ToString();
                addElector.prenomtxt.Text = DataGridViewElector.SelectedRows[0].Cells[2].Value.ToString();
                addElector.matriculetxt.Text = DataGridViewElector.SelectedRows[0].Cells[3].Value.ToString();
            addElector.generate.Visible = false;
                DataGridViewImageColumn pic1 = new DataGridViewImageColumn();
                DataGridViewImageColumn image2 = new DataGridViewImageColumn();

                pic1.ImageLayout = DataGridViewImageCellLayout.Stretch;
                image2 = (DataGridViewImageColumn)DataGridViewElector.Columns[4];
                image2.ImageLayout = DataGridViewImageCellLayout.Stretch;
                MemoryStream memoryStream = new MemoryStream((byte[])DataGridViewElector.SelectedRows[0].Cells[4].Value);

                addElector.pictureElector.Image = Image.FromStream(memoryStream);
                addElector.ShowDialog();
            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string RequeteSelection = "SELECT * FROM ELECTEUR";
            SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
            SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            DataGridViewElector.DataSource = dataSet.Tables[0];
            var imageColumn = (DataGridViewImageColumn)DataGridViewElector.Columns[4];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        public void Pronostique() {
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();


                string sql = "select * from PARTICIPANT  WHERE AGE >20 ORDER BY AGE DESC";
                SqlCommand s = new SqlCommand(sql, con);
                SqlDataReader r = s.ExecuteReader();

                while (r.Read())
                {
                    Pagepronostique pagepronostique = new Pagepronostique();


                    pagepronostique.Nom.Text = r[1].ToString();

                    pagepronostique.sloganPronostique.Text = r[6].ToString();
                    //  pagepronostique.voteProgress.Value = int.Parse(r[5].ToString());

                    pagepronostique.num.Text = r[3].ToString();
                    pagepronostique.progressBarPronostique.Value = int.Parse(r[3].ToString());
                    pagepronostique.Sexepro.Text = r[7].ToString();



                    byte[] img = (byte[])r["PHOTO"];
                    MemoryStream ms = new MemoryStream(img);
                    pagepronostique.pictureBox1.Image = Image.FromStream(ms);

                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(pagepronostique);


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

        private void PronostiquePage_Click(object sender, EventArgs e)
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
                  Pagepronostique pagepronostique = new Pagepronostique();

                    
                    pagepronostique.Nom.Text = r[1].ToString();
                   
                    pagepronostique.sloganPronostique.Text = r[6].ToString();
                  //  pagepronostique.voteProgress.Value = int.Parse(r[5].ToString());
                   
                    pagepronostique.progressBarPronostique.Value = int.Parse(r[3].ToString());
                    pagepronostique.Sexepro.Text = r[7].ToString();
                   
              

                    byte[] img = (byte[])r["PHOTO"];
                    MemoryStream ms = new MemoryStream(img);
                    pagepronostique.pictureBox1.Image = Image.FromStream(ms);

                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(pagepronostique);


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

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.ShowDialog();
        }

        private void Logout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void RefreshPronostique_Click(object sender, EventArgs e)
        {
            Pronostique();
        }

        private void RefreshWiner_Click(object sender, EventArgs e)
        {
            ShowFloypannelResult();
        }

        private void rechecheElecteur_TextChanged(object sender, EventArgs e)
        {
            if (rechecheElecteur.Text != "")
            {
              

                con = new SqlConnection(ConnectionString);
                con.Open();
                string RequeteSelection = "SELECT * FROM ELECTEUR where  NOM Like '" + rechecheElecteur.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
                SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
                var dataSet = new DataSet();
                sda.Fill(dataSet);
                DataGridViewElector.DataSource = dataSet.Tables[0];
            }
            else
            {
                AfficherElector();
            }


        }

        private void recherchepaticipant_TextChanged(object sender, EventArgs e)
        {
            if (recherchepaticipant.Text != "")
            {


                con = new SqlConnection(ConnectionString);
                con.Open();
                string RequeteSelection = "SELECT * FROM PARTICIPANT where  NOM Like '" + recherchepaticipant.Text + "%'";
                SqlDataAdapter sda = new SqlDataAdapter(RequeteSelection, con);
                SqlCommandBuilder sqlBuild = new SqlCommandBuilder(sda);
                var dataSet = new DataSet();
                sda.Fill(dataSet);
                datagridParticipant.DataSource = dataSet.Tables[0];
            }
            else
            {
                AfficherParticipant();
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
