using System.Collections.Generic;
using System.Linq;
using ConsoleEFCore.Models;

namespace ConsoleEFCore.Repository
{
  public class PacienteRepository : IRepository<Paciente>
  {
    public IList<Paciente> GetAll()
    {
      using (var context = new HospitalContext())
      {
        return context.Pacientes.ToList();
      }
    }

    public Paciente GetById(int id)
    {
      Paciente paciente;
      using (var context = new HospitalContext())
      {
        paciente = context.Pacientes.Find(id);
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

    public void Excluir(int idEntidade)
    {
      using (var context = new HospitalContext())
      {
        Paciente paciente = context.Pacientes.Find(idEntidade);
        context.Pacientes.Remove(paciente);
        context.SaveChanges();
      }
    }
  }
}