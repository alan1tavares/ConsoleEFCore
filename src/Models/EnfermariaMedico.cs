namespace ConsoleEFCore.Models
{
  public class EnfermariaMedico
  {
    public int EnfermariaId { get; set; }
    public Enfermaria Enfermaria { get; set; }
    public int MedicoId { get; set; }
    public Medico Medico { get; set; }
  }
}