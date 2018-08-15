using Ddd.Domain.Entities.Produtos;
using Microsoft.EntityFrameworkCore;

namespace Ddd.Infra.Data.EntityConfig
{
    public class ProdutoConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(e =>
            {
                e.ToTable("Produto");

                e.HasKey(w => w.Id);

                e.Property(w => w.Nome).HasMaxLength(100).IsRequired();
            });
        }
    }
}