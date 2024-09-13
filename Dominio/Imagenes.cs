using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagenes
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string UrlImagen { get; set; }
        //para devolver directamente la UrlImagen del archivo
        public override string ToString()
        {
            return UrlImagen;
        }
    }
}
