using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEFCore.Repository
{
  public class PacienteRepository : IRepository<Paciente>
  {
    public IList<Paciente> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Pacientes
          .Include(paciente => paciente.Endereco)
          .ToList();
      }
    }

    public Paciente GetById(object chave)
    {
      Paciente paciente;
      using (var context = new HospitalContext())
      {
        paciente = context.Pacientes.Find(chave);
      }
      return paciente;
    }

    public void Salvar(Paciente entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Pacientes.Add(entidade);
        context.SaveChanges();
      }
    }

    public void Editar(Paciente entidade)
    {
      using (var context = new HospitalContext())
      {
        context.Pacientes.Update(entidade);
        context.SaveChanges();
      }
    }

    public void Excluir(object chave)
    {
      using (var context = new HospitalContext())
      {
        Paciente paciente = context.Pacientes.Find(chave);
        context.Pacientes.Remove(paciente);
        context.SaveChanges();
      }
    }
  }
}