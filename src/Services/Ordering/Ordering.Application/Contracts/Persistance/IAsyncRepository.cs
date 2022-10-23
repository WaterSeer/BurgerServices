using Ordering.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T,bool>> predicate, CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken,
            Expression<Func<T,bool>> predicate = null, 
            Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);

        Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken,
          Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
          List<Expression<Func<T, object>>> includes = null,
          bool disableTracking = true);

        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
