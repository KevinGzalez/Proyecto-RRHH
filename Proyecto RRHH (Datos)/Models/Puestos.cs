using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Puestos
    {
        public Puestos()
        {
            Candidatos = new HashSet<Candidatos>();
            Empleados = new HashSet<Empleados>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string NivelDeRiesgo { get; set; }
        public decimal Salario { get; set; }
        public int Departamento { get; set; }
        public int? Estado { get; set; }

        public virtual Departamentos DepartamentoNavigation { get; set; }
        public virtual Estados EstadoNavigation { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
