using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Reflection;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>(); // Inicializamos una lista de objetos de tipo Permiso

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Creamos una consulta SQL para seleccionar información de permisos
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdRol, p.NombreMenu");
                    query.AppendLine("FROM PERMISO p");
                    query.AppendLine("INNER JOIN ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("INNER JOIN USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("WHERE u.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario); // Agregamos un parámetro para idusuario
                    cmd.CommandType = CommandType.Text; // Establecemos el tipo de comando como texto

                    oconexion.Open(); // Abrimos la conexión a la base de datos

                    using (SqlDataReader dr = cmd.ExecuteReader()) // Ejecutamos la consulta y creamos un lector de datos
                    {
                        while (dr.Read()) // Recorremos los resultados
                        {
                            lista.Add(new Permiso()
                            {
                                // Creamos objetos de tipo Permiso y los agregamos a la lista
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>(); // En caso de error, inicializamos la lista vacía
                }
            }

            return lista; // Devolvemos la lista de permisos
        }
    }
}