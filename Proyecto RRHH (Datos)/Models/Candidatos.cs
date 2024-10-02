using System;
using System.Collections.Generic;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class Candidatos
    {
        public Candidatos()
        {
            CandidatoCompetencias = new HashSet<CandidatoCompetencias>();
            Capacitaciones = new HashSet<Capacitaciones>();
            ExperienciaLaboral = new HashSet<ExperienciaLaboral>();
            IdiomasCandidatos = new HashSet<IdiomasCandidatos>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int AspiracionPuesto { get; set; }
        public decimal AspiracionSalarial { get; set; }
        public int? Estado { get; set; }
        public string Recomendado { get; set; }

        public virtual Puestos AspiracionPuestoNavigation { get; set; }
        public virtual EstadosCandidato EstadoNavigation { get; set; }
        public virtual ICollection<CandidatoCompetencias> CandidatoCompetencias { get; set; }
        public virtual ICollection<Capacitaciones> Capacitaciones { get; set; }
        public virtual ICollection<ExperienciaLaboral> ExperienciaLaboral { get; set; }
        public virtual ICollection<IdiomasCandidatos> IdiomasCandidatos { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
