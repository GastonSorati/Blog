using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostViewModels
    {
        [Display(Name = "Título")]
        [Required (ErrorMessage = "Titulo Requerido")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Descripción Requerida")]
        public string Descripcion { get; set; }

        [Display(Name = "Contenido")]
        [Required(ErrorMessage = "Contenido Requerido")]
        public string Contenido { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "Categoría Requerida")]
        public int IdCategoria { get; set; }

        [Display(Name = "Imágen")]
        [Required(ErrorMessage = "Imágen Requerida")]
        public string Imagen { get; set; }

        [Display(Name = "Tags Asociados")]
        public List<int> IdTags { get; set; }
    }
}