using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;
using System.Net.Mail;
using FluentEmail;
using System.Threading.Tasks;

namespace APP_ELTAMBO.Controllers
{
    [Authorize]
    public class CarritoController : Controller
    {
        // GET: Carrito
        string userID = System.Web.HttpContext.Current.User.Identity.GetUserId();
        CarritoDAO shop = new CarritoDAO();
        ProductoDAO pro = new ProductoDAO();
        CuponDAO cup = new CuponDAO();
        UsuarioDAO user = new UsuarioDAO();
        PedidoDAO pe = new PedidoDAO();
        EmailDAO email = new EmailDAO();
        //twilioDAO sms = new twilioDAO();
        public ActionResult Index()
        {
            List<Carrito> lista = shop.listarCarrito(userID);

            Usuario tmpuser = user.BuscarDetalleUsuarioID(userID);

            double subTotal =  Double.Parse("0.00");
            double costoEnvio = Double.Parse("5.00");
            double Descuento = Double.Parse("0.00");
            double Total = Double.Parse("0.00");
            foreach (var item in lista)
            {
                subTotal = item.SubTotal + subTotal;
            }
            Total = (subTotal + costoEnvio) - Descuento;
            ViewBag.getSubTotal = subTotal;
            ViewBag.getEnvio = costoEnvio;
            ViewBag.getDescuento = Descuento;
            ViewBag.getTotal = Total;
            ViewBag.getUsuario = tmpuser;
            return View(lista);
        }
        public async Task<ActionResult> DetalleCompra()
        {
            Usuario tmp = user.BuscarUsuarioPorID(userID);
            
            Pedido miPedido = pe.MiPedido(userID);
            miPedido.nombreUsuario = tmp.Nombre + "," + tmp.Apellido;
            miPedido.listaProductos = pe.detallePedido(miPedido.IdPedido);
            ViewBag.ListaProducto = miPedido.listaProductos;
            ViewBag.nombreUsuario = miPedido.nombreUsuario;

            //Enviamos correo de forma asincrona
            var tarea = Task.Run(() => {
                var correo = Email.From("aragcar@gmail.com")
                 .To(tmp.Email)
                 .Subject("Pedido realizado - El Tambo +")
                 .UsingTemplateFromFile(Server.MapPath(@"~/Templates/EmailTemplate.cshtml"), miPedido);
                //envido de mensaje al administrador 
                //sms.enviarSMS("+51954189939", "Se realizo una compra...");
                correo.SendAsync((sender, e) => {
                    Console.WriteLine("Email enviado");
                });
            });
            await tarea;


            return View(miPedido);
        }
        [AllowAnonymous]
        public JsonResult AgregarProducto(int idProducto)
        {
            if (userID == null)
            {
                return Json(new { message = "<i class='fa fa-info-circle' aria-hidden='true'></i> Debe registrarse o iniciar sesión para comprar" });
            }
            else
            {
                Producto tmp = pro.buscarProductoID(idProducto);
                shop.insertarItem(tmp, 1, userID);
                return Json(new { message = "<i class='fa fa-plus' aria-hidden='true'></i> El producto fue añadido al carrito" });
            }
           }
        public JsonResult AumentarItem(int idProducto, int cantidad)
        {
            Producto tmp = pro.buscarProductoID(idProducto);
            shop.aumentarItem(tmp, cantidad, userID);
            return Json(new { message = "<i class='fa fa-plus' aria-hidden='true'></i> La cantidad fue aumentada" });
        }
        public JsonResult TotalItems()
        {
            string x = shop.totalItems(userID);
            return Json(new { total = x });
        }
        public JsonResult quitarProducto(int IdProducto)
        {
            shop.quitarItem(IdProducto, userID);
            return Json(new { message = "El producto seleccionado fue eliminado de la lista" });
        }
        public JsonResult aplicarCupon(string CodigoCupon)
        {
            Cupon x = cup.buscarCuponTexto(CodigoCupon);
            cup.asignarCuponUser(x,userID);
            return Json(new { message = "Haz aplicado tu cupón de descuento" });
        }

        public JsonResult crearPedido(double subtotal, double total, double envio)
        {
            Usuario usertmp = user.BuscarDetalleUsuarioID(userID);
            List<Carrito> listaCarrito = shop.listarCarrito(userID);
            Pedido tmp = new Pedido();
            tmp.IdUsuario = userID;
            tmp.SubTotal = subtotal;
            tmp.Total = total;
            tmp.Envio = envio;
            tmp.Descuento = 0.00;
            tmp.Direccion = usertmp.Direccion;
            tmp.Referencia = usertmp.Referencia;
            tmp.Distrito = usertmp.NombreDistrito;
            tmp.Provincia = usertmp.NombreProvincia;
            tmp.Region = usertmp.NombreRegion;

            if (ModelState.IsValid)
            {
               int idPedidoActual = pe.insertarPedido(tmp);
                foreach (Carrito item in listaCarrito)
                {
                    pe.insertarDetalle(idPedidoActual, item);
                }
                shop.vaciarCarrito(tmp.IdUsuario);

                return Json(new { url = "Carrito/DetalleCompra" });
            }
            return Json(new { url = "Error al procesar el pedido" });
        }
    }
}