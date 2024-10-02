using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class PuestosGenerales
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string NivelDeRiesgo { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }
        public string Estados { get; set; }
    }
}
