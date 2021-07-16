using System.Collections.Generic;

namespace ConsoleEFCore.Models
{
  public class Enfermaria
  {
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int NumeroDeLeitos { get; set; }
    public IEnumerable<Paciente> Pacientes { get; set; }
  }
}