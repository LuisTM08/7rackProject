using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Cupon
    {
        [DisplayName("ID")]
        public int IdCupon { get; set; }
        [DisplayName("Nombre Cupón")]
        public string NombreCupon { get; set; }
        [DisplayName("Codigo Cupón")]
        public string CodigoCupon { get; set; }
        [DisplayName("Porcentaje")]
        public int Porcentaje { get; set; }
        [DisplayName("Visibilidad")]
        public int Visibilidad { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
    }
}