using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITag
    {
        List<Tag> ObtenerTags();
        int CrearTag(Tag model);
        Tag ObtenerTagPorId(int id);
        int ModificarTag(Tag model, bool eliminar);
    }
}
