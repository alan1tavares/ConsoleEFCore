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

    public Medico GetById(object chave)
    {
      Medico medico;
      using (var context = new HospitalContext())
      {
        medico = context.Medicos.Find(chave);
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

    public void Excluir(object chave)
    {
      using (var context = new HospitalContext())
      {
        Medico medico = context.Medicos.Find(chave);
        context.Medicos.Remove(medico);
        context.SaveChanges();
      }
    }
  }
}