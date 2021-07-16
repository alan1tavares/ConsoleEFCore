using System.Collections.Generic;

namespace ConsoleEFCore.Models
{
  public class Medico
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Especialidade { get; set; }
    public IList<EnfermariaMedico> Enfermarias { get; set; }

    public override string ToString()
    {
      return $"Id({Id}) - Nome({Nome}) - Especialidade({Especialidade})";
    }
  }
}