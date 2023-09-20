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
    }
}
