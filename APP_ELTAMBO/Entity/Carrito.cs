using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Carrito
    {
        [DisplayName("Código Usuario")]
        public string IdLogin { get; set; }
        [DisplayName("Código Producto")]
        public int IdProducto { get; set; }
        [DisplayName("Descripción")]
        public string NombreProducto { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Precio/Unidad")]
        public double PrecioUnidad { get; set; }
        [DisplayName("Sub Total")]
        public double SubTotal { get; set; }
        [DisplayName("Imagen")]
        public string Imagen { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
    }
}