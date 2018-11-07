using Ddd.Domain.Base;
using Ddd.Infra.Data.CrossCutting.Resources;

namespace Ddd.Domain.Entities.Tarefas
{
    public class Tarefa : EntityBase
    {
        public Tarefa(string descricao, string titulo)
        {
            SetDescricao(descricao);
            SetTitulo(titulo);
        }

        public Tarefa()
        {
        }

        public string Descricao { get; private set; }
        public string Titulo { get; private set; }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                AddError(DomainResources.Tarefa_TituloEObrigatorio);
                return;
            }

            Titulo = titulo;
        }
    }
}