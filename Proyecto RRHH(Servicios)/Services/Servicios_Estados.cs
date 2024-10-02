using Proyecto_RRHH__Datos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RH__Servicios_.Services
{
    public class Servicios_Estados
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public List<Estados> ConsultaGeneral()
        {
            return DB.Estados.Select(x => x).ToList();
        }
    }
}
