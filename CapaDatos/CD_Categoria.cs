using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Categoria
    {
        // Método que recupera una lista de objetos de tipo 'Categoria' desde la base de datos.
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();  // Inicializa una lista vacía de objetos 'Categoria'.

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdCategoria, Descripcion, Estado FROM CATEGORIA");

                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();  

                    using (SqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                            
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Categoria>();
                }
            }

            return lista; 
        }


        public int registrar(Categoria obj, out string mensaje)
        {
            int idCategoriaGenerado = 0;
            mensaje = string.Empty;     

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RregistrarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado

                    oconexion.Open();  // Abre la conexión a la base de datos.

                    cmd.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado en la base de datos

                    idCategoriaGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idCategoriaGenerado = 0;
                mensaje = ex.Message;  
            }

            return idCategoriaGenerado;  
        }


        public bool editar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;  
            mensaje = string.Empty;  

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarCategoria", oconexion);  
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);         
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;  
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;         

                    cmd.CommandType = CommandType.StoredProcedure; 

                    oconexion.Open();

                    cmd.ExecuteNonQuery();  

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message; 
            }

            return respuesta; 
        }

        public bool eliminar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarCategoria", oconexion);

                    
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);

                    
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open(); 

                    cmd.ExecuteNonQuery();


                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;  
        }
    }
}
