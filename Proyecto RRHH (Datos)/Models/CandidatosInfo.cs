using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class CandidatosInfo
    {
        public string Puesto { get; set; }
        public string Estado { get; set; }
        public decimal Salario { get; set; }
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public decimal? AspiracionSalarial { get; set; }
        public string Recomendado { get; set; }
        public string Departamento { get; set; }
    }
}
