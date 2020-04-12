using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        Task<int> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        int AddRange(IEnumerable<T> entities);
        Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
        int Count(Expression<Func<T, bool>> where);
        Task<int> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken));
        void Delete(Expression<Func<T, bool>> where);
        void Delete(T entity);
        Task<int> DeleteAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> DeleteAsync(T entity, CancellationToken cancellation = default(CancellationToken));
        T Find(Expression<Func<T, bool>> where);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> FindAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken));
        T FindById(int id);
        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        IQueryable<T> Queryable();
        IQueryable<T> Select(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, int? page = null, int? pageSize = null);
        Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, int? page = null, int? pageSize = null, CancellationToken cancellationToken = default(CancellationToken));
        void Update(T entity);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        void Updates(IEnumerable<T> entities);
        Task<int> UpdatesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
    }
}
