using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Datos;

namespace Negocio
{
    public class ConsultasPosts :IPost
    {

        BlogBDEntities db = new BlogBDEntities();      
        ConsultasCategorias consultasCategorias = new ConsultasCategorias();
        ConsultasTags consultasTags = new ConsultasTags();

        public List<Post> ObtenerPosts()
        {            
            var posts = db.Posts.Where(x => x.Eliminado == false).OrderByDescending(x => x.FechaPublicacion);
            List<Post> resultado = new List<Post>();
            List<Tag> listTag = new List<Tag>();
            foreach (var item in posts.ToList())
            {
                resultado.Add(new Post()
                {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Contenido = item.Contenido,
                    FechaPublicacion = item.FechaPublicacion,
                    Descripcion = item.Descripcion,
                    Categoria = new Categoria { Id = item.Categorias.Id, Descripcion = item.Categorias.Descripcion },
                    Autor = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName, Avatar = item.AspNetUsers.Avatar },
                    Imagen = item.Imagen,
                    Eliminado = item.Eliminado,
                    Tags = item.Tags.Select(x => new Tag() { Id = x.Id, Descripcion = x.Descripcion }).ToList()
                });
            }
            return resultado;
        }

        public List<Post> ObtenerTodosLosPosts()
        {
            var posts = db.Posts.OrderByDescending(x => x.FechaPublicacion);
            List<Post> resultado = new List<Post>();
            List<Tag> listTag = new List<Tag>();
            foreach (var item in posts.ToList())
            {
                resultado.Add(new Post()
                {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Contenido = item.Contenido,
                    FechaPublicacion = item.FechaPublicacion,
                    Descripcion = item.Descripcion,
                    Categoria = new Categoria { Id = item.Categorias.Id, Descripcion = item.Categorias.Descripcion },
                    Autor = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName, Avatar = item.AspNetUsers.Avatar },
                    Imagen = item.Imagen,
                    Eliminado = item.Eliminado,
                    Tags = item.Tags.Select(x => new Tag() { Id = x.Id, Descripcion = x.Descripcion }).ToList()
                });
            }
            return resultado;
        }

        public List<Post> ObtenerPostsPorCategoria(int id)
        {
            var posts = db.Posts.Where(x => x.IdCategoria == id && x.Eliminado == false).OrderByDescending(x => x.FechaPublicacion);
            List<Post> resultado = new List<Post>();
            foreach (var item in posts.ToList())
            {
                resultado.Add(new Post()
                {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Contenido = item.Contenido,
                    FechaPublicacion = item.FechaPublicacion,
                    Descripcion = item.Descripcion,
                    Categoria = new Categoria { Id = item.Categorias.Id, Descripcion = item.Categorias.Descripcion },
                    Autor = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName, Avatar = item.AspNetUsers.Avatar },
                    Imagen = item.Imagen,
                    Eliminado = item.Eliminado
                });
            }
            return resultado;
        }

        public List<Post> ObtenerPostsPorTags(int id)
        {
            var posts = db.Posts.Where(x => x.Eliminado == false && x.Tags.Any(t => t.Id == id)).OrderByDescending(x => x.FechaPublicacion);

            List<Post> resultado = new List<Post>();
            foreach (var item in posts.ToList())
            {
                resultado.Add(new Post()
                {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Contenido = item.Contenido,
                    FechaPublicacion = item.FechaPublicacion,
                    Descripcion = item.Descripcion,
                    Categoria = new Categoria { Id = item.Categorias.Id, Descripcion = item.Categorias.Descripcion },
                    Autor = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName, Avatar = item.AspNetUsers.Avatar },
                    Imagen = item.Imagen,
                    Eliminado = item.Eliminado
                });
            }
            return resultado;
        }

        public Post ObtenerPostPorId(int id)
        {
            List<Tag> listTag = new List<Tag>();
            var post = db.Posts.Where(x => x.Id == id).FirstOrDefault();
            Post resultado = (post == null) ? null : new Post()
            {
                Id = post.Id,
                Titulo = post.Titulo,
                Contenido = post.Contenido,
                FechaPublicacion = post.FechaPublicacion,
                Descripcion = post.Descripcion,
                Comentarios = post.Comentarios.Where(x=>x.Estados.Descripcion == "Activo").Select(x => new Comentario() { Id = x.Id, Contenido = x.Contenido, Usuario = new Usuario() {UserName = x.AspNetUsers.UserName, Avatar = x.AspNetUsers.Avatar }, Fecha = x.FechaPublicacion }).ToList(),
                IdCategoria = post.IdCategoria,
                Autor = new Usuario { Id = post.AspNetUsers.Id, UserName = post.AspNetUsers.UserName, Avatar = post.AspNetUsers.Avatar },
                Imagen = post.Imagen,
                Eliminado = post.Eliminado,
                Tags = post.Tags.Select(x => new Tag() { Id = x.Id, Descripcion = x.Descripcion }).ToList()
            };

            return resultado;
        }

        public int CrearPost(Post model)
        {
            Posts nuevopost = new Posts();
            nuevopost.Titulo = model.Titulo;
            nuevopost.Contenido = model.Contenido;
            nuevopost.Descripcion = model.Descripcion;
            nuevopost.FechaPublicacion = DateTime.Now;
            nuevopost.Eliminado = false;
            nuevopost.Autor = model.IdAutor;
            nuevopost.IdCategoria = model.IdCategoria;
            nuevopost.Imagen = model.Imagen;
            db.Posts.Add(nuevopost);
            if (model.IdTags.Count != 0)
            {
                foreach (var item in model.IdTags)
                {
                    Tags tag = db.Tags.Where(t => t.Id == item).First();
                    nuevopost.Tags.Add(tag);
                }
                db.Posts.Add(nuevopost);
            }
            db.SaveChanges();
            int idgenerado = nuevopost.Id;
            return (idgenerado);
        }

        public int ModificarPost(Post model, bool eliminar)
        {
            Posts postActual = db.Posts.Where(x => x.Id == model.Id).SingleOrDefault();

            if (postActual != null)
            {
                if (eliminar)
                {
                    postActual.Eliminado = true;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        postActual.Imagen = model.Imagen;
                    }

                    if (model.IdTags != null)
                    {
                        postActual.Tags.Clear();
                        foreach (var item in model.IdTags)
                        {
                            Tags tag = db.Tags.Where(t => t.Id == item).First();
                            postActual.Tags.Add(tag);
                        }
                    }
                    postActual.Descripcion = model.Descripcion;
                    postActual.IdCategoria = model.IdCategoria;
                    postActual.Titulo = model.Titulo;
                    postActual.Contenido = model.Contenido;
                    postActual.FechaPublicacion = model.FechaPublicacion;
                    postActual.Eliminado = model.Eliminado;

                }
                db.SaveChanges();
            }
            return postActual.Id;
        }
    }
}

