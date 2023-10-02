using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp; // Importa el espacio de nombres FontAwesome.Sharp, que probablemente contiene iconos personalizados.

using CapaEntidad; // Importa el espacio de nombres CapaEntidad, que probablemente contiene definiciones de entidades.
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        private static Usuario usuarioActual; // Declara una variable estática para almacenar el usuario actual.
        private static IconMenuItem MenuActivo = null; // Declara una variable estática para rastrear el elemento de menú activo.
        private static Form FormularioActivo = null; // Declara una variable estática para rastrear el formulario activo.

        public Principal(Usuario objusuario)
        {
            usuarioActual = objusuario; // Inicializa la variable de usuarioActual con el usuario proporcionado.

            InitializeComponent(); // Inicializa los componentes de la ventana de inicio.
            customizeDesign();
        }

        /* ------------------- Codigo para mostrar los diferentes paneles -------------------*/
        private void AbrirFormulario(Form formulario)
        {
            if (contenedor.Controls.Count > 0)
            {
                // Si ya hay un formulario en el contenedor, lo eliminamos.
                contenedor.Controls.RemoveAt(0);
            }

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.FromArgb(220, 234, 252);

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        /* ------------------- Codigo para mostrar los diferentes paneles -------------------*/





        private void customizeDesign()
        {
            panelSubMenuConfig.Visible = false;
            panelSubMenuVentas.Visible = false;
            panelSubMenuCompras.Visible = false;
            panelSubMenuReportes.Visible = false;
            //.. mas personalizacion
        }

        private void hideSubMenu()
        {
            if (panelSubMenuConfig.Visible == true)
            {
                panelSubMenuConfig.Visible = false;
            }
            if (panelSubMenuVentas.Visible == true)
            {
                panelSubMenuVentas.Visible = false;
            }
            if (panelSubMenuCompras.Visible == true)
            {
                panelSubMenuCompras.Visible = false;
            }
            if (panelSubMenuReportes.Visible == true)
            {
                panelSubMenuReportes.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuConfig);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Form frmcategoria = new frmcategoria();
            AbrirFormulario(frmcategoria);

            hideSubMenu();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Form frmproductos = new frmproductos();
            AbrirFormulario(frmproductos);

            hideSubMenu();
        }

        private void btnEmpresa_Click_1(object sender, EventArgs e)
        {
            Form frmempresa = new frmEmpresa();
            AbrirFormulario(frmempresa);

            hideSubMenu();
        }


        private void btnVentas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuVentas);
        }

        private void btnVentas1_Click(object sender, EventArgs e)
        {
            Form frmRegistrarVenta = new frmRegistrarVenta();
            AbrirFormulario(frmRegistrarVenta);

            hideSubMenu();
        }

        private void btnVentas2_Click(object sender, EventArgs e)
        {
            Form frmDetalleVenta = new frmDetalleVenta();
            AbrirFormulario(frmDetalleVenta);

            hideSubMenu();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuCompras);
        }

        private void btnCompras1_Click(object sender, EventArgs e)
        {
            Form frmregistrarcompra = new frmRegistrarCompra();
            AbrirFormulario(frmregistrarcompra);

            hideSubMenu();
        }

        private void btnCompras2_Click(object sender, EventArgs e)
        {
            Form frmdetalleventa = new frmDetalleCompra();
            AbrirFormulario(frmdetalleventa);

            hideSubMenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuReportes);
        }

        private void btnReportes2_Click_1(object sender, EventArgs e)
        {
            //..
            // Codigo correspondiente
            //..

            hideSubMenu();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            // Obtener la lista de permisos del usuario actual
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            // Iterar a través de los controles dentro del "menu" (presumiblemente un Panel u otro contenedor)
            foreach (Control control in menu.Controls)
            {
                // Verificar si el control es de tipo IconButton
                if (control is IconButton iconButton)
                {
                    // Verificar si el nombre del control coincide con algún permiso en la lista
                    bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconButton.Name);

                    // Si el permiso no se encuentra, ocultar el control (IconButton)
                    if (!encontrado)
                    {
                        iconButton.Visible = false;
                    }
                }
            }

            // Configurar el texto del label "lblusuario" con el nombre del usuario actual
            lblusuario.Text = usuarioActual.NombreCompleto;
        }




        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Abre el formulario frmUsuarios en el panel "contenedor".
            Form frmUsuarios = new frmUsuarios();
            AbrirFormulario(frmUsuarios);
        }


        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual al hacer clic en un botón.
            MsgBox m = new MsgBox("question", "¿Desea cerrar sesión?");
            DialogResult respuesta = m.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                this.Close();
            }

            if (respuesta == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Form frmclientes = new frmclientes();
            AbrirFormulario(frmclientes);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Form frmproveedores = new frmproveedores();
            AbrirFormulario(frmproveedores);
        }

        private void btnReportes2_Click(object sender, EventArgs e)
        {
            Form frmReporteVenta = new frmReporteVentas();
            AbrirFormulario(frmReporteVenta);

            hideSubMenu();
        }
    }
}
