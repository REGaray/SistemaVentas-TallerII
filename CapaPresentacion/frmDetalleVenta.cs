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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtbusqueda.Select();

            //dgvDetalleVenta.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvDetalleVenta.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvDetalleVenta.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvDetalleVenta.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvDetalleVenta.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtener una instancia de la clase de lógica de negocios de Venta y llamar al método ObtenerVenta
            Venta oVenta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);

            // Verificar si la venta fue encontrada (IdVenta diferente de 0)
            if (oVenta.IdVenta != 0)
            {

                // Mostrar el número de documento en el campo correspondiente
                txtnumerodocumento.Text = oVenta.NumeroDocumento;

                // Mostrar la fecha de registro en el campo correspondiente
                txtfecha.Text = oVenta.FechaRegistro;

                // Mostrar el tipo de documento en el campo correspondiente
                txttipodocumento.Text = oVenta.TipoDocumento;

                // Mostrar el nombre completo del usuario en el campo correspondiente
                txtusuario.Text = oVenta.oUsuario.NombreCompleto;

                // Mostrar el documento del cliente en el campo correspondiente
                txtdoccliente.Text = oVenta.DocumentoCliente;

                // Mostrar el nombre del cliente en el campo correspondiente
                txtnombrecliente.Text = oVenta.NombreCliente;

                // Limpiar las filas existentes en el DataGridView
                dgvdata.Rows.Clear();

                // Iterar a través de los detalles de la venta y agregar filas al DataGridView
                foreach (Detalle_Venta dv in oVenta.oDetalleVenta)
                {
                    dgvdata.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                }

                // Mostrar el monto total en el campo correspondiente con formato
                txtmontototal.Text = oVenta.MontoTotal.ToString("0.00");

                // Mostrar el monto de pago en el campo correspondiente con formato
                txtmontopago.Text = oVenta.MontoPago.ToString("0.00");

                // Mostrar el monto de cambio en el campo correspondiente con formato
                txtmontocambio.Text = oVenta.MontoCambio.ToString("0.00");
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            // Limpiar el campo de texto de fecha
            txtfecha.Text = "";

            // Limpiar el campo de texto de tipo de documento
            txttipodocumento.Text = "";

            // Limpiar el campo de texto de usuario
            txtusuario.Text = "";

            // Limpiar el campo de texto de documento del cliente
            txtdoccliente.Text = "";

            // Limpiar el campo de texto de nombre del cliente
            txtnombrecliente.Text = "";

            // Limpiar todas las filas en el DataGridView
            dgvdata.Rows.Clear();

            // Establecer el texto del campo de monto total a "0.00"
            txtmontototal.Text = "0.00";

            // Establecer el texto del campo de monto de pago a "0.00"
            txtmontopago.Text = "0.00";

            // Establecer el texto del campo de monto de cambio a "0.00"
            txtmontocambio.Text = "0.00";
        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            // Verificar si el campo de tipo de documento está vacío
            if (txttipodocumento.Text == "")
            {
                // Mostrar un mensaje de advertencia y salir del método
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Obtener la plantilla HTML desde los recursos del proyecto
            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();

            // Obtener los datos del negocio a través de la lógica de negocios
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // Reemplazar placeholders en la plantilla con datos reales del negocio
            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            // Reemplazar placeholders en la plantilla con datos de la venta
            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);
            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            // Generar filas HTML para los detalles de la venta
            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", txtmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", txtmontocambio.Text);

            // Configurar el cuadro de diálogo para guardar el archivo PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            // Mostrar el cuadro de diálogo y verificar si se seleccionó "OK"
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                // Crear un flujo de archivo para escribir el documento PDF
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Crear un documento PDF con iTextSharp
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    // Obtener una instancia de PdfWriter para escribir en el documento
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Obtener el logo del negocio y agregarlo al PDF
                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    // Parsear el HTML generado al documento PDF
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Cerrar el documento y el flujo de archivo
                    pdfDoc.Close();
                    stream.Close();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
