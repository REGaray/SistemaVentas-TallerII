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


    }
}
