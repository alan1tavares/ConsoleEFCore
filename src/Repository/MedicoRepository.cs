using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class MedicoRepository : IRepository<Medico>
  {
    public IList<Medico> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Medicos.ToList();
      }
    }

    public Medico GetById(int id)
    {
      Medico medico;
      using (var context = new HospitalContext())
      {
        medico = context.Medicos.Find(id);
      }
      return medico;
    }

    public void Salvar(Medico entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Medicos.Add(entidade);
        context.SaveChanges();
      }
    }

    public void Editar(Medico entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Medicos.Update(entidade);
        context.SaveChanges();
      }
    }

    public void Excluir(int idEntidade)
    {
      using (var context = new HospitalContext())
      {
        Medico medico = context.Medicos.Find(idEntidade);
        context.Medicos.Remove(medico);
        context.SaveChanges();
      }
    }
  }
}