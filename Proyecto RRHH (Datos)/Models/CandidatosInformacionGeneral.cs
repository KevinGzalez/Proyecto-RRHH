using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class CandidatosInformacionGeneral
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public decimal? AspiracionSalarial { get; set; }
        public int? Estado { get; set; }
        public string Recomendado { get; set; }
        public string Competencia { get; set; }
        public string Comentario { get; set; }
        public string NivelHabilidad { get; set; }
    }
}
