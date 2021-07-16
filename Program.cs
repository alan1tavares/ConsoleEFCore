using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();

      Console.WriteLine("Bem vindo ao Hospital Lambda!!4");
      Console.WriteLine("Fique a vontade para naver no nosso menu");

      while (true)
      {
        ExibirMenu();
        Console.WriteLine();

        Console.WriteLine("Qual opção escolhida?");
        var entrada = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (entrada)
        {
          case 1:
            GravarPaciente();
            break;
          case 2:
            Console.WriteLine("Não Implementado");
            break;
          case 3:
            Console.WriteLine("Não Implementado");
            break;
          case 4:
            Console.WriteLine("\nLista dos Pacientes");
            ListarPacientes();
            break;
          case 5:
            Console.WriteLine("Cadastrar Consulta\n");
            ListarPacientes();
            RealizarConsulta();
            break;
          case 6:
            Console.WriteLine("Listar Consultas\n");
            ListarConsultas();
            break;

          default:
            return;
        }

        Console.WriteLine("\nEnter para voltar: ");
        Console.Read();

        Console.Clear();

      }
      AtualizarPacientes();
      ListarPacientes();
      ExluirPacientes();
      ListarPacientes();

      Console.WriteLine("Finish");
    }

    private static void ExibirMenu()
    {
      Console.WriteLine("1- Gravar Paciente");
      Console.WriteLine("2- Atualizar Paciente");
      Console.WriteLine("3- Excluir Paciente");
      Console.WriteLine("4- Listar Pacientes");
      Console.WriteLine("5- Realizar Consulta");
      Console.WriteLine("6- Listar Pacientes");
    }

    public static void GravarPaciente()
    {
      Console.WriteLine("1- Gravar Paciente");

      Paciente paciente = new Paciente();

      Console.WriteLine("Nome:");
      paciente.Nome = Console.ReadLine();

      Console.WriteLine("Idade");
      paciente.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Alergias");
      paciente.Alergias = Console.ReadLine();

      using (var context = new HospitalContext())
      {
        context.Pacientes.Add(paciente);
        context.SaveChanges();
      }
    }
    public static void ListarPacientes()
    {
      using (var context = new HospitalContext())
      {
        IList<Paciente> pacientes = context.Pacientes.ToList();
        foreach (var paciente in pacientes)
        {
          Console.WriteLine(paciente);
        }
      }
    }
    private static void RealizarConsulta()
    {
      Consulta consulta = new Consulta();

      Console.WriteLine("Id do paciente:");
      var idDoPaciente = Convert.ToInt32(Console.ReadLine());
      consulta.PacienteId = idDoPaciente;

      Console.WriteLine("Diagnóstico:");
      consulta.Diagnostico = Console.ReadLine();

      using (var context = new HospitalContext())
      {
        context.Consultas.Add(consulta);
        context.SaveChanges();
      }
    }

    private static void ListarConsultas()
    {
      using (var context = new HospitalContext())
      {
        IList<Consulta> consultas = context.Consultas.ToList();
        foreach (var consulta in consultas)
        {
          Console.WriteLine(consulta);
        }
      }
    }

    private static Paciente BuscarPaciente(int aIdDoPaciente)
    {
      Paciente paciente;
      using (var context = new HospitalContext())
      {
        paciente = context.Pacientes.Find(aIdDoPaciente);
      }
      return paciente;
    }

    private static void AtualizarPacientes()
    {
      GravarPaciente();
      using (var context = new HospitalContext())
      {
        Paciente paciente = context.Pacientes.First();
        paciente.Nome = "Maria Silva";
        context.Pacientes.Update(paciente);
        context.SaveChanges();
      }
    }

    private static void ExluirPacientes()
    {
      using (var context = new HospitalContext())
      {
        IList<Paciente> pacientes = context.Pacientes.ToList();
        foreach (var paciente in pacientes)
        {
          context.Pacientes.Remove(paciente);
        }
        context.SaveChanges();
      }
    }
  }
}
