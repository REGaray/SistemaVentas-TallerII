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
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmRegistrarCompra : Form
    {
        private Usuario _Usuario;

        public frmRegistrarCompra(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }


        private void frmRegistrarCompra_Load(object sender, EventArgs e)
        {
            // Se agregan elementos al control 'cbotipodocumento' como opciones en un combo.
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });

            // Se establece el miembro para mostrar en el control 'cbotipodocumento' como "Texto".
            cbotipodocumento.DisplayMember = "Texto";

            // Se establece el valor interno en el control 'cbotipodocumento' como "Valor".
            cbotipodocumento.ValueMember = "Valor";

            // Se establece el índice seleccionado en el control 'cbotipodocumento' para mostrar la primera opción por defecto.
            cbotipodocumento.SelectedIndex = 0;

            // Se establece el texto del control 'txtfecha' como la fecha y hora actual formateada como "dd/MM/yyyy".
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Se inicializan los campos de texto 'txtidproveedor' y 'txtidproducto' con el valor "0".
            txtidproveedor.Text = "0";
            txtidproducto.Text = "0";

            //MessageBox.Show(_Usuario.NombreCompleto);


            //dgvRC.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvRC.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvRC.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvRC.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvRC.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            // Se crea y muestra un formulario modal 'mdProveedor' para buscar proveedores.
            using (var modal = new md_Proveedor())
            {
                // Se muestra el formulario modal y se espera a que se cierre.
                var result = modal.ShowDialog();

                // Si el resultado del formulario modal es "OK" (el usuario seleccionó un proveedor).
                if (result == DialogResult.OK)
                {
                    // Se actualizan los campos de texto con los datos del proveedor seleccionado.
                    txtidproveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtdocproveedor.Text = modal._Proveedor.Documento;
                    txtnombreproveedor.Text = modal._Proveedor.RazonSocial;
                }
                else
                {
                    // Si el resultado no es "OK" (el usuario canceló la selección), se selecciona el campo de texto 'txtdocproveedor'.
                    txtdocproveedor.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            // Se crea y muestra un formulario modal 'mdProducto' para buscar productos.
            using (var modal = new mdProducto())
            {
                // Se muestra el formulario modal y se espera a que se cierre.
                var result = modal.ShowDialog();

                // Si el resultado del formulario modal es "OK" (el usuario seleccionó un producto).
                if (result == DialogResult.OK)
                {
                    // Se actualizan los campos de texto con los datos del producto seleccionado.
                    txtidproducto.Text = modal._Producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._Producto.Codigo;
                    txtproducto.Text = modal._Producto.Nombre;
                    txtpreciocompra.Select();
                }
                else
                {
                    // Si el resultado no es "OK" (el usuario canceló la selección), se selecciona el campo de texto 'txtcodproducto'.
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si la tecla presionada es "Enter" (Return).
            if (e.KeyData == Keys.Enter)
            {

                // Busca un producto en la lista de productos que tenga el código ingresado y esté activo.
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                // Si se encontró un producto con el código ingresado.
                if (oProducto != null)
                {
                    // Cambia el color de fondo del campo de texto 'txtcodproducto' a verde (Honeydew).
                    txtcodproducto.BackColor = Color.Honeydew;
                    // Actualiza los campos 'txtidproducto' y 'txtproducto' con los datos del producto encontrado.
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre;
                    // Establece el foco en el campo de texto 'txtpreciocompra' para continuar la entrada de datos.
                    txtpreciocompra.Select();
                }
                else
                {
                    // Si no se encontró un producto, cambia el color de fondo del campo de texto 'txtcodproducto' a rojo (MistyRose).
                    txtcodproducto.BackColor = Color.MistyRose;
                    // Establece 'txtidproducto' en "0" y 'txtproducto' en una cadena vacía.
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                }
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            // Variables para almacenar el precio de compra, precio de venta y para verificar si el producto ya existe.
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            // Se verifica si el ID del producto es 0, lo que significa que no se ha seleccionado un producto.
            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Se verifica si el valor en 'txtpreciocompra' se puede convertir a un valor decimal.
            if (!decimal.TryParse(txtpreciocompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            // Se verifica si el valor en 'txtprecioventa' se puede convertir a un valor decimal.
            if (!decimal.TryParse(txtprecioventa.Text, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            // Se verifica si el producto ya existe en el control 'dgvdata'.
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            // Si el producto no existe en el control 'dgvdata'.
            if (!producto_existe)
            {

                // Se agrega una nueva fila al control 'dgvdata' con los datos del producto y los cálculos necesarios.
                dgvdata.Rows.Add(new object[] {
                txtidproducto.Text,
                txtproducto.Text,
                preciocompra.ToString("0.00"),
                precioventa.ToString("0.00"),
                txtcantidad.Value.ToString(),
                (txtcantidad.Value * preciocompra).ToString("0.00")
        });

                // Se llama a la función 'calcularTotal' para actualizar el total.
                calcularTotal();

                // Se llama a la función 'limpiarProducto' para limpiar los campos relacionados con el producto.
                limpiarProducto();

                // Se establece el foco en el campo de texto 'txtcodproducto' para continuar la entrada de datos.
                txtcodproducto.Select();
            }
        }


        private void limpiarProducto()
        {
            // Restablece los campos relacionados con el producto a sus valores iniciales o vacíos.
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtcodproducto.BackColor = Color.White;
            txtproducto.Text = "";
            txtpreciocompra.Text = "";
            txtprecioventa.Text = "";
            txtcantidad.Value = 1;
        }


        private void calcularTotal()
        {
            decimal total = 0;
            if (dgvdata.Rows.Count > 0)
            {
                // Calcula el total sumando los subtotales de todas las filas en el control 'dgvdata'.
                foreach (DataGridViewRow row in dgvdata.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            // Actualiza el campo 'txttotalpagar' con el valor total calculado y lo formatea como moneda.
            txttotalpagar.Text = total.ToString("0.00");
        }



    }
}
