using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace APP_ELTAMBO.Entity
{
    public class Producto
    {
        [DisplayName("Código")]
        public int IdProducto { get; set; }
        [DisplayName("Nombre")]
        public string NombreProd { get; set; }
        [DisplayName("Descripción")]
        public string DescripcionPro { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        [DisplayName("Precio Unitario")]
        public double PrecioUnitario { get; set; }
        
        [DisplayName("Unidades en Stock")]
        [Required(ErrorMessage = "Ingrese un stock")]
        public int Stock { get; set; }
        [DisplayName("Visibilidad")]
        public int? EnPortada { get; set; }
        [DisplayName("Categoria")]
        public int IdCategoria { get; set; }
        [DisplayName("Categoria")]
        public string NombreCategoria { get; set; }
        [DisplayName("Marca")]
        public int IdMarca { get; set; }
        [DisplayName("Marca")]
        public string NombreMarca { get; set; }
        [DisplayName("Imagen")]
        public string ImagenProducto { get; set; }
        [DisplayName("Estado")]
        public int Estado { get; set; }
    }
}