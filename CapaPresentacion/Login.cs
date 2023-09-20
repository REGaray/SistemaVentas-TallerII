using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;    // Importa el espacio de nombres CapaNegocio para utilizar la clase CN_Usuario.
using CapaEntidad;    // Importa el espacio de nombres CapaEntidad para utilizar la clase Usuario.

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();  // Inicializa los componentes del formulario.
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario actual al hacer clic en un botón.
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            if(ousuario != null)
            {
                // Crea una nueva instancia del formulario "Inicio".
                Inicio form = new Inicio();

                // Muestra el formulario "Inicio" y lo hace visible.
                form.Show();

                // Oculta el formulario actual (el de inicio de sesión).
                this.Hide();

                // Asocia un manejador de eventos al evento de cierre del formulario "Inicio".
                form.FormClosing += frm_closing;
            } else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        // Manejador de eventos para el cierre del formulario "Inicio".
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // Limpia los campos de entrada en la pestaña de inicio de sesión cuando se vuelve a mostrar.
            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();  // Vuelve a mostrar el formulario de inicio de sesión.
        }
    }
}
