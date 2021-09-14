using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class UsuarioRepository : IRepository<Usuario>
  {
    private HospitalContext _Context;

    public UsuarioRepository(HospitalContext context) => _Context = context;

    public IList<Usuario> GetAll() => _Context.Usuarios.ToList();

    public void Salvar(Usuario entidade)
    {
      _Context.Add(entidade);
      _Context.SaveChanges();
    }

    public void Editar(Usuario entidade)
    {
      _Context.Update(entidade);
      _Context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _Context.Usuarios.Remove(GetById(chave));
      _Context.SaveChanges();
    }

    public Usuario GetById(object chave) => _Context.Find<Usuario>(chave);
  }
}