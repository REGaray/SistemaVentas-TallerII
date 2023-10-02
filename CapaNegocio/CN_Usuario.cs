using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;     // Importa el espacio de nombres CapaDatos para utilizar la clase CD_Usuario.
using CapaEntidad;   // Importa el espacio de nombres CapaEntidad para utilizar la clase Usuario.

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();  // Crea una instancia de la clase CD_Usuario para interactuar con la capa de datos.

        // Método que llama al método 'Listar' de la clase CD_Usuario y devuelve la lista de usuarios obtenida.
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();  // Llama al método 'Listar' de CD_Usuario y devuelve la lista de usuarios recuperada de la base de datos.
        }

        public int registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del usuario\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el Nombre Completo del usuario\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Clave == "")
            {
                mensaje += "Es necesario la Clave del usuario\n";
            }

            // Si se encontraron errores de validación, devuelve 0 y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Llama a la función "registrar" del objeto "objcd_usuario" para realizar el registro.
                return objcd_usuario.registrar(obj, out mensaje);
            }
        }

        public bool editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Documento == "")
            {
                mensaje += "Es necesario el Documento del usuario\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el NombreCompleto del usuario\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Clave == "")
            {
                mensaje += "Es necesario el Clave del usuario\n";
            }

            // Si se encontraron errores de validación, devuelve False y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama a la función "editar" del objeto "objcd_usuario" para realizar la edición.
                return objcd_usuario.editar(obj, out mensaje);
            }
        }

        public bool eliminar(Usuario obj, out string mensaje)
        {
            // Llama a la función "eliminar" del objeto "objcd_usuario" para realizar la eliminación.
            return objcd_usuario.eliminar(obj, out mensaje);
        }
    }
}
