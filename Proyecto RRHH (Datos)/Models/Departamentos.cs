using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Puestos = new HashSet<Puestos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Puestos> Puestos { get; set; }
    }
}
