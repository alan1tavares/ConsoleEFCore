using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class PacienteRepository : IRepository<Paciente>
  {
    private HospitalContext _context;
    public PacienteRepository(HospitalContext context) => _context = context;

    public IList<Paciente> GetAll()
    {
      return _context.Pacientes
        .Include(paciente => paciente.Endereco)
        .ToList();
    }

    public void Salvar(Paciente entidade)
    {
      _context.Add(entidade);
      _context.SaveChanges();
    }

    public void Editar(Paciente entidade)
    {
      _context.Update(entidade);
      _context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _context.Remove(GetById(chave));
      _context.SaveChanges();
    }

    public Paciente GetById(object chave) => _context.Find<Paciente>(chave);
  }
}