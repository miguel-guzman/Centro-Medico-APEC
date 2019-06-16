using prjHospital.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace prjHospital.Data
{
  public class HospitalContext : DbContext
  {
    public HospitalContext() : base("HospitalContext")
    {
    }

    public DbSet<ActividadEspecialidadModel> ActividadEspecialidades { get; set; }
    public DbSet<ActividadModel> Actividades { get; set; }
    public DbSet<EpisodioModel> Episodios { get; set; }
    public DbSet<EspecialidadModel> Especialidades { get; set; }
    public DbSet<MedicoModel> Medicos { get; set; }
    public DbSet<PersonaModel> Personas { get; set; }
    public DbSet<SexoModel> Sexos { get; set; }
    public DbSet<TipoEgresoModel> TipoEgresos { get; set; }
    public DbSet<TipoIngresoModel> TipoIngresos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    }
  }
}