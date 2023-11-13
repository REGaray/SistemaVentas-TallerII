using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd_Cliente = new CD_Cliente();  // Crea una instancia de la clase CD_Cliente para interactuar con la capa de datos.

        // Método que llama al método 'Listar' de la clase CD_Cliente y devuelve la lista de Clientes obtenida.
        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();  // Llama al método 'Listar' de CD_Cliente y devuelve la lista de Clientes recuperada de la base de datos.
        }

        public int registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del Cliente\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el Nombre Completo del Cliente\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Correo == "")
            {
                mensaje += "Es necesario la Correo del Cliente\n";
            }

            // Si se encontraron errores de validación, devuelve 0 y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Llama a la función "registrar" del objeto "objcd_Cliente" para realizar el registro.
                return objcd_Cliente.registrar(obj, out mensaje);
            }
        }

        public bool editar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del Cliente\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el NombreCompleto del Cliente\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Correo == "")
            {
                mensaje += "Es necesario la Correo del Cliente\n";
            }

            // Si se encontraron errores de validación, devuelve False y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama a la función "editar" del objeto "objcd_Cliente" para realizar la edición.
                return objcd_Cliente.editar(obj, out mensaje);
            }
        }

        public bool eliminar(Cliente obj, out string mensaje)
        {
            // Llama a la función "eliminar" del objeto "objcd_Cliente" para realizar la eliminación.
            return objcd_Cliente.eliminar(obj, out mensaje);
        }
    }
}
