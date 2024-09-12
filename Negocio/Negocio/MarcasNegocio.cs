using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcasNegocio
    {
        public List<Marcas> listar()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //preparamos la consulta y ejecutamos el lector, mientras este lea se ejecutara lo del while
                datos.setQuery("SELECT * FROM Marcas");
                datos.executeReader();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();

                    // Aca rellenamos los objetos que vamos a empujar a la lista con los valores de la DB
                    // aux.prop = (tipoDato)datos.Lector["col"];
                    // --- reemplazar prop por propiedad de Articulos, tipodato por el dato esperado(como el lector devuelve
                    // --- un objeto debemos castearlo) y en col, la columna de la DB.

                    // ej-
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
