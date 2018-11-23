using Contract;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CategoriasController : Controller
    {
        private readonly ICategoria consultasCategorias;
        public CategoriasController(ICategoria consultasCategorias)
        {
            this.consultasCategorias = consultasCategorias;
        }
     
       
        // GET: Categorias
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
        public ActionResult Details(int id)
        {
            var model = consultasCategorias.ObtenerCategoriaPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria model, HttpPostedFileBase Imagen)
        {
            try
            {
                // TODO: Add insert logic here
                try
                {
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
        public ActionResult Edit(int id)
        {
            var model = consultasCategorias.ObtenerCategoriaPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria model)
        {

            try
            {
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
