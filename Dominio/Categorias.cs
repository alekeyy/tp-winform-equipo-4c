﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        //cambio el to string
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
