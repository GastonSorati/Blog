using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Negocio;
using Blog.Models;
using Contract;
using System.Web.Helpers;
using System.IO;

namespace Blog.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly IUsuario consultasUsuarios;
        private readonly IEstado consultasEstados;
        private readonly IRolesUsuario consultasRolesUsuario;
        public UsuariosController(IUsuario consultasUsuarios, IEstado consultasEstados, IRolesUsuario consultasRolesUsuario)
        {
            this.consultasUsuarios = consultasUsuarios;
            this.consultasEstados = consultasEstados;
            this.consultasRolesUsuario = consultasRolesUsuario;
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var model = consultasUsuarios.ObtenerUsuarios();
            return View(model);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            var model = consultasUsuarios.ObtenerUsuarioPorId(id);
            ViewBag.Estados = new SelectList(consultasEstados.ObtenerEstados(), "Id", "Descripcion", model.IdEstado);
            ViewBag.Roles = new SelectList(consultasRolesUsuario.ObtenerRoles(), "Id", "Descripcion",model.Rol.Id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Usuarios/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Edit(string id, Usuario model)
        {

            try
            {
                model.Id = id;
                var idGenerado = consultasUsuarios.ModificarUsuario(model, false);
                //ViewBag.Estados = new SelectList(ConsultasEstados.ObtenerEstados(), "Id", "Descripcion", model.Estado.Id);
                //ViewBag.Roles = new SelectList(ConsultasRolesUsuario.ObtenerRoles(), "Id", "Descripcion", model.Rol.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize (Roles = "Administrador, Usuario")]
        public ActionResult Details(string username)
        {
            var model = consultasUsuarios.ObtenerUsuarioPorUsername(username);
            return View(model);
        }


        [Authorize(Roles = "Administrador, Usuario")]
        public ActionResult Edit_Profile()
        {
            var id = User.Identity.GetUserId();
            var model = consultasUsuarios.ObtenerUsuarioPorId(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Users/Edit_Profile/5
        [Authorize(Roles = "Administrador, Usuario")]
        [HttpPost]
        public ActionResult Edit_Profile(Usuario model, HttpPostedFileBase Avatar)
        {

            try
            {
                if (Avatar != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(model.Avatar)))
                    {
                        System.IO.File.Delete(Server.MapPath(model.Avatar));
                    }
                    WebImage img = new WebImage(Avatar.InputStream);
                    FileInfo fotoinfo = new FileInfo(Avatar.FileName);

                    string nuevafoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(500, 500, false);
                    img.Save("~/Imagenes/ImagenUsuario/" + nuevafoto);
                    model.Avatar = "/Imagenes/ImagenUsuario/" + nuevafoto;

                }
                var id = User.Identity.GetUserId();
                model.Id = id;
                var idGenerado = consultasUsuarios.ModificarPerfilUsuario(model);
                return View(model);
            }
            catch
            {
                return View();
            }

        }

    }
}
