using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        // Instancia de la clase CD_Reporte que maneja las operaciones en la capa de datos
        private CD_Reporte objcd_reporte = new CD_Reporte();

        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            // Llama al método correspondiente en la capa de datos (CD_Reporte)
            return objcd_reporte.Compra(fechainicio, fechafin, idproveedor);
        }

        public List<Reporte_Venta> Venta(string fechainicio, string fechafin)
        {
            // Llama al método correspondiente en la capa de datos (CD_Reporte)
            return objcd_reporte.Venta(fechainicio, fechafin);
        }
    }

}
