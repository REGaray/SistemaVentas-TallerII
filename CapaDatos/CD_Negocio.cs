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
    public class CD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase "Conexion".
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Define una consulta SQL para seleccionar los datos del negocio con un ID específico (en este caso, IDNegocio = 1).
                    string query = "SELECT IdNegocio, Nombre, RUC, Direccion FROM NEGOCIO WHERE IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    // Ejecuta la consulta y lee los resultados.
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Crea un objeto de la clase Negocio y asigna los valores obtenidos de la base de datos.
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                RUC = dr["RUC"].ToString(),
                                Direccion = dr["Direccion"].ToString()
                            };
                        }
                    }
                }
            }
            catch
            {
                // En caso de una excepción, se asigna un objeto de negocio vacío.
                obj = new Negocio();
            }

            return obj;
        }


        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase "Conexion".
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Define una consulta SQL para actualizar los datos del negocio con un ID específico (en este caso, IDNegocio = 1).
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Nombre = @nombre,");
                    query.AppendLine("RUC = @ruc,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", objeto.RUC);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.CommandType = CommandType.Text;

                    // Ejecuta la consulta y verifica si se afectó al menos una fila en la base de datos.
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudieron guardar los datos";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de una excepción, se captura el mensaje de error.
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }


        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase "Conexion".
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Define una consulta SQL para seleccionar el logotipo del negocio con un ID específico (en este caso, IDNegocio = 1).
                    string query = "SELECT Logo FROM NEGOCIO WHERE IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    // Ejecuta la consulta y recupera los datos del logotipo como un arreglo de bytes.
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de una excepción, se establece "obtenido" como false y se asigna un arreglo de bytes vacío.
                obtenido = false;
                LogoBytes = new byte[0];
            }

            return LogoBytes;
        }



        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                // Establece una conexión a la base de datos utilizando la cadena de conexión definida en la clase "Conexion".
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    // Define una consulta SQL para actualizar el logotipo del negocio con un ID específico (en este caso, IDNegocio = 1).
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Logo = @imagen");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@imagen", image);
                    cmd.CommandType = CommandType.Text;

                    // Ejecuta la consulta y verifica si se afectó al menos una fila en la base de datos.
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de una excepción, se captura el mensaje de error.
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }








    }
}
