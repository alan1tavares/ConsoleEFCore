namespace ConsoleEFCore.Models
{
  public class Endereco
  {
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public Paciente Paciente { get; set; }

    public override string ToString()
    {
      return $"Logradouro({Logradouro}) - Numero({Numero})";
    }
  }
}