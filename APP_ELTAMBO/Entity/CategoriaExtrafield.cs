using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class CategoriaExtrafield
    {
        public int IdExtrafield { get; set; }
        public int IdCategoria { get; set; }
        public string Valor { get; set; }
        public string Campo { get; set; }
    }
}