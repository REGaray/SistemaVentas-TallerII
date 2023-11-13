using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor();  // Crea una instancia de la clase CD_Proveedor para interactuar con la capa de datos.

        // Método que llama al método 'Listar' de la clase CD_Proveedor y devuelve la lista de Proveedors obtenida.
        public List<Proveedor> Listar()
        {
            return objcd_Proveedor.Listar();  // Llama al método 'Listar' de CD_Proveedor y devuelve la lista de Proveedors recuperada de la base de datos.
        }

        public int registrar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del Proveedor\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.RazonSocial == "")
            {
                mensaje += "Es necesario la RazonSocial Completo del Proveedor\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Correo == "")
            {
                mensaje += "Es necesario el Correo del Proveedor\n";
            }

            // Si se encontraron errores de validación, devuelve 0 y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Llama a la función "registrar" del objeto "objcd_Proveedor" para realizar el registro.
                return objcd_Proveedor.registrar(obj, out mensaje);
            }
        }

        public bool editar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del Proveedor\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.RazonSocial == "")
            {
                mensaje += "Es necesario la RazonSocial Completo del Proveedor\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Correo == "")
            {
                mensaje += "Es necesario el Correo del Proveedor\n";
            }

            // Si se encontraron errores de validación, devuelve False y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama a la función "editar" del objeto "objcd_Proveedor" para realizar la edición.
                return objcd_Proveedor.editar(obj, out mensaje);
            }
        }

        public bool eliminar(Proveedor obj, out string mensaje)
        {
            // Llama a la función "eliminar" del objeto "objcd_Proveedor" para realizar la eliminación.
            return objcd_Proveedor.eliminar(obj, out mensaje);
        }
    }
}
