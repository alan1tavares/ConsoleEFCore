using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleEFCore
{
  public class HospitalContext : DbContext
  {
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.EnableSensitiveDataLogging();
      optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=hospital;User Id=postgres;Password=1234;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      Paciente paciente = new Paciente();
      paciente.Id = 1;
      paciente.Nome = "Carlos Eduardo";
      paciente.Idade = 38;
      paciente.Alergias = "Abelha;Formiga";
      modelBuilder.Entity<Paciente>().HasData(paciente);

      Consulta consulta = new Consulta();
      consulta.Id = 1;
      consulta.PacienteId = 1;
      consulta.Diagnostico = "Ficar longe de formiga";
      modelBuilder.Entity<Consulta>().HasData(consulta);
    }
  }
}