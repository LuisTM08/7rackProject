using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace APP_ELTAMBO.Entity
{
    public class Usuario
    {
        [DisplayName("Código")]
        public int IdUsuario { get; set; }
        public string IdLogin { get; set; }
        [DisplayName("Nombres")]
        public string Nombre { get; set; }
        [DisplayName("Apellidos")]
        public string Apellido { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Sexo")]
        public string Sexo { get; set; }
        [DisplayName("DNI")]
        public string DNI { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public string FechaNacimiento { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        [DisplayName("Referencias")]
        public string Referencia { get; set; }
        [DisplayName("Región")]
        public int IdRegion { get; set; }
        [DisplayName("Región")]
        public string NombreRegion { get; set; }
        [DisplayName("Provincia")]
        public int IdProvincia { get; set; }
        [DisplayName("Provincia")]
        public string NombreProvincia { get; set; }
        [DisplayName("Distrito")]
        public int IdDistrito { get; set; }
        [DisplayName("Distrito")]
        public string NombreDistrito { get; set; }
        public string Avatar { get; set; }
    }
}