using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class PedidoDetalle
    {
        [DisplayName("Cod. Pedido")]
        public int IdPedido { get; set; }
        [DisplayName("Cod. Producto")]
        public int IdProducto { get; set; }
        [DisplayName("Nombre Producto")]
        public string nomProducto { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Precio Unidad")]
        public double PrecioUnidad { get; set; }
        [DisplayName("SubTotal")]
        public double SubTotal { get; set; }
        [DisplayName("Imagen")]
        public string Imagen { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
    }
}