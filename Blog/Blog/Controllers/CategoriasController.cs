using Contract;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Blog.Controllers
{
 
    public class CategoriasController : Controller
    {
        private readonly ICategoria consultasCategorias;
        public CategoriasController(ICategoria consultasCategorias)
        {
            this.consultasCategorias = consultasCategorias;
        }


        // GET: Categorias
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var model = consultasCategorias.ObtenerTodasLasCategorias();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult _PartialCategorias()
        {
            var model = consultasCategorias.ObtenerCategorias();
            return PartialView("_PartialCategorias",model);
        }

        [AllowAnonymous]
        public ActionResult _NavigationCategorias()
        {
            var model = consultasCategorias.ObtenerCategorias();
            return PartialView("_NavigationCategorias", model);
        }

        // GET: Categorias/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id)
        {
            var model = consultasCategorias.ObtenerCategoriaPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // GET: Categorias/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Create(Categoria model, HttpPostedFileBase Imagen)
        {
            try
            {
                // TODO: Add insert logic here
                try
                {
                    if (Imagen != null)
                    {
                        WebImage img = new WebImage(Imagen.InputStream);
                        FileInfo imageninfo = new FileInfo(Imagen.FileName);

                        string nuevaimagen = Guid.NewGuid().ToString() + imageninfo.Extension;
                        img.Resize(150, 150, false);
                        img.Save("~/Imagenes/ImagenCategoria/" + nuevaimagen);
                        model.Imagen = "/Imagenes/ImagenCategoria/" + nuevaimagen;
                    }
                    var idGenerado = consultasCategorias.CrearCategoria(model);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View();
                }              
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id)
        {
            var model = consultasCategorias.ObtenerCategoriaPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Categorias/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Edit(int id, Categoria model, HttpPostedFileBase Imagen)
        {

            try
            {
                if (Imagen != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(model.Imagen)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.Imagen));
                    }
                    WebImage img = new WebImage(Imagen.InputStream);
                    FileInfo fotoinfo = new FileInfo(Imagen.FileName);

                    string nuevafoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(150, 150, false);
                    img.Save("~/Imagenes/ImagenCategoria/" + nuevafoto);
                    model.Imagen = "/Imagenes/ImagenCategoria/" + nuevafoto;
                }
                model.Id = id;
                var idGenerado = consultasCategorias.ModificarCategoria(model, false);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
