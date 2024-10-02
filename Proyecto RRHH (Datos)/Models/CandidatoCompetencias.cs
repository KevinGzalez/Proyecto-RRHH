using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class CandidatoCompetencias
    {
        public int Id { get; set; }
        public int? Candidato { get; set; }
        public int? Competencia { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
        public virtual Competencias CompetenciaNavigation { get; set; }
    }
}
