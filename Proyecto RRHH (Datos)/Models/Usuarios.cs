using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Usuarios
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public int? Estado { get; set; }
        public int? Candidato { get; set; }

        public virtual Candidatos CandidatoNavigation { get; set; }
        public virtual Estados EstadoNavigation { get; set; }
    }
}
