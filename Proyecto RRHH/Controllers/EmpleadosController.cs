using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Proyecto_RRHH_Servicios_.Services;

namespace Proyecto_RRHH.Controllers
{
    public class EmpleadosController : Controller
    {
        Servicios_Empleados sv = new Servicios_Empleados();

        public IActionResult Index()
        {
            var Model = sv.ConsultaGeneral();
            return View(Model);
        }
        public IActionResult Details(int id)
        {
            var Model = sv.ConsultaPorCodigo(id);
            return View(Model);
        }

        [HttpPost]
        public FileResult Export(DateTime fechainicial, DateTime fechafinal)
        {
            var Model = sv.ConsultaPorFeccha(fechainicial, fechafinal); 
            DataTable dt = new DataTable("Empleados");
            dt.Columns.AddRange(new DataColumn[6]{
                new DataColumn("Codigo"),
                new DataColumn("Cedula"),
                new DataColumn("Nombre"),
                new DataColumn("Fecha Ingreso"),
                new DataColumn("Puesto"),
                new DataColumn("Estado"),

            });
            if(fechainicial == DateTime.MinValue)
            {
                Model = sv.ConsultaGeneral();
            }
            foreach (var item in Model)
            {
                dt.Rows.Add(item.CodigoEmpleador, item.Cedula, item.Nombre, item.FechaIngreso, item.PuestoNavigation.Descripcion, item.EstadoNavigation.Descripcion);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Empleados.xlsx");
                }
            }

        }
    }
}
