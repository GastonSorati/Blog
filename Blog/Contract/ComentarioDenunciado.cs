using System;

namespace Contract
{
    public class ComentarioDenunciado
    {
        public int Id { get; set; }
        public Nullable<int> IdComentario { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<int> IdMotivo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Descripcion { get; set; }

        public virtual MotivoDenuncia Motivo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Comentario Comentario { get; set; }
    }
}