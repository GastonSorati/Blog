using System;

namespace Contract
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Eliminado { get; set; }
        public string Imagen { get; set; }
    }
}