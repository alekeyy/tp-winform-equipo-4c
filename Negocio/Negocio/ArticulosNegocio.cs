using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //preparamos la consulta y ejecutamos el lector, mientras este lea se ejecutara lo del while
                datos.setConsulta("SELECT a.Id, Codigo, Nombre, IdMarca, IdCategoria, m.Descripcion as marca, a.Descripcion,  C.Descripcion Categoria, I.ImagenUrl UrlImagen, M.Descripcion Marca  FROM ARTICULOS A, CATEGORIAS C, IMAGENES I, MARCAS M  WHERE C.Id = A.IdCategoria AND I.IdArticulo = A.Id AND M.Id = A.IdMarca\r\n");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    // Aca rellenamos los objetos que vamos a empujar a la lista con los valores de la DB
                    // aux.prop = (tipoDato)datos.Lector["col"];
                    // --- reemplazar prop por propiedad de Articulos, tipodato por el dato esperado(como el lector devuelve
                    // --- un objeto debemos castearlo) y en col, la columna de la DB.

                    // ej-
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    //estos vienen de otras tablas(Marcas y Categoria, las relacionamos por las columnas de id)
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Imagen = new Imagenes();
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.Imagen.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    lista.Add(aux);
                }

                return lista;
            } catch (Exception ex) {
                throw ex;
            }
        }

        //Funciones para asignar a los botones del diseño
        public void Agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria) VALUES(" + nuevo.Codigo + ", " + nuevo.Nombre + ", " + nuevo.Descripcion + ", @IdMarca, @IdCategoria)");
                datos.setearParametro("@IdMarca", nuevo.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.IdCategoria);
                datos.ejecutarLectura();
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Articulos modif)
        {

        }
    }
}
