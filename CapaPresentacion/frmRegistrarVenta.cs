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
using CapaPresentacion.Modals;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class frmRegistrarVenta : Form
    {
        // Declarar una variable miembro para almacenar información sobre el usuario actual
        private Usuario _Usuario;

        // Constructor del formulario que toma un objeto Usuario opcional como parámetro
        public frmRegistrarVenta(Usuario oUsuario = null)
        {
            // Asignar el objeto Usuario proporcionado al miembro _Usuario
            _Usuario = oUsuario;

            // Inicializar el formulario y sus componentes
            InitializeComponent();
        }

        private void frmRegistrarVenta_Load(object sender, EventArgs e)
        {
            // Agregar opciones de tipo de documento (Boleta y Factura) al ComboBox cbotipodocumento
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });

            // Establecer la propiedad DisplayMember para mostrar el texto de las opciones en el ComboBox
            cbotipodocumento.DisplayMember = "Texto";

            // Establecer la propiedad ValueMember para obtener el valor de las opciones seleccionadas
            cbotipodocumento.ValueMember = "Valor";

            // Establecer el índice seleccionado por defecto en el ComboBox (en este caso, la primera opción)
            cbotipodocumento.SelectedIndex = 0;

            // Establecer el texto de txtfecha como la fecha actual en el formato "dd/MM/yyyy"
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Establecer el texto de txtidproducto como "0"
            txtidproducto.Text = "0";

            // Inicializar los campos de pago, cambio y total a valores predeterminados o vacíos
            txtpagocon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";



            //dgvdata.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvdata.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvdata.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvdata.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvdata.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            // Abrir el formulario modal para buscar clientes
            using (var modal = new mdCliente())
            {
                // Mostrar el formulario modal y capturar el resultado del cuadro de diálogo
                var result = modal.ShowDialog();

                // Verificar el resultado del cuadro de diálogo
                if (result == DialogResult.OK)
                {
                    // Si se selecciona un cliente, actualizar los campos correspondientes en el formulario principal
                    txtdocumentocliente.Text = modal._Cliente.Documento;
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto;
                    txtcodproducto.Select();  // Colocar el foco en el siguiente control (supongo que es un cuadro de texto para el código del producto)
                }
                else
                {
                    // Si se cancela la selección, colocar el foco en el campo de documento del cliente
                    txtdocumentocliente.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            // Abrir el formulario modal para buscar productos
            using (var modal = new mdProducto())
            {
                // Mostrar el formulario modal y capturar el resultado del cuadro de diálogo
                var result = modal.ShowDialog();

                // Verificar el resultado del cuadro de diálogo
                if (result == DialogResult.OK)
                {
                    // Si se selecciona un producto, actualizar los campos correspondientes en el formulario principal
                    txtidproducto.Text = modal._Producto.IdProducto.ToString();
                    txtcodproducto.Text = modal._Producto.Codigo;
                    txtproducto.Text = modal._Producto.Nombre;
                    txtprecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtstock.Text = modal._Producto.Stock.ToString();
                    txtcantidad.Select();  // Colocar el foco en el siguiente control (supongo que es un cuadro de texto para la cantidad)
                }
                else
                {
                    // Si se cancela la selección, colocar el foco en el campo de código del producto
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es la tecla "Enter"
            if (e.KeyData == Keys.Enter)
            {
                // Buscar el producto en la lista de productos activos que coincida con el código ingresado
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodproducto.Text && p.Estado == true).FirstOrDefault();

                // Verificar si se encontró un producto con el código ingresado
                if (oProducto != null)
                {
                    // Si se encuentra el producto, cambiar el color de fondo del cuadro de texto a Honeydew (verde claro)
                    txtcodproducto.BackColor = Color.Honeydew;
                    // Actualizar los campos del formulario principal con la información del producto encontrado
                    txtidproducto.Text = oProducto.IdProducto.ToString();
                    txtproducto.Text = oProducto.Nombre;
                    txtprecio.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtstock.Text = oProducto.Stock.ToString();
                    txtcantidad.Select();  // Colocar el foco en el siguiente control (supongo que es un cuadro de texto para la cantidad)
                }
                else
                {
                    // Si no se encuentra el producto, cambiar el color de fondo del cuadro de texto a MistyRose (rosa claro)
                    txtcodproducto.BackColor = Color.MistyRose;
                    // Restablecer los campos del formulario principal a sus valores iniciales
                    txtidproducto.Text = "0";
                    txtproducto.Text = "";
                    txtprecio.Text = "";
                    txtstock.Text = "";
                    txtcantidad.Value = 1;
                }
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            // Declaración de variables
            decimal precio = 0;
            bool producto_existe = false;

            // Validar si se ha seleccionado un producto
            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validar el formato del precio
            if (!decimal.TryParse(txtprecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecio.Select();
                return;
            }

            // Validar si la cantidad es mayor al stock disponible
            if (Convert.ToInt32(txtstock.Text) < Convert.ToInt32(txtcantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verificar si el producto ya existe en el DataGridView
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            // Si el producto no existe en la lista, agregarlo
            if (!producto_existe)
            {
                // Restar la cantidad del producto al stock
                bool respuesta = new CN_Venta().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(txtcantidad.Value.ToString())
                );

                // Verificar si se restó el stock correctamente
                if (respuesta)
                {
                    // Agregar una nueva fila al DataGridView con la información del producto
                    dgvdata.Rows.Add(new object[] {
                txtidproducto.Text,
                txtproducto.Text,
                precio.ToString("0.00"),
                txtcantidad.Value.ToString(),
                (txtcantidad.Value * precio).ToString("0.00")
            });

                    // Calcular y mostrar el total
                    calcularTotal();

                    // Limpiar los campos relacionados al producto
                    limpiarProducto();

                    // Colocar el foco en el cuadro de texto de código de producto
                    txtcodproducto.Select();
                }
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;

            // Verificar si hay filas en el DataGridView
            if (dgvdata.Rows.Count > 0)
            {
                // Recorrer todas las filas y sumar los subtotales
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
                }
            }

            // Mostrar el total en el cuadro de texto correspondiente
            txttotalpagar.Text = total.ToString("0.00");
        }


        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "";
            txtcantidad.Value = 1;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verificar si la celda es la de encabezado (RowIndex < 0)
            if (e.RowIndex < 0)
                return;

            // Verificar si la celda es la sexta columna (ColumnIndex == 5)
            if (e.ColumnIndex == 5)
            {
                // Dibujar la celda
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Obtener las dimensiones del icono (delete25 es probablemente un ícono de eliminar)
                var w = Properties.Resources.delete_16.Width;
                var h = Properties.Resources.delete_16.Height;

                // Calcular la posición del ícono en el centro de la celda
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                // Dibujar el ícono en la posición calculada
                e.Graphics.DrawImage(Properties.Resources.delete_16, new Rectangle(x, y, w, h));

                // Indicar que el evento ha sido manejado
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la celda clicada es el botón de eliminar
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                // Obtener el índice de la fila clicada
                int index = e.RowIndex;

                // Verificar si el índice es válido (mayor o igual a cero)
                if (index >= 0)
                {
                    // Obtener el IdProducto y la Cantidad de la fila clicada
                    int idProducto = Convert.ToInt32(dgvdata.Rows[index].Cells["IdProducto"].Value.ToString());
                    int cantidad = Convert.ToInt32(dgvdata.Rows[index].Cells["Cantidad"].Value.ToString());

                    // Sumar el stock correspondiente al producto eliminado
                    bool respuesta = new CN_Venta().SumarStock(idProducto, cantidad);

                    // Verificar si la operación de sumar stock fue exitosa
                    if (respuesta)
                    {
                        // Eliminar la fila del DataGridView
                        dgvdata.Rows.RemoveAt(index);

                        // Recalcular el total después de la eliminación
                        calcularTotal();
                    }
                }
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un dígito
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;  // Permitir dígitos
            }
            else
            {
                // Verificar si el cuadro de texto está vacío y el carácter es un punto
                if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;  // Impedir el punto si el cuadro de texto está vacío
                }
                else
                {
                    // Permitir teclas de control (por ejemplo, retroceso) y el carácter punto
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;  // Permitir teclas de control y el punto
                    }
                    else
                    {
                        e.Handled = true;  // Impedir cualquier otro carácter
                    }
                }
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un dígito
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;  // Permitir dígitos
            }
            else
            {
                // Verificar si el cuadro de texto está vacío y el carácter es un punto
                if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;  // Impedir el punto si el cuadro de texto está vacío
                }
                else
                {
                    // Permitir teclas de control (por ejemplo, retroceso) y el carácter punto
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;  // Permitir teclas de control y el punto
                    }
                    else
                    {
                        e.Handled = true;  // Impedir cualquier otro carácter
                    }
                }
            }
        }


        private void calcularcambio()
        {
            // Verificar si no hay productos en la venta
            if (txttotalpagar.Text.Trim() == "")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);

            // Verificar si el campo de pago contiene un valor
            if (txtpagocon.Text.Trim() == "")
            {
                txtpagocon.Text = "0";
            }

            // Intentar convertir el valor del campo de pago a decimal
            if (decimal.TryParse(txtpagocon.Text.Trim(), out pagacon))
            {
                // Verificar si el pago es menor que el total
                if (pagacon < total)
                {
                    txtcambio.Text = "0.00";  // El pago no es suficiente, el cambio es cero
                }
                else
                {
                    decimal cambio = pagacon - total;  // Calcular el cambio
                    txtcambio.Text = cambio.ToString("0.00");  // Mostrar el cambio en el formato deseado
                }
            }
        }

        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }

        private void btncrearventa_Click(object sender, EventArgs e)
        {
            // Verifica si el campo de documento del cliente está vacío
            if (txtdocumentocliente.Text == "")
            {
                MessageBox.Show("Debe ingresar documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verifica si el campo de nombre del cliente está vacío
            if (txtnombrecliente.Text == "")
            {
                MessageBox.Show("Debe ingresar nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verifica si no se han ingresado productos en la venta
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Crea una DataTable para almacenar el detalle de la venta
            DataTable detalle_venta = new DataTable();

            // Define las columnas de la DataTable
            detalle_venta.Columns.Add("IdProducto", typeof(int));
            detalle_venta.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_venta.Columns.Add("Cantidad", typeof(int));
            detalle_venta.Columns.Add("SubTotal", typeof(decimal));

            // Recorre las filas del DataGridView para llenar la DataTable
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                detalle_venta.Rows.Add(new object[] {
                row.Cells["IdProducto"].Value.ToString(),
                row.Cells["Precio"].Value.ToString(),
                row.Cells["Cantidad"].Value.ToString(),
                row.Cells["SubTotal"].Value.ToString()
                });
            }

            // Obtiene un correlativo para el número de documento de la venta
            int idcorrelativo = new CN_Venta().ObtenerCorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);

            // Calcula el cambio
            calcularcambio();

            // Crea un objeto de la clase Venta con los datos de la venta
            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                TipoDocumento = ((OpcionCombo)cbotipodocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtdocumentocliente.Text,
                NombreCliente = txtnombrecliente.Text,
                MontoPago = Convert.ToDecimal(txtpagocon.Text),
                MontoCambio = Convert.ToDecimal(txtcambio.Text),
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text)
            };

            // Registra la venta en la base de datos
            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, detalle_venta, out mensaje);

            // Muestra un mensaje según la respuesta del registro
            if (respuesta)
            {
                // Muestra un mensaje con el número de venta generado y da la opción de copiar al portapapeles
                var result = MessageBox.Show("Numero de venta generada:\n" + numeroDocumento + "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                // Si el usuario elige copiar al portapapeles, copia el número de documento
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);

                // Limpia los campos y DataGridView después de la venta exitosa
                txtdocumentocliente.Text = "";
                txtnombrecliente.Text = "";
                dgvdata.Rows.Clear();
                calcularTotal();
                txtpagocon.Text = "";
                txtcambio.Text = "";
            }
            else
            {
                // Muestra un mensaje de error en caso de que el registro falle
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
