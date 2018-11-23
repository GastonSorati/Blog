using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract
{
    public interface IUsuario
    {
        List<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuarioPorId(string id);
        Usuario ObtenerUsuarioPorUsername(string username);
        string ModificarUsuario(Usuario model, bool eliminar);
        string ModificarPerfilUsuario(Usuario model);
    }
}
