using System.Collections.Generic;

namespace ConsoleEFCore.Repository
{
    public interface IRepository<Entidade>
    {
        IList<Entidade> GetAll();
        Entidade GetById(int id);
        void Salvar(Entidade entidade);
        void Editar(Entidade entidade);
        void Excluir(int idEntidade);
    }
}