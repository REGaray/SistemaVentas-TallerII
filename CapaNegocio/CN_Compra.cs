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
    public class CN_Compra
    {
        private CD_Compra objcd_compra = new CD_Compra(); // Instancia de la clase CD_Compra para acceder a sus métodos

        // Método para obtener el correlativo de compra utilizando el objeto de la capa de datos
        public int ObtenerCorrelativo()
        {
            return objcd_compra.ObtenerCorrelativo();
        }

        // Método para registrar una compra utilizando el objeto de la capa de datos
        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_compra.Registrar(obj, DetalleCompra, out Mensaje);
        }

        // Método para obtener una compra con su detalle utilizando el objeto de la capa de datos
        public Compra ObtenerCompra(string numero)
        {
            // Obtener la compra desde la capa de datos
            Compra oCompra = objcd_compra.ObtenerCompra(numero);

            // Verificar si se encontró la compra
            if (oCompra.IdCompra != 0)
            {
                // Obtener el detalle de la compra utilizando el objeto de la capa de datos
                List<Detalle_Compra> oDetalleCompra = objcd_compra.ObtenerDetalleCompra(oCompra.IdCompra);

                // Asignar el detalle obtenido a la propiedad correspondiente en el objeto Compra
                oCompra.oDetalleCompra = oDetalleCompra;
            }

            // Devolver la compra
            return oCompra;
        }

    }
}
