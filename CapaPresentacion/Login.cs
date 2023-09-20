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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            // creamos una nueva instancia de este formulario
            Inicio form = new Inicio();

            // mostramos el formulario y tambien hacemos que se pueda ocultar
            form.Show();

            // Oculta el formulario actual (el de inicio de sesión).
            this.Hide();

            // Asocia un manejador de eventos al evento de cierre del formulario "Inicio".
            form.FormClosing += frm_closing;

        }

        // Manejador de eventos para el cierre del formulario "Inicio".
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // limpiamos los imputs en la pestaña de logeo cuando volvamos al mismo.
            txtdocumento.Text = "";
            txtclave.Text = "";
            this.Show();
        }
    }
}
