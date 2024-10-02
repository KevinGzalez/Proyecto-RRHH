using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class EstadosCandidato
    {
        public EstadosCandidato()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Candidatos> Candidatos { get; set; }
    }
}
