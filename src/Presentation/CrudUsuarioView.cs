using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Repository;
using ConsoleEFCore.src.Utils;

namespace ConsoleEFCore.Presentation
{
  public class CrudUsuarioView : CrudBaseView
  {
    private IRepository<Usuario> _repositorio;
    public CrudUsuarioView(IRepository<Usuario> repositorio)
    {
      NomeDaEntidade = "Usuario";
      _repositorio = repositorio;
    }
    protected override void Cadastrar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Cadastro");

      Usuario usuario = new Usuario();

      Console.WriteLine("Nome do usuário:");
      usuario.UserName= Console.ReadLine();

      Console.WriteLine("Password");
      usuario.PasswordHash = PassworldUtils.GetHash(Console.ReadLine());

      _repositorio.Salvar(usuario);
    }

    protected override void Editar()
    {
      Console.WriteLine($"{NomeDaEntidade} - Edição\n");
      ExibirTodosUsuarios();
      Console.WriteLine("\nInsira o Id do usuario que será editado:");
      string guid = Console.ReadLine();
      Usuario usuario = _repositorio.GetById(guid);

      Console.WriteLine("\nCaso");

      Console.WriteLine("Nome do usuário:");
      usuario.UserName= Console.ReadLine();

      Console.WriteLine("Password");
      usuario.PasswordHash = PassworldUtils.GetHash(Console.ReadLine());

      _repositorio.Editar(usuario);
    }

    protected override void Listar()
    {
      Console.WriteLine("Listagem de Usuarios");
      ExibirTodosUsuarios();
      Console.WriteLine("\nAperte qualquer tecla para voltar");
      Console.ReadLine();
    }

    protected override void Excluir()
    {
      Console.WriteLine($"{NomeDaEntidade} - Exclusão\n");
      ExibirTodosUsuarios();
      Console.WriteLine("\nInsira o Id do usuario que será excluído:");
      string chave = Console.ReadLine();
      _repositorio.Excluir(chave);
    }

    private void ExibirTodosUsuarios()
    {
      foreach (var usuario in _repositorio.GetAll())
        Console.WriteLine(usuario);
    }
  }
}