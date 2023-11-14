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
    public class CD_Compra
    {
        public int ObtenerCorrelativo()
        {
            // Variable para almacenar el valor del correlativo
            int idcorrelativo = 0;

            // Utilizando la declaración "using" para asegurar la liberación de recursos automáticamente
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Construir la consulta SQL para obtener el correlativo
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM COMPRA");

                    // Crear un nuevo comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Ejecutar la consulta y asignar el resultado al correlativo
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar el valor predeterminado (0) al correlativo
                    idcorrelativo = 0;
                }
            }

            // Devolver el valor del correlativo obtenido
            return idcorrelativo;
        }


        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            // Variables de respuesta y mensaje
            bool Respuesta = false;
            Mensaje = string.Empty;

            // Utilizando la declaración "using" para asegurar la liberación de recursos automáticamente
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL con el nombre del procedimiento almacenado y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand("sp_RegistrarCompra", oconexion);

                    // Asignar parámetros al comando con los valores del objeto Compra y la tabla DetalleCompra
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Ejecutar el procedimiento almacenado
                    cmd.ExecuteNonQuery();

                    // Obtener los resultados de la operación desde los parámetros de salida
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar los valores predeterminados a las variables de respuesta y mensaje
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }

            // Devolver la respuesta de la operación
            return Respuesta;
        }

        // Método para obtener una compra a partir de su número utilizando la capa de datos
        public Compra ObtenerCompra(string numero)
        {
            // Objeto Compra para almacenar los resultados de la consulta
            Compra obj = new Compra();

            // Utilizando la declaración "using" para asegurar la liberación de recursos automáticamente
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Construir la consulta SQL para obtener la compra
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT c.IdCompra,");
                    query.AppendLine("u.NombreCompleto,");
                    query.AppendLine("pr.Documento,pr.RazonSocial,");
                    query.AppendLine("c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,CONVERT(char(10), c.FechaRegistro, 103) AS [FechaRegistro]");
                    query.AppendLine("FROM COMPRA c");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario");
                    query.AppendLine("INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("WHERE c.NumeroDocumento = @numero");

                    // Crear un nuevo comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Utilizar un lector de datos para obtener los resultados de la consulta
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Iterar sobre los resultados y asignarlos al objeto Compra
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                oProveedor = new Proveedor() { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar un nuevo objeto Compra vacío
                    obj = new Compra();
                }
            }

            // Devolver el objeto Compra obtenido
            return obj;
        }



        // Método para obtener el detalle de una compra a partir de su ID utilizando la capa de datos
        public List<Detalle_Compra> ObtenerDetalleCompra(int idcompra)
        {
            // Lista para almacenar los detalles de la compra
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();

            try
            {
                // Utilizando la declaración "using" para asegurar la liberación de recursos automáticamente
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();

                    // Construir la consulta SQL para obtener el detalle de la compra
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal FROM DETALLE_COMPRA dc");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto");
                    query.AppendLine("WHERE dc.IdCompra =  @idcompra");

                    // Crear un nuevo comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    // Utilizando un lector de datos para obtener los resultados de la consulta
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Iterar sobre los resultados y agregar cada detalle a la lista
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Compra()
                            {
                                // Crear un nuevo objeto Detalle_Compra con los valores obtenidos de la consulta
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de error, asignar una lista vacía
                oLista = new List<Detalle_Compra>();
            }

            // Devolver la lista de detalles de compra
            return oLista;
        }



    }
}
