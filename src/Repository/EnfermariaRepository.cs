using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class EnfermariaRepository : IRepository<Enfermaria>
  {
    public IList<Enfermaria> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Enfermarias
          .Include(enfermaria => enfermaria.EnfermariaMedico)
          .ThenInclude(enfermariaMedico => enfermariaMedico.Medico)
          .ToList();
      }
    }

    public Enfermaria GetById(int id)
    {
      Enfermaria enfermaria;
      using (var context = new HospitalContext())
      {
        enfermaria = context.Enfermarias.Find(id);
      }
      return enfermaria;
    }

    public void Salvar(Enfermaria entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Enfermarias.Add(entidade);
        context.SaveChanges();
      }
    }

    public void Editar(Enfermaria entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Enfermarias.Update(entidade);
        context.SaveChanges();
      }
    }

    public void Excluir(int idEntidade)
    {
      using (var context = new HospitalContext())
      {
        Enfermaria enfermaria = context.Enfermarias.Find(idEntidade);
        context.Enfermarias.Remove(enfermaria);
        context.SaveChanges();
      }
    }
  }
}