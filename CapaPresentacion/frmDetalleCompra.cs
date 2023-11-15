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
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using iTextSharp.text;

namespace CapaPresentacion
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            //dgvdata.Rows.Add("", "Alfajor tatin", "$150.00", 3, "$450.00");
            //dgvdata.Rows.Add("", "Alaris Malbec", "$1500.00", 1, "$1.500.00");
            //dgvdata.Rows.Add("", "Coca 1,5L Ret.", "$650.00", 2, "$1300.00");
            //dgvdata.Rows.Add("", "Marlboro box", "$1.100.00", 2, "$2.200.00");
            //dgvdata.Rows.Add("", "Topline Seven Menta", "$250.00", 2, "$500.00");
        }


        // Manejador de eventos para el botón de buscar
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // Obtener la compra utilizando el número de documento ingresado
            Compra oCompra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);

            // Verificar si se encontró la compra
            if (oCompra.IdCompra != 0)
            {
                // Mostrar los datos de la compra en la interfaz de usuario
                txtnumerodocumento.Text = oCompra.NumeroDocumento;
                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.TipoDocumento;
                txtusuario.Text = oCompra.oUsuario.NombreCompleto;
                txtdocproveedor.Text = oCompra.oProveedor.Documento;
                txtnombreproveedor.Text = oCompra.oProveedor.RazonSocial;

                // Limpiar las filas existentes en el DataGridView
                dgvdata.Rows.Clear();

                // Llenar el DataGridView con los detalles de la compra
                foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    dgvdata.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                // Mostrar el monto total de la compra en el TextBox correspondiente
                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdocproveedor.Text = "";
            txtnombreproveedor.Text = "";

            dgvdata.Rows.Clear();
            txtmontototal.Text = "0.00";
        }

        private void btndescargar_Click(object sender, EventArgs e)
        {
            // Verificar si el tipo de documento está vacío
            if (txttipodocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Obtener la plantilla HTML desde los recursos del proyecto
            string Texto_Html = Properties.Resources.PlantillaCompra.ToString();

            // Obtener los datos del negocio
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            // Reemplazar las etiquetas en la plantilla HTML con los datos obtenidos
            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);

            Texto_Html = Texto_Html.Replace("@docproveedor", txtdocproveedor.Text);
            Texto_Html = Texto_Html.Replace("@nombreproveedor", txtnombreproveedor.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            // Construir las filas de la tabla HTML con los datos del DataGridView
            string filas = string.Empty;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            // Reemplazar la etiqueta de las filas en la plantilla HTML con los datos construidos
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", txtmontototal.Text);

            // Configurar el cuadro de diálogo para guardar el archivo PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            // Verificar si se seleccionó un destino válido para guardar el archivo
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                // Crear un flujo de archivo para escribir en el documento PDF
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    // Crear un documento PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    // Configurar el escritor PDF para escribir en el flujo de archivo
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Obtener el logo del negocio
                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    // Si se obtuvo el logo, agregarlo al documento PDF
                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    // Utilizar un lector de texto para procesar la plantilla HTML
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        // Parsear el HTML y agregarlo al documento PDF
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Cerrar el documento PDF y el flujo de archivo
                    pdfDoc.Close();
                    stream.Close();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
