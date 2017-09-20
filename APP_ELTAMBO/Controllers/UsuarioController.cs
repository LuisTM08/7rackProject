using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.Mvc;
using APP_ELTAMBO.Entity;
using APP_ELTAMBO.Models;
using System.IO;
using System.Diagnostics;


namespace APP_ELTAMBO.Controllers
{
    
    public class UsuarioController : Controller
    {
        // GET: Usuario
        UsuarioDAO user = new UsuarioDAO();
        UbigeoDAO ubigeo = new UbigeoDAO();
        UtilitarioDAO util = new UtilitarioDAO();

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(user.ListarUsuarios());
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult DetalleUsuario(string idLogin) {
            Usuario xUser = user.BuscarDetalleUsuarioID(idLogin);
            if (!String.IsNullOrEmpty(xUser.Avatar.ToString()))
            {
                ViewBag.getImage = Url.Content("~/Uploads/users/") + xUser.Avatar;
            }
            else
            {
                ViewBag.getImage = Url.Content("~/images/avatar-user.svg");
            }
            return View(xUser);
        }
        public ActionResult buscarProvincia(int region)
        {
            var provincias = ubigeo.listarProvincia(region);
            return Json(provincias, JsonRequestBehavior.AllowGet);
        }
        public ActionResult buscarDistrito(int provincia)
        {
            var distritos = ubigeo.listarDistrito(provincia);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Edit(string IdLogin)
        {
            ViewBag.listarRegion = new SelectList(ubigeo.listarRegion(), "IdRegion", "NombreRegion");
            ViewBag.listarSexo = new SelectList(user.getSexo(), "idCombo", "Descripcion");
            Usuario xUser = user.BuscarUsuarioPorID(IdLogin);
            ViewBag.getEmail = xUser.Email;
            if (!String.IsNullOrEmpty(xUser.Avatar.ToString()))
            {
                ViewBag.getImage = Url.Content("~/Uploads/users/") + xUser.Avatar;
            }
            else
            {
                ViewBag.getImage = Url.Content("~/images/avatar-user.svg");
            }
            return View(xUser);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Usuario a)
        {
            ViewBag.listarSexo = new SelectList(user.getSexo(), "idCombo", "Descripcion");
            ViewBag.listarRegion = new SelectList(ubigeo.listarRegion(), "IdRegion", "NombreRegion");
            ViewBag.getIDRegion = a.IdRegion;
            ViewBag.getIDProvincia = a.IdProvincia;
            ViewBag.getIDDistrito = a.IdDistrito;
            Usuario xUser = user.BuscarUsuarioPorID(a.IdLogin);
            ViewBag.getEmail = xUser.Email;
            if (!String.IsNullOrEmpty(xUser.Avatar.ToString()))
            {
                ViewBag.getImage = Url.Content("~/Uploads/users/") + xUser.Avatar;
            }
            else
            {
                ViewBag.getImage = Url.Content("~/images/avatar-user.svg");
            }
            user.UpdateUser(a);
            return View();
        }
        [HttpPost]
        public JsonResult Upload(FormCollection formData) {

            string idUser = formData["userIDLogin"];
            Usuario a = user.BuscarUsuarioPorID(idUser);
            string ruta = "~/Uploads/users/";

            if (Request.Files == null)
            {
                return Json("No existe imagen seleccionada");
            }

            var upload = Request.Files[0];
            var path = Server.MapPath(ruta);
            //Si no existe el directorio lo creamos
            if (!Directory.Exists(path)) {
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
            Usuario a = user.BuscarUsuarioPorID(img.userID);
            string nombreImagen = img.NombreImagen;

            string ruta = "~/Uploads/users/"; 
            string sourceFile = Request.MapPath(ruta + nombreImagen);
            Image oImagen = Bitmap.FromFile(sourceFile);

            Bitmap bmp = new Bitmap(w,h, oImagen.PixelFormat);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(oImagen, new Rectangle(0, 0, w, h), new Rectangle(x, y,w, h), GraphicsUnit.Pixel);
            System.Drawing.Imaging.ImageFormat frm = oImagen.RawFormat;
            oImagen.Dispose();
            string destFile = Request.MapPath(ruta + nombreImagen);
            util.insertImageUser(img.userID, nombreImagen);
            bmp.Save(destFile, frm);
            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/');
            return Json(baseUrl + ruta.Substring(1) + nombreImagen);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string idLogin)
        {
            Usuario userDelete = user.BuscarDetalleUsuarioID(idLogin);
            
            return View(userDelete);
        }
        [HttpPost ActionName("Delete")]
        public ActionResult DeleteConfirmar(string idLogin)
        {
            if (ModelState.IsValid)
            {
                Usuario tmp = new Usuario();
                tmp.IdLogin = idLogin;
                user.Detele(tmp);
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}