using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Niveles
    {
        public Niveles()
        {
            Capacitaciones = new HashSet<Capacitaciones>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Capacitaciones> Capacitaciones { get; set; }
    }
}
