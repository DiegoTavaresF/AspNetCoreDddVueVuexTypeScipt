using System;
using System.Linq;

namespace Ddd.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        IQueryable<TEntity> GetAll();

        TEntity GetById(long id);

        void Excluir(TEntity entity);

        int SaveChanges();

        void Update(TEntity obj);
    }
}