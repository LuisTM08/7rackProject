using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;
using System.IO;
using System.Drawing;

namespace APP_ELTAMBO.Controllers
{
    [Authorize( Roles = "Administrador")]
    public class ProductoController : Controller
    {
        // GET: Producto
        ProductoDAO pro = new ProductoDAO();
        CategoriaDAO cat = new CategoriaDAO();
        UtilitarioDAO util = new UtilitarioDAO();
        MarcaDAO ma = new MarcaDAO();

        public ActionResult Index()
        {
            return View(pro.listarProductos());
        }
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(cat.listarCategorias(), "IdCategoria", "NombreCat");
            ViewBag.listarMedidas = new SelectList(util.enPortada(), "idCombo", "Descripcion");
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            ViewBag.Marcas = new SelectList(ma.listarMarcas(),"IdMarca", "NombreMarca");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Producto p)
        {
            ViewBag.Categorias = new SelectList(cat.listarCategorias(), "IdCategoria", "NombreCat");
            ViewBag.listarMedidas = new SelectList(util.enPortada(), "idCombo", "Descripcion");
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            ViewBag.Marcas = new SelectList(ma.listarMarcas(), "IdMarca", "NombreMarca");
            if (ModelState.IsValid)
            {
                pro.registerProducto(p);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = new SelectList(cat.listarCategorias(), "IdCategoria", "NombreCat");
            ViewBag.listarMedidas = new SelectList(util.enPortada(), "idCombo", "Descripcion");
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            ViewBag.Marcas = new SelectList(ma.listarMarcas(), "IdMarca", "NombreMarca");
            Producto p = pro.buscarProductoID(id);
            if (!String.IsNullOrEmpty(p.ImagenProducto.ToString()))
            {
                ViewBag.getImage = p.ImagenProducto;
            }
            else
            {
                ViewBag.getImage = null;
            }
            return View(p);
        }
        
        [HttpPost]
        public ActionResult Edit(Producto prod)
        {
            ViewBag.Categorias = new SelectList(cat.listarCategorias(), "IdCategoria", "NombreCat");
            ViewBag.listarMedidas = new SelectList(util.enPortada(), "idCombo", "Descripcion");
            ViewBag.listarEstado = new SelectList(util.listarEstados(), "idCombo", "Descripcion");
            ViewBag.Marcas = new SelectList(ma.listarMarcas(), "IdMarca", "NombreMarca");
            if (ModelState.IsValid)
            {
                pro.updateProducto(prod);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public JsonResult Upload(FormCollection formData)
        {

            string ruta = "~/Uploads/products/";

            if (Request.Files == null)
            {
                return Json("No existe imagen seleccionada");
            }

            var upload = Request.Files[0];
            var path = Server.MapPath(ruta);
            //Si no existe el directorio lo creamos
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //subimos y guardarmos la imagen
            string filename = Path.GetFileName(upload.FileName);

            //guardando
            upload.SaveAs(Server.MapPath(ruta) + filename);
            return Json(filename);
        }
        [HttpPost]
        public JsonResult Crop(ImageCrop img)
        {
            int x = Convert.ToInt32(img.CorX);
            int y = Convert.ToInt32(img.CorY);
            int h = Convert.ToInt32(img.CorH);
            int w = Convert.ToInt32(img.CorW);
            
            string nombreImagen = img.NombreImagen;

            string ruta = "~/Uploads/products/";
            string sourceFile = Request.MapPath(ruta + nombreImagen);
            Image oImagen = Bitmap.FromFile(sourceFile);

            Bitmap bmp = new Bitmap(w, h, oImagen.PixelFormat);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(oImagen, new Rectangle(0, 0, w, h), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
            System.Drawing.Imaging.ImageFormat frm = oImagen.RawFormat;
            oImagen.Dispose();
            string destFile = Request.MapPath(ruta + nombreImagen);
            bmp.Save(destFile, frm);
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
            return Json(baseUrl + ruta.Substring(1) + nombreImagen);
        }
        [HttpPost]
        public JsonResult Borrar(Producto producto)
        {
            Producto tmp = new Producto();
            tmp.IdProducto = producto.IdProducto;
            tmp.ImagenProducto = producto.ImagenProducto;
            var fileImagen = Path.Combine(HttpContext.Server.MapPath("~/Uploads/products/"), tmp.ImagenProducto);
            if (System.IO.File.Exists(fileImagen))
            {
                System.IO.File.Delete(fileImagen);
            }
            
            return Json(new { message = "Imagen borrar correctamente" });
        }
    }
}