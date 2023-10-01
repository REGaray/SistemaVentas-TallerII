using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

// Declaración del espacio de nombres CapaNegocio
namespace CapaNegocio
{
    // Declaración de la clase CN_Rol
    public class CN_Rol
    {
        // Creación de una instancia privada de la clase CD_Rol
        // (esto presume que CD_Rol es una clase existente)
        private CD_Rol objcd_rol = new CD_Rol();

        // Declaración del método Listar que devuelve una lista de objetos de tipo Rol
        public List<Rol> Listar()
        {
            // Llama al método Listar de la instancia objcd_rol y devuelve su resultado
            return objcd_rol.Listar();
        }
    }
}
