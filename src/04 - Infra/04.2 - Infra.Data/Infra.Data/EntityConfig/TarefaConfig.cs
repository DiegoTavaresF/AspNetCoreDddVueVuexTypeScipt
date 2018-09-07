using Ddd.Domain.Base;
using Ddd.Domain.Entities.Tarefas;
using Microsoft.EntityFrameworkCore;

namespace Ddd.Infra.Data.EntityConfig
{
    public class TarefaConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(e =>
            {
                e.ToTable(nameof(Tarefa));

                e.HasKey(w => w.Id);

                e.Property(w => w.Titulo).HasMaxLength(ColumnLengths.TarefaTituloMaxLength).IsRequired();
                e.Property(w => w.Descricao).HasMaxLength(ColumnLengths.TarefaDescricaoMaxLength);
            });
        }
    }
}