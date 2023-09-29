using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

using CapaDatos;     // Importa el espacio de nombres CapaDatos para utilizar la clase CD_Usuario.
using CapaEntidad;   // Importa el espacio de nombres CapaEntidad para utilizar la clase Usuario.

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_permiso = new CD_Permiso();  // Crea una instancia de la clase CD_Permiso para interactuar con la capa de datos.

        // Método que llama al método 'Listar' de la clase CD_Permiso y devuelve la lista de permisos obtenida.
        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_permiso.Listar(IdUsuario);  // Llama al método 'Listar' de CD_Permiso y devuelve la lista de permisos recuperada de la base de datos.
        }
    }
}
