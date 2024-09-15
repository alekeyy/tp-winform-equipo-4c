using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        // devuelve el obj de tipo lector
        public SqlDataReader Lector {
            get { return lector; }
        }

        // constructor que prepare la conexion apenas es creado
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }

        // declaramos la consulta a realizar
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        // para pasar parametros
        public void setearParametro(string nombre, string valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void setearParametro(string nombre, int valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void setearParametro(string nombre, float valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //ejecutar el lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public object ejecutarEscalar()
        {
            comando.Connection = conexion;
            object resultado;
            try
            {
                conexion.Open();
                // metodo que devuelve solo la primer columna de la tabla en este caso, la columna id
                resultado = comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                conexion.Close(); 
            }
            return resultado; 
        }


        //despues de intentar una consulta, cerramos la conexion en el metodo donde este la accion
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
