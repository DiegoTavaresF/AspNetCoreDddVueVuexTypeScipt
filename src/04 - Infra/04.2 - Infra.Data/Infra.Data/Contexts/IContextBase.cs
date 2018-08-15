using Ddd.Domain.Entities.Produtos;
using Ddd.Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ddd.Infra.Data.Contexts
{
    public interface IContextBase
    {
        DbSet<Produto> Produtos { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}