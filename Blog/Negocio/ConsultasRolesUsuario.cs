using Contract;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConsultasRolesUsuario: IRolesUsuario
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<RolUsuario> ObtenerRoles()
        {
            var roles = db.AspNetRoles;
            List<RolUsuario> resultado = new List<RolUsuario>();
            foreach (var item in roles.ToList())
            {
                resultado.Add(new RolUsuario()
                {
                    Id = item.Id,
                    Descripcion = item.Name
                });
            }
            return resultado;
        }
    }
}
