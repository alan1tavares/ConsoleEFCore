using System.Collections.Generic;

namespace ConsoleEFCore.Repository
{
    public interface IRepositorio<Entidade>
    {
        IList<Entidade> GetPacientes();
        Entidade GetById(int id);
        void Salvar(Entidade entidade);
        void Editar(Entidade entidade);
        void Excluir(int idEntidade);
    }
}