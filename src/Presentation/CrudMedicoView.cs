using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Repository;

namespace ConsoleEFCore.Presentation
{
  public class CrudMedicoView : CrudBaseView
  {
    private IRepository<Medico> _repositorio;
    public CrudMedicoView(IRepository<Medico> repositorio)
    {
      NomeDaEntidade = "Medico";
      _repositorio = repositorio;
    }
    protected override void Cadastrar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Cadastro");

      Medico medico = new Medico();

      Console.WriteLine("Nome:");
      medico.Nome = Console.ReadLine();

      Console.WriteLine("Idade:");
      medico.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Especialidade");
      medico.Especialidade = Console.ReadLine();

      _repositorio.Salvar(medico);
    }

    protected override void Editar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Edição\n");
      ExibirTodosMedicos();
      Console.WriteLine("\nInsira o Id do medico que será editado:");
      int id = Convert.ToInt32(Console.ReadLine());
      Medico medico = _repositorio.GetById(id);

      Console.WriteLine("\nCaso");

      Console.WriteLine("Nome:");
      medico.Nome = Console.ReadLine();

      Console.WriteLine("Idade");
      medico.Idade = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Especialidade");
      medico.Especialidade = Console.ReadLine();

      _repositorio.Editar(medico);
    }

    protected override void Listar()
    {
      Console.WriteLine("Listagem de Medicos");
      ExibirTodosMedicos();
      Console.WriteLine("\nAperte qualquer tecla para voltar");
      Console.ReadLine();
    }

    protected override void Excluir()
    {
      Console.WriteLine($"{NomeDaEntidade} - Exclusão\n");
      ExibirTodosMedicos();
      Console.WriteLine("\nInsira o Id do medico que será excluído:");
      int id = Convert.ToInt32(Console.ReadLine());
      _repositorio.Excluir(id);
    }

    private void ExibirTodosMedicos()
    {
      foreach (var medico in _repositorio.GetAll())
        Console.WriteLine(medico);
    }
  }
}