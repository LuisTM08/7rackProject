using APP_ELTAMBO.Models;
using APP_ELTAMBO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_ELTAMBO.Controllers
{
    public class HomeController : Controller
    {
        ProductoDAO pro = new ProductoDAO();
        CategoriaDAO cat = new CategoriaDAO();
        Producto producto = new Producto();
        int registros = 3;

        public ActionResult Index()
        {
            ViewBag.listarCatergorias = cat.listarCategorias();
            ViewBag.listaProducto = pro.listarProductosHome();
            ViewBag.listarSlider = pro.listarProductosPortada().ToList(); ;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //Catalogo
        public ActionResult Catalogo(int? pag = 0)
        {
            int c = pro.listarProductos().Count;
            ViewBag.registros = c % registros != 0 ? c / registros + 1 : c / registros;
            int pagact = (int)pag;
            int regini = pagact * registros;
            int regfin = regini + registros;
            var lista = pro.listarProductos();
            for (int i = regini; i < regfin; i++)
            {
                if (i == c) break;
                lista.Add(pro.listarProductos().ToList()[i]);

            }
            //ViewBag.listaProducto = pro.listarProductos();
            return View(lista);
        }
        //Por Categorias
        public ActionResult Categoria(int? id)
        {
            ViewBag.listarCatergorias = cat.listarCategorias();
            
            if (id == null)
            {
                id = 1;
            }
            List<Producto> lista = pro.listarCategoriaProductos(id);
            return View(lista);
        }

        //Buscador cabecera
        public ActionResult Buscar(string filtro)
        {
            if (filtro == null)
            {
                filtro = string.Empty;
            }
            else
            {
                ViewBag.filtro = filtro;
            }

            ViewBag.searchProducto = pro.listarSearchProductos(filtro);
            return View(pro.listarSearchProductos(filtro).ToList());
        }
        public ActionResult Producto(int id)
        {
            Producto p = pro.buscarProductoID(id);
            ViewBag.listarCatergorias = cat.listarCategorias();
            ViewBag.listarRecomendados = pro.listarProductosRecomendados();
            return View(p);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}