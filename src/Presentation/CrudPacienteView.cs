using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Repository;

namespace ConsoleEFCore.Presentation
{
  public class CrudPacienteView : CrudBaseView
  {
    private IRepository<Paciente> _repositorio;
    public CrudPacienteView(IRepository<Paciente> repositorio)
    {
      NomeDaEntidade = "Paciente";
      _repositorio = repositorio;
    }
    protected override void Cadastrar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Cadastro");

      Paciente paciente = new Paciente();

      Console.WriteLine("Nome:");
      paciente.Nome = Console.ReadLine();

      Console.WriteLine("Idade");
      paciente.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Alergias");
      paciente.Alergias = Console.ReadLine();

      Endereco endereco = new Endereco();
      
      Console.WriteLine("Logradouro");
      endereco.Logradouro = Console.ReadLine();

      Console.WriteLine("Numero");
      endereco.Numero = Convert.ToInt32(Console.ReadLine());

      paciente.Endereco = endereco;

      _repositorio.Salvar(paciente);
    }

    protected override void Editar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Edição\n");
      ExibirTodosPacientes();
      Console.WriteLine("\nInsira o Id do paciente que será editado:");
      int id = Convert.ToInt32(Console.ReadLine());
      Paciente paciente = _repositorio.GetById(id);

      Console.WriteLine("\nCaso");

      Console.WriteLine("Nome:");
      paciente.Nome = Console.ReadLine();

      Console.WriteLine("Idade");
      paciente.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Alergias");
      paciente.Alergias = Console.ReadLine();

      _repositorio.Editar(paciente);
    }

    protected override void Listar()
    {
      Console.WriteLine("Listagem de Pacientes");
      ExibirTodosPacientes();
      Console.WriteLine("\nAperte qualquer tecla para voltar");
      Console.ReadLine();
    }

    protected override void Excluir()
    {
      Console.WriteLine($"{NomeDaEntidade} - Exclusão\n");
      ExibirTodosPacientes();
      Console.WriteLine("\nInsira o Id do paciente que será excluído:");
      int id = Convert.ToInt32(Console.ReadLine());
      _repositorio.Excluir(id);
    }

    private void ExibirTodosPacientes()
    {
      foreach (var paciente in _repositorio.GetAll())
        Console.WriteLine(paciente);
    }
  }
}