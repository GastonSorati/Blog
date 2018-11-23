using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract
{
    public interface IComentario
    {
        List<Comentario> ObtenerComentarios();
        Comentario ObtenerComentarioPorId(int id);
        int CrearComentario(Comentario model);
        int ModificarComentario(Comentario model, bool eliminar);
    }
}
