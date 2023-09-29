namespace CapaPresentacion
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            panel1 = new Panel();
            lblEmpresa = new Label();
            btnReportes = new FontAwesome.Sharp.IconButton();
            btnConfiguracion = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            btnProveedores = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            btnCompras = new FontAwesome.Sharp.IconButton();
            panelReportes = new Panel();
            btnReportes2 = new FontAwesome.Sharp.IconButton();
            btnReportes1 = new FontAwesome.Sharp.IconButton();
            panelCompras = new Panel();
            btnCompras2 = new FontAwesome.Sharp.IconButton();
            btnCompras1 = new FontAwesome.Sharp.IconButton();
            panelVentas = new Panel();
            btnVentas2 = new FontAwesome.Sharp.IconButton();
            btnVentas1 = new FontAwesome.Sharp.IconButton();
            panelConfiguracion = new Panel();
            btnNegocio = new FontAwesome.Sharp.IconButton();
            btnProducto = new FontAwesome.Sharp.IconButton();
            btnCategoria = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            btncancelar = new FontAwesome.Sharp.IconButton();
            lblUsuarioActivo = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panelReportes.SuspendLayout();
            panelCompras.SuspendLayout();
            panelVentas.SuspendLayout();
            panelConfiguracion.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(1, 13, 44);
            panel1.Controls.Add(lblUsuarioActivo);
            panel1.Controls.Add(lblEmpresa);
            panel1.Controls.Add(btnReportes);
            panel1.Controls.Add(btnConfiguracion);
            panel1.Controls.Add(btnUsuarios);
            panel1.Controls.Add(btnProveedores);
            panel1.Controls.Add(btnVentas);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(btnCompras);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 633);
            panel1.TabIndex = 0;
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmpresa.ForeColor = Color.White;
            lblEmpresa.Location = new Point(12, 6);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(110, 20);
            lblEmpresa.TabIndex = 11;
            lblEmpresa.Text = "JR Software ®";
            // 
            // btnReportes
            // 
            btnReportes.AutoEllipsis = true;
            btnReportes.BackColor = Color.FromArgb(15, 49, 120);
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReportes.ForeColor = Color.White;
            btnReportes.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            btnReportes.IconColor = Color.White;
            btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes.IconSize = 30;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(12, 433);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(10, 0, 0, 0);
            btnReportes.Size = new Size(203, 47);
            btnReportes.TabIndex = 8;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseMnemonic = false;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.AutoEllipsis = true;
            btnConfiguracion.BackColor = Color.FromArgb(15, 49, 120);
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfiguracion.ForeColor = Color.White;
            btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnConfiguracion.IconColor = Color.White;
            btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfiguracion.IconSize = 30;
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.Location = new Point(12, 168);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracion.Size = new Size(203, 47);
            btnConfiguracion.TabIndex = 3;
            btnConfiguracion.Text = "Configuración";
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = false;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.AutoEllipsis = true;
            btnUsuarios.BackColor = Color.FromArgb(15, 49, 120);
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnUsuarios.IconColor = Color.White;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.IconSize = 30;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(12, 115);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnUsuarios.Size = new Size(203, 47);
            btnUsuarios.TabIndex = 2;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            // 
            // btnProveedores
            // 
            btnProveedores.AutoEllipsis = true;
            btnProveedores.BackColor = Color.FromArgb(15, 49, 120);
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.IconChar = FontAwesome.Sharp.IconChar.TruckRampBox;
            btnProveedores.IconColor = Color.White;
            btnProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProveedores.IconSize = 30;
            btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Location = new Point(12, 380);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(10, 0, 0, 0);
            btnProveedores.Size = new Size(203, 47);
            btnProveedores.TabIndex = 7;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseMnemonic = false;
            btnProveedores.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            btnVentas.AutoEllipsis = true;
            btnVentas.BackColor = Color.FromArgb(15, 49, 120);
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas.ForeColor = Color.White;
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            btnVentas.IconColor = Color.White;
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.IconSize = 30;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(12, 221);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(10, 0, 0, 0);
            btnVentas.Size = new Size(203, 47);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseMnemonic = false;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnClientes
            // 
            btnClientes.AutoEllipsis = true;
            btnClientes.BackColor = Color.FromArgb(15, 49, 120);
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClientes.ForeColor = Color.White;
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            btnClientes.IconColor = Color.White;
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 30;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(12, 327);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(10, 0, 0, 0);
            btnClientes.Size = new Size(203, 47);
            btnClientes.TabIndex = 6;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseMnemonic = false;
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // btnCompras
            // 
            btnCompras.AutoEllipsis = true;
            btnCompras.BackColor = Color.FromArgb(15, 49, 120);
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras.ForeColor = Color.White;
            btnCompras.IconChar = FontAwesome.Sharp.IconChar.Dolly;
            btnCompras.IconColor = Color.White;
            btnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras.IconSize = 30;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(12, 274);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(10, 0, 0, 0);
            btnCompras.Size = new Size(203, 47);
            btnCompras.TabIndex = 5;
            btnCompras.Text = "Compras";
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseMnemonic = false;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // panelReportes
            // 
            panelReportes.BackColor = Color.FromArgb(9, 34, 88);
            panelReportes.Controls.Add(btnReportes2);
            panelReportes.Controls.Add(btnReportes1);
            panelReportes.Location = new Point(724, 409);
            panelReportes.Name = "panelReportes";
            panelReportes.Size = new Size(203, 94);
            panelReportes.TabIndex = 10;
            // 
            // btnReportes2
            // 
            btnReportes2.AutoEllipsis = true;
            btnReportes2.BackColor = Color.Transparent;
            btnReportes2.FlatAppearance.BorderSize = 0;
            btnReportes2.FlatAppearance.MouseOverBackColor = Color.Black;
            btnReportes2.FlatStyle = FlatStyle.Flat;
            btnReportes2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReportes2.ForeColor = Color.White;
            btnReportes2.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnReportes2.IconColor = Color.White;
            btnReportes2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes2.IconSize = 30;
            btnReportes2.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes2.Location = new Point(0, 47);
            btnReportes2.Name = "btnReportes2";
            btnReportes2.Padding = new Padding(10, 0, 0, 0);
            btnReportes2.Size = new Size(203, 47);
            btnReportes2.TabIndex = 8;
            btnReportes2.Text = "Opcion2Reportes";
            btnReportes2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes2.UseVisualStyleBackColor = false;
            // 
            // btnReportes1
            // 
            btnReportes1.AutoEllipsis = true;
            btnReportes1.BackColor = Color.Transparent;
            btnReportes1.FlatAppearance.BorderSize = 0;
            btnReportes1.FlatAppearance.MouseOverBackColor = Color.Black;
            btnReportes1.FlatStyle = FlatStyle.Flat;
            btnReportes1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReportes1.ForeColor = Color.White;
            btnReportes1.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnReportes1.IconColor = Color.White;
            btnReportes1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes1.IconSize = 30;
            btnReportes1.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes1.Location = new Point(0, 0);
            btnReportes1.Name = "btnReportes1";
            btnReportes1.Padding = new Padding(10, 0, 0, 0);
            btnReportes1.Size = new Size(203, 47);
            btnReportes1.TabIndex = 7;
            btnReportes1.Text = "Opcion1Reportes";
            btnReportes1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes1.UseVisualStyleBackColor = false;
            btnReportes1.Click += btnReportes1_Click;
            // 
            // panelCompras
            // 
            panelCompras.BackColor = Color.FromArgb(9, 34, 88);
            panelCompras.Controls.Add(btnCompras2);
            panelCompras.Controls.Add(btnCompras1);
            panelCompras.Location = new Point(724, 309);
            panelCompras.Name = "panelCompras";
            panelCompras.Size = new Size(203, 94);
            panelCompras.TabIndex = 9;
            // 
            // btnCompras2
            // 
            btnCompras2.AutoEllipsis = true;
            btnCompras2.BackColor = Color.Transparent;
            btnCompras2.FlatAppearance.BorderSize = 0;
            btnCompras2.FlatAppearance.MouseOverBackColor = Color.Black;
            btnCompras2.FlatStyle = FlatStyle.Flat;
            btnCompras2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras2.ForeColor = Color.White;
            btnCompras2.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnCompras2.IconColor = Color.White;
            btnCompras2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras2.IconSize = 30;
            btnCompras2.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras2.Location = new Point(0, 47);
            btnCompras2.Name = "btnCompras2";
            btnCompras2.Padding = new Padding(10, 0, 0, 0);
            btnCompras2.Size = new Size(203, 47);
            btnCompras2.TabIndex = 8;
            btnCompras2.Text = "Opcion2Compras";
            btnCompras2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras2.UseVisualStyleBackColor = false;
            // 
            // btnCompras1
            // 
            btnCompras1.AutoEllipsis = true;
            btnCompras1.BackColor = Color.Transparent;
            btnCompras1.FlatAppearance.BorderSize = 0;
            btnCompras1.FlatAppearance.MouseOverBackColor = Color.Black;
            btnCompras1.FlatStyle = FlatStyle.Flat;
            btnCompras1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras1.ForeColor = Color.White;
            btnCompras1.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnCompras1.IconColor = Color.White;
            btnCompras1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras1.IconSize = 30;
            btnCompras1.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras1.Location = new Point(0, 0);
            btnCompras1.Name = "btnCompras1";
            btnCompras1.Padding = new Padding(10, 0, 0, 0);
            btnCompras1.Size = new Size(203, 47);
            btnCompras1.TabIndex = 7;
            btnCompras1.Text = "Opcion1Compras";
            btnCompras1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras1.UseVisualStyleBackColor = false;
            // 
            // panelVentas
            // 
            panelVentas.BackColor = Color.FromArgb(9, 34, 88);
            panelVentas.Controls.Add(btnVentas2);
            panelVentas.Controls.Add(btnVentas1);
            panelVentas.Location = new Point(724, 209);
            panelVentas.Name = "panelVentas";
            panelVentas.Size = new Size(203, 94);
            panelVentas.TabIndex = 3;
            // 
            // btnVentas2
            // 
            btnVentas2.AutoEllipsis = true;
            btnVentas2.BackColor = Color.Transparent;
            btnVentas2.FlatAppearance.BorderSize = 0;
            btnVentas2.FlatAppearance.MouseOverBackColor = Color.Black;
            btnVentas2.FlatStyle = FlatStyle.Flat;
            btnVentas2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas2.ForeColor = Color.White;
            btnVentas2.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnVentas2.IconColor = Color.White;
            btnVentas2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas2.IconSize = 30;
            btnVentas2.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas2.Location = new Point(0, 47);
            btnVentas2.Name = "btnVentas2";
            btnVentas2.Padding = new Padding(10, 0, 0, 0);
            btnVentas2.Size = new Size(203, 47);
            btnVentas2.TabIndex = 8;
            btnVentas2.Text = "Opcion2Ventas";
            btnVentas2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas2.UseVisualStyleBackColor = false;
            // 
            // btnVentas1
            // 
            btnVentas1.AutoEllipsis = true;
            btnVentas1.BackColor = Color.Transparent;
            btnVentas1.FlatAppearance.BorderSize = 0;
            btnVentas1.FlatAppearance.MouseOverBackColor = Color.Black;
            btnVentas1.FlatStyle = FlatStyle.Flat;
            btnVentas1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas1.ForeColor = Color.White;
            btnVentas1.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnVentas1.IconColor = Color.White;
            btnVentas1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas1.IconSize = 30;
            btnVentas1.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas1.Location = new Point(0, 0);
            btnVentas1.Name = "btnVentas1";
            btnVentas1.Padding = new Padding(10, 0, 0, 0);
            btnVentas1.Size = new Size(203, 47);
            btnVentas1.TabIndex = 7;
            btnVentas1.Text = "Opcion1Ventas";
            btnVentas1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas1.UseVisualStyleBackColor = false;
            btnVentas1.Click += iconButton1_Click_1;
            // 
            // panelConfiguracion
            // 
            panelConfiguracion.BackColor = Color.FromArgb(9, 34, 88);
            panelConfiguracion.Controls.Add(btnNegocio);
            panelConfiguracion.Controls.Add(btnProducto);
            panelConfiguracion.Controls.Add(btnCategoria);
            panelConfiguracion.Location = new Point(724, 62);
            panelConfiguracion.Name = "panelConfiguracion";
            panelConfiguracion.Size = new Size(203, 141);
            panelConfiguracion.TabIndex = 2;
            // 
            // btnNegocio
            // 
            btnNegocio.AutoEllipsis = true;
            btnNegocio.BackColor = Color.FromArgb(9, 34, 88);
            btnNegocio.FlatAppearance.BorderSize = 0;
            btnNegocio.FlatAppearance.MouseOverBackColor = Color.Black;
            btnNegocio.FlatStyle = FlatStyle.Flat;
            btnNegocio.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNegocio.ForeColor = Color.White;
            btnNegocio.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnNegocio.IconColor = Color.White;
            btnNegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNegocio.IconSize = 30;
            btnNegocio.ImageAlign = ContentAlignment.MiddleLeft;
            btnNegocio.Location = new Point(0, 94);
            btnNegocio.Name = "btnNegocio";
            btnNegocio.Padding = new Padding(10, 0, 0, 0);
            btnNegocio.Size = new Size(203, 47);
            btnNegocio.TabIndex = 8;
            btnNegocio.Text = "Negocio";
            btnNegocio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNegocio.UseVisualStyleBackColor = false;
            // 
            // btnProducto
            // 
            btnProducto.Anchor = AnchorStyles.None;
            btnProducto.AutoEllipsis = true;
            btnProducto.BackColor = Color.FromArgb(9, 34, 88);
            btnProducto.FlatAppearance.BorderSize = 0;
            btnProducto.FlatAppearance.MouseOverBackColor = Color.Black;
            btnProducto.FlatStyle = FlatStyle.Flat;
            btnProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnProducto.ForeColor = Color.White;
            btnProducto.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnProducto.IconColor = Color.White;
            btnProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProducto.IconSize = 30;
            btnProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducto.Location = new Point(0, 47);
            btnProducto.Name = "btnProducto";
            btnProducto.Padding = new Padding(10, 0, 0, 0);
            btnProducto.Size = new Size(203, 47);
            btnProducto.TabIndex = 7;
            btnProducto.Text = "Producto";
            btnProducto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProducto.UseVisualStyleBackColor = false;
            // 
            // btnCategoria
            // 
            btnCategoria.Anchor = AnchorStyles.None;
            btnCategoria.AutoEllipsis = true;
            btnCategoria.BackColor = Color.FromArgb(9, 34, 88);
            btnCategoria.FlatAppearance.BorderSize = 0;
            btnCategoria.FlatAppearance.MouseOverBackColor = Color.Black;
            btnCategoria.FlatStyle = FlatStyle.Flat;
            btnCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCategoria.ForeColor = Color.White;
            btnCategoria.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnCategoria.IconColor = Color.White;
            btnCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategoria.IconSize = 30;
            btnCategoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategoria.Location = new Point(0, 0);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Padding = new Padding(10, 0, 0, 0);
            btnCategoria.Size = new Size(203, 47);
            btnCategoria.TabIndex = 6;
            btnCategoria.Text = "Categoría";
            btnCategoria.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategoria.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(1, 13, 44);
            panel2.Controls.Add(btncancelar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(230, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(720, 34);
            panel2.TabIndex = 1;
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
            btncancelar.Location = new Point(686, 0);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(34, 34);
            btncancelar.TabIndex = 12;
            btncancelar.TextAlign = ContentAlignment.MiddleRight;
            btncancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuarioActivo.ForeColor = Color.White;
            lblUsuarioActivo.Location = new Point(12, 26);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(50, 15);
            lblUsuarioActivo.TabIndex = 12;
            lblUsuarioActivo.Text = "Usuario:";
            lblUsuarioActivo.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(788, 609);
            label1.Name = "label1";
            label1.Size = new Size(150, 15);
            label1.TabIndex = 13;
            label1.Text = "Versión 1.0.0 release 011023";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 234, 252);
            ClientSize = new Size(950, 633);
            Controls.Add(label1);
            Controls.Add(panelReportes);
            Controls.Add(panelCompras);
            Controls.Add(panelVentas);
            Controls.Add(panel2);
            Controls.Add(panelConfiguracion);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Principal";
            Text = "Form1";
            Load += Principal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelReportes.ResumeLayout(false);
            panelCompras.ResumeLayout(false);
            panelVentas.ResumeLayout(false);
            panelConfiguracion.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton btnConfiguracion;
        private FontAwesome.Sharp.IconButton btnReportes;
        private FontAwesome.Sharp.IconButton btnProveedores;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnCompras;
        private Panel panelConfiguracion;
        private FontAwesome.Sharp.IconButton btnProducto;
        private FontAwesome.Sharp.IconButton btnCategoria;
        private Panel panelVentas;
        private FontAwesome.Sharp.IconButton btnNegocio;
        private FontAwesome.Sharp.IconButton btnVentas2;
        private FontAwesome.Sharp.IconButton btnVentas1;
        private Panel panelCompras;
        private FontAwesome.Sharp.IconButton btnCompras2;
        private FontAwesome.Sharp.IconButton btnCompras1;
        private Panel panelReportes;
        private FontAwesome.Sharp.IconButton btnReportes2;
        private FontAwesome.Sharp.IconButton btnReportes1;
        private Label lblEmpresa;
        private FontAwesome.Sharp.IconButton btncancelar;
        private Label lblUsuarioActivo;
        private Label label1;
    }
}