using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;

namespace APP_ELTAMBO.Controllers
{
    public class ContactoController : Controller
    {

        ContactoDAO contacto = new ContactoDAO();
        // GET: Contacto
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contacto c)
        {
            if (ModelState.IsValid)
            {
                contacto.registerMensaje(c);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}