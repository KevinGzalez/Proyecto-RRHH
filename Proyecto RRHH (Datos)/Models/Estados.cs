using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Empleados = new HashSet<Empleados>();
            Idiomas = new HashSet<Idiomas>();
            Puestos = new HashSet<Puestos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Idiomas> Idiomas { get; set; }
        public virtual ICollection<Puestos> Puestos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
