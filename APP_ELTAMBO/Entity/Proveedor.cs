using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string NomContacto { get; set; }
        public string CargoContacto { get; set; }
        public string Fono { get; set; }
        public string Email { get; set; }
        public int IdRegion { get; set; }
        public int IdProvincia { get; set; }
        public int IdDistrito { get; set; }
        public int IdPais { get; set; }
    }
}