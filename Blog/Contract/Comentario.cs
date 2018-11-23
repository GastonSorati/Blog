using Contract;
using System;

namespace Contract
{
    public class Comentario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IdUsuario { get; set; }
        public string Contenido { get; set; }
        public string Autor { get; set; }
        public int Post { get; set; }
        public int IdEstado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Estado Estado { get; set; }
    }
}