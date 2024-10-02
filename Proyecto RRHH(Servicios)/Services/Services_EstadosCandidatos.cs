using Proyecto_RRHH__Datos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_RH__Servicios_.Services
{
    public class Services_EstadosCandidatos
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();

        public List<string> Consulta()
        {
            return DB.EstadosCandidato.Select(x => x.Descripcion).ToList();
        }
        public List<EstadosCandidato> ConsultaGeneral()
        {
            return DB.EstadosCandidato.Select(x=>x).ToList();
        }
    }
}
