using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class ConsultaRepository : IRepository<Consulta>
  {
    private HospitalContext _context;

    public ConsultaRepository(HospitalContext context) => _context = context;

    public IList<Consulta> GetAll() => _context.Consultas.ToList();

    public void Salvar(Consulta entidade)
    {
      _context.Add(entidade);
      _context.SaveChanges();
    }

    public void Editar(Consulta entidade)
    {
      _context.Update(entidade);
      _context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _context.Consultas.Remove(GetById(chave));
      _context.SaveChanges();
    }

    public Consulta GetById(object chave) => _context.Find<Consulta>(chave);
  }
}