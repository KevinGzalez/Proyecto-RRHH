using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto_RRHH__Datos_.Models
{
    public partial class ProjectRRHHContext : DbContext
    {
        public ProjectRRHHContext()
        {
        }

        public ProjectRRHHContext(DbContextOptions<ProjectRRHHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidatoCompetencias> CandidatoCompetencias { get; set; }
        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<CandidatosInfo> CandidatosInfo { get; set; }
        public virtual DbSet<CandidatosInformacionGeneral> CandidatosInformacionGeneral { get; set; }
        public virtual DbSet<Capacitaciones> Capacitaciones { get; set; }
        public virtual DbSet<Competencias> Competencias { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstadosCandidato> EstadosCandidato { get; set; }
        public virtual DbSet<ExperienciaLaboral> ExperienciaLaboral { get; set; }
        public virtual DbSet<Idiomas> Idiomas { get; set; }
        public virtual DbSet<IdiomasCandidatos> IdiomasCandidatos { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<NivelesHabilidad> NivelesHabilidad { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<PuestosGenerales> PuestosGenerales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosCandidatos> UsuariosCandidatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-BP17\\SQLEXPRESS;Database=Proyect_RRHH;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatoCompetencias>(entity =>
            {
                entity.ToTable("Candidato_Competencias");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CandidatoNavigation)
                    .WithMany(p => p.CandidatoCompetencias)
                    .HasForeignKey(d => d.Candidato)
                    .HasConstraintName("FK_Candidato_Competencias_Candidatos");

                entity.HasOne(d => d.CompetenciaNavigation)
                    .WithMany(p => p.CandidatoCompetencias)
                    .HasForeignKey(d => d.Competencia)
                    .HasConstraintName("FK_Candidato_Competencias_Competencias");
            });

            modelBuilder.Entity<Candidatos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspiracionPuesto).HasColumnName("Aspiracion puesto");

                entity.Property(e => e.AspiracionSalarial)
                    .HasColumnName("Aspiracion Salarial")
                    .HasColumnType("money");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recomendado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AspiracionPuestoNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.AspiracionPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Puesto_Candidato");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Candidatos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Estado_Candidatos");
            });

            modelBuilder.Entity<CandidatosInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Candidatos_Info");

                entity.Property(e => e.AspiracionSalarial)
                    .HasColumnName("Aspiracion Salarial")
                    .HasColumnType("money");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recomendado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");
            });

            modelBuilder.Entity<CandidatosInformacionGeneral>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Candidatos_Informacion_General");

                entity.Property(e => e.AspiracionSalarial)
                    .HasColumnName("Aspiracion Salarial")
                    .HasColumnType("money");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Comentario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Competencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelHabilidad)
                    .HasColumnName("Nivel Habilidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Recomendado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Capacitaciones>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("Fecha_final")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_inicio")
                    .HasColumnType("date");

                entity.Property(e => e.Institucion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CandidatoNavigation)
                    .WithMany(p => p.Capacitaciones)
                    .HasForeignKey(d => d.Candidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidatos_Capacitaciones");

                entity.HasOne(d => d.NivelNavigation)
                    .WithMany(p => p.Capacitaciones)
                    .HasForeignKey(d => d.Nivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nivel_Candidatos");
            });

            modelBuilder.Entity<Competencias>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comentario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.NivelNavigation)
                    .WithMany(p => p.Competencias)
                    .HasForeignKey(d => d.Nivel)
                    .HasConstraintName("FK_Competencias_Niveles_Habilidad");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpleador);

                entity.Property(e => e.CodigoEmpleador)
                    .HasColumnName("Codigo_empleador")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("Fecha_Ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Empleados_Estados");

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Puestos");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadosCandidato>(entity =>
            {
                entity.ToTable("Estados candidato");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExperienciaLaboral>(entity =>
            {
                entity.ToTable("Experiencia Laboral");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinal)
                    .HasColumnName("Fecha_final")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("Fecha_inicio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");

                entity.HasOne(d => d.CandidatoNavigation)
                    .WithMany(p => p.ExperienciaLaboral)
                    .HasForeignKey(d => d.Candidato)
                    .HasConstraintName("FK_Experiencia Laboral_Candidatos");
            });

            modelBuilder.Entity<Idiomas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Idiomas)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Idiomas_Estados");

                entity.HasOne(d => d.NivelNavigation)
                    .WithMany(p => p.Idiomas)
                    .HasForeignKey(d => d.Nivel)
                    .HasConstraintName("FK_Idiomas_Niveles_Habilidad");
            });

            modelBuilder.Entity<IdiomasCandidatos>(entity =>
            {
                entity.ToTable("Idiomas_Candidatos");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CandidatoNavigation)
                    .WithMany(p => p.IdiomasCandidatos)
                    .HasForeignKey(d => d.Candidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Idiomas_Candidatos_Candidatos");

                entity.HasOne(d => d.IdiomasNavigation)
                    .WithMany(p => p.IdiomasCandidatos)
                    .HasForeignKey(d => d.Idiomas)
                    .HasConstraintName("FK_Idiomas_Candidatos_Idiomas");
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelesHabilidad>(entity =>
            {
                entity.ToTable("Niveles_Habilidad");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Puestos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelDeRiesgo)
                    .HasColumnName("Nivel de riesgo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.Departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dapartamento_Puestos");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Estados_Puestos");
            });

            modelBuilder.Entity<PuestosGenerales>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PuestosGenerales");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estados)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NivelDeRiesgo)
                    .HasColumnName("Nivel de riesgo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("money");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Usuario);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CandidatoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Candidato)
                    .HasConstraintName("FK_Usuarios_Candidatos");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Usuarios_Estados");
            });

            modelBuilder.Entity<UsuariosCandidatos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Usuarios_Candidatos");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
