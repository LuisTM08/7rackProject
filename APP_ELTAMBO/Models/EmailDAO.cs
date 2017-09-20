using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using FluentEmail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace APP_ELTAMBO.Models
{
    public class EmailDAO
    {
        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.liva.com  puerto:25
         */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        public EmailDAO()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("aragcar@gmail.com", "chamilo2.0");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
        public MailMessage mensajeCorreo(string asunto, string email, string mensaje)
        { 
            MailMessage msg = new MailMessage();
            msg.Subject = asunto;
            msg.To.Add(new MailAddress(email));
            msg.From = new MailAddress("pedidos@eltambo.pe", "EL TAMBO +");
            msg.Body = mensaje;
            return msg;
            
        }
        
    }
}