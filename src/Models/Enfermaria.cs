using System.Collections.Generic;

namespace ConsoleEFCore.Models
{
  public class Enfermaria
  {
  
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int NumeroDeLeitos { get; set; }
    public IList<EnfermariaMedico> EnfermariaMedico { get; set; }

    public Enfermaria()
    {
      this.EnfermariaMedico = new List<EnfermariaMedico>();
    }

    public void AicionarMedico(int medicoId)
    {
      this.EnfermariaMedico.Add(new EnfermariaMedico() {MedicoId = medicoId, EnfermariaId = Id});
    }

    public override string ToString()
    {
      string result = $"Id({Id}) - Nome({Descricao}) - Medicos:\n";
      foreach (var item in EnfermariaMedico)
        result += $"\t{item.Medico}\n";
          
      return result;
    }
  }
}