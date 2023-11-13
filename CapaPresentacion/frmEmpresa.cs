using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmEmpresa : Form
    {
        public frmEmpresa()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            // Se crea un nuevo flujo de memoria (MemoryStream) para almacenar los bytes de la imagen.
            MemoryStream ms = new MemoryStream();

            // Se escriben los bytes de la imagen en el flujo de memoria.
            ms.Write(imageBytes, 0, imageBytes.Length);

            // Se crea una nueva imagen (Bitmap) a partir de los bytes almacenados en el flujo de memoria.
            Image image = new Bitmap(ms);

            // Se devuelve la imagen creada.
            return image;
        }


        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            // Se inicializa la variable 'obtenido' en 'true' para indicar que se obtuvo el logo correctamente.
            bool obtenido = true;

            // Se llama al método 'ObtenerLogo' de la clase 'CN_Negocio' para obtener el logo del negocio
            // y se almacena en 'byteimage'. Además, se verifica si se obtuvo correctamente.
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

            // Si el logo se obtuvo correctamente (obtenido == true), se muestra en el control 'picLogo'.
            if (obtenido)
                picLogo.Image = ByteToImage(byteimage);

            // Se llama al método 'ObtenerDatos' de la clase 'CN_Negocio' para obtener los datos del negocio
            // y se almacenan en 'datos'.
            Negocio datos = new CN_Negocio().ObtenerDatos();

            // Los datos obtenidos se asignan a los controles de la interfaz de usuario para mostrarlos.
            txtnombre.Text = datos.Nombre;
            txtruc.Text = datos.RUC;
            txtdireccion.Text = datos.Direccion;
        }

        private void btnsubir_Click(object sender, EventArgs e)
        {
            // Se inicializa la variable 'mensaje' para almacenar mensajes relacionados con la subida del logo.
            string mensaje = string.Empty;

            // Se crea un cuadro de diálogo para seleccionar un archivo de imagen.
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();

            // Se establece un filtro para el tipo de archivo que se puede seleccionar.
            oOpenFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            // Se verifica si el usuario selecciona un archivo y hace clic en "Aceptar".
            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se leen los bytes del archivo seleccionado y se almacenan en 'byteimage'.
                byte[] byteimage = File.ReadAllBytes(oOpenFileDialog.FileName);

                // Se llama al método 'ActualizarLogo' de la clase 'CN_Negocio' para actualizar el logo
                // utilizando los bytes de la imagen. Se verifica si la actualización fue exitosa.
                bool respuesta = new CN_Negocio().ActualizarLogo(byteimage, out mensaje);

                // Si la actualización fue exitosa, se muestra la imagen en el control 'picLogo'.
                if (respuesta)
                    picLogo.Image = ByteToImage(byteimage);
                else
                    // Si hubo un error en la actualización, se muestra un mensaje de error.
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            // Se inicializa la variable 'mensaje' para almacenar mensajes relacionados con la operación de guardado.
            string mensaje = string.Empty;

            // Se crea un objeto 'Negocio' con los datos ingresados en los controles de la interfaz de usuario.
            Negocio obj = new Negocio()
            {
                Nombre = txtnombre.Text,
                RUC = txtruc.Text,
                Direccion = txtdireccion.Text
            };

            // Se llama al método 'GuardarDatos' de la clase 'CN_Negocio' para intentar guardar los datos del negocio.
            // El resultado de la operación y cualquier mensaje de error se almacenan en 'respuesta' y 'mensaje' respectivamente.
            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);

            // Si la operación de guardado fue exitosa, se muestra un mensaje de confirmación.
            if (respuesta)
                MessageBox.Show("Los cambios fueron guardados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                // Si no se pudieron guardar los cambios, se muestra un mensaje de error.
                MessageBox.Show("No se pudo guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
