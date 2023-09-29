using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (panelConfiguracion.Visible == true)
            {
                panelConfiguracion.Visible = false;
            }
            else
            {
                panelConfiguracion.Visible = true;
            }

            //Posiciones de los botones del menú Configuración cuando está expandido
            btnUsuarios.Location = new Point(12, 115);
            btnConfiguracion.Location = new Point(12, 168);
            btnCategoria.Location = new Point(12, 262);
            btnProducto.Location = new Point(12, 309);
            btnNegocio.Location = new Point(12, 356);
            btnVentas.Location = new Point(12, 363);
            btnCompras.Location = new Point(12, 416);
            btnClientes.Location = new Point(12, 469);
            btnProveedores.Location = new Point(12, 522);
            btnReportes.Location = new Point(12, 575);

            if (panelConfiguracion.Visible == false)
            {
                //Estas son las posiciones iniciales de todos los botones cuando los menúes están contraídos
                btnUsuarios.Location = new Point(12, 115);
                btnConfiguracion.Location = new Point(12, 168);
                btnVentas.Location = new Point(12, 221);
                btnCompras.Location = new Point(12, 274);
                btnClientes.Location = new Point(12, 327);
                btnProveedores.Location = new Point(12, 380);
                btnReportes.Location = new Point(12, 433);
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //Estas son las posiciones iniciales de todos los botones cuando los menúes están contraídos
            btnUsuarios.Location = new Point(12, 115);
            btnConfiguracion.Location = new Point(12, 168);
            btnVentas.Location = new Point(12, 221);
            btnCompras.Location = new Point(12, 274);
            btnClientes.Location = new Point(12, 327);
            btnProveedores.Location = new Point(12, 380);
            btnReportes.Location = new Point(12, 433);

            panelConfiguracion.Hide();
            panelVentas.Hide();
            panelCompras.Hide();
            panelReportes.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (panelVentas.Visible == true)
            {
                panelVentas.Visible = false;
            }
            else
            {
                panelVentas.Visible = true;
            }

            //Posiciones de los botones del menú Ventas cuando está expandido
            btnUsuarios.Location = new Point(12, 115);
            btnConfiguracion.Location = new Point(12, 168);
            btnVentas.Location = new Point(12, 221);
            btnVentas1.Location = new Point(12, 268);
            btnVentas2.Location = new Point(12, 315);
            btnCompras.Location = new Point(12, 368);
            btnClientes.Location = new Point(12, 421);
            btnProveedores.Location = new Point(12, 474);
            btnReportes.Location = new Point(12, 527);

            if (panelConfiguracion.Visible == false)
            {
                //Estas son las posiciones iniciales de todos los botones cuando los menúes están contraídos
                btnUsuarios.Location = new Point(12, 115);
                btnConfiguracion.Location = new Point(12, 168);
                btnVentas.Location = new Point(12, 221);
                btnCompras.Location = new Point(12, 274);
                btnClientes.Location = new Point(12, 327);
                btnProveedores.Location = new Point(12, 380);
                btnReportes.Location = new Point(12, 433);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            if (panelCompras.Visible == true)
            {
                panelCompras.Visible = false;
            }
            else
            {
                panelCompras.Visible = true;
            }

            //Posiciones de los botones del menú Compras cuando está expandido
            btnUsuarios.Location = new Point(12, 115);
            btnConfiguracion.Location = new Point(12, 168);
            btnVentas.Location = new Point(12, 221);
            btnCompras.Location = new Point(12, 274);
            btnCompras1.Location = new Point(12, 321);
            btnCompras2.Location = new Point(12, 368);
            btnClientes.Location = new Point(12, 421);
            btnProveedores.Location = new Point(12, 474);
            btnReportes.Location = new Point(12, 527);

            if (panelConfiguracion.Visible == false)
            {
                //Estas son las posiciones iniciales de todos los botones cuando los menúes están contraídos
                btnUsuarios.Location = new Point(12, 115);
                btnConfiguracion.Location = new Point(12, 168);
                btnVentas.Location = new Point(12, 221);
                btnCompras.Location = new Point(12, 274);
                btnClientes.Location = new Point(12, 327);
                btnProveedores.Location = new Point(12, 380);
                btnReportes.Location = new Point(12, 433);
            }

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (panelReportes.Visible == true)
            {
                panelReportes.Visible = false;
            }
            else
            {
                panelReportes.Visible = true;
            }

            //Posiciones de los botones del menú Reportes cuando está expandido
            btnUsuarios.Location = new Point(12, 115);
            btnConfiguracion.Location = new Point(12, 168);
            btnVentas.Location = new Point(12, 221);
            btnCompras.Location = new Point(12, 274);
            btnClientes.Location = new Point(12, 327);
            btnProveedores.Location = new Point(12, 380);
            btnReportes.Location = new Point(12, 433);
            btnReportes1.Location = new Point(12, 480);
            btnReportes2.Location = new Point(12, 527);

            if (panelConfiguracion.Visible == false)
            {
                //Estas son las posiciones iniciales de todos los botones cuando los menúes están contraídos
                btnUsuarios.Location = new Point(12, 115);
                btnConfiguracion.Location = new Point(12, 168);
                btnVentas.Location = new Point(12, 221);
                btnCompras.Location = new Point(12, 274);
                btnClientes.Location = new Point(12, 327);
                btnProveedores.Location = new Point(12, 380);
                btnReportes.Location = new Point(12, 433);
            }

        }

        private void btnReportes1_Click(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            MsgBox m = new MsgBox("question", "¿Desea salir?");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
