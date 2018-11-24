using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Contract;
using Microsoft.AspNet.Identity;
using Negocio;
using Blog.Models;

namespace Blog.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PostsController : Controller
    {
        private readonly IPost consultasPosts;
        private readonly ICategoria consultasCategorias;
        private readonly ITag consultasTags;
        public PostsController(IPost consultasPosts, ICategoria consultasCategorias, ITag consultasTags)
        {
            this.consultasPosts = consultasPosts;
            this.consultasCategorias = consultasCategorias;
            this.consultasTags = consultasTags;
        }

        [AllowAnonymous]
        // GET: Posts
        public ActionResult Index()
        {
            var model = consultasPosts.ObtenerPosts();
            ViewBag.SubTitle = "últimos posts";
            return View(model);
        }

        public ActionResult Admin()
        {
            var model = consultasPosts.ObtenerTodosLosPosts();
            return View(model);
        }

        [AllowAnonymous]
        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            var model = consultasPosts.ObtenerPostPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(consultasCategorias.ObtenerCategorias(), "Id", "Descripcion");

            ViewBag.Tags = new MultiSelectList(consultasTags.ObtenerTags(), "Id", "Descripcion");


            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post model, HttpPostedFileBase Imagen)
        {
            ViewBag.Categorias = new SelectList(consultasCategorias.ObtenerCategorias(), "Id", "Descripcion");

            ViewBag.Tags = new MultiSelectList(consultasTags.ObtenerTags(), "Id", "Descripcion");
            try
            {
                
                    if (Imagen != null)
                    {
                        WebImage img = new WebImage(Imagen.InputStream);
                        FileInfo imageninfo = new FileInfo(Imagen.FileName);

                        string nuevaimagen = Guid.NewGuid().ToString() + imageninfo.Extension;
                        img.Resize(900, 300, false);
                        img.Save("~/Imagenes/ImagenPosts/" + nuevaimagen);
                        model.Imagen = "/Imagenes/ImagenPosts/" + nuevaimagen;
                    }

                    var idGenerado = consultasPosts.CrearPost(new Post()
                    {
                        IdAutor = User.Identity.GetUserId(),
                        Titulo = model.Titulo,
                        Descripcion = model.Descripcion,
                        Contenido = model.Contenido,
                        Imagen = model.Imagen,
                        IdCategoria = model.IdCategoria,
                        IdTags = model.IdTags
                    });

                    return RedirectToAction("Details", new { id = idGenerado });
              
            }
            catch
            {

                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = consultasPosts.ObtenerPostPorId(id);
            ViewBag.Categorias = new SelectList(consultasCategorias.ObtenerCategorias(), "Id", "Descripcion", model.IdCategoria);
            ViewBag.Tags = new MultiSelectList(consultasTags.ObtenerTags(), "Id", "Descripcion",model.IdTags);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post model, HttpPostedFileBase Imagen)
        {
            ViewBag.Categorias = new SelectList(consultasCategorias.ObtenerCategorias(), "Id", "Descripcion", model.IdCategoria);
            ViewBag.Tags = new MultiSelectList(consultasTags.ObtenerTags(), "Id", "Descripcion",model.IdTags);
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
                    img.Resize(900, 300, false);
                    img.Save("~/Imagenes/ImagenPosts/" + nuevafoto);
                    model.Imagen = "/Imagenes/ImagenPosts/" + nuevafoto;
                }
                    model.Id = id;
                var idGenerado = consultasPosts.ModificarPost(model, false);

                return RedirectToAction("Admin");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Categorias(int id)
        {
            var model = consultasPosts.ObtenerPostsPorCategoria(id);
            var cat = consultasCategorias.ObtenerCategoriaPorId(id);
            if (model == null)

                return RedirectToAction("Index");

            ViewBag.SubTitle = cat.Descripcion;
            return View("Index", model);
        }

        [AllowAnonymous]
        public ActionResult Tags(int id)
        {
            var model = consultasPosts.ObtenerPostsPorTags(id);
            var tag = consultasTags.ObtenerTagPorId(id);

            if (model == null)
                return RedirectToAction("Index");

            ViewBag.SubTitle = tag.Descripcion;
            return View("Index", model);
        }

        [AllowAnonymous]
        public ActionResult Search()
        {
            var model = consultasPosts.ObtenerPosts();
            return View(model);
        } 
    }
}
