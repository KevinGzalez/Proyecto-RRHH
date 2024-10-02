using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_RRHH__Datos_.Models;
using Proyecto_RH__Servicios_.Services;

namespace Proyecto_RH.Controllers
{
    public class VacantesController : Controller
    {
        Servicios_Vacantes sv = new Servicios_Vacantes();
        Servicios_Departamentos svd = new Servicios_Departamentos();
        Servicios_Estados sve = new Servicios_Estados();
        [HttpGet]
        public IActionResult Index()
        {
            var Model = sv.ConsultaGeneral();
            return View(Model);
        }

        [HttpGet]
        public  IActionResult Edit(int id)
        {
             var Model = sv.ConsultaPorCodigo(id);
             List<Departamentos> Departamentos = svd.ConsultaGeneral();
             List<Estados> Estados = sve.ConsultaGeneral();
             IDictionary<int, string> DepartamentosD = new Dictionary<int, string>();
             IDictionary<int, string> EstadosD = new Dictionary<int, string>();
             foreach (var item in Departamentos)
             {
                 DepartamentosD.Add(item.Id, item.Descripcion);
             }
             foreach(var item in Estados)
             {
                 EstadosD.Add(item.Id, item.Descripcion);   
             }
             ViewBag.departamentosd = DepartamentosD;
             ViewBag.estadosd = EstadosD;
            return View(Model);
        }

        [HttpPost]
        public IActionResult Edit(Puestos da)
        {
            sv.Actualizar(da);
            return RedirectToAction("Index", "Vacantes");
        }


        [HttpGet]
        public IActionResult Create()
        {
            List<Departamentos> Departamentos = svd.ConsultaGeneral();
            List<Estados> Estados = sve.ConsultaGeneral();
            IDictionary<int, string> DepartamentosD = new Dictionary<int, string>();
            IDictionary<int, string> EstadosD = new Dictionary<int, string>();
            foreach (var item in Departamentos)
            {
                DepartamentosD.Add(item.Id, item.Descripcion);
            }
            foreach (var item in Estados)
            {
                EstadosD.Add(item.Id, item.Descripcion);
            }
            ViewBag.departamentosd = DepartamentosD;
            ViewBag.estadosd = EstadosD;
            ViewBag.NuevoCodigo = sv.NuevoCodigo();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Puestos da)
        {
            sv.Nuevo(da); 
            return RedirectToAction("Index", "Vacantes");

        } 

    }
}
