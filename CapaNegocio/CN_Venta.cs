using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        // Crear una instancia de la capa de datos para operaciones relacionadas con ventas
        private CD_Venta objcd_venta = new CD_Venta();

        // Método para restar stock de un producto en la base de datos
        public bool RestarStock(int idproducto, int cantidad)
        {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        // Método para sumar stock de un producto en la base de datos
        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }

        // Método para obtener el correlativo actual para el número de venta
        public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }

        // Método para registrar una venta en la base de datos
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        // Método para obtener una venta por su número de documento
        public Venta ObtenerVenta(string numero)
        {
            // Obtener la venta base por su número de documento
            Venta oVenta = objcd_venta.ObtenerVenta(numero);

            // Verificar si se encontró una venta válida
            if (oVenta.IdVenta != 0)
            {
                // Obtener los detalles de la venta y asignarlos al objeto Venta
                List<Detalle_Venta> oDetalleVenta = objcd_venta.ObtenerDetalleVenta(oVenta.IdVenta);
                oVenta.oDetalleVenta = oDetalleVenta;
            }

            // Devolver el objeto Venta con los detalles obtenidos
            return oVenta;
        }

    }
}
