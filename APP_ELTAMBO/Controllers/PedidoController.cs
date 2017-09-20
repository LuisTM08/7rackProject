using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;

namespace APP_ELTAMBO.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        PedidoDAO pe = new PedidoDAO();
        UtilitarioDAO util = new UtilitarioDAO();
        public ActionResult Index()
        {
            List<Pedido> pedidos = pe.listarPedidos();
            return View(pedidos);
        }
        public ActionResult Delete(int id)
        {
            return View(pe.buscarPedidoID(id));
        }
        [HttpPost ActionName("Delete")]
        public ActionResult DeleteConfirmar(int id)
        {
            if (ModelState.IsValid)
            {
                Pedido tmp = new Pedido();
                tmp.IdPedido = id;
                pe.borrarPedido(tmp);
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Details(int id)
        {
            Pedido tmp = pe.buscarPedidoID(id);
           
            return View(tmp);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.listarEstadoPago = new SelectList(util.listarEstadoPago(), "idCombo", "Descripcion");
            ViewBag.listarEstadoPedido = new SelectList(util.listaEstadoPedido(), "idCombo", "Descripcion");
            return View(pe.buscarPedidoID(id));
        }
    }
}