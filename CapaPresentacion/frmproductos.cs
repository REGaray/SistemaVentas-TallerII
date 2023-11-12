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
using ClosedXML.Excel;
using static Guna.UI2.Native.WinApi;

namespace CapaPresentacion
{
    public partial class frmproductos : Form
    {
        public frmproductos()
        {
            InitializeComponent();
        }

        private void frmproductos_Load(object sender, EventArgs e)
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

            // Obtiene una lista de roles y la asigna al ComboBox "cbocategoria".
            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                // Agrega cada rol como una opción en el ComboBox "cbocategoria".
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cbocategoria".
            cbocategoria.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cbocategoria".
            cbocategoria.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cbocategoria".
            cbocategoria.SelectedIndex = 0;

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
            List<Producto> lista = new CN_Producto().Listar();

            foreach (Producto item in lista)
            {
                // Agrega una nueva fila con los datos del usuario al DataGridView.
                dgvdata.Rows.Add(new object[] {
                "",
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.oCategoria.IdCategoria,
                item.oCategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }



            //dgvproductos.Rows.Add("", 100, "Leche LV LS x 1l", "Leche Larga Vida La Serenísima x 1l", "Lácteos", 30, "$230", "$310", "Activo");
            //dgvproductos.Rows.Add("", 101, "Coca Cola x3l", "Gaseosa Coca Cola x 3l Regular", "Gaseosas", 20, "$1100", "$1400", "Activo");
            //dgvproductos.Rows.Add("", 102, "Chocolatada Cindor x1l", "Leche Chocolatada Cindor x 1l", "Lácteos", 10, "$800", "$980", "Activo");
            //dgvproductos.Rows.Add("", 103, "Puré De la Huerta 510ml", "Puré de Tomate De la Huerta 510ml", "Almacén", 18, "$200", "$300", "Activo");
            //dgvproductos.Rows.Add("", 104, "Marlboro Box 20", "Cigarrillo Marlboro Box 20", "Cigarrilos", 30, "990", "$1100", "Activo");
            //dgvproductos.Rows.Add("", 105, "Fernet Branca 75cc", "Fernet Branca 75cc", "Espirituosas", 6, "$2900", "$3600", "Activo");
            //dgvproductos.Rows.Add("", 106, "Sprite 2.25l", "Gaseosa Sprite 2.25l Regular", "Gaseosas", 10, "$890", "$1100", "Activo");
            //dgvproductos.Rows.Add("", 107, "Gancia 450cc", "Aperitivo Gancia 450cc", "Espirituosas", 10, "$800", "$1230", "Activo");
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Inicializa una variable de mensaje vacía.
            string mensaje = string.Empty;

            // Crea un objeto Usuario con los datos del formulario.
            Producto obj = new Producto()
            {
                IdProducto = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                Descripcion = txtdescripcion.Text,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (obj.IdProducto == 0)
            {
                // Llama al método "registrar" de la clase CN_Usuario para registrar al usuario en la base de datos.
                int idGenerado = new CN_Producto().registrar(obj, out mensaje);

                // Verifica si se registró correctamente un usuario.
                if (idGenerado != 0)
                {
                    // Agrega una nueva fila con los datos del usuario registrado en el DataGridView.
                    dgvdata.Rows.Add(new object[] {
                    "",
                    idGenerado,
                    txtcodigo.Text,
                    txtnombre.Text,
                    txtdescripcion.Text,
                    ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                    "0",
                    "0.00",
                    "0.00",
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).Texto.ToString()
                    });

                    // Llama al método "limpiar" para limpiar los campos del formulario.
                    limpiar();
                }
                else
                {
                    // Muestra un mensaje de error en caso de que no se haya registrado el usuario.
                    MsgBox m = new MsgBox("error", mensaje);
                    m.ShowDialog();
                    //MessageBox.Show(mensaje);
                }
            }
            // Este bloque de código se ejecuta cuando el resultado de la edición de un usuario es 'false'.
            // El código intenta editar un usuario utilizando la clase CN_Usuario y actualiza una fila en un DataGridView (dgvdata) si la edición es exitosa.
            // Si la edición no es exitosa, muestra un mensaje de error a través de un cuadro de diálogo MsgBox.

            // Bloque de código:
            else
            {
                // Intenta editar el usuario utilizando la clase CN_Usuario y almacena el resultado en 'resultado'.
                bool resultado = new CN_Producto().editar(obj, out mensaje);

                if (resultado)
                {
                    // Si la edición fue exitosa, actualiza la fila en el DataGridView con los nuevos valores.
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtid.Text)];

                    // Actualiza las celdas de la fila con los valores ingresados por el usuario.
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();

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
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            // Una vez limpiado los campos, el focus vuelve a el txtDocumento.
            txtcodigo.Select();
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

                    // Llena los campos del formulario con los datos de la fila seleccionada en el DataGridView.
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    // Busca y selecciona el elemento correspondiente en el ComboBox "cborol" basado en el IdRol.
                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value.ToString()))
                        {
                            int indice_combo = cbocategoria.Items.IndexOf(oc);
                            cbocategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

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


        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Comprueba si el valor en el campo de texto "txtid" es diferente de cero.
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                // Muestra un cuadro de diálogo de confirmación.
                if (MessageBox.Show("¿Desea eliminar el producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Inicializa una cadena de mensajes vacía.
                    string mensaje = string.Empty;

                    // Crea un objeto Producto con el IdProducto especificado.
                    Producto obj = new Producto()
                    {
                        IdProducto = Convert.ToInt32(txtid.Text)
                    };

                    // Llama a un método de la clase CN_Producto para eliminar el producto y obtiene una respuesta y un mensaje.
                    bool respuesta = new CN_Producto().eliminar(obj, out mensaje);

                    if (respuesta)
                    {
                        // Elimina la fila correspondiente en un DataGridView (dgvdata).
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        // Limpia los campos del formulario.
                        limpiar();
                    }
                    else
                    {
                        // Muestra un mensaje de advertencia en caso de fallo en la eliminación.
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
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

        private void btnlimpiarform_Click(object sender, EventArgs e)
        {
            limpiar();
        }


        private void btnexportar_Click(object sender, EventArgs e)
        {
            // Verifica si no hay filas en el DataGridView (dgvdata) para exportar.
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // Crea una nueva DataTable (dt) para almacenar los datos a exportar.
                DataTable dt = new DataTable();

                // Itera a través de las columnas visibles del DataGridView para agregarlas como columnas en la DataTable.
                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }

                // Itera a través de las filas visibles del DataGridView para agregar los datos a la DataTable.
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                        });
                    }
                }

                // Configura el diálogo de guardado de archivo.
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmSS"));
                savefile.Filter = "Archivos de Excel | *.xlsx";

                // Muestra el diálogo de guardado de archivo y procede si el usuario elige una ubicación para guardar.
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Crea un nuevo archivo Excel usando la biblioteca ClosedXML (XLWorkbook).
                        XLWorkbook wb = new XLWorkbook();

                        // Agrega la DataTable (dt) como una hoja en el archivo Excel.
                        var hoja = wb.Worksheets.Add(dt, "Informe");

                        // Ajusta automáticamente el ancho de las columnas para que se ajusten al contenido.
                        hoja.ColumnsUsed().AdjustToContents();

                        // Guarda el archivo Excel en la ubicación especificada por el usuario.
                        wb.SaveAs(savefile.FileName);

                        // Muestra un mensaje de éxito.
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        // Muestra un mensaje de error en caso de problemas durante la generación del reporte.
                        MessageBox.Show("Error al generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

    }
}
