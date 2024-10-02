using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH__Datos_.Models;
using Proyecto_RH__Servicios_.Services;
using Microsoft.AspNetCore;

namespace Proyecto_RH.Controllers
{
    public class AuthenticationController : Controller
    {
        Servicios_Usuarios Sv = new Servicios_Usuarios();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuarios id)
        {
            if(Sv.ValidacionUsuario(id))
            {

                if(Sv.UsuarioAdmin(id.Usuario))
                {
                    ViewBag.usuario = "admin";
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.usuario = "estandar";
                return RedirectToAction("Index", "HomeCandidato");
            }
            ViewBag.Message = "Usuario o contraseña incorrecta";
            return View();
        }
    }
}
