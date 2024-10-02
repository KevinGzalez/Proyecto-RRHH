using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH__Datos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RRHH_Servicios_.Services
{
    public class Servicios_Empleados
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public void Nuevo(Empleados id)
        {
            id.CodigoEmpleador = NuevoCodigo();
            DB.Empleados.Add(id);
            DB.SaveChanges();
        }

        public List<Empleados> ConsultaGeneral()
        {
            return DB.Empleados.Include(x => x.PuestoNavigation).Include(x => x.EstadoNavigation).ToList();
        }

        public List<Empleados> ConsultaPorFeccha(DateTime fechainicial, DateTime fechafinal)
        {

            DateTime fechafinalD = fechafinal;
            var fechainicialD = fechainicial.ToString("dd/mm/yyyy");
            return DB.Empleados.Include(x => x.PuestoNavigation).Include(x => x.EstadoNavigation).Where(x=>x.FechaIngreso >= fechainicial).Where(x=>x.FechaIngreso <= fechafinal).ToList();
        }
        public Empleados ConsultaPorCodigo(int id)
        {
            return DB.Empleados.Include(x=>x.PuestoNavigation).Include(x => x.EstadoNavigation).FirstOrDefault(x=>x.CodigoEmpleador == id);
        }

        public int NuevoCodigo()
        {
            if(DB.Empleados.Select(x=>x).Count() >= 1)
            {
                return DB.Empleados.OrderByDescending(x => x.CodigoEmpleador).FirstOrDefault().CodigoEmpleador + 1;
            }
            return 1;
            
        }
    }
}
