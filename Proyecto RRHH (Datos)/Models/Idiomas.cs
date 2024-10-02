using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Idiomas
    {
        public Idiomas()
        {
            IdiomasCandidatos = new HashSet<IdiomasCandidatos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Nivel { get; set; }
        public int Estado { get; set; }

        public virtual Estados EstadoNavigation { get; set; }
        public virtual NivelesHabilidad NivelNavigation { get; set; }
        public virtual ICollection<IdiomasCandidatos> IdiomasCandidatos { get; set; }
    }
}
