using Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Blog.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TagsController : Controller
    {

        private readonly ITag consultasTags;
        public TagsController(ITag consultasTags)
        {
            this.consultasTags = consultasTags;
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var model = consultasTags.ObtenerTags();
            return View(model);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            var model = consultasTags.ObtenerTagPorId(id);

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
        public ActionResult Create(Tag model)
        {
            try
            {
                // TODO: Add insert logic here
                try
                {
                    var idGenerado = consultasTags.CrearTag(model);

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
            var model = consultasTags.ObtenerTagPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tag model)
        {

            try
            {
                model.Id = id;
                var idGenerado = consultasTags.ModificarTag(model, false);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
