using System;
using System.Linq;
using System.Linq.Expressions;
using LJAF.Domain.Contract.Repositories;
using LJAF.Domain.Entity;
using LJAF.Infra.Data.Context;

namespace LJAF.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        protected readonly LjafContext _context;

        public BaseRepository(LjafContext context)
        {
            _context = context;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
