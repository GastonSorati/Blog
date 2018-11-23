using Contract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public int IdEstado { get; set; }
        public string IdRol { get; set; }


        public virtual Estado Estado { get; set; }
        public virtual RolUsuario Rol { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<ComentarioDenunciado> ComentariosDenunciados { get; set; }
        public virtual ICollection<Post> Posts { get; set; }


    }
}
