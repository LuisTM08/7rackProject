using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Categoria
    {
        [DisplayName("Código")]
        public int IdCategoria { get; set; }
        [DisplayName("Nombre Categoria")]
        public string NombreCat { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
    }
}