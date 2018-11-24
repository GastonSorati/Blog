using Contract;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class ConsultasTags: ITag
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<Tag> ObtenerTags()
        {
            var tags = db.Tags;
            List<Tag> resultado = new List<Tag>();
            foreach (var item in tags.ToList())
            {

                resultado.Add(new Tag()
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Posts = item.Posts.Select(x => new Post() { Id = x.Id}).ToList()
                });
            }
            return resultado;
        }

        public Tag ObtenerTagPorId(int id)
        {
            var tag = db.Tags.Where(x => x.Id == id).FirstOrDefault();
            Tag resultado = (tag == null) ? null : new Tag()
            {
                Id = tag.Id,
                Descripcion = tag.Descripcion,

            };

            return resultado;
        }

        public int CrearTag(Tag model)
        {
            Tags nuevatag = new Tags();
            nuevatag.Descripcion = model.Descripcion;
            db.Tags.Add(nuevatag);
            db.SaveChanges();
            int idgenerado = nuevatag.Id;
            return (idgenerado);
        }

        public int ModificarTag(Tag model, bool eliminar)
        {
            Tags tagActual = db.Tags.Where(x => x.Id == model.Id).SingleOrDefault();

            if (tagActual != null)
            {
                if (eliminar)
                {
                    //tagActual.Eliminado = true;
                }
                else
                {
                    tagActual.Descripcion = model.Descripcion;
                }
                db.SaveChanges();
            }
            return tagActual.Id;
        }
    }
}
