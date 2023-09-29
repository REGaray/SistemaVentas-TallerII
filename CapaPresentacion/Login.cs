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
            // Cierra el formulario actual al hacer clic en un botón.
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

        //Evento que se inicia al querer ingresar al sistema, y muestra un MessageBox si no se pudo ingresar
        private void btningresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Documento == txtdocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();

            if (ousuario != null)
            {
                // Crea una nueva instancia del formulario "Inicio".
                Principal form = new Principal(ousuario);

                // Muestra el formulario "Inicio" y lo hace visible.
                form.Show();

                // Oculta el formulario actual (el de inicio de sesión).
                this.Hide();

                // Asocia un manejador de eventos al evento de cierre del formulario "Inicio".
                form.FormClosing += frm_closing;
            }
            else
            {
                MsgBox m = new MsgBox("error", "No se encontró el usuario");
                m.ShowDialog();
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

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        //Método que redonda las esquinas de un formulario
        private void Login_Load_1(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            //se ajusta el valor de redondeo a cambiar de la esquina
            int radio = 30;

            //Esquina superior izquierda
            path.AddArc(0, 0, radio, radio, 180, 90);
            //Esquina superior derecha
            path.AddArc(this.Width - radio, 0, radio, radio, 270, 90);
            //Esquina inferior derecha
            path.AddArc(this.Width - radio, this.Height - radio, radio, radio, 0, 90);
            //Esquina inferior izquierda
            path.AddArc(0, this.Height - radio, radio, radio, 90, 90);

            //Crea una región con el path del rectángulo redondeado y lo aplica al formulario Login
            this.Region = new Region(path);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        //Método que permite arrastrar la ventana principal de Login y moverla por la pantalla
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Checkea si el click fue en la barra del título del formulario
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, (IntPtr)0);
                }
            }
        }
    }
}
