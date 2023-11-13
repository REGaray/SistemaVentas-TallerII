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
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmclientes : Form
    {
        public frmclientes()
        {
            InitializeComponent();
        }

        private void frmclientes_Load(object sender, EventArgs e)
        {
            // Agrega las opciones "Activo" e "Inactivo" al ComboBox "cboestado".
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cboestado".
            cboestado.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cboestado".
            cboestado.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cboestado" (en este caso, "Activo").
            cboestado.SelectedIndex = 0;

            // Obtiene una lista de roles y la asigna al ComboBox "cborol".
            List<Rol> listaRol = new CN_Rol().Listar();


            // Llena el ComboBox "cbobusqueda" con las opciones de búsqueda basadas en las columnas visibles del DataGridView.
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cbobusqueda".
            cbobusqueda.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cbobusqueda".
            cbobusqueda.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cbobusqueda".
            cbobusqueda.SelectedIndex = 0;

            // Obtiene una lista de usuarios y los muestra en el DataGridView.
            List<Cliente> lista = new CN_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                // Agrega una nueva fila con los datos del usuario al DataGridView.
                dgvdata.Rows.Add(new object[] { "", item.IdCliente, item.Documento, item.NombreCompleto, item.Correo, item.Telefono,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }



            //dgvclientes.Rows.Add("", "12876456", "Constructora DelNea", "constructoradelnea@gmail.com", 3794877654, "Activo");
            //dgvclientes.Rows.Add("", "90654783907", "Produnoa SA", "produnoa@gmail.com", 3624536740, "Activo");
            //dgvclientes.Rows.Add("", "11111111", "Consumidor Final", "correoejemplo@gmail.com", 3794111222, "Activo");
            //dgvclientes.Rows.Add("", "37876904", "Alberto Tito Rios", "albertito@gmail.com", 372453647, "Activo");
            //dgvclientes.Rows.Add("", "41928847", "Juan Se", "juanse@gmail.com", 3795654372, "Activo");
        }
    }
}
