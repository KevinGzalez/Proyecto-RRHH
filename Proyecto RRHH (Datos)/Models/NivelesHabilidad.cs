using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class NivelesHabilidad
    {
        public NivelesHabilidad()
        {
            Competencias = new HashSet<Competencias>();
            Idiomas = new HashSet<Idiomas>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Competencias> Competencias { get; set; }
        public virtual ICollection<Idiomas> Idiomas { get; set; }
    }
}
