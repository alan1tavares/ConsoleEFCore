using System;
using ConsoleEFCore.Presentation;
using ConsoleEFCore.Repository;

namespace ConsoleEFCore
{
  public class App
  {
    public static void Executar()
    {
      while (true)
      {
        Console.Clear();

        Console.WriteLine("Bem vindo ao Hospital Lambda!!");
        Console.WriteLine("Fique a vontade para navegar no nosso menu");

        Console.WriteLine("1- Paciente");
        Console.WriteLine("2- Médico");
        Console.WriteLine("3- Consulta");
        Console.WriteLine("4- Enfermaria");

        Console.WriteLine("\nEscolha uma opção");
        int opcao;
        Int32.TryParse(Console.ReadLine(), out opcao);

        CrudBaseView crud;
        switch (opcao)
        {
          case 1:
            crud = new CrudPacienteView(new PacienteRepository());
            break;
          case 3:
            crud = new CrudConsultaView(new ConsultaRepository(), new PacienteRepository());
            break;
          default:
            return;
        }
        crud.Executar();

      }

    }
  }
}