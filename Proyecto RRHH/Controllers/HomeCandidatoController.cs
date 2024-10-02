using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_RRHH.Controllers
{
    public class HomeCandidatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
