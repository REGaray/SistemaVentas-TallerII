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
            menu = new Panel();
            panelSubMenuReportes = new Panel();
            btnreporteV = new FontAwesome.Sharp.IconButton();
            btnReportes2 = new FontAwesome.Sharp.IconButton();
            btnReportes = new FontAwesome.Sharp.IconButton();
            btnProveedores = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            panelSubMenuCompras = new Panel();
            btnCompras2 = new FontAwesome.Sharp.IconButton();
            btnCompras1 = new FontAwesome.Sharp.IconButton();
            btnCompras = new FontAwesome.Sharp.IconButton();
            panelSubMenuVentas = new Panel();
            btnVentas2 = new FontAwesome.Sharp.IconButton();
            btnVentas1 = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            panelSubMenuConfig = new Panel();
            btnEmpresa = new FontAwesome.Sharp.IconButton();
            btnProducto = new FontAwesome.Sharp.IconButton();
            btnCategoria = new FontAwesome.Sharp.IconButton();
            btnConfiguracion = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            panel5 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblUsuarioActivo = new Label();
            lblEmpresa = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            lblusuario = new Label();
            panel2 = new Panel();
            btncancelar = new FontAwesome.Sharp.IconButton();
            contenedor = new Panel();
            menu.SuspendLayout();
            panelSubMenuReportes.SuspendLayout();
            panelSubMenuCompras.SuspendLayout();
            panelSubMenuVentas.SuspendLayout();
            panelSubMenuConfig.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.AutoScroll = true;
            menu.BackColor = Color.FromArgb(1, 13, 44);
            menu.Controls.Add(panelSubMenuReportes);
            menu.Controls.Add(btnReportes);
            menu.Controls.Add(btnProveedores);
            menu.Controls.Add(btnClientes);
            menu.Controls.Add(panelSubMenuCompras);
            menu.Controls.Add(btnCompras);
            menu.Controls.Add(panelSubMenuVentas);
            menu.Controls.Add(btnVentas);
            menu.Controls.Add(panelSubMenuConfig);
            menu.Controls.Add(btnConfiguracion);
            menu.Controls.Add(btnUsuarios);
            menu.Controls.Add(panel5);
            menu.Controls.Add(lblUsuarioActivo);
            menu.Controls.Add(lblEmpresa);
            menu.Controls.Add(panel3);
            menu.Dock = DockStyle.Left;
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(230, 650);
            menu.TabIndex = 0;
            // 
            // panelSubMenuReportes
            // 
            panelSubMenuReportes.Controls.Add(btnreporteV);
            panelSubMenuReportes.Controls.Add(btnReportes2);
            panelSubMenuReportes.Dock = DockStyle.Top;
            panelSubMenuReportes.Location = new Point(0, 718);
            panelSubMenuReportes.Name = "panelSubMenuReportes";
            panelSubMenuReportes.Size = new Size(213, 80);
            panelSubMenuReportes.TabIndex = 14;
            // 
            // btnreporteV
            // 
            btnreporteV.BackColor = Color.FromArgb(9, 34, 88);
            btnreporteV.Dock = DockStyle.Bottom;
            btnreporteV.FlatAppearance.BorderSize = 0;
            btnreporteV.FlatStyle = FlatStyle.Flat;
            btnreporteV.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnreporteV.ForeColor = Color.White;
            btnreporteV.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnreporteV.IconColor = Color.White;
            btnreporteV.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnreporteV.IconSize = 30;
            btnreporteV.ImageAlign = ContentAlignment.MiddleLeft;
            btnreporteV.Location = new Point(0, 40);
            btnreporteV.Name = "btnreporteV";
            btnreporteV.Padding = new Padding(20, 0, 0, 0);
            btnreporteV.Size = new Size(213, 40);
            btnreporteV.TabIndex = 24;
            btnreporteV.Text = "Reporte Venta";
            btnreporteV.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnreporteV.UseVisualStyleBackColor = false;
            btnreporteV.Click += btnreporteV_Click;
            // 
            // btnReportes2
            // 
            btnReportes2.BackColor = Color.FromArgb(9, 34, 88);
            btnReportes2.Dock = DockStyle.Top;
            btnReportes2.FlatAppearance.BorderSize = 0;
            btnReportes2.FlatStyle = FlatStyle.Flat;
            btnReportes2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReportes2.ForeColor = Color.White;
            btnReportes2.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnReportes2.IconColor = Color.White;
            btnReportes2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes2.IconSize = 30;
            btnReportes2.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes2.Location = new Point(0, 0);
            btnReportes2.Name = "btnReportes2";
            btnReportes2.Padding = new Padding(20, 0, 0, 0);
            btnReportes2.Size = new Size(213, 40);
            btnReportes2.TabIndex = 23;
            btnReportes2.Text = "Reporte Compra";
            btnReportes2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes2.UseVisualStyleBackColor = false;
            btnReportes2.Click += btnReportes2_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(15, 49, 120);
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReportes.ForeColor = Color.White;
            btnReportes.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            btnReportes.IconColor = Color.White;
            btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes.IconSize = 30;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 671);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(10, 0, 0, 0);
            btnReportes.Size = new Size(213, 47);
            btnReportes.TabIndex = 21;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(15, 49, 120);
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.IconChar = FontAwesome.Sharp.IconChar.TruckRampBox;
            btnProveedores.IconColor = Color.White;
            btnProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProveedores.IconSize = 30;
            btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Location = new Point(0, 624);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(10, 0, 0, 0);
            btnProveedores.Size = new Size(213, 47);
            btnProveedores.TabIndex = 20;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(15, 49, 120);
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClientes.ForeColor = Color.White;
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            btnClientes.IconColor = Color.White;
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 30;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(0, 577);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(10, 0, 0, 0);
            btnClientes.Size = new Size(213, 47);
            btnClientes.TabIndex = 19;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // panelSubMenuCompras
            // 
            panelSubMenuCompras.Controls.Add(btnCompras2);
            panelSubMenuCompras.Controls.Add(btnCompras1);
            panelSubMenuCompras.Dock = DockStyle.Top;
            panelSubMenuCompras.Location = new Point(0, 497);
            panelSubMenuCompras.Name = "panelSubMenuCompras";
            panelSubMenuCompras.Size = new Size(213, 80);
            panelSubMenuCompras.TabIndex = 14;
            // 
            // btnCompras2
            // 
            btnCompras2.BackColor = Color.FromArgb(9, 34, 88);
            btnCompras2.Dock = DockStyle.Top;
            btnCompras2.FlatAppearance.BorderSize = 0;
            btnCompras2.FlatStyle = FlatStyle.Flat;
            btnCompras2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras2.ForeColor = Color.White;
            btnCompras2.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnCompras2.IconColor = Color.White;
            btnCompras2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras2.IconSize = 30;
            btnCompras2.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras2.Location = new Point(0, 40);
            btnCompras2.Name = "btnCompras2";
            btnCompras2.Padding = new Padding(20, 0, 0, 0);
            btnCompras2.Size = new Size(213, 40);
            btnCompras2.TabIndex = 20;
            btnCompras2.Text = "Ver detalle";
            btnCompras2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras2.UseVisualStyleBackColor = false;
            btnCompras2.Click += btnCompras2_Click;
            // 
            // btnCompras1
            // 
            btnCompras1.BackColor = Color.FromArgb(9, 34, 88);
            btnCompras1.Dock = DockStyle.Top;
            btnCompras1.FlatAppearance.BorderSize = 0;
            btnCompras1.FlatStyle = FlatStyle.Flat;
            btnCompras1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras1.ForeColor = Color.White;
            btnCompras1.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnCompras1.IconColor = Color.White;
            btnCompras1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras1.IconSize = 30;
            btnCompras1.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras1.Location = new Point(0, 0);
            btnCompras1.Name = "btnCompras1";
            btnCompras1.Padding = new Padding(20, 0, 0, 0);
            btnCompras1.Size = new Size(213, 40);
            btnCompras1.TabIndex = 18;
            btnCompras1.Text = "Registrar";
            btnCompras1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras1.UseVisualStyleBackColor = false;
            btnCompras1.Click += btnCompras1_Click;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.FromArgb(15, 49, 120);
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCompras.ForeColor = Color.White;
            btnCompras.IconChar = FontAwesome.Sharp.IconChar.Dolly;
            btnCompras.IconColor = Color.White;
            btnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras.IconSize = 30;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(0, 450);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(10, 0, 0, 0);
            btnCompras.Size = new Size(213, 47);
            btnCompras.TabIndex = 18;
            btnCompras.Text = "Compras";
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // panelSubMenuVentas
            // 
            panelSubMenuVentas.Controls.Add(btnVentas2);
            panelSubMenuVentas.Controls.Add(btnVentas1);
            panelSubMenuVentas.Dock = DockStyle.Top;
            panelSubMenuVentas.Location = new Point(0, 370);
            panelSubMenuVentas.Name = "panelSubMenuVentas";
            panelSubMenuVentas.Size = new Size(213, 80);
            panelSubMenuVentas.TabIndex = 14;
            // 
            // btnVentas2
            // 
            btnVentas2.BackColor = Color.FromArgb(9, 34, 88);
            btnVentas2.Dock = DockStyle.Top;
            btnVentas2.FlatAppearance.BorderSize = 0;
            btnVentas2.FlatStyle = FlatStyle.Flat;
            btnVentas2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas2.ForeColor = Color.White;
            btnVentas2.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnVentas2.IconColor = Color.White;
            btnVentas2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas2.IconSize = 30;
            btnVentas2.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas2.Location = new Point(0, 40);
            btnVentas2.Name = "btnVentas2";
            btnVentas2.Padding = new Padding(20, 0, 0, 0);
            btnVentas2.Size = new Size(213, 40);
            btnVentas2.TabIndex = 19;
            btnVentas2.Text = "Ver detalle";
            btnVentas2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas2.UseVisualStyleBackColor = false;
            btnVentas2.Click += btnVentas2_Click;
            // 
            // btnVentas1
            // 
            btnVentas1.BackColor = Color.FromArgb(9, 34, 88);
            btnVentas1.Dock = DockStyle.Top;
            btnVentas1.FlatAppearance.BorderSize = 0;
            btnVentas1.FlatStyle = FlatStyle.Flat;
            btnVentas1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas1.ForeColor = Color.White;
            btnVentas1.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnVentas1.IconColor = Color.White;
            btnVentas1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas1.IconSize = 30;
            btnVentas1.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas1.Location = new Point(0, 0);
            btnVentas1.Name = "btnVentas1";
            btnVentas1.Padding = new Padding(20, 0, 0, 0);
            btnVentas1.Size = new Size(213, 40);
            btnVentas1.TabIndex = 17;
            btnVentas1.Text = "Registrar";
            btnVentas1.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas1.UseVisualStyleBackColor = false;
            btnVentas1.Click += btnVentas1_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(15, 49, 120);
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVentas.ForeColor = Color.White;
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            btnVentas.IconColor = Color.White;
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.IconSize = 30;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 323);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(10, 0, 0, 0);
            btnVentas.Size = new Size(213, 47);
            btnVentas.TabIndex = 17;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // panelSubMenuConfig
            // 
            panelSubMenuConfig.Controls.Add(btnEmpresa);
            panelSubMenuConfig.Controls.Add(btnProducto);
            panelSubMenuConfig.Controls.Add(btnCategoria);
            panelSubMenuConfig.Dock = DockStyle.Top;
            panelSubMenuConfig.Location = new Point(0, 203);
            panelSubMenuConfig.Name = "panelSubMenuConfig";
            panelSubMenuConfig.Size = new Size(213, 120);
            panelSubMenuConfig.TabIndex = 16;
            // 
            // btnEmpresa
            // 
            btnEmpresa.BackColor = Color.FromArgb(9, 34, 88);
            btnEmpresa.Dock = DockStyle.Top;
            btnEmpresa.FlatAppearance.BorderSize = 0;
            btnEmpresa.FlatStyle = FlatStyle.Flat;
            btnEmpresa.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEmpresa.ForeColor = Color.White;
            btnEmpresa.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnEmpresa.IconColor = Color.White;
            btnEmpresa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEmpresa.IconSize = 30;
            btnEmpresa.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmpresa.Location = new Point(0, 80);
            btnEmpresa.Name = "btnEmpresa";
            btnEmpresa.Padding = new Padding(20, 0, 0, 0);
            btnEmpresa.Size = new Size(213, 40);
            btnEmpresa.TabIndex = 17;
            btnEmpresa.Text = "Empresa";
            btnEmpresa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmpresa.UseVisualStyleBackColor = false;
            btnEmpresa.Click += btnEmpresa_Click_1;
            // 
            // btnProducto
            // 
            btnProducto.BackColor = Color.FromArgb(9, 34, 88);
            btnProducto.Dock = DockStyle.Top;
            btnProducto.FlatAppearance.BorderSize = 0;
            btnProducto.FlatStyle = FlatStyle.Flat;
            btnProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnProducto.ForeColor = Color.White;
            btnProducto.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnProducto.IconColor = Color.White;
            btnProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProducto.IconSize = 30;
            btnProducto.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducto.Location = new Point(0, 40);
            btnProducto.Name = "btnProducto";
            btnProducto.Padding = new Padding(20, 0, 0, 0);
            btnProducto.Size = new Size(213, 40);
            btnProducto.TabIndex = 15;
            btnProducto.Text = "Productos";
            btnProducto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProducto.UseVisualStyleBackColor = false;
            btnProducto.Click += btnProducto_Click;
            // 
            // btnCategoria
            // 
            btnCategoria.BackColor = Color.FromArgb(9, 34, 88);
            btnCategoria.Dock = DockStyle.Top;
            btnCategoria.FlatAppearance.BorderSize = 0;
            btnCategoria.FlatStyle = FlatStyle.Flat;
            btnCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCategoria.ForeColor = Color.White;
            btnCategoria.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnCategoria.IconColor = Color.White;
            btnCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategoria.IconSize = 30;
            btnCategoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategoria.Location = new Point(0, 0);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Padding = new Padding(20, 0, 0, 0);
            btnCategoria.Size = new Size(213, 40);
            btnCategoria.TabIndex = 14;
            btnCategoria.Text = "Categoría";
            btnCategoria.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategoria.UseVisualStyleBackColor = false;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.BackColor = Color.FromArgb(15, 49, 120);
            btnConfiguracion.Dock = DockStyle.Top;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfiguracion.ForeColor = Color.White;
            btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Gears;
            btnConfiguracion.IconColor = Color.White;
            btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfiguracion.IconSize = 30;
            btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.Location = new Point(0, 156);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracion.Size = new Size(213, 47);
            btnConfiguracion.TabIndex = 14;
            btnConfiguracion.Text = "Configuración";
            btnConfiguracion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracion.UseVisualStyleBackColor = false;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(15, 49, 120);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnUsuarios.IconColor = Color.White;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.IconSize = 30;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 109);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 0, 0);
            btnUsuarios.Size = new Size(213, 47);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Controls.Add(pictureBox1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 45);
            panel5.Name = "panel5";
            panel5.Size = new Size(213, 64);
            panel5.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(12, 3);
            label1.Name = "label1";
            label1.Size = new Size(150, 15);
            label1.TabIndex = 13;
            label1.Text = "Versión 1.0.0 release 011023";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 64);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
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
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(213, 45);
            panel3.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblusuario);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(213, 45);
            panel4.TabIndex = 15;
            // 
            // lblusuario
            // 
            lblusuario.AutoSize = true;
            lblusuario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblusuario.ForeColor = Color.White;
            lblusuario.Location = new Point(61, 26);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(61, 15);
            lblusuario.TabIndex = 22;
            lblusuario.Text = "unUsuario";
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
            // contenedor
            // 
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(230, 34);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(720, 616);
            contenedor.TabIndex = 14;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(220, 234, 252);
            ClientSize = new Size(950, 650);
            Controls.Add(contenedor);
            Controls.Add(panel2);
            Controls.Add(menu);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(800, 600);
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SistemaVentas";
            Load += Principal_Load;
            MouseDown += Principal_MouseDown;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            panelSubMenuReportes.ResumeLayout(false);
            panelSubMenuCompras.ResumeLayout(false);
            panelSubMenuVentas.ResumeLayout(false);
            panelSubMenuConfig.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel menu;
        private Panel panel2;
        private Label lblEmpresa;
        private FontAwesome.Sharp.IconButton btncancelar;
        private Label lblUsuarioActivo;
        private Panel panel3;
        private Panel panel4;
        private Panel panel6;
        private FontAwesome.Sharp.IconButton btnCategoria;
        private FontAwesome.Sharp.IconButton btnProducto;
        private FontAwesome.Sharp.IconButton btnEmpresa;
        private FontAwesome.Sharp.IconButton btnVentas;
        private Panel panel7;
        private FontAwesome.Sharp.IconButton btnVentas2;
        private FontAwesome.Sharp.IconButton btnVentas1;
        private FontAwesome.Sharp.IconButton btnCompras;
        private Panel panel8;
        private FontAwesome.Sharp.IconButton btnCompras1;
        private FontAwesome.Sharp.IconButton btnCompras2;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnProveedores;
        private FontAwesome.Sharp.IconButton btnReportes;
        private Panel panel9;
        private FontAwesome.Sharp.IconButton btnReportes1;
        private Panel panelSubMenuConfig;
        private Panel panelSubMenuVentas;
        private Panel panelSubMenuCompras;
        private Panel panelSubMenuReportes;
        private Label lblusuario;
        private FontAwesome.Sharp.IconButton btnReportes2;
        private FontAwesome.Sharp.IconButton btnConfiguracion;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private Panel panel5;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel contenedor;
        private FontAwesome.Sharp.IconButton btnreporteV;
    }
}