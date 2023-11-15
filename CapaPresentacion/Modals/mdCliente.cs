using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Modals
{
    public partial class mdCliente : Form
    {

        public Cliente _Cliente { get; set; }
        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // Agregar opciones de búsqueda al ComboBox cbobusqueda basadas en las columnas del DataGridView dgvdata
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            // Establecer la propiedad DisplayMember para mostrar el texto de las opciones en el ComboBox
            cbobusqueda.DisplayMember = "Texto";

            // Establecer la propiedad ValueMember para obtener el valor de las opciones seleccionadas
            cbobusqueda.ValueMember = "Valor";

            // Establecer el índice seleccionado por defecto en el ComboBox (en este caso, la primera opción)
            cbobusqueda.SelectedIndex = 0;

            // Obtener la lista de clientes desde la capa de negocios (CN_Cliente)
            List<Cliente> lista = new CN_Cliente().Listar();

            // Agregar filas al DataGridView (dgvdata) solo para los clientes activos (Estado = true)
            foreach (Cliente item in lista)
            {
                if (item.Estado)
                    dgvdata.Rows.Add(new object[] { item.Documento, item.NombreCompleto });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener el índice de la fila y la columna donde se hizo doble clic
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            // Verificar que se haya hecho clic dentro de una celda válida (no en el encabezado)
            if (iRow >= 0 && iColum >= 0)
            {
                // Crear un nuevo objeto Cliente con la información de la fila seleccionada
                _Cliente = new Cliente()
                {
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    NombreCompleto = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString()
                };

                // Establecer DialogResult en OK para indicar que la operación fue exitosa
                this.DialogResult = DialogResult.OK;

                // Cerrar el formulario actual
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtener el nombre de la columna a utilizar como criterio de búsqueda
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            // Verificar si hay filas en el DataGridView
            if (dgvdata.Rows.Count > 0)
            {
                // Iterar a través de todas las filas del DataGridView
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Obtener el valor de la celda en la columna seleccionada y convertirlo a mayúsculas para realizar una comparación sin distinción entre mayúsculas y minúsculas
                    string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                    // Verificar si el valor de la celda contiene el texto de búsqueda ingresado (ignorando mayúsculas y minúsculas)
                    if (valorCelda.Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        // Mostrar la fila si cumple con el criterio de búsqueda
                        row.Visible = true;
                    }
                    else
                    {
                        // Ocultar la fila si no cumple con el criterio de búsqueda
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // Limpiar el cuadro de búsqueda
            txtbusqueda.Text = "";

            // Mostrar todas las filas del DataGridView
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
