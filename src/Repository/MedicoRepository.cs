using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class MedicoRepository : IRepository<Medico>
  {
    private HospitalContext _context;

    public MedicoRepository(HospitalContext context) => _context = context;

    public IList<Medico> GetAll() => _context.Medicos.ToList();

    public void Salvar(Medico entidade)
    {
      _context.Add(entidade);
      _context.SaveChanges();
    }

    public void Editar(Medico entidade)
    {
      _context.Update(entidade);
      _context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _context.Remove(GetById(chave));
      _context.SaveChanges();
    }

    public Medico GetById(object chave) => _context.Find<Medico>(chave);
  }
}