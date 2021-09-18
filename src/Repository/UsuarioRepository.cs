using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsoleEFCore.Repository
{
  public class UsuarioRepository : IRepository<Usuario>
  {
    private UserManager<Usuario> _userManager;

    public UsuarioRepository(UserManager<Usuario> userManager) => _userManager = userManager;

    public IList<Usuario> GetAll() => _userManager.Users.ToList<Usuario>();

    public void Salvar(Usuario entidade) => _userManager.CreateAsync(entidade).Wait();

    public void Editar(Usuario entidade) => _userManager.UpdateAsync(entidade).Wait();

    public void Excluir(object chave) => _userManager.DeleteAsync(GetById(chave)).Wait();

    public Usuario GetById(object chave) => _userManager.FindByIdAsync((string)chave).Result;
  }
}