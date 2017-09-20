using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;

namespace APP_ELTAMBO.Controllers
{
    public class CompraController : Controller
    {
        string userID = System.Web.HttpContext.Current.User.Identity.GetUserId();
        CompraDAO compra = new CompraDAO();
        UsuarioDAO user = new UsuarioDAO();
        // GET: Compra
        public ActionResult Index()
        {
            List<DetalleCompra> lista = compra.listarCompra(userID);

            Usuario tmpuser = user.BuscarDetalleUsuarioID(userID);       
            double Total = Double.Parse("0.00");
            ViewBag.getTotal = Total;
            ViewBag.getUsuario = tmpuser;
            return View(lista);
        }
    }
}