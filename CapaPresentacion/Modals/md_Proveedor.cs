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

namespace CapaPresentacion.Modales
{
    public partial class md_Proveedor : Form
    {
        public Proveedor _Proveedor { get; set; }

        public md_Proveedor()
        {
            InitializeComponent();
        }

        private void md_Proveedor_Load(object sender, EventArgs e)
        {
            // Para cada columna en el control 'dgvdata'.
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                // Si la columna está visible en la vista.
                if (columna.Visible == true)
                {
                    // Se agregan elementos al control 'cbobusqueda' como opciones en un combo.
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }

            // Se establece el miembro para mostrar en el control 'cbobusqueda' como "Texto".
            cbobusqueda.DisplayMember = "Texto";

            // Se establece el valor interno en el control 'cbobusqueda' como "Valor".
            cbobusqueda.ValueMember = "Valor";

            // Se establece el índice seleccionado en el control 'cbobusqueda' para mostrar la primera opción por defecto.
            cbobusqueda.SelectedIndex = 0;

            // Se llama al método 'Listar' de la clase 'CN_Proveedor' para obtener una lista de proveedores.
            List<Proveedor> lista = new CN_Proveedor().Listar();

            // Para cada proveedor en la lista, se agregan filas al control 'dgvdata' con los datos correspondientes.
            foreach (Proveedor item in lista)
            {
                dgvdata.Rows.Add(new object[] { item.IdProveedor, item.Documento, item.RazonSocial });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se obtiene el índice de la fila y columna de la celda en la que se hizo doble clic.
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            // Se verifica si el doble clic se realizó en una fila válida y en una columna que no es la primera (índice 0).
            if (iRow >= 0 && iColum > 0)
            {

                // Se crea un objeto 'Proveedor' con los datos de la fila seleccionada en el control 'dgvdata'.
                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvdata.Rows[iRow].Cells["Id"].Value.ToString()),
                    Documento = dgvdata.Rows[iRow].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvdata.Rows[iRow].Cells["RazonSocial"].Value.ToString()
                };

                // Se establece el resultado del formulario como "OK" para indicar que se seleccionó un proveedor.
                this.DialogResult = DialogResult.OK;

                // Se cierra el formulario modal.
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                // Filtrar filas en una tabla o grilla según un criterio de búsqueda.
                // Este código compara el contenido de la celda en la columna 'columnaFiltro'
                // con el texto ingresado en el control 'txtbusqueda'.

                // Parámetros:
                // - row: La fila actual que se va a evaluar.
                // - columnaFiltro: El nombre de la columna en la que se va a buscar.
                // - txtbusqueda.Text: El texto de búsqueda ingresado por el usuario.

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Convertir el valor de la celda en texto y eliminar espacios en blanco,
                    // luego convertirlo a mayúsculas para hacer una comparación sin distinción
                    // entre mayúsculas y minúsculas.
                    string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                    // Convertir el texto de búsqueda a mayúsculas para hacer una comparación sin distinción
                    // entre mayúsculas y minúsculas.
                    string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

                    // Verificar si el valor de la celda contiene el texto de búsqueda.
                    // Si es así, hacer visible la fila; de lo contrario, ocultarla.
                    if (valorCelda.Contains(textoBusqueda))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de búsqueda al establecer su texto como una cadena vacía.
            txtbusqueda.Text = "";

            // Mostrar todas las filas en el DataGridView estableciendo la propiedad 'Visible' de cada fila como verdadera.
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
