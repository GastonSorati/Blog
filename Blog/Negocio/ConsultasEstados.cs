using Contract;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConsultasEstados :IEstado
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<Estado> ObtenerEstados()
        {
            var estados = db.Estados;
            List<Estado> resultado = new List<Estado>();
            foreach (var item in estados.ToList())
            {
                resultado.Add(new Estado()
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion
                });
            }
            return resultado;
        }
    }
}
