using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{

    public class CN_Negocio
    {
        // Se crea una instancia de la clase CD_Negocio para interactuar con la capa de datos.
        private CD_Negocio objcd_negocio = new CD_Negocio();

        // Método para obtener datos de un Negocio desde la capa de datos.
        public Negocio ObtenerDatos()
        {
            return objcd_negocio.ObtenerDatos();
        }

        // Método para guardar datos de un Negocio en la base de datos y devuelve un mensaje.
        // Además, verifica si se proporciona un nombre, número de RUC y dirección válidos.
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            // Verifica si el nombre del negocio está vacío.
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre\n";
            }

            // Verifica si el número de RUC del negocio está vacío.
            if (obj.RUC == "")
            {
                Mensaje += "Es necesario el número de RUC\n";
            }

            // Verifica si la dirección del negocio está vacía.
            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la dirección\n";
            }

            // Si el mensaje no está vacío, indica que hubo errores y devuelve "false".
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama al método de la capa de datos para guardar los datos del negocio.
                return objcd_negocio.GuardarDatos(obj, out Mensaje);
            }
        }

        // Método para obtener el logo de un negocio y establecer si se obtuvo correctamente.
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negocio.ObtenerLogo(out obtenido);
        }

        // Método para actualizar el logo de un negocio y devuelve un mensaje.
        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objcd_negocio.ActualizarLogo(imagen, out mensaje);
        }
    }

}
