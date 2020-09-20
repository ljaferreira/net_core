using System;
using System.Linq;
using System.Linq.Expressions;
using LJAF.Domain.Entity;

namespace LJAF.Domain.Contract.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
