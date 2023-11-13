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
    }
}
