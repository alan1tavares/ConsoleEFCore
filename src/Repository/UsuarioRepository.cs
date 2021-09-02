using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class UsuarioRepository : IRepository<Usuario>
  {
    public IList<Usuario> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Usuarios.ToList();
      }
    }

    public Usuario GetById(object chave)
    {
      Usuario usuario;
      using (var context = new HospitalContext())
      {
        usuario = context.Usuarios.Find(chave);
      }
      return usuario;
    }

    public void Salvar(Usuario entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Usuarios.Add(entidade);
        context.SaveChanges();
      }
    }

    public void Editar(Usuario entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Usuarios.Update(entidade);
        context.SaveChanges();
      }
    }

    public void Excluir(object chave)
    {
      using (var context = new HospitalContext())
      {
        Usuario usuario = context.Usuarios.Find(chave);
        context.Usuarios.Remove(usuario);
        context.SaveChanges();
      }
    }
  }
}