using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Empleados
    {
        public int CodigoEmpleador { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        public int Puesto { get; set; }
        public int? Estado { get; set; }

        public virtual Estados EstadoNavigation { get; set; }
        public virtual Puestos PuestoNavigation { get; set; }
    }
}
