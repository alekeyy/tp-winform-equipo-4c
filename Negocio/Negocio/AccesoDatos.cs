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
            conexion = new SqlConnection("acaPonganSuDB");
            comando = new SqlCommand();
        }

        // declaramos la consulta a realizar
        public void setQuery(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }

        //ejecutar el lector
        public void executeReader()
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

        //despues de intentar una consulta, cerramos la conexion en el metodo donde este la accion
        public void closeConnection()
        {
            if(lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
