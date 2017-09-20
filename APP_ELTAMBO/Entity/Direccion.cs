using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string LugarDireccion { get; set; }
        public int TipoDireccion { get; set; }
        public string Urbanizacion { get; set; }
        public int IdRegion { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public string Referencia { get; set; }
        public int DirFactura { get; set; }

    }
}