using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class ConsultaRepository : IRepository<Consulta>
  {
    public IList<Consulta> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Consultas.ToList();
      }
    }

    public Consulta GetById(int id)
    {
      Consulta consulta;
      using (var context = new HospitalContext())
      {
        consulta = context.Consultas.Find(id);
      }
      return consulta;
    }

    public void Salvar(Consulta entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Consultas.Add(entidade);
        context.SaveChanges();
      }
    }

    public void Editar(Consulta entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Consultas.Update(entidade);
        context.SaveChanges();
      }
    }

    public void Excluir(int idEntidade)
    {
      using (var context = new HospitalContext())
      {
        Consulta consulta = context.Consultas.Find(idEntidade);
        context.Consultas.Remove(consulta);
        context.SaveChanges();
      }
    }
  }
}