using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Pedido
    {
        [DisplayName("ID")]
        public int IdPedido { get; set; }
        [DisplayName("Código Usuario")]
        public string IdUsuario { get; set; }
        [DisplayName("Fecha Pedido")]
        public string FechaPedido { get; set; }
        [DisplayName("Fecha Entrega")]
        public string FechaEntrega { get; set; }
        [DisplayName("Fecha Envio")]
        public string FechaEnvio { get; set; }
        [DisplayName("SubTotal")]
        public double SubTotal { get; set; }
        [DisplayName("Total")]
        public double Total { get; set; }
        [DisplayName("Costo Envio")]
        public double Envio { get; set; }
        [DisplayName("Descuento")]
        public double Descuento { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Referencias")]
        public string Referencia { get; set; }
        [DisplayName("Distrito")]
        public string Distrito { get; set; }
        [DisplayName("Provincia")]
        public string Provincia { get; set; }
        [DisplayName("Región")]
        public string Region { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
        [DisplayName("Estado de Pago")]
        public int Pago { get; set; }

        public List<PedidoDetalle> listaProductos { get; set; }
        [DisplayName("Cliente")]
        public string nombreUsuario { get; set; }
    }
}