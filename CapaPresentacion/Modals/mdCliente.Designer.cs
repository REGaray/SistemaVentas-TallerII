﻿namespace CapaPresentacion.Modals
{
    partial class mdCliente
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            dgvdata = new Guna.UI2.WinForms.Guna2DataGridView();
            Documento = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            txtbusqueda = new Guna.UI2.WinForms.Guna2TextBox();
            cbobusqueda = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnlimpiarbuscador = new Guna.UI2.WinForms.Guna2Button();
            btnbuscar = new Guna.UI2.WinForms.Guna2Button();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            guna2CustomGradientPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvdata.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(1, 13, 44);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.ColumnHeadersHeight = 22;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { Documento, NombreCompleto });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 195, 202);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvdata.DefaultCellStyle = dataGridViewCellStyle3;
            dgvdata.Dock = DockStyle.Fill;
            dgvdata.GridColor = Color.FromArgb(231, 229, 255);
            dgvdata.Location = new Point(0, 0);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvdata.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvdata.RowHeadersVisible = false;
            dgvdata.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 252);
            dgvdata.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(33, 40, 70);
            dgvdata.RowTemplate.Height = 28;
            dgvdata.Size = new Size(800, 364);
            dgvdata.TabIndex = 41;
            dgvdata.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvdata.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvdata.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvdata.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvdata.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvdata.ThemeStyle.BackColor = Color.White;
            dgvdata.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvdata.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvdata.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvdata.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvdata.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvdata.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvdata.ThemeStyle.HeaderStyle.Height = 22;
            dgvdata.ThemeStyle.ReadOnly = true;
            dgvdata.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvdata.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvdata.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvdata.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvdata.ThemeStyle.RowsStyle.Height = 28;
            dgvdata.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvdata.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvdata.CellDoubleClick += dgvdata_CellDoubleClick;
            // 
            // Documento
            // 
            Documento.FillWeight = 120.950859F;
            Documento.HeaderText = "Nro Documento";
            Documento.Name = "Documento";
            Documento.ReadOnly = true;
            // 
            // NombreCompleto
            // 
            NombreCompleto.FillWeight = 96.9196548F;
            NombreCompleto.HeaderText = "Nombre Completo";
            NombreCompleto.Name = "NombreCompleto";
            NombreCompleto.ReadOnly = true;
            // 
            // txtbusqueda
            // 
            txtbusqueda.BackColor = Color.White;
            txtbusqueda.BorderRadius = 13;
            txtbusqueda.CustomizableEdges = customizableEdges1;
            txtbusqueda.DefaultText = "";
            txtbusqueda.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbusqueda.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbusqueda.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbusqueda.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbusqueda.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbusqueda.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtbusqueda.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbusqueda.Location = new Point(300, 29);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PasswordChar = '\0';
            txtbusqueda.PlaceholderText = "";
            txtbusqueda.SelectedText = "";
            txtbusqueda.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtbusqueda.Size = new Size(251, 36);
            txtbusqueda.TabIndex = 42;
            // 
            // cbobusqueda
            // 
            cbobusqueda.BackColor = Color.White;
            cbobusqueda.BorderRadius = 13;
            cbobusqueda.CustomizableEdges = customizableEdges3;
            cbobusqueda.DrawMode = DrawMode.OwnerDrawFixed;
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FocusedColor = Color.FromArgb(94, 148, 255);
            cbobusqueda.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbobusqueda.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbobusqueda.ForeColor = Color.FromArgb(68, 88, 112);
            cbobusqueda.ItemHeight = 30;
            cbobusqueda.Location = new Point(146, 29);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cbobusqueda.Size = new Size(148, 36);
            cbobusqueda.TabIndex = 47;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.White;
            guna2HtmlLabel7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel7.Location = new Point(74, 38);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(62, 17);
            guna2HtmlLabel7.TabIndex = 44;
            guna2HtmlLabel7.Text = "Buscar por:";
            // 
            // btnlimpiarbuscador
            // 
            btnlimpiarbuscador.BackColor = Color.White;
            btnlimpiarbuscador.BorderRadius = 18;
            btnlimpiarbuscador.Cursor = Cursors.Hand;
            btnlimpiarbuscador.CustomizableEdges = customizableEdges5;
            btnlimpiarbuscador.DisabledState.BorderColor = Color.DarkGray;
            btnlimpiarbuscador.DisabledState.CustomBorderColor = Color.DarkGray;
            btnlimpiarbuscador.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnlimpiarbuscador.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnlimpiarbuscador.FillColor = Color.FromArgb(217, 83, 79);
            btnlimpiarbuscador.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnlimpiarbuscador.ForeColor = Color.White;
            btnlimpiarbuscador.Image = Properties.Resources.broom_32;
            btnlimpiarbuscador.Location = new Point(680, 29);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnlimpiarbuscador.Size = new Size(38, 36);
            btnlimpiarbuscador.TabIndex = 45;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.White;
            btnbuscar.BorderRadius = 18;
            btnbuscar.Cursor = Cursors.Hand;
            btnbuscar.CustomizableEdges = customizableEdges7;
            btnbuscar.DisabledState.BorderColor = Color.DarkGray;
            btnbuscar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnbuscar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnbuscar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnbuscar.FillColor = Color.FromArgb(33, 43, 70);
            btnbuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnbuscar.ForeColor = Color.White;
            btnbuscar.Image = Properties.Resources.search_32_white;
            btnbuscar.Location = new Point(592, 29);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnbuscar.Size = new Size(38, 36);
            btnbuscar.TabIndex = 46;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(dgvdata);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges9;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.Location = new Point(0, 86);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2CustomGradientPanel1.Size = new Size(800, 364);
            guna2CustomGradientPanel1.TabIndex = 51;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtbusqueda);
            panel1.Controls.Add(cbobusqueda);
            panel1.Controls.Add(guna2HtmlLabel7);
            panel1.Controls.Add(btnlimpiarbuscador);
            panel1.Controls.Add(btnbuscar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 86);
            panel1.TabIndex = 50;
            // 
            // mdCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(panel1);
            Name = "mdCliente";
            Text = "mdCliente";
            Load += mdCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            guna2CustomGradientPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvdata;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn NombreCompleto;
        private Guna.UI2.WinForms.Guna2TextBox txtbusqueda;
        private Guna.UI2.WinForms.Guna2ComboBox cbobusqueda;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btnlimpiarbuscador;
        private Guna.UI2.WinForms.Guna2Button btnbuscar;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Panel panel1;
    }
}