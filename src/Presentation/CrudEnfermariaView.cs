using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Repository;

namespace ConsoleEFCore.Presentation
{
  public class CrudEnfermariaView : CrudBaseView
  {
    private IRepository<Enfermaria> _repositorio;
    private IRepository<Medico> _repositorioMedico;

    public CrudEnfermariaView(IRepository<Enfermaria> repositorio, IRepository<Medico> repositorioMedico)
    {
      NomeDaEntidade = "Enfermaria";
      _repositorio = repositorio;
      _repositorioMedico = repositorioMedico;
    }
    protected override void Cadastrar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Cadastro");

      Enfermaria enfermaria = new Enfermaria();

      Console.WriteLine("Descrição:");
      enfermaria.Descricao = Console.ReadLine();

      Console.WriteLine("Número de Leitos:");
      enfermaria.NumeroDeLeitos = Convert.ToInt32(Console.ReadLine());

      AdicionarMedico(enfermaria);

      _repositorio.Salvar(enfermaria);
    }

    private void AdicionarMedico(Enfermaria enfermaria)
    {
      while (true)
      {
        Console.Clear();
        Console.WriteLine("Adicionar Medico(s/n):");
        if (Console.ReadLine().ToLower() == "s")
        {
          foreach (var elemento in _repositorioMedico.GetAll())
            Console.WriteLine(elemento);
          
          Console.WriteLine("Id do médico:");
          int idMedico = Convert.ToInt32(Console.ReadLine());
          enfermaria.AicionarMedico(idMedico);
        }
        else
          return;
      }
    }

    protected override void Editar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Edição\n");
      ExibirTodosEnfermarias();
      Console.WriteLine("\nInsira o Id do enfermaria que será editado:");
      int id = Convert.ToInt32(Console.ReadLine());
      Enfermaria enfermaria = _repositorio.GetById(id);

      Console.WriteLine("\nCaso");

      Console.WriteLine("Descrição:");
      enfermaria.Descricao = Console.ReadLine();

      Console.WriteLine("Número de Leitos");
      enfermaria.NumeroDeLeitos = Convert.ToInt32(Console.ReadLine());

      _repositorio.Editar(enfermaria);
    }

    protected override void Listar()
    {
      Console.WriteLine("Listagem de Enfermarias");
      ExibirTodosEnfermarias();
      Console.WriteLine("\nAperte qualquer tecla para voltar");
      Console.ReadLine();
    }

    protected override void Excluir()
    {
      Console.WriteLine($"{NomeDaEntidade} - Exclusão\n");
      ExibirTodosEnfermarias();
      Console.WriteLine("\nInsira o Id do enfermaria que será excluído:");
      int id = Convert.ToInt32(Console.ReadLine());
      _repositorio.Excluir(id);
    }

    private void ExibirTodosEnfermarias()
    {
      foreach (var enfermaria in _repositorio.GetAll())
        Console.WriteLine(enfermaria);
    }
  }
}