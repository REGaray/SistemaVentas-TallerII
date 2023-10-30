using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        // Crea una instancia de la clase CD_Categoria para interactuar con la capa de datos.
        private CD_Categoria objcd_Categoria = new CD_Categoria();  

        // Método que llama al método 'Listar' de la clase CD_Categoria y devuelve la lista de Categorias obtenida.
        public List<Categoria> Listar()
        {
            // Llama al método 'Listar' de CD_Categoria y devuelve la lista de Categorias recuperada de la base de datos.
            return objcd_Categoria.Listar();  
        }

        public int registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            // Si se encontraron errores de validación, devuelve 0 y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                // Llama a la función "registrar" del objeto "objcd_Categoria" para realizar el registro.
                return objcd_Categoria.registrar(obj, out mensaje);
            }
        }

        public bool editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Verifica si el campo Clave está vacío y agrega un mensaje de error si es necesario.
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            // Si se encontraron errores de validación, devuelve False y establece el mensaje de error.
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                // Llama a la función "editar" del objeto "objcd_Categoria" para realizar la edición.
                return objcd_Categoria.editar(obj, out mensaje);
            }
        }

        public bool eliminar(Categoria obj, out string mensaje)
        {
            // Llama a la función "eliminar" del objeto "objcd_Categoria" para realizar la eliminación.
            return objcd_Categoria.eliminar(obj, out mensaje);
        }
    }
}

