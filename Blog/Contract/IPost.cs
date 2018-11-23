using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IPost
    {
        List<Post> ObtenerPosts();
        List<Post> ObtenerTodosLosPosts();
        List<Post> ObtenerPostsPorCategoria(int id);
        List<Post> ObtenerPostsPorTags(int id);
        Post ObtenerPostPorId(int id);
        int CrearPost(Post model);
        int ModificarPost(Post model, bool eliminar);
    }
}
