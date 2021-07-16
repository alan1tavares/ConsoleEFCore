namespace ConsoleEFCore
{
  public class Paciente
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Alergias { get; set; }
    public int Sexo {get; set;}

    public override string ToString()
    {
      return $"Id({Id}) - Nome({Nome}) - Idade({Idade})";
    }
  }
}

