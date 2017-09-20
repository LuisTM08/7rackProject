using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class DetalleCompra
    {
        [DisplayName("Código Usuario")]
        public string IdLogin { get; set; }
        [DisplayName("Código Producto")]
        public int IdProducto { get; set; }
        [DisplayName("Producto")]
        public string NombreProducto { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Fecha Pedido")]
        public string FechaPedido { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Total")]
        public double Total { get; set; }
    }
}