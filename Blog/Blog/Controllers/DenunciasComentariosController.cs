using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contract;
using Microsoft.AspNet.Identity;
using Negocio;

namespace Blog.Controllers
{
    [Authorize]
    public class DenunciasComentariosController : Controller
    {

        private readonly IDenuncia consultasDenuncias;
        private readonly IMotivo consultasMotivos;
        public DenunciasComentariosController(IDenuncia consultasDenuncias, IMotivo consultasMotivos)
        {
            this.consultasDenuncias = consultasDenuncias;
            this.consultasMotivos = consultasMotivos;
        }

        public ActionResult Index()
        {
            var model = consultasDenuncias.ObtenerComentariosDenunciados();
            return View(model);
        }
        // GET: Denuncias/Create
        public ActionResult Create()
        {
            ViewBag.Motivos = new SelectList(consultasMotivos.ObtenerMotivosDenuncias(), "Id", "Descripcion");
            return View();
        }

        // POST: Denuncias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioDenunciado model,int IdComentario, int IdPost)
        {
            ConsultasDenuncias consultasdenuncias = new ConsultasDenuncias();
            var IdDenunciante = User.Identity.GetUserId();       
            model.IdUsuario = IdDenunciante;
            model.IdComentario = IdComentario;
            var idgenerado = consultasdenuncias.CrearDenunciaComentario(model);
            //return View(model);

            return RedirectToAction("Details", "Posts", new { id = IdPost });

        }

        public ActionResult CrearDenunciaComentario(string descripcion, int id, int motivo)
        {
            ConsultasDenuncias consultasdenuncias = new ConsultasDenuncias();
            var IdDenunciante = User.Identity.GetUserId();
            ComentarioDenunciado model = new ComentarioDenunciado();
            model.IdUsuario = IdDenunciante;
            model.Descripcion = descripcion;
            model.IdComentario = id;
            model.IdMotivo = motivo;
            var idgenerado = consultasdenuncias.CrearDenunciaComentario(model);

            return RedirectToAction("Details", "Posts" /*new { id = idpost }*/);
        }

    }
}
