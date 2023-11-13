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
using DocumentFormat.OpenXml.Wordprocessing;

namespace CapaPresentacion
{
    public partial class frmproveedores : Form
    {
        public frmproveedores()
        {
            InitializeComponent();
        }

        private void frmproveedores_Load(object sender, EventArgs e)
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

            // Obtiene una lista de Proveedors y los muestra en el DataGridView.
            List<Proveedor> lista = new CN_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                // Agrega una nueva fila con los datos del Proveedor al DataGridView.
                dgvdata.Rows.Add(new object[] { "", item.IdProveedor, item.Documento, item.RazonSocial, item.Correo, item.Telefono,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Inicializa una variable de mensaje vacía.
            string mensaje = string.Empty;

            // Crea un objeto Proveedor con los datos del formulario.
            Proveedor objProveedor = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                RazonSocial = txtrazonsocial.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (objProveedor.IdProveedor == 0)
            {
                // Llama al método "registrar" de la clase CN_Proveedor para registrar al Proveedor en la base de datos.
                int idProveedorGenerado = new CN_Proveedor().registrar(objProveedor, out mensaje);

                // Verifica si se registró correctamente un Proveedor.
                if (idProveedorGenerado != 0)
                {
                    // Agrega una nueva fila con los datos del Proveedor registrado en el DataGridView.
                    dgvdata.Rows.Add(new object[] { "", idProveedorGenerado, txtdocumento.Text, txtrazonsocial.Text, txtcorreo.Text, txttelefono.Text,
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
                    });

                    // Llama al método "limpiar" para limpiar los campos del formulario.
                    limpiar();
                }
                else
                {
                    // Muestra un mensaje de error en caso de que no se haya registrado el Proveedor.
                    MsgBox m = new MsgBox("error", mensaje);
                    m.ShowDialog();
                    //MessageBox.Show(mensaje);
                }
            }
            // Este bloque de código se ejecuta cuando el resultado de la edición de un Proveedor es 'false'.
            // El código intenta editar un Proveedor utilizando la clase CN_Proveedor y actualiza una fila en un DataGridView (dgvdata) si la edición es exitosa.
            // Si la edición no es exitosa, muestra un mensaje de error a través de un cuadro de diálogo MsgBox.

            // Bloque de código:
            else
            {
                // Intenta editar el Proveedor utilizando la clase CN_Proveedor y almacena el resultado en 'resultado'.
                bool resultado = new CN_Proveedor().editar(objProveedor, out mensaje);

                if (resultado)
                {
                    // Si la edición fue exitosa, actualiza la fila en el DataGridView con los nuevos valores.
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtid.Text)];

                    // Actualiza las celdas de la fila con los valores ingresados por el Proveedor.
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;

                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();

                    // Limpia los campos de entrada.
                    limpiar();
                }
                else
                {
                    // Si la edición no fue exitosa, muestra un mensaje de error en un cuadro de diálogo.
                    MsgBox m = new MsgBox("error", mensaje);
                    m.ShowDialog();
                }
            }
        }



        private void limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtrazonsocial.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cboestado.SelectedIndex = 0;

            // Una vez limpiado los campos, el focus vuelve a el txtDocumento.
            txtdocumento.Select();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica si la celda que se va a pintar está en la fila de encabezado (rowIndex < 0).
            if (e.RowIndex < 0)
            {
                return; // No hace nada si es una celda de encabezado.
            }

            // Verifica si la celda que se va a pintar pertenece a la primera columna (columnIndex == 0).
            if (e.ColumnIndex == 0)
            {
                // Pinta toda la celda (incluyendo el fondo y el borde).
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Obtiene el ancho y alto de la imagen que se va a dibujar.
                var w = Properties.Resources.icons8_checkmark_16.Width;
                var h = Properties.Resources.icons8_checkmark_16.Height;

                // Calcula la posición (coordenadas X e Y) para centrar la imagen en la celda.
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                // Dibuja la imagen (en este caso, una marca de verificación) en la celda.
                e.Graphics.DrawImage(Properties.Resources.icons8_checkmark_16, new Rectangle(x, y, w, h));

                // Marca la celda como "manejada" para indicar que se ha personalizado su apariencia.
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda clicada pertenece a la columna "btnseleccionar".
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                // Obtiene el índice de la fila clicada.
                int indice = e.RowIndex;

                // Verifica si el índice de fila es válido (mayor o igual a 0).
                if (indice >= 0)
                {
                    // Establece el índice de fila en el campo de texto "txtindice".
                    txtindice.Text = indice.ToString();

                    // Llena los campos del formulario con los datos de la fila seleccionada en el DataGridView.
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();

                    // Busca y selecciona el elemento correspondiente en el ComboBox "cboestado" basado en el Estadovalor.
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["Estadovalor"].Value.ToString()))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }
    }
}
