using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class ExperienciaLaboral
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Descripcion { get; set; }
        public string Puesto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public decimal Salario { get; set; }
        public int? Candidato { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
    }
}
