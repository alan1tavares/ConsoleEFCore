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

    public Consulta GetById(object chave)
    {
      Consulta consulta;
      using (var context = new HospitalContext())
      {
        consulta = context.Consultas.Find(chave);
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

    public void Excluir(object chave)
    {
      using (var context = new HospitalContext())
      {
        Consulta consulta = context.Consultas.Find(chave);
        context.Consultas.Remove(consulta);
        context.SaveChanges();
      }
    }
  }
}