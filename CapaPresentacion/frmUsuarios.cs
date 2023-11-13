using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
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

            foreach (Rol item in listaRol)
            {
                // Agrega cada rol como una opción en el ComboBox "cborol".
                cborol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }

            // Establece el atributo "Texto" como el valor a mostrar en el ComboBox "cborol".
            cborol.DisplayMember = "Texto";

            // Establece el atributo "Valor" como el valor a obtener del ComboBox "cborol".
            cborol.ValueMember = "Valor";

            // Selecciona la primera opción en el ComboBox "cborol".
            cborol.SelectedIndex = 0;

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
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                // Agrega una nueva fila con los datos del usuario al DataGridView.
                dgvdata.Rows.Add(new object[] { "", item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo"
                });
            }
        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Inicializa una variable de mensaje vacía.
            string mensaje = string.Empty;

            // Crea un objeto Usuario con los datos del formulario.
            Usuario objusuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                NombreCompleto = txtnombrecompleto.Text,
                Correo = txtcorreo.Text,
                Clave = txtclave.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (objusuario.IdUsuario == 0)
            {
                // Llama al método "registrar" de la clase CN_Usuario para registrar al usuario en la base de datos.
                int idUsuarioGenerado = new CN_Usuario().registrar(objusuario, out mensaje);

                // Verifica si se registró correctamente un usuario.
                if (idUsuarioGenerado != 0)
                {
                    // Agrega una nueva fila con los datos del usuario registrado en el DataGridView.
                    dgvdata.Rows.Add(new object[] { "", idUsuarioGenerado, txtdocumento.Text, txtnombrecompleto.Text, txtcorreo.Text, txtclave.Text,
                    ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
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
                bool resultado = new CN_Usuario().editar(objusuario, out mensaje);

                if (resultado)
                {
                    // Si la edición fue exitosa, actualiza la fila en el DataGridView con los nuevos valores.
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtid.Text)];

                    // Actualiza las celdas de la fila con los valores ingresados por el usuario.
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtnombrecompleto.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Clave"].Value = txtcorreo.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).Texto.ToString();
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
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
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
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();

                    // Busca y selecciona el elemento correspondiente en el ComboBox "cborol" basado en el IdRol.
                    foreach (OpcionCombo oc in cborol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdRol"].Value.ToString()))
                        {
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
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
            // Verificar si se ha seleccionado un usuario (el valor de txtid.Text no es igual a 0).
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                // Mostrar un cuadro de diálogo de confirmación antes de eliminar al usuario.
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    // Crear un objeto de usuario con el ID de usuario a eliminar.
                    Usuario objusuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtid.Text),
                    };

                    // Llamar al método de eliminación de usuario (eliminar) a través de la clase CN_Usuario.
                    // El resultado se almacena en la variable 'respuesta', y cualquier mensaje se guarda en 'mensaje'.
                    bool respuesta = new CN_Usuario().eliminar(objusuario, out mensaje);

                    // Verificar si la eliminación fue exitosa.
                    if (respuesta)
                    {
                        // Si la eliminación fue exitosa, eliminar la fila correspondiente en el DataGridView.
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        // Si la eliminación no fue exitosa, mostrar un mensaje de advertencia.
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
    }
}
