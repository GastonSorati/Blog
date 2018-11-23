using System;
using System.Collections.Generic;

namespace Contract
{
    public class Post
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int IdCategoria { get; set; }
        public string IdAutor { get; set; }
        public int Puntaje { get; set; }
        public int IdEstado { get; set; }
        public bool Eliminado { get; set; }
        public List<int> IdTags { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        public virtual List<Comentario> Comentarios { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}