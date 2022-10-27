using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly OrderContext _orderContext;

        public RepositoryBase(OrderContext orderContext)
        {
            _orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _orderContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            return await _orderContext.Set<T>().Where(predicate).ToListAsync();
        }







        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        

        public Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

        public Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
