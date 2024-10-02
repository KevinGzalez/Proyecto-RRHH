using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Competencias
    {
        public Competencias()
        {
            CandidatoCompetencias = new HashSet<CandidatoCompetencias>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Nivel { get; set; }
        public string Comentario { get; set; }

        public virtual NivelesHabilidad NivelNavigation { get; set; }
        public virtual ICollection<CandidatoCompetencias> CandidatoCompetencias { get; set; }
    }
}
