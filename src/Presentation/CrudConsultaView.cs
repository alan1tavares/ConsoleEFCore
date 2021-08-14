using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Repository;

namespace ConsoleEFCore.Presentation
{
  public class CrudConsultaView : CrudBaseView
  {
    private IRepository<Consulta> _consultaRepository;
    private IRepository<Paciente> _pacienteRepository;

    public CrudConsultaView(IRepository<Consulta> consultaRepository, IRepository<Paciente> pacienteRepository)
    {
      NomeDaEntidade = "Consulta";
      _consultaRepository = consultaRepository;
      _pacienteRepository = pacienteRepository;
    }
    protected override void Cadastrar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Cadastro");

      Consulta consulta = new Consulta();

      consulta.PacienteId = GetIdDoPacienteSilecionado();

      Console.WriteLine("Diagnóstico:");
      consulta.Diagnostico = Console.ReadLine();

      _consultaRepository.Salvar(consulta);
    }

    private int GetIdDoPacienteSilecionado()
    {
      Console.WriteLine("Selecione o Id do Paciente para a realização da consulta");
      foreach (var paciente in _pacienteRepository.GetAll())
        Console.WriteLine(paciente);
      
      Console.WriteLine("\nPaciente Id:");
      return Convert.ToInt32(Console.ReadLine());
    }

    protected override void Editar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Edição\n");
      ExibirTodosConsultas();
      Console.WriteLine("\nInsira o Id do consulta que será editado:");
      int id = Convert.ToInt32(Console.ReadLine());
      Consulta consulta = _consultaRepository.GetById(id);

      Console.WriteLine("\nCaso");

      Console.WriteLine("Id do paciente:");
      var idDoPaciente = Convert.ToInt32(Console.ReadLine());
      consulta.PacienteId = idDoPaciente;

      Console.WriteLine("Diagnóstico:");
      consulta.Diagnostico = Console.ReadLine();

      _consultaRepository.Editar(consulta);
    }

    protected override void Listar()
    {
      Console.WriteLine("Listagem de Consultas");
      ExibirTodosConsultas();
      Console.WriteLine("\nAperte qualquer tecla para voltar");
      Console.ReadLine();
    }

    protected override void Excluir()
    {
      Console.WriteLine($"{NomeDaEntidade} - Exclusão\n");
      ExibirTodosConsultas();
      Console.WriteLine("\nInsira o Id da consulta que será excluída:");
      int id = Convert.ToInt32(Console.ReadLine());
      _consultaRepository.Excluir(id);
    }

    private void ExibirTodosConsultas()
    {
      foreach (var consulta in _consultaRepository.GetAll())
        Console.WriteLine(consulta);
    }
  }
}