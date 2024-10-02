using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_RRHH__Datos_.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_RRHH_Servicios_.Services;

namespace Proyecto_RH__Servicios_.Services
{
    public class Servicios_Candidatos
    {
        ProjectRRHHContext DB = new ProjectRRHHContext();
        Services_EstadosCandidatos Sv = new Services_EstadosCandidatos();
        Servicios_Empleados sve = new Servicios_Empleados();

        public IDictionary<string, int> Estados = new Dictionary<string, int>();
        public Servicios_Candidatos()
        {
            List<Candidatos> candidatosLista = DB.Candidatos.Include("EstadoNavigation").Select(x => x).ToList();
            foreach(var item in Sv.Consulta())
            {
                Estados.Add(item, candidatosLista.Where(x => x.EstadoNavigation.Descripcion == item).Count());
            }
        }

        public Candidatos ConsultaPorCodigo(int id)
        {
            return DB.Candidatos.Include("EstadoNavigation").Include("AspiracionPuestoNavigation").FirstOrDefault(x => x.Id == id);
        }

        public List<Candidatos> ConsultaGeneral()
        {
            return DB.Candidatos.Include("AspiracionPuestoNavigation").Include("EstadoNavigation").Where(x=>x.Estado != 7).ToList();

        }
        public void Actualizar(Candidatos candidatos)
        {
            DB.Entry(candidatos).State = EntityState.Modified;
            DB.SaveChanges();
        }
        public List<Candidatos> ConsultaPorCriterios(int? vacante, int? estado)
        {
            var Model = ConsultaGeneral();
            if(vacante != null)
            {
                Model = Model.Where(x => x.AspiracionPuesto == vacante).ToList();
            }
            if (estado != null)
            {
                Model = Model.Where(x => x.Estado == estado).ToList();
            }
            return Model;
        }

        public void SiguienteEstado(int id)
        {
            throw new NotImplementedException();
        }

        public void Futuro(int id)
        {
            throw new NotImplementedException();
        }

        public void ColocarEstado(int id, string estado)
        {
            Candidatos cand = ConsultaPorCodigo(id);

            switch (estado)
            {
                case "Descartar":
                    cand.Estado = 5;
                    Actualizar(cand);
                    break;
                case "Futuro":
                    cand.Estado = 6;
                    Actualizar(cand);
                    break;
                case "Siguiente":
                    if(cand.Estado == 4)
                    {
                        cand.Estado = 7;
                        Actualizar(cand);
                        FormalizarEmpleado(cand);

                        break;
                    }
                    if(cand.Estado == 5 || cand.Estado == 6)
                    {
                        break;
                    }
                    cand.Estado = cand.Estado + 1;
                    Actualizar(cand);
                    break;
            }

        }

        public void FormalizarEmpleado(Candidatos candidatos)
        {
            Empleados emp = new Empleados()
            {
                Cedula = candidatos.Cedula,
                Nombre = candidatos.Nombre,
                Puesto = candidatos.AspiracionPuesto,
                Estado = 1,
                FechaIngreso = DateTime.Today,
            };
            sve.Nuevo(emp);
        }

        public List<IdiomasCandidatos> ConsultaIdiomas(int id)
        {
            return DB.IdiomasCandidatos.Include("CandidatoNavigation")
                                       .Include(x=>x.IdiomasNavigation)
                                            .ThenInclude(x => x.NivelNavigation)
                                            .Where(x=>x.Candidato== id).ToList();
        }
        public List<CandidatoCompetencias> CandidatoCompetencias(int id)
        {
            return DB.CandidatoCompetencias.Include("CandidatoNavigation")
                                       .Include(x => x.CompetenciaNavigation)
                                            .ThenInclude(x => x.NivelNavigation)
                                            .Where(x => x.Candidato == id).ToList();
        }
        public List<Capacitaciones> CandidatoCapacitaciones(int id)
        {
            return DB.Capacitaciones.Include("NivelNavigation")
                                    .Where(x => x.Candidato == id).ToList();
        }
        public List<ExperienciaLaboral> CandidatoExperiencia(int id)
        {
            return DB.ExperienciaLaboral.Where(x => x.Candidato == id).ToList();
        }
    }
}
