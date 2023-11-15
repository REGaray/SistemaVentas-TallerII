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
    public class CD_Venta
    {
        // Método para obtener el correlativo para una nueva venta
        public int ObtenerCorrelativo()
        {
            // Inicializar el correlativo como 0
            int idcorrelativo = 0;

            // Utilizar una conexión SQL para acceder a la base de datos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Construir la consulta para obtener el correlativo
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM VENTA");

                    // Crear un comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Obtener el correlativo ejecutando la consulta y convirtiéndolo a entero
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar 0 al correlativo
                    idcorrelativo = 0;
                }
            }

            // Devolver el correlativo obtenido
            return idcorrelativo;
        }

        // Método para restar la cantidad de productos vendidos del stock
        public bool RestarStock(int idproducto, int cantidad)
        {
            // Inicializar la respuesta como verdadera
            bool respuesta = true;

            // Utilizar una conexión SQL para acceder a la base de datos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Construir la consulta para restar la cantidad de productos vendidos del stock
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock - @cantidad WHERE IdProducto = @idproducto");

                    // Crear un comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Ejecutar la consulta y verificar si se afectaron filas
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar falsa a la respuesta
                    respuesta = false;
                }
            }

            // Devolver la respuesta obtenida
            return respuesta;
        }

        // Método para sumar la cantidad de productos al stock
        public bool SumarStock(int idproducto, int cantidad)
        {
            // Inicializar la respuesta como verdadera
            bool respuesta = true;

            // Utilizar una conexión SQL para acceder a la base de datos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Construir la consulta para sumar la cantidad de productos al stock
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE Producto SET Stock = Stock + @cantidad WHERE IdProducto = @idproducto");

                    // Crear un comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.CommandType = CommandType.Text;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Ejecutar la consulta y verificar si se afectaron filas
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    // En caso de error, asignar falsa a la respuesta
                    respuesta = false;
                }
            }

            // Devolver la respuesta obtenida
            return respuesta;
        }



        // Método para registrar una venta en la base de datos
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            // Inicializar la respuesta como falsa y el mensaje como vacío
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                // Utilizar una conexión SQL para acceder a la base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    // Crear un comando SQL con el nombre del procedimiento almacenado y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand("usp_RegistrarVenta", oconexion);

                    // Configurar los parámetros del comando con los datos de la venta y el detalle de la venta
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.MontoPago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.MontoCambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Abrir la conexión a la base de datos
                    oconexion.Open();

                    // Ejecutar el procedimiento almacenado
                    cmd.ExecuteNonQuery();

                    // Obtener el resultado y el mensaje de salida
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // En caso de error, asignar falsa a la respuesta y el mensaje de error
                Respuesta = false;
                Mensaje = ex.Message;
            }

            // Devolver la respuesta obtenida
            return Respuesta;
        }


        // Método para obtener una venta por su número de documento
        public Venta ObtenerVenta(string numero)
        {
            // Inicializar un objeto de tipo Venta
            Venta obj = new Venta();

            // Utilizar una conexión SQL para acceder a la base de datos
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    // Construir la consulta para obtener los detalles de la venta
                    query.AppendLine("SELECT v.IdVenta, u.NombreCompleto,");
                    query.AppendLine("v.DocumentoCliente, v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento, v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago, v.MontoCambio, v.MontoTotal,");
                    query.AppendLine("CONVERT(char(10), v.FechaRegistro, 103) [FechaRegistro]");
                    query.AppendLine("FROM VENTA v");
                    query.AppendLine("INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario");
                    query.AppendLine("WHERE v.NumeroDocumento = @numero");

                    // Crear un comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    // Ejecutar la consulta y leer los resultados
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Construir el objeto Venta con los datos obtenidos de la consulta
                            obj = new Venta()
                            {
                                IdVenta = int.Parse(dr["IdVenta"].ToString()),
                                oUsuario = new Usuario() { NombreCompleto = dr["NombreCompleto"].ToString() },
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoPago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                MontoCambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch
                {
                    // En caso de error, asignar un objeto Venta vacío
                    obj = new Venta();
                }
            }

            // Devolver el objeto Venta obtenido
            return obj;
        }

        // Método para obtener los detalles de una venta por su identificador
        public List<Detalle_Venta> ObtenerDetalleVenta(int idVenta)
        {
            // Inicializar una lista de Detalle_Venta
            List<Detalle_Venta> oLista = new List<Detalle_Venta>();

            // Utilizar una conexión SQL para acceder a la base de datos
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    // Construir la consulta para obtener los detalles de la venta
                    query.AppendLine("SELECT p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal FROM DETALLE_VENTA dv");
                    query.AppendLine("INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto");
                    query.AppendLine("WHERE dv.IdVenta = @idventa");

                    // Crear un comando SQL con la consulta y la conexión proporcionada
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.CommandType = System.Data.CommandType.Text;

                    // Ejecutar la consulta y leer los resultados
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Construir objetos Detalle_Venta y agregarlos a la lista
                            oLista.Add(new Detalle_Venta()
                            {
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                            });
                        }
                    }
                }
                catch
                {
                    // En caso de error, asignar una lista de Detalle_Venta vacía
                    oLista = new List<Detalle_Venta>();
                }
            }

            // Devolver la lista de Detalle_Venta obtenida
            return oLista;
        }


    }
}
