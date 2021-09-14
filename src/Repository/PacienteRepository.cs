using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class PacienteRepository : IRepository<Paciente>
  {
    private HospitalContext _Context;
    public PacienteRepository(HospitalContext context) => _Context = context;

    public IList<Paciente> GetAll()
    {
      return _Context.Pacientes
        .Include(paciente => paciente.Endereco)
        .ToList();
    }

    public void Salvar(Paciente entidade)
    {
      _Context.Add(entidade);
      _Context.SaveChanges();
    }

    public void Editar(Paciente entidade)
    {
      _Context.Update(entidade);
      _Context.SaveChanges();
    }

    public void Excluir(object chave)
    {
      _Context.Remove(GetById(chave));
      _Context.SaveChanges();
    }

    public Paciente GetById(object chave) => _Context.Find<Paciente>(chave);
  }
}