namespace Rankin.Views
{
    partial class AddParticipant
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParticipant));
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.agetxt = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.sexeCb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.closeBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.slogan = new Guna.UI2.WinForms.Guna2TextBox();
            this.prenomtxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.nomtxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.delete = new Guna.UI2.WinForms.Guna2Button();
            this.SaveParticipant = new Guna.UI2.WinForms.Guna2Button();
            this.edite = new Guna.UI2.WinForms.Guna2Button();
            this.idtxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBoxParticipant = new System.Windows.Forms.PictureBox();
            this.titleParticipant = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agetxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.pictureBox2);
            this.materialCard2.Controls.Add(this.pictureBox1);
            this.materialCard2.Controls.Add(this.agetxt);
            this.materialCard2.Controls.Add(this.sexeCb);
            this.materialCard2.Controls.Add(this.closeBtn);
            this.materialCard2.Controls.Add(this.slogan);
            this.materialCard2.Controls.Add(this.prenomtxt);
            this.materialCard2.Controls.Add(this.nomtxt);
            this.materialCard2.Controls.Add(this.delete);
            this.materialCard2.Controls.Add(this.SaveParticipant);
            this.materialCard2.Controls.Add(this.edite);
            this.materialCard2.Controls.Add(this.idtxt);
            this.materialCard2.Controls.Add(this.materialLabel2);
            this.materialCard2.Controls.Add(this.pictureBoxParticipant);
            this.materialCard2.Controls.Add(this.titleParticipant);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(14, 8);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(659, 408);
            this.materialCard2.TabIndex = 2;
            // 
            // agetxt
            // 
            this.agetxt.BackColor = System.Drawing.Color.Transparent;
            this.agetxt.BorderRadius = 4;
            this.agetxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.agetxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.agetxt.Location = new System.Drawing.Point(53, 210);
            this.agetxt.Name = "agetxt";
            this.agetxt.Size = new System.Drawing.Size(200, 36);
            this.agetxt.TabIndex = 10;
            this.agetxt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sexeCb
            // 
            this.sexeCb.BackColor = System.Drawing.Color.Transparent;
            this.sexeCb.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(46)))), ((int)(((byte)(208)))));
            this.sexeCb.BorderRadius = 4;
            this.sexeCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sexeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexeCb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sexeCb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sexeCb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sexeCb.ForeColor = System.Drawing.Color.Black;
            this.sexeCb.ItemHeight = 30;
            this.sexeCb.Items.AddRange(new object[] {
            "homme",
            "femme"});
            this.sexeCb.Location = new System.Drawing.Point(53, 252);
            this.sexeCb.Name = "sexeCb";
            this.sexeCb.Size = new System.Drawing.Size(200, 36);
            this.sexeCb.StartIndex = 1;
            this.sexeCb.TabIndex = 9;
            // 
            // closeBtn
            // 
            this.closeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeBtn.FillColor = System.Drawing.Color.Red;
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(633, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closeBtn.Size = new System.Drawing.Size(15, 15);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Text = "X";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // slogan
            // 
            this.slogan.Animated = true;
            this.slogan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(46)))), ((int)(((byte)(208)))));
            this.slogan.BorderRadius = 4;
            this.slogan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.slogan.DefaultText = "";
            this.slogan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.slogan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.slogan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.slogan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.slogan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.slogan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.slogan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.slogan.Location = new System.Drawing.Point(337, 194);
            this.slogan.Name = "slogan";
            this.slogan.PasswordChar = '\0';
            this.slogan.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.slogan.PlaceholderText = "slogan";
            this.slogan.SelectedText = "";
            this.slogan.Size = new System.Drawing.Size(176, 75);
            this.slogan.TabIndex = 8;
            this.slogan.TextChanged += new System.EventHandler(this.guna2TextBox5_TextChanged);
            // 
            // prenomtxt
            // 
            this.prenomtxt.Animated = true;
            this.prenomtxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(46)))), ((int)(((byte)(208)))));
            this.prenomtxt.BorderRadius = 4;
            this.prenomtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.prenomtxt.DefaultText = "";
            this.prenomtxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.prenomtxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.prenomtxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.prenomtxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.prenomtxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.prenomtxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.prenomtxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.prenomtxt.Location = new System.Drawing.Point(53, 150);
            this.prenomtxt.Name = "prenomtxt";
            this.prenomtxt.PasswordChar = '\0';
            this.prenomtxt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prenomtxt.PlaceholderText = "entrer votre prenom";
            this.prenomtxt.SelectedText = "";
            this.prenomtxt.Size = new System.Drawing.Size(200, 36);
            this.prenomtxt.TabIndex = 8;
            // 
            // nomtxt
            // 
            this.nomtxt.Animated = true;
            this.nomtxt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(46)))), ((int)(((byte)(208)))));
            this.nomtxt.BorderRadius = 4;
            this.nomtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nomtxt.DefaultText = "";
            this.nomtxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nomtxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nomtxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nomtxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nomtxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nomtxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nomtxt.ForeColor = System.Drawing.Color.Black;
            this.nomtxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nomtxt.Location = new System.Drawing.Point(53, 82);
            this.nomtxt.Name = "nomtxt";
            this.nomtxt.PasswordChar = '\0';
            this.nomtxt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nomtxt.PlaceholderText = "entrer votre nom";
            this.nomtxt.SelectedText = "";
            this.nomtxt.Size = new System.Drawing.Size(200, 36);
            this.nomtxt.TabIndex = 8;
            // 
            // delete
            // 
            this.delete.Animated = true;
            this.delete.BorderRadius = 5;
            this.delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.delete.ForeColor = System.Drawing.Color.White;
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Location = new System.Drawing.Point(178, 312);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(97, 36);
            this.delete.TabIndex = 7;
            this.delete.Text = "Supprimer";
            this.delete.Visible = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // SaveParticipant
            // 
            this.SaveParticipant.Animated = true;
            this.SaveParticipant.BorderRadius = 5;
            this.SaveParticipant.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SaveParticipant.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SaveParticipant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SaveParticipant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SaveParticipant.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(72)))), ((int)(((byte)(177)))));
            this.SaveParticipant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SaveParticipant.ForeColor = System.Drawing.Color.White;
            this.SaveParticipant.Image = ((System.Drawing.Image)(resources.GetObject("SaveParticipant.Image")));
            this.SaveParticipant.Location = new System.Drawing.Point(366, 321);
            this.SaveParticipant.Name = "SaveParticipant";
            this.SaveParticipant.Size = new System.Drawing.Size(102, 36);
            this.SaveParticipant.TabIndex = 7;
            this.SaveParticipant.Text = "enregistrer";
            this.SaveParticipant.Click += new System.EventHandler(this.Save_Click);
            // 
            // edite
            // 
            this.edite.Animated = true;
            this.edite.BorderRadius = 5;
            this.edite.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.edite.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.edite.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.edite.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.edite.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(126)))), ((int)(((byte)(51)))));
            this.edite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.edite.ForeColor = System.Drawing.Color.White;
            this.edite.Image = ((System.Drawing.Image)(resources.GetObject("edite.Image")));
            this.edite.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.edite.Location = new System.Drawing.Point(53, 312);
            this.edite.Name = "edite";
            this.edite.Size = new System.Drawing.Size(102, 36);
            this.edite.TabIndex = 7;
            this.edite.Text = "Editer";
            this.edite.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            this.edite.Visible = false;
            this.edite.Click += new System.EventHandler(this.edite_Click);
            // 
            // idtxt
            // 
            this.idtxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.idtxt.DefaultText = "";
            this.idtxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.idtxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.idtxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idtxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.idtxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idtxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.idtxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.idtxt.Location = new System.Drawing.Point(257, 28);
            this.idtxt.Name = "idtxt";
            this.idtxt.PasswordChar = '\0';
            this.idtxt.PlaceholderText = "";
            this.idtxt.SelectedText = "";
            this.idtxt.Size = new System.Drawing.Size(80, 17);
            this.idtxt.TabIndex = 6;
            this.idtxt.Visible = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(255)))));
            this.materialLabel2.Location = new System.Drawing.Point(363, 57);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(120, 19);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Choisi une photo";
            // 
            // pictureBoxParticipant
            // 
            this.pictureBoxParticipant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxParticipant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxParticipant.ErrorImage = null;
            this.pictureBoxParticipant.Location = new System.Drawing.Point(337, 82);
            this.pictureBoxParticipant.Name = "pictureBoxParticipant";
            this.pictureBoxParticipant.Size = new System.Drawing.Size(176, 104);
            this.pictureBoxParticipant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxParticipant.TabIndex = 2;
            this.pictureBoxParticipant.TabStop = false;
            this.pictureBoxParticipant.Click += new System.EventHandler(this.pictureBoxParticipant_Click);
            // 
            // titleParticipant
            // 
            this.titleParticipant.AutoSize = true;
            this.titleParticipant.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleParticipant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(255)))));
            this.titleParticipant.Location = new System.Drawing.Point(208, 0);
            this.titleParticipant.Name = "titleParticipant";
            this.titleParticipant.Size = new System.Drawing.Size(211, 25);
            this.titleParticipant.TabIndex = 0;
            this.titleParticipant.Text = "Ajouter un Participant";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(519, 264);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(75)))), ((int)(((byte)(255)))));
            this.guna2Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(72)))), ((int)(((byte)(177)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 417);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(687, 31);
            this.guna2Panel1.TabIndex = 15;
            // 
            // AddParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(687, 448);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.materialCard2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddParticipant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddParticipant";
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agetxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParticipant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MaterialSkin.Controls.MaterialCard materialCard2;
        private Guna.UI2.WinForms.Guna2CircleButton closeBtn;
        public Guna.UI2.WinForms.Guna2TextBox slogan;
        public Guna.UI2.WinForms.Guna2TextBox prenomtxt;
        public Guna.UI2.WinForms.Guna2TextBox nomtxt;
        public Guna.UI2.WinForms.Guna2Button delete;
        public Guna.UI2.WinForms.Guna2Button SaveParticipant;
        public Guna.UI2.WinForms.Guna2Button edite;
        public Guna.UI2.WinForms.Guna2TextBox idtxt;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public System.Windows.Forms.PictureBox pictureBoxParticipant;
        public System.Windows.Forms.Label titleParticipant;
        public Guna.UI2.WinForms.Guna2ComboBox sexeCb;
        public Guna.UI2.WinForms.Guna2NumericUpDown agetxt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}