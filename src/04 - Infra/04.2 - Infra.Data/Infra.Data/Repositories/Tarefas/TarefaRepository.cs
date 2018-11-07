using Ddd.Domain.Entities.Tarefas;
using Ddd.Domain.Repositories;
using Ddd.Infra.Data.Contexts;

namespace Ddd.Infra.Data.Repositories.Tarefas
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ContextBase context)
            : base(context)
        {
        }
    }
}