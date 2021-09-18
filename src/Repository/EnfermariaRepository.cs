using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class EnfermariaRepository : IRepository<Enfermaria>
  {
    private HospitalContext _context;

    public EnfermariaRepository(HospitalContext context) => _context = context;

    public IList<Enfermaria> GetAll() =>
      _context.Enfermarias
        .Include(enfermaria => enfermaria.EnfermariaMedico)
        .ThenInclude(enfermariaMedico => enfermariaMedico.Medico)
        .ToList();

    public void Salvar(Enfermaria entidade)
    {
      _context.Add(entidade);
      _context.SaveChanges();
    }

    public void Editar(Enfermaria entidade)
    {
      _context.Update(entidade);
      _context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _context.Remove(GetById(chave));
      _context.SaveChanges();
    }
    
    public Enfermaria GetById(object chave) => _context.Find<Enfermaria>(chave);
  }
}