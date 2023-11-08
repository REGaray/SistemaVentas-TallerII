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
    public class CD_Producto
    {
        // Método que recupera una lista de objetos de tipo 'Producto' desde la base de datos.
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();  // Inicializa una lista vacía de objetos 'Producto'.

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria, c.Descripcion[DescripcionCategoria], Stock, PrecioCompra, PrecioVenta, p.Estado FROM PRODUCTO p");
                    query.AppendLine("INNER JOIN CATEGORIA c ON c.IdCategoria = p.IdCategoria");




                    // Crea un comando SQL para ejecutar la consulta.
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    using (SqlDataReader dr = cmd.ExecuteReader())  // Ejecuta la consulta y obtiene un lector de datos.
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                // Crea un objeto 'Producto' y asigna valores desde la base de datos.
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();  // En caso de error, reinicia la lista como vacía.
                }
            }

            return lista;  // Devuelve la lista de Productos recuperada de la base de datos.
        }


        public int registrar(Producto obj, out string mensaje)
        {
            int idProductoGenerado = 0;  // Variable para almacenar el ID del Producto generado
            mensaje = string.Empty;     // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);           // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;  // Parámetro de salida para almacenar el ID del Producto generado
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;           // Parámetro de salida para almacenar un mensaje de resultado

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    // Obtiene el ID del Producto generado y el mensaje de resultado desde los parámetros de salida
                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                mensaje = ex.Message;  // Si ocurre una excepción, se captura y se almacena en 'mensaje'
            }

            return idProductoGenerado;  // Devuelve el ID del Producto generado
        }


        public bool editar(Producto obj, out string mensaje)
        {
            bool respuesta = false;  // Variable para almacenar la respuesta (inicialmente falsa)
            mensaje = string.Empty;  // Variable para almacenar un mensaje de resultado (inicialmente vacío)

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oconexion);  // Crea un nuevo comando SQL que llama al procedimiento almacenado
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);         // Agrega parámetros al comando SQL con los valores del objeto 'obj'
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
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

        public bool eliminar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase Conexion.
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Crea un nuevo comando SQL para llamar al procedimiento almacenado "SP_ELIMINARProducto" en la conexión.
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion);

                    // Agrega el parámetro "IdProducto" al comando y establece su valor con el IdProducto del objeto Producto.
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);

                    // Agrega los parámetros de salida "Respuesta" y "Mensaje" al comando.
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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
