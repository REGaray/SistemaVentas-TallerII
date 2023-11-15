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
using ClosedXML.Excel;

namespace CapaPresentacion
{
    public partial class frmReporteVenta : Form
    {
        public frmReporteVenta()
        {
            InitializeComponent();
        }

        private void frmReporteVenta_Load(object sender, EventArgs e)
        {
            // 1. Iterar a través de cada columna en el DataGridView.
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                // 2. Agregar un nuevo elemento al ComboBox de búsqueda con el nombre y texto de la columna.
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }

            // 3. Establecer las propiedades DisplayMember y ValueMember del ComboBox de búsqueda.
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";

            // 4. Establecer el índice seleccionado del ComboBox de búsqueda a 0 (primera columna).
            cbobusqueda.SelectedIndex = 0;
        }

        private void btnbuscarreporte_Click(object sender, EventArgs e)
        {
            // 1. Crear una lista de ReporteVenta para almacenar los resultados de la búsqueda.
            List<Reporte_Venta> lista = new List<Reporte_Venta>();

            // 2. Realizar la búsqueda de ventas utilizando la clase CN_Reporte.
            lista = new CN_Reporte().Venta(txtfechainicio.Value.ToString(), txtfechafin.Value.ToString());

            // 3. Limpiar las filas existentes en el DataGridView.
            dgvdata.Rows.Clear();

            // 4. Llenar el DataGridView con los resultados de la búsqueda.
            foreach (Reporte_Venta rv in lista)
            {

        dgvdata.Rows.Add(new object[] {
                rv.FechaRegistro,
                rv.TipoDocumento,
                rv.NumeroDocumento,
                rv.MontoTotal,
                rv.UsuarioRegistro,
                rv.DocumentoCliente,
                rv.NombreCliente,
                rv.CodigoProducto,
                rv.NombreProducto,
                rv.Categoria,
                rv.PrecioVenta,
                rv.Cantidad,
                rv.SubTotal
                });
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // 1. Obtener el nombre de la columna seleccionada en el ComboBox de búsqueda.
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            // 2. Verificar si hay filas en el DataGridView.
            if (dgvdata.Rows.Count > 0)
            {
                // 3. Iterar a través de cada fila en el DataGridView.
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // 4. Verificar si el valor en la celda de la columna seleccionada contiene el texto de búsqueda.
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                        // 5. Mostrar la fila si el valor cumple con el criterio de búsqueda.
                        row.Visible = true;
                    else
                        // 6. Ocultar la fila si el valor no cumple con el criterio de búsqueda.
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            // 1. Limpiar el cuadro de texto de búsqueda.
            txtbusqueda.Text = "";

            // 2. Mostrar todas las filas en el DataGridView.
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay registros en el DataGridView.
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // 2. Crear un DataTable para almacenar los datos del DataGridView.
                DataTable dt = new DataTable();

                // 3. Crear las columnas del DataTable basadas en las columnas del DataGridView.
                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                // 4. Llenar el DataTable con los datos visibles del DataGridView.
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[] {
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString()
                });
                    }
                }

                // 5. Configurar y mostrar el cuadro de diálogo para guardar el archivo Excel.
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 6. Crear un libro de trabajo de Excel y agregar una hoja con los datos.
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");

                        // 7. Ajustar el ancho de las columnas según el contenido.
                        hoja.ColumnsUsed().AdjustToContents();

                        // 8. Guardar el archivo Excel en la ubicación especificada.
                        wb.SaveAs(savefile.FileName);

                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
