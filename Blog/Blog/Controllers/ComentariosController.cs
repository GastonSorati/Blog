using Contract;
using Microsoft.AspNet.Identity;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ComentariosController : Controller
    {

        private readonly IComentario consultasComentarios;
        private readonly IEstado consultasEstados;
        public ComentariosController(IComentario consultasComentarios, IEstado consultasEstados)
        {
            this.consultasComentarios = consultasComentarios;
            this.consultasEstados = consultasEstados;
        }
        // GET: Comentarios
        public ActionResult Index()
        {
            var model = consultasComentarios.ObtenerComentarios();
            return View(model);         
        }

        public ActionResult Edit(int id)
        {          
            var model = consultasComentarios.ObtenerComentarioPorId(id);
            ViewBag.Estados = new SelectList(consultasEstados.ObtenerEstados(), "Id", "Descripcion", model.IdEstado);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, Comentario model)
        {
            ViewBag.Estados = new SelectList(consultasEstados.ObtenerEstados(), "Id", "Descripcion", model.IdEstado);
            try
            {
                model.Id = id;
                var idGenerado = consultasComentarios.ModificarComentario(model, false);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public JsonResult CrearComentario(string comentario, int IdPost)
        {
            ConsultasComentarios consultascomentarios = new ConsultasComentarios();
            var IdAutor = User.Identity.GetUserId();

            Comentario model = new Comentario();
            model.Autor = IdAutor;
            model.Contenido = comentario;
            model.Post = IdPost;
            var idgenerado = consultascomentarios.CrearComentario(model);
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult EliminarComentario(int IdComentario, int IdPost)
        {
            ConsultasComentarios consultascomentarios = new ConsultasComentarios();

            Comentario model = new Comentario();
            model.Id = IdComentario;
            model.Post = IdPost;
            var idgenerado = consultascomentarios.ModificarComentario(model,true);
            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}