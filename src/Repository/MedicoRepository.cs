using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class MedicoRepository : IRepository<Medico>
  {
    private HospitalContext _Context;

    public MedicoRepository(HospitalContext context) => _Context = context;

    public IList<Medico> GetAll() => _Context.Medicos.ToList();

    public void Salvar(Medico entidade)
    {
      _Context.Add(entidade);
      _Context.SaveChanges();
    }

    public void Editar(Medico entidade)
    {
      _Context.Update(entidade);
      _Context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _Context.Remove(GetById(chave));
      _Context.SaveChanges();
    }

    public Medico GetById(object chave) => _Context.Find<Medico>(chave);
  }
}