namespace CapaPresentacion
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            txtdocumento = new TextBox();
            txtclave = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btningresar = new FontAwesome.Sharp.IconButton();
            btncancelar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label5 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtdocumento
            // 
            txtdocumento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtdocumento.Location = new Point(54, 104);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.Size = new Size(195, 23);
            txtdocumento.TabIndex = 3;
            // 
            // txtclave
            // 
            txtclave.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtclave.Location = new Point(54, 171);
            txtclave.Name = "txtclave";
            txtclave.PasswordChar = '*';
            txtclave.Size = new Size(195, 23);
            txtclave.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(1, 28, 83);
            label3.ForeColor = Color.White;
            label3.Location = new Point(54, 86);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 5;
            label3.Text = "Nro Documento";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(1, 28, 83);
            label4.ForeColor = Color.White;
            label4.Location = new Point(54, 153);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 6;
            label4.Text = "Contraseña";
            // 
            // btningresar
            // 
            btningresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btningresar.BackColor = Color.FromArgb(1, 28, 83);
            btningresar.Cursor = Cursors.Hand;
            btningresar.FlatAppearance.BorderColor = Color.Silver;
            btningresar.FlatStyle = FlatStyle.Flat;
            btningresar.ForeColor = Color.White;
            btningresar.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btningresar.IconColor = Color.White;
            btningresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btningresar.IconSize = 21;
            btningresar.Location = new Point(75, 233);
            btningresar.Name = "btningresar";
            btningresar.Size = new Size(126, 45);
            btningresar.TabIndex = 7;
            btningresar.Text = "Ingresar";
            btningresar.TextAlign = ContentAlignment.MiddleRight;
            btningresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btningresar.UseVisualStyleBackColor = false;
            btningresar.Click += btningresar_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = Color.Transparent;
            btncancelar.BackgroundImage = (Image)resources.GetObject("btncancelar.BackgroundImage");
            btncancelar.BackgroundImageLayout = ImageLayout.Center;
            btncancelar.Cursor = Cursors.Hand;
            btncancelar.Dock = DockStyle.Right;
            btncancelar.FlatAppearance.BorderColor = Color.Black;
            btncancelar.FlatAppearance.BorderSize = 0;
            btncancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(1, 33, 99);
            btncancelar.FlatStyle = FlatStyle.Flat;
            btncancelar.ForeColor = Color.White;
            btncancelar.IconChar = FontAwesome.Sharp.IconChar.X;
            btncancelar.IconColor = Color.Transparent;
            btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btncancelar.IconSize = 16;
            btncancelar.ImageAlign = ContentAlignment.BottomCenter;
            btncancelar.Location = new Point(907, 0);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(34, 34);
            btncancelar.TabIndex = 8;
            btncancelar.TextAlign = ContentAlignment.MiddleRight;
            btncancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += iconButton2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 28, 83);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btncancelar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 34);
            panel1.TabIndex = 9;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 6);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 1;
            label5.Text = "JR Software ®";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 28, 83);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtdocumento);
            panel2.Controls.Add(btningresar);
            panel2.Controls.Add(txtclave);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(58, 107);
            panel2.Name = "panel2";
            panel2.Size = new Size(276, 323);
            panel2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(80, 16);
            label1.Name = "label1";
            label1.Size = new Size(121, 30);
            label1.TabIndex = 10;
            label1.Text = "Bienvenido";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Left;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(23, 169);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(941, 536);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(941, 536);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtdocumento;
        private TextBox txtclave;
        private Label label3;
        private Label label4;
        private FontAwesome.Sharp.IconButton btningresar;
        private FontAwesome.Sharp.IconButton btncancelar;
        private Panel panel1;
        private Label label5;
        private Panel panel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox3;
    }
}