using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Marca
    {
        [DisplayName("Código")]
        public int IdMarca { get; set; }
        [DisplayName("Nombre de Marca")]
        public string NombreMarca { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
    }
}