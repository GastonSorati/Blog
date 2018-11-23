using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contract
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Descripcion Tag")]
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public List<Post> Posts { get; set; }
    }
}