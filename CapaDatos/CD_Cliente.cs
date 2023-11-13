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
    public class CD_Cliente
    {
        // Método que recupera una lista de objetos de tipo 'Cliente' desde la base de datos.
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();  // Inicializa una lista vacía de objetos 'Cliente'.

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCliente, Documento, NombreCompleto, Correo, Telefono, Estado FROM CLIENTE");




                    // Crea un comando SQL para ejecutar la consulta.
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())  // Ejecuta la consulta y obtiene un lector de datos.
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                // Crea un objeto 'Cliente' y asigna valores desde la base de datos.
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),                                
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();  // En caso de error, reinicia la lista como vacía.
                }
            }

            return lista;  // Devuelve la lista de Clientes recuperada de la base de datos.
        }


        public int registrar(Cliente obj, out string mensaje)
        {
            int idClienteGenerado = 0;  // Variable para almacenar el ID del Cliente generado
            mensaje = string.Empty;     // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);           // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar el ID del Cliente generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;           // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene el ID del Cliente generado y el mensaje de resultado desde los parámetros de salida
                    idClienteGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClienteGenerado = 0;
                mensaje = ex.Message;  // Si ocurre una excepción, se captura y se almacena en 'mensaje'
            }

            return idClienteGenerado;  // Devuelve el ID del Cliente generado
        }


        public bool editar(Cliente obj, out string mensaje)
        {
            bool respuesta = false;  // Variable para almacenar la respuesta (inicialmente falsa)
            mensaje = string.Empty;  // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarCliente", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);         // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);           // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);
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

        public bool eliminar(Cliente obj, out string mensaje)
        {
            // Inicializar respuesta como falso
            bool respuesta = false;
            // Inicializar mensaje como una cadena vacía
            mensaje = string.Empty;

            try
            {
                // Crear una nueva conexión a la base de datos utilizando la cadena de conexión definida en la clase 'Conexion'
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Crear un comando SQL para eliminar un registro de la tabla 'CLIENTE' donde el 'IdCLiente' coincide con el valor proporcionado
                    SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE IdCLiente = @id", oconexion);
                    // Agregar un parámetro llamado "@id" y asignarle el valor de 'IdCliente' del objeto 'obj'
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);
                    // Establecer el tipo de comando como 'Text', indicando que se trata de una consulta de texto plano
                    cmd.CommandType = CommandType.Text;
                    // Abrir la conexión a la base de datos
                    oconexion.Open();
                    // Ejecutar la consulta SQL y verificar si afectó más de 0 filas, si es así, establecer respuesta en verdadero
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                // En caso de una excepción, establecer respuesta en falso y asignar el mensaje de la excepción a la variable 'mensaje'
                respuesta = false;
                mensaje = ex.Message;
            }

            // Devolver el valor de respuesta, que indica si la operación de eliminación fue exitosa
            return respuesta;
        }


    }
}

