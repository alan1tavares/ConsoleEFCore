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
      App.Executar();
    }

    private static void ExibirMenu()
    {
      Console.WriteLine("1- Cadastrar Paciente");
      Console.WriteLine("2- Cadastrar Médico");
      Console.WriteLine("3- Excluir Paciente");
      Console.WriteLine("4- Listar Pacientes");
      Console.WriteLine("5- Realizar Consulta");
      Console.WriteLine("6- Listar Pacientes");
    }

    public static void CadastrarPaciente()
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

    private static void CadastrarMedico()
    {
      Console.WriteLine("2- Cadastrar Médico");

      Medico medico = new Medico();

      Console.WriteLine("Nome:");
      medico.Nome = Console.ReadLine();

      Console.WriteLine("Idade");
      medico.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Especialidade");
      medico.Especialidade = Console.ReadLine();

      using (var context = new HospitalContext())
      {
        context.Medicos.Add(medico);
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
      CadastrarPaciente();
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
