using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        //Sobrecargamos el constructor de la clase con parámetros
        public MsgBox(string pTipo, string pMensaje)
        {
            InitializeComponent();
            //Cambiamos el texto del label (el text) por el string que recibimos
            lblMsg.Text = pMensaje;
            //creamos un condicional para mostrar imagen y cambiar los colores
            switch (pTipo)
            {
                case "question":
                    //Cambiamos el label del título
                    lblTitulo.Text = "Pregunta";
                    //Cambiamos el color de la letra
                    lblTitulo.ForeColor = Color.FromArgb(255, 193, 7);
                    //cambiamos el color del panel que simula la primer línea
                    pL1.BackColor = Color.FromArgb(255, 193, 7);
                    //Volvemos visible a la imagen
                    pbQuestion.Visible = true;
                    break;
                case "warning":
                    //Cambiamos el label del título
                    lblTitulo.Text = "Advertencia";
                    //Cambiamos el color de la letra
                    lblTitulo.ForeColor = Color.FromArgb(33, 150, 243);
                    //cambiamos el color del panel que simula la primer línea
                    pL1.BackColor = Color.FromArgb(33, 150, 243);
                    //Volvemos visible a la imagen
                    pbWarning.Visible = true;
                    break;
                case "error":
                    //Cambiamos el label del título
                    lblTitulo.Text = "Error";
                    //Cambiamos el color de la letra
                    lblTitulo.ForeColor = Color.FromArgb(244, 67, 54);
                    //cambiamos el color del panel que simula la primer línea
                    pL1.BackColor = Color.FromArgb(244, 67, 54);
                    //Volvemos visible a la imagen
                    pbError.Visible = true;
                    btnCancelar.Visible = false;
                    break;
                default:
                    lblTitulo.Text = "Error al seleccionar";
                    break;
            }
        }

        //Evento para los botones, cuando el mouse entre en el botón
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.FromArgb(56, 87, 129);
            b.ForeColor = Color.White;
        }

        //Evento cuando el mouse sale del botón
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button b = sender as Button;
            b.BackColor = Color.FromArgb(1, 28, 83);
            b.ForeColor = Color.White;
        }

        //Evento click del botón aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Enviamos como respuesta al click en el botón Aceptar el comando OK
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Enviamos como respuesta al click en el botón Cancelar el comando cancel
            DialogResult = DialogResult.Cancel;
        }
    }
}
