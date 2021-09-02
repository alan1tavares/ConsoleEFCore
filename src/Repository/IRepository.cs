using System.Collections.Generic;

namespace ConsoleEFCore.Repository
{   
    public interface IRepository<Entidade>
    {
        IList<Entidade> GetAll();
        Entidade GetById(object chave);
        void Salvar(Entidade entidade);
        void Editar(Entidade entidade);
        void Excluir(object chave);
    }
}