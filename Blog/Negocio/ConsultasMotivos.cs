using Contract;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConsultasMotivos :IMotivo
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<MotivoDenuncia> ObtenerMotivosDenuncias()
        {
            var motivos = db.MotivosDenuncia;
            List<MotivoDenuncia> resultado = new List<MotivoDenuncia>();
            foreach (var item in motivos.ToList())
            {
                resultado.Add(new MotivoDenuncia()
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion
                });
            }
            return resultado;
        }
    }
}
