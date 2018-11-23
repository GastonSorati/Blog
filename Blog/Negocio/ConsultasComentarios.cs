using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Datos;



namespace Negocio
{
    public class ConsultasComentarios: IComentario
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<Comentario> ObtenerComentarios()
        {
            var coment = db.Comentarios;
            List<Comentario> resultado = new List<Comentario>();
            foreach (var item in coment.ToList())
            {
                resultado.Add(new Comentario()
                {
                    Id = item.Id,
                    Usuario = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName },
                    Fecha = item.FechaPublicacion,       
                    Post = item.Post,
                    IdEstado = item.IdEstado,
                    Estado = new Estado { Id= item.Estados.Id, Descripcion = item.Estados.Descripcion },
                });
            }
            return resultado;
        }

        public Comentario ObtenerComentarioPorId(int id)
        {
            var comment = db.Comentarios.Where(x => x.Id == id).FirstOrDefault();
            Comentario resultado = (comment == null) ? null : new Comentario()
            {
                Id = comment.Id,
                Usuario = new Usuario { Id = comment.AspNetUsers.Id, UserName = comment.AspNetUsers.UserName },
                Fecha = comment.FechaPublicacion,
                Post = comment.Post,
                IdEstado = comment.IdEstado,
                Estado = new Estado { Id = comment.Estados.Id, Descripcion = comment.Estados.Descripcion },

            };

            return resultado;
        }

        public int CrearComentario(Comentario model)
        {
            Comentarios nuevocomentario = new Comentarios();
            nuevocomentario.Contenido = model.Contenido;
            nuevocomentario.Autor = model.Autor;
            nuevocomentario.FechaPublicacion = DateTime.Now;
            nuevocomentario.Post = model.Post;
            nuevocomentario.IdEstado = 1;
            db.Comentarios.Add(nuevocomentario);
            db.SaveChanges();
            int idgenerado = nuevocomentario.Id;
            return (idgenerado);
        }

        public int ModificarComentario(Comentario model, bool eliminar)
        {
            Comentarios comentarioActual = db.Comentarios.Where(x => x.Id == model.Id && x.Post == model.Post).SingleOrDefault();

            if (comentarioActual != null)
            {
                if (eliminar)
                {
                    comentarioActual.IdEstado = 4;

                }                   
                else
                {

                    comentarioActual.FechaPublicacion = model.Fecha;
                    comentarioActual.Post = model.Post;
                    comentarioActual.IdEstado = model.IdEstado;
                }
                db.SaveChanges();
            }
            return comentarioActual.Post;
        }
    }
   
}
