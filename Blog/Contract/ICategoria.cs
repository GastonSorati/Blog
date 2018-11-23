using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contract
{
    public interface ICategoria
    {
        List<Categoria> ObtenerTodasLasCategorias();
        List<Categoria> ObtenerCategorias();
        Categoria ObtenerCategoriaPorId(int id);
        int CrearCategoria(Categoria model);
        int ModificarCategoria(Categoria model, bool eliminar);
    }
}
