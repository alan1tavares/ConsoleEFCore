using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class ConsultaRepository : IRepository<Consulta>
  {
    private HospitalContext _Context;

    public ConsultaRepository(HospitalContext context) => _Context = context;

    public IList<Consulta> GetAll() => _Context.Consultas.ToList();

    public void Salvar(Consulta entidade)
    {
      _Context.Add(entidade);
      _Context.SaveChanges();
    }

    public void Editar(Consulta entidade)
    {
      _Context.Update(entidade);
      _Context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _Context.Consultas.Remove(GetById(chave));
      _Context.SaveChanges();
    }

    public Consulta GetById(object chave) => _Context.Find<Consulta>(chave);
  }
}