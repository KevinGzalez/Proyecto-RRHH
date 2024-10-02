using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_RH__Servicios_.Services;

namespace Proyecto_RH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Servicios_Candidatos sv = new Servicios_Candidatos();
        Services_EstadosCandidatos sve = new Services_EstadosCandidatos();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.Estados = sv.Estados;
            ViewBag.estadosd = sve.ConsultaGeneral();
           /* ViewBag.Visto = sv.Estados.FirstOrDefault(x => x.Key == "Visto").Value;
            ViewBag.preseleccion = sv.Estados.FirstOrDefault(x => x.Key == "Preseleccion").Value;
            ViewBag.Entrevistado = sv.Estados.FirstOrDefault(x => x.Key == "Entrevistado").Value;
            ViewBag.Finalizado = sv.Estados.FirstOrDefault(x => x.Key == "Finalizado").Value;
            ViewBag.Descartado = sv.Estados.FirstOrDefault(x => x.Key == "Descartado").Value;
            ViewBag.Futuro = sv.Estados.FirstOrDefault(x => x.Key == "Uso en un futuro").Value;*/
            return View();
        }
    }
}
