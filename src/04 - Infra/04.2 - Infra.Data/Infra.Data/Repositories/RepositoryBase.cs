using Ddd.Domain.Base;
using Ddd.Domain.Repositories;
using Ddd.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Ddd.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ContextBase _context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly int TenantId;

        public RepositoryBase(ContextBase context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(long id)
        {
            return DbSet.FirstOrDefault(w => w.Id == id);
        }

        public virtual void Excluir(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).Property(x => x.Excluido).IsModified = true;
            _context.Entry(entity).Property(x => x.DataDaUltimaAlteracao).IsModified = true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}