using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

// a partir de aca empezamos a hacer petisiones a nuestra base de datos con las sentencias de SQL Server

namespace CapaDatos
{
    public class CD_Usuario
    {
        // agregamos un metodo que nos permita listar todos los usuarios que tenemos en nuestra BD
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {

            }
        }

    }
}
