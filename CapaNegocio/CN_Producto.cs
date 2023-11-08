using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objcd_Producto = new CD_Producto();  // Crea una instancia de la clase CD_Producto para interactuar con la capa de datos.

        // Método que llama al método 'Listar' de la clase CD_Producto y devuelve la lista de Productos obtenida.
        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();  // Llama al método 'Listar' de CD_Producto y devuelve la lista de Productos recuperada de la base de datos.
        }

        public int registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el Codigo del Producto\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el Nombre Completo del Producto\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la Descripcion del Producto\n";
            }

            // Si se encontraron errores de validación, devuelve 0 y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Llama a la función "registrar" del objeto "objcd_Producto" para realizar el registro.
                return objcd_Producto.registrar(obj, out mensaje);
            }
        }

        public bool editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Documento está vacío y agrega un mensaje de error si es necesario.
            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el Codigo del Producto\n";
            }

            // Verifica si el campo NombreCompleto está vacío y agrega un mensaje de error si es necesario.
            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el Nombre Completo del Producto\n";
            }

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la Descripcion del Producto\n";
            }

            // Si se encontraron errores de validación, devuelve False y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama a la función "editar" del objeto "objcd_Producto" para realizar la edición.
                return objcd_Producto.editar(obj, out mensaje);
            }
        }

        public bool eliminar(Producto obj, out string mensaje)
        {
            // Llama a la función "eliminar" del objeto "objcd_Producto" para realizar la eliminación.
            return objcd_Producto.eliminar(obj, out mensaje);
        }
    }
}
