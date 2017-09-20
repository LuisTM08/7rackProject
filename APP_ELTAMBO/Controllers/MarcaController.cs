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
    public class MarcaController : Controller
    {
        // GET: Marca
        MarcaDAO m = new MarcaDAO();
        UtilitarioDAO util = new UtilitarioDAO();
        public ActionResult Index()
        {
            return View(m.listarMarcas());
        }
        public ActionResult Create()
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Marca a)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");

            if (ModelState.IsValid)
            {
                m.insertMarca(a);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            return View(m.buscarMarcaID(id));
        }
        [HttpPost]
        public ActionResult Edit(Marca a)
        {
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            if (ModelState.IsValid)
            {
                m.updateMarca(a);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(m.buscarMarcaID(id));
        }
        [HttpPost ActionName("Delete")]
        public ActionResult DeleteConfirmar(int id)
        {
            if (ModelState.IsValid)
            {
                Marca tmp = new Marca();
                tmp.IdMarca = id;
                m.deleteMarca(tmp);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}