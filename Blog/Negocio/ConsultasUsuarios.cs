using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace Negocio
{
    public class ConsultasUsuarios :IUsuario
    {
        BlogBDEntities db = new BlogBDEntities();

        public List<Usuario> ObtenerUsuarios()
        {           
            var usuarios = db.AspNetUsers; //activo
            List<Usuario> resultado = new List<Usuario>();
            foreach (var item in usuarios.ToList())
            {
                resultado.Add(new Usuario()
                {
                    Id = item.Id,
                    Email = item.Email,
                    EmailConfirmed = item.EmailConfirmed,
                    PasswordHash = item.PasswordHash,
                    SecurityStamp = item.SecurityStamp,
                    PhoneNumber = item.PhoneNumber,
                    PhoneNumberConfirmed = item.PhoneNumberConfirmed,
                    TwoFactorEnabled = item.TwoFactorEnabled,
                    LockoutEnabled = item.LockoutEnabled,
                    AccessFailedCount = item.AccessFailedCount,
                    UserName = item.UserName,               
                    Avatar = item.Avatar,
                    Estado = new Estado { Id = item.Estados.Id, Descripcion = item.Estados.Descripcion },
                    Rol = item.AspNetRoles.Select(x => new RolUsuario() { Id = x.Id, Descripcion = x.Name }).FirstOrDefault()
                });
            }

            return resultado;
        }

        public Usuario ObtenerUsuarioPorId(string id)
        {
            var usuario = db.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
            Usuario resultado = (usuario == null) ? null : new Usuario()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                EmailConfirmed = usuario.EmailConfirmed,
                PasswordHash = usuario.PasswordHash,
                SecurityStamp = usuario.SecurityStamp,
                PhoneNumber = usuario.PhoneNumber,
                PhoneNumberConfirmed = usuario.PhoneNumberConfirmed,
                TwoFactorEnabled = usuario.TwoFactorEnabled,
                LockoutEnabled = usuario.LockoutEnabled,
                AccessFailedCount = usuario.AccessFailedCount,
                UserName = usuario.UserName,               
                Avatar = usuario.Avatar,
                 IdEstado = usuario.IdEstado,
                 Nombre = usuario.Nombre,
                 Apellido = usuario.Apellido,
                Rol = usuario.AspNetRoles.Select(x => new RolUsuario() { Id = x.Id, Descripcion = x.Name }).FirstOrDefault()
            };

            return resultado;
        }

        public Usuario ObtenerUsuarioPorUsername(string username)
        {
            var usuario = db.AspNetUsers.Where(x => x.UserName == username).FirstOrDefault();
            Usuario resultado = (usuario == null) ? null : new Usuario()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                EmailConfirmed = usuario.EmailConfirmed,
                PasswordHash = usuario.PasswordHash,
                SecurityStamp = usuario.SecurityStamp,
                PhoneNumber = usuario.PhoneNumber,
                PhoneNumberConfirmed = usuario.PhoneNumberConfirmed,
                TwoFactorEnabled = usuario.TwoFactorEnabled,
                LockoutEnabled = usuario.LockoutEnabled,
                AccessFailedCount = usuario.AccessFailedCount,
                UserName = usuario.UserName,                
                Avatar = usuario.Avatar,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Estado = new Estado { Id = usuario.Estados.Id, Descripcion = usuario.Estados.Descripcion },
                Rol = usuario.AspNetRoles.Select(x => new RolUsuario() { Id = x.Id, Descripcion = x.Name }).FirstOrDefault()
            };

            return resultado;
        }

        public string ModificarUsuario(Usuario model, bool eliminar)
        {
            AspNetUsers usuarioActual = db.AspNetUsers.Where(x => x.Id == model.Id).SingleOrDefault();
            var rol = db.AspNetRoles.Where(x => x.Id == model.IdRol).SingleOrDefault();

            if (usuarioActual != null)
            {
                if (eliminar)
                {
                    usuarioActual.IdEstado = 3;
                }
                else
                {
                    if (model.Avatar != null)
                    {
                        usuarioActual.Avatar = model.Avatar;
                    }
                    usuarioActual.UserName = model.UserName;
                    usuarioActual.Email = model.Email;
                    usuarioActual.EmailConfirmed = model.EmailConfirmed;
                    usuarioActual.IdEstado = model.IdEstado;
                    usuarioActual.AspNetRoles.Clear();
                    usuarioActual.AspNetRoles.Add(rol);

                }
                db.SaveChanges();
            }
            return usuarioActual.Id;
        }

        public string ModificarPerfilUsuario(Usuario model)
        {
            AspNetUsers usuarioActual = db.AspNetUsers.Where(x => x.Id == model.Id).SingleOrDefault();

            if (usuarioActual != null)
            {            
                 if (model.Avatar != null)
                 {
                     usuarioActual.Avatar = model.Avatar;
                 }

                usuarioActual.UserName = model.UserName;
                usuarioActual.Nombre = model.Nombre;
                usuarioActual.Apellido = model.Apellido;


                db.SaveChanges();
            }
            return usuarioActual.Id;
        }
    }
}
