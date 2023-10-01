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

// Declaración del espacio de nombres CapaDatos
namespace CapaDatos
{
    // Declaración de la clase CD_Rol
    public class CD_Rol
    {
        // Declaración del método Listar que devuelve una lista de objetos de tipo Rol
        public List<Rol> Listar()
        {
            // Creación de una lista para almacenar objetos de tipo Rol
            List<Rol> lista = new List<Rol>();

            // Uso de la declaración "using" para garantizar la liberación adecuada de recursos
            // Crea una instancia de SqlConnection utilizando la cadena de conexión definida en la clase "Conexion"
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Creación de una consulta SQL para seleccionar IdRol y Descripcion desde la tabla ROL
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol, Descripcion FROM ROL");

                    // Creación de un comando SqlCommand utilizando la consulta SQL y la conexión SqlConnection
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    // Abre la conexión a la base de datos
                    oconexion.Open();

                    // Uso de SqlDataReader para leer los resultados de la consulta
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Iteración a través de los registros devueltos por la consulta
                        while (dr.Read())
                        {
                            // Creación de objetos de tipo Rol y agregándolos a la lista
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de una excepción, se crea una lista vacía
                    lista = new List<Rol>();
                }
            }

            // Devuelve la lista de objetos de tipo Rol (puede estar vacía en caso de error)
            return lista;
        }
    }
}

