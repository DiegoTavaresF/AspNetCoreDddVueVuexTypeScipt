using Ddd.Domain.UnitOfWork;
using Ddd.Infra.Data.Contexts;

namespace Ddd.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextBase _context;

        public UnitOfWork(ContextBase context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}