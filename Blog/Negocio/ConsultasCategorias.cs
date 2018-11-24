using Contract;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{

    public class ConsultasCategorias: ICategoria
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<Categoria> ObtenerTodasLasCategorias()
        {
            var categorias = db.Categorias;
            List<Categoria> resultado = new List<Categoria>();
            foreach (var item in categorias.ToList())
            {
                resultado.Add(new Categoria()
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Eliminado = item.Eliminado,
                    Imagen = item.Imagen,
                    
                });
            }
            return resultado;
        }

        public List<Categoria> ObtenerCategorias()
        {           
            var categorias = db.Categorias.Where(x => x.Eliminado == false);
            List<Categoria> resultado = new List<Categoria>();
            foreach (var item in categorias.ToList())
            {
                resultado.Add(new Categoria()
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Imagen = item.Imagen,
                });
            }
            return resultado;
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {     
            var categoria = db.Categorias.Where(x => x.Id == id).FirstOrDefault();
            Categoria resultado = (categoria == null) ? null : new Categoria()
            {
                Id = categoria.Id,
                Descripcion = categoria.Descripcion,
                Eliminado = categoria.Eliminado,
                Imagen = categoria.Imagen,
            };

            return resultado;
        }

        public int CrearCategoria(Categoria model)
        {
            Categorias nuevacategoria = new Categorias();
            nuevacategoria.Descripcion = model.Descripcion;
            nuevacategoria.Eliminado = false;
            nuevacategoria.Imagen = model.Imagen;
            db.Categorias.Add(nuevacategoria);
            db.SaveChanges();
            int idgenerado = nuevacategoria.Id;
            return (idgenerado);
        }

        public int ModificarCategoria(Categoria model, bool eliminar)
        {
            Categorias categoriaActual = db.Categorias.Where(x => x.Id == model.Id).SingleOrDefault();

            if (categoriaActual != null)
            {
                if (eliminar)
                {                   
                    categoriaActual.Eliminado = true;
                }
                else
                {
                    if (model.Imagen != null)
                    {
                        categoriaActual.Imagen = model.Imagen;
                    }
                    categoriaActual.Descripcion = model.Descripcion;
                    categoriaActual.Eliminado = model.Eliminado;
                }
                db.SaveChanges();
            }
            return categoriaActual.Id;
        }
    }
}
