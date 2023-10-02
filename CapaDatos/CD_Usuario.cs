using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;  // Importa la clase de entidad definida en otro archivo.
using System.Reflection;
using System.Net.Http.Headers;
using System.Collections;
using System.Security.Claims;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_Usuario
    {
        // Método que recupera una lista de objetos de tipo 'Usuario' desde la base de datos.
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();  // Inicializa una lista vacía de objetos 'Usuario'.

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");
                    



                    // Crea un comando SQL para ejecutar la consulta.
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())  // Ejecuta la consulta y obtiene un lector de datos.
                    {
                        while (dr.Read()) {
                            lista.Add(new Usuario()
                            {
                                // Crea un objeto 'Usuario' y asigna valores desde la base de datos.
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }

                } catch (Exception ex)
                {
                    lista = new List<Usuario>();  // En caso de error, reinicia la lista como vacía.
                }
            }

            return lista;  // Devuelve la lista de usuarios recuperada de la base de datos.
        }


        public int registrar(Usuario obj, out string mensaje)
        {
            int idUsuarioGenerado = 0;  // Variable para almacenar el ID del usuario generado
            mensaje = string.Empty;     // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);           // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar el ID del usuario generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;           // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene el ID del usuario generado y el mensaje de resultado desde los parámetros de salida
                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                mensaje = ex.Message;  // Si ocurre una excepción, se captura y se almacena en 'mensaje'
            }

            return idUsuarioGenerado;  // Devuelve el ID del usuario generado
        }


        public bool editar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;  // Variable para almacenar la respuesta (inicialmente falsa)
            mensaje = string.Empty;  // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);         // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar la respuesta (1 si se editó, 0 si no)
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene la respuesta (1 si se editó, 0 si no) y el mensaje de resultado desde los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;  // Si ocurre una excepción, se captura y se almacena en 'mensaje'
            }

            return respuesta;  // Devuelve la respuesta (true si se editó, false si no)
        }

        public bool eliminar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Crea un nuevo comando SQL para llamar al procedimiento almacenado "SP_ELIMINARUSUARIO" en la conexión.
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);

                    // Agrega el parámetro "IdUsuario" al comando y establece su valor con el IdUsuario del objeto Usuario.
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);

                    // Agrega los parámetros de salida "Respuesta" y "Mensaje" al comando.
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;

                    // Establece el tipo de comando como un procedimiento almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos.

                    // Obtiene la respuesta y el mensaje de salida del procedimiento almacenado.
                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;  // Captura cualquier excepción y la almacena en el mensaje de salida.
            }

            return respuesta;  // Devuelve True si la eliminación se realizó con éxito, False en caso contrario.
        }

    }
}
