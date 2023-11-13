using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Proveedor
    {
        // Método que recupera una lista de objetos de tipo 'Proveedor' desde la base de datos.
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();  // Inicializa una lista vacía de objetos 'Proveedor'.

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProveedor, Documento, RazonSocial, Correo, Telefono, Estado FROM PROVEEDOR\r\n");




                    // Crea un comando SQL para ejecutar la consulta.
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())  // Ejecuta la consulta y obtiene un lector de datos.
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                // Crea un objeto 'Proveedor' y asigna valores desde la base de datos.
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();  // En caso de error, reinicia la lista como vacía.
                }
            }

            return lista;  // Devuelve la lista de Proveedors recuperada de la base de datos.
        }


        public int registrar(Proveedor obj, out string mensaje)
        {
            int idProveedorGenerado = 0;  // Variable para almacenar el ID del Proveedor generado
            mensaje = string.Empty;     // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);           // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar el ID del Proveedor generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;           // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene el ID del Proveedor generado y el mensaje de resultado desde los parámetros de salida
                    idProveedorGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProveedorGenerado = 0;
                mensaje = ex.Message;  // Si ocurre una excepción, se captura y se almacena en 'mensaje'
            }

            return idProveedorGenerado;  // Devuelve el ID del Proveedor generado
        }


        public bool editar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;  // Variable para almacenar la respuesta (inicialmente falsa)
            mensaje = string.Empty;  // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);         // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar la respuesta (1 si se editó, 0 si no)
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene la respuesta (1 si se editó, 0 si no) y el mensaje de resultado desde los parámetros de salida
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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

        public bool eliminar(Proveedor obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Crea un nuevo comando SQL para llamar al procedimiento almacenado "SP_ELIMINARProveedor" en la conexión.
                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion);

                    // Agrega el parámetro "IdProveedor" al comando y establece su valor con el IdProveedor del objeto Proveedor.
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);

                    // Agrega los parámetros de salida "Respuesta" y "Mensaje" al comando.
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    // Establece el tipo de comando como un procedimiento almacenado.
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos.

                    // Obtiene la respuesta y el mensaje de salida del procedimiento almacenado.
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
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
