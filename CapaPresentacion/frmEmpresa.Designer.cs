namespace CapaPresentacion
{
    partial class frmEmpresa
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            picLogo = new PictureBox();
            btnsubir = new Guna.UI2.WinForms.Guna2Button();
            txtruc = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            groupBox1 = new GroupBox();
            btnguardarcambios = new Guna.UI2.WinForms.Guna2Button();
            txtdireccion = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txtnombre = new Guna.UI2.WinForms.Guna2TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(picLogo);
            panel1.Controls.Add(btnsubir);
            panel1.Controls.Add(txtruc);
            panel1.Controls.Add(guna2HtmlLabel2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(txtdireccion);
            panel1.Controls.Add(guna2HtmlLabel4);
            panel1.Controls.Add(guna2HtmlLabel3);
            panel1.Controls.Add(guna2HtmlLabel5);
            panel1.Controls.Add(txtnombre);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(704, 577);
            panel1.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(17, 39);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(447, 351);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 57;
            picLogo.TabStop = false;
            // 
            // btnsubir
            // 
            btnsubir.BackColor = Color.White;
            btnsubir.Cursor = Cursors.Hand;
            btnsubir.CustomizableEdges = customizableEdges1;
            btnsubir.DisabledState.BorderColor = Color.DarkGray;
            btnsubir.DisabledState.CustomBorderColor = Color.DarkGray;
            btnsubir.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnsubir.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnsubir.FillColor = Color.FromArgb(33, 70, 40);
            btnsubir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnsubir.ForeColor = Color.White;
            btnsubir.Image = Properties.Resources.upload_32;
            btnsubir.Location = new Point(17, 396);
            btnsubir.Name = "btnsubir";
            btnsubir.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnsubir.Size = new Size(126, 36);
            btnsubir.TabIndex = 48;
            btnsubir.Text = "Subir";
            btnsubir.Click += btnsubir_Click;
            // 
            // txtruc
            // 
            txtruc.BackColor = Color.Transparent;
            txtruc.CustomizableEdges = customizableEdges3;
            txtruc.DefaultText = "";
            txtruc.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtruc.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtruc.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtruc.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtruc.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtruc.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtruc.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtruc.Location = new Point(326, 529);
            txtruc.Name = "txtruc";
            txtruc.PasswordChar = '\0';
            txtruc.PlaceholderText = "";
            txtruc.SelectedText = "";
            txtruc.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtruc.Size = new Size(138, 36);
            txtruc.TabIndex = 55;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(326, 506);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(35, 17);
            guna2HtmlLabel2.TabIndex = 54;
            guna2HtmlLabel2.Text = "R.U.C:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnguardarcambios);
            groupBox1.Location = new Point(534, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 77);
            groupBox1.TabIndex = 53;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controles";
            // 
            // btnguardarcambios
            // 
            btnguardarcambios.Cursor = Cursors.Hand;
            btnguardarcambios.CustomizableEdges = customizableEdges5;
            btnguardarcambios.DisabledState.BorderColor = Color.DarkGray;
            btnguardarcambios.DisabledState.CustomBorderColor = Color.DarkGray;
            btnguardarcambios.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnguardarcambios.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnguardarcambios.FillColor = Color.FromArgb(33, 43, 70);
            btnguardarcambios.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnguardarcambios.ForeColor = Color.White;
            btnguardarcambios.Location = new Point(16, 22);
            btnguardarcambios.Name = "btnguardarcambios";
            btnguardarcambios.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnguardarcambios.Size = new Size(126, 36);
            btnguardarcambios.TabIndex = 0;
            btnguardarcambios.Text = "Guardar cambios";
            // 
            // txtdireccion
            // 
            txtdireccion.BackColor = Color.Transparent;
            txtdireccion.CustomizableEdges = customizableEdges7;
            txtdireccion.DefaultText = "";
            txtdireccion.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtdireccion.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtdireccion.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtdireccion.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtdireccion.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtdireccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtdireccion.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtdireccion.Location = new Point(172, 529);
            txtdireccion.Name = "txtdireccion";
            txtdireccion.PasswordChar = '\0';
            txtdireccion.PlaceholderText = "9 de Julio 2102";
            txtdireccion.SelectedText = "";
            txtdireccion.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtdireccion.Size = new Size(138, 36);
            txtdireccion.TabIndex = 52;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Location = new Point(172, 506);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(56, 17);
            guna2HtmlLabel4.TabIndex = 50;
            guna2HtmlLabel4.Text = "Direccion:";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Location = new Point(18, 506);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(98, 17);
            guna2HtmlLabel3.TabIndex = 49;
            guna2HtmlLabel3.Text = "Nombre Negocio:";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Location = new Point(12, 16);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(33, 17);
            guna2HtmlLabel5.TabIndex = 56;
            guna2HtmlLabel5.Text = "Logo:";
            // 
            // txtnombre
            // 
            txtnombre.BackColor = Color.Transparent;
            txtnombre.CustomizableEdges = customizableEdges9;
            txtnombre.DefaultText = "";
            txtnombre.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtnombre.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtnombre.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtnombre.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtnombre.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtnombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtnombre.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtnombre.Location = new Point(15, 529);
            txtnombre.Name = "txtnombre";
            txtnombre.PasswordChar = '\0';
            txtnombre.PlaceholderText = "Nn";
            txtnombre.SelectedText = "";
            txtnombre.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtnombre.Size = new Size(138, 36);
            txtnombre.TabIndex = 51;
            // 
            // frmEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(704, 577);
            Controls.Add(panel1);
            Name = "frmEmpresa";
            Text = "Form1";
            Load += frmEmpresa_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnsubir;
        private Guna.UI2.WinForms.Guna2TextBox txtruc;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2Button btnguardarcambios;
        private Guna.UI2.WinForms.Guna2TextBox txtdireccion;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2TextBox txtnombre;
    }
}