using System;

namespace ConsoleEFCore.Presentation
{
  public abstract class CrudBaseView
  {
    protected string NomeDaEntidade;

    public void Executar()
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine($"{NomeDaEntidade}\n");
        Console.WriteLine("1- Visualizar");
        Console.WriteLine("2- Cadastrar");
        Console.WriteLine("3- Editar");
        Console.WriteLine("4- Excluir\n");

        Console.WriteLine("Escolha a opção");
        int opcaoEcolhida;
        Int32.TryParse(Console.ReadLine(), out opcaoEcolhida);
        
        Console.Clear();
        switch (opcaoEcolhida)
        {
          case 1:
            Listar();
            break;
          case 2:
            Cadastrar();
            break;
          case 3:
            Editar();
            break;
          case 4:
            Excluir();
            break;
          default:
            return;
        }
      }
    }
    protected abstract void Listar();
    protected abstract void Cadastrar();
    protected abstract void Editar();
    protected abstract void Excluir();

  }
}