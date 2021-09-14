using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class EnfermariaRepository : IRepository<Enfermaria>
  {
    private HospitalContext _Context;

    public EnfermariaRepository(HospitalContext context) => _Context = context;

    public IList<Enfermaria> GetAll() =>
      _Context.Enfermarias
        .Include(enfermaria => enfermaria.EnfermariaMedico)
        .ThenInclude(enfermariaMedico => enfermariaMedico.Medico)
        .ToList();

    public void Salvar(Enfermaria entidade)
    {
      _Context.Add(entidade);
      _Context.SaveChanges();
    }

    public void Editar(Enfermaria entidade)
    {
      _Context.Update(entidade);
      _Context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _Context.Remove(GetById(chave));
      _Context.SaveChanges();
    }
    
    public Enfermaria GetById(object chave) => _Context.Find<Enfermaria>(chave);
  }
}