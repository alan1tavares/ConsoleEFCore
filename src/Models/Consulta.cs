namespace ConsoleEFCore.Models
{
  public class Consulta
  {
    public int Id { get; set; }
    public string Diagnostico { get; set; }
    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }
    
    public override string ToString()
    {
      return $"Id|Consulta({Id}) - Id|Paciente({PacienteId}) - Diagnostico({Diagnostico})";
    }
  }
}
