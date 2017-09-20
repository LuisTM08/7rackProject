using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;

namespace APP_ELTAMBO.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CuponController : Controller
    {
        // GET: Cupon
        CuponDAO cupon = new CuponDAO();
        UtilitarioDAO util = new UtilitarioDAO();
       
        public ActionResult Index()
        {
            List<Cupon> lista = cupon.listarCupon();
            return View(lista);
        }
        public ActionResult Create()
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cupon c)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            if (ModelState.IsValid)
            {
                cupon.registrarCupon(c);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            Cupon x = cupon.buscarCuponID(id);
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(Cupon c)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            if (ModelState.IsValid)
            {
                cupon.actualizaCupon(c);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(cupon.buscarCuponID(id));
        }
        [HttpPost ActionName("Delete")]
        public ActionResult DeleteConfirmar(int id)
        {
            if (ModelState.IsValid)
            {
                Cupon tmp = new Cupon();
                tmp.IdCupon = id;
                cupon.borrarCupon(tmp);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}