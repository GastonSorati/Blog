using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Datos;

namespace Negocio
{
    public class ConsultasDenuncias: IDenuncia
    {
        BlogBDEntities db = new BlogBDEntities();

       public List<ComentarioDenunciado> ObtenerComentariosDenunciados()
        {
            var coment = db.ComentariosDenunciados;
            List<ComentarioDenunciado> resultado = new List<ComentarioDenunciado>();
            foreach (var item in coment.ToList())
            {
                resultado.Add(new ComentarioDenunciado()
                {
                    Id = item.Id,
                    Usuario = new Usuario { Id = item.AspNetUsers.Id, UserName = item.AspNetUsers.UserName },
                    Fecha = item.Fecha,
                    Comentario = new Comentario { Id = item.Comentarios.Id,Post=item.Comentarios.Post ,Autor=item.Comentarios.AspNetUsers.UserName},
                    Motivo = new MotivoDenuncia { Descripcion = item.MotivosDenuncia.Descripcion },
                    Descripcion = item.Descripcion
                });
            }
            return resultado;
        }

        public int CrearDenunciaComentario(ComentarioDenunciado model)
        {
            ComentariosDenunciados nuevocomentdenuncia = new ComentariosDenunciados();

            nuevocomentdenuncia.Usuario = model.IdUsuario;
            nuevocomentdenuncia.Fecha = DateTime.Now;
            nuevocomentdenuncia.IdComentario = model.IdComentario;
            nuevocomentdenuncia.Motivo = model.IdMotivo;
            nuevocomentdenuncia.Descripcion = model.Descripcion;
            db.ComentariosDenunciados.Add(nuevocomentdenuncia);
            db.SaveChanges();
            if (db.ComentariosDenunciados.Where(x => x.IdComentario == model.IdComentario).ToList().Count > 5)
            {
                var comentario = db.Comentarios.Where(x => x.Id == model.IdComentario).FirstOrDefault();
                comentario.IdEstado = 2;
                db.SaveChanges();
            }
            var idgenerado = nuevocomentdenuncia.Id;
            return (idgenerado);

        }

    }
}
