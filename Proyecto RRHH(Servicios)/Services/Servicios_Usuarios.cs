using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_RRHH__Datos_.Models;
namespace Proyecto_RH__Servicios_.Services
{
    public class Servicios_Usuarios
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public bool ValidacionUsuario(Usuarios user)
        {
            if (DB.Usuarios.FirstOrDefault(x => x.Usuario == user.Usuario && x.Contrasena == user.Contrasena) != null)
            {
                return true;
            }
            return false;
        }

        public bool UsuarioAdmin(string user)
        {
            var model = DB.Usuarios.FirstOrDefault(x => x.Usuario == user).Rol;
            return model == "Administrador" ? true : false;
        }

    }
} 
