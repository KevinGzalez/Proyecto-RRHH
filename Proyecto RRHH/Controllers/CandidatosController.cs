using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RH__Servicios_.Services;

namespace Proyecto_RH.Controllers
{
    public class CandidatosController : Controller
    {
        Servicios_Candidatos sv = new Servicios_Candidatos();
        Services_EstadosCandidatos sve = new Services_EstadosCandidatos();
        Servicios_Vacantes svv = new Servicios_Vacantes();
        [HttpGet]
        public IActionResult Index()
        {
            var Model = sv.ConsultaGeneral();
            ViewBag.estadosd = sve.ConsultaGeneral();
            ViewBag.vacantesd = svv.ConsultaGeneral();

            return View(Model);
        }

        [HttpPost]
        public IActionResult Index(int? vacante, int? estado)
        {
            var Model = sv.ConsultaPorCriterios(vacante, estado);
            ViewBag.estadosd = sve.ConsultaGeneral();
            ViewBag.vacantesd = svv.ConsultaGeneral();
            return View(Model);
        }

        public IActionResult Detail(int id)
        {
            var Model = sv.ConsultaPorCodigo(id);
            ViewBag.idiomas = sv.ConsultaIdiomas(id);
            ViewBag.competencias = sv.CandidatoCompetencias(id);
            ViewBag.capacitaciones = sv.CandidatoCapacitaciones(id);
            ViewBag.experiencias = sv.CandidatoExperiencia(id);
            return View(Model);
        }

        public IActionResult Categorizar(int id, string estado)
        {
            sv.ColocarEstado(id, estado);
            return RedirectToAction("Index");
        }
    }
}
