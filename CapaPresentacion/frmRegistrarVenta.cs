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
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmRegistrarVenta : Form
    {
        // Declarar una variable miembro para almacenar información sobre el usuario actual
        private Usuario _Usuario;

        // Constructor del formulario que toma un objeto Usuario opcional como parámetro
        public frmRegistrarVenta(Usuario oUsuario = null)
        {
            // Asignar el objeto Usuario proporcionado al miembro _Usuario
            _Usuario = oUsuario;

            // Inicializar el formulario y sus componentes
            InitializeComponent();
        }

        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {
            // Agregar opciones de tipo de documento (Boleta y Factura) al ComboBox cbotipodocumento
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });

            // Establecer la propiedad DisplayMember para mostrar el texto de las opciones en el ComboBox
            cbotipodocumento.DisplayMember = "Texto";

            // Establecer la propiedad ValueMember para obtener el valor de las opciones seleccionadas
            cbotipodocumento.ValueMember = "Valor";

            // Establecer el índice seleccionado por defecto en el ComboBox (en este caso, la primera opción)
            cbotipodocumento.SelectedIndex = 0;

            // Establecer el texto de txtfecha como la fecha actual en el formato "dd/MM/yyyy"
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Establecer el texto de txtidproducto como "0"
            txtidproducto.Text = "0";

            // Inicializar los campos de pago, cambio y total a valores predeterminados o vacíos
            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";



            //dgvdata.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvdata.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvdata.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvdata.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvdata.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }




    }
}
