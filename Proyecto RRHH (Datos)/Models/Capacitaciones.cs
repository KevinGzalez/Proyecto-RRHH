using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Capacitaciones
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Nivel { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaInicio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaFinal { get; set; }
        public string Institucion { get; set; }
        public int Candidato { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
        public virtual Niveles NivelNavigation { get; set; }
    }
}
