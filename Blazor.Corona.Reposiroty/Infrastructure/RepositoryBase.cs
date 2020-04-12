using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Infrastructure
{
    /// <summary>
    /// DbSet 기본 쿼리문 Base Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        #region Private Member
        protected CoronaContext Context;
        private readonly DbSet<T> dbset;
        #endregion

        #region Constructor
        public RepositoryBase(CoronaContext context)
        {
            Context = context;
            dbset = context.Set<T>();
        }
        #endregion

        #region Basic Repository Function Area

        #region Add Function Area : Entity 추가
        /// <summary>
        /// Entity 추가
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            dbset.Add(entity);
            return Context.SaveChanges();
        }

        /// <summary>
        /// Entity 추가 : 비동기
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public virtual async Task<int> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            await dbset.AddAsync(entity, cancellationToken);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// 여러개의 Entity 추가
        /// </summary>
        /// <param name="entities">entity 목록</param>
        /// <returns></returns>
        public virtual int AddRange(IEnumerable<T> entities)
        {
            dbset.AddRange(entities);
            return Context.SaveChanges();
        }
        /// <summary>
        /// 여러개의 Entity 추가 : 비동기
        /// </summary>
        /// <param name="entities">entity 목록</param>
        /// <returns></returns>
        public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            await dbset.AddRangeAsync(entities, cancellationToken);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Delete Function Area : Entity 삭제
        /// <summary>
        /// Entity 삭제하기
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
            Context.SaveChanges();
        }
        /// <summary>
        /// Entity 삭제하기
        /// </summary>
        /// <param name="where">조건식</param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            dbset.RemoveRange(objects);
            Context.SaveChanges();
        }
        /// <summary>
        /// Entity 삭제하기 : 비동기
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            dbset.Remove(entity);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Entity 삭제하기 : 비동기 
        /// </summary>
        /// <param name="where">조건식</param>
        /// <param name="cancellation">CancellationToken</param>
        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            IEnumerable<T> objects = await dbset.Where<T>(where).ToListAsync();//.AsEnumerable();
            dbset.RemoveRange(objects);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Find Function Area : Entity 찾기 With 조건문
        /// <summary>
        /// 해당 Entity 찾기
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>Eitnty of Typeof(T)</returns>
        public T Find(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).AsNoTracking().FirstOrDefault<T>();
        }
        /// <summary>
        /// 해당 Entity 찾기 : 비동기
        /// </summary>
        /// <param name="where">조건식</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns>>Eitnty of Typeof(T)</returns>
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await dbset.Where(where).AsNoTracking().FirstOrDefaultAsync<T>(cancellationToken);
        }
        /// <summary>
        /// 해당 Entities 찾기 
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>Entities of Typeof(T)</returns>
        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).AsNoTracking().ToList<T>();
        }
        /// <summary>
        /// 해당 Entities 찾기 
        /// </summary>
        /// <param name="where">조건식</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns>Entities of Typeof(T)</returns>
        public virtual async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await dbset.Where(where).AsNoTracking().ToListAsync<T>(cancellationToken);
        }
        /// <summary>
        /// id 로 entity 찾기
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Entity</returns>
        public virtual T FindById(int id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// id 로 entity 찾기 : 비동기
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>entity</returns>
        public virtual async Task<T> FindByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await dbset.FindAsync(id);
        }
        #endregion

        #region GetAll Function Area : 모든 Entity 가져오기
        /// <summary>
        /// 모든 Entity 반환
        /// </summary>
        /// <returns>All entities of typeof(T)</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsNoTracking().ToList();
        }
        /// <summary>
        /// 모든 Entity 반환 : 비동기
        /// </summary>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns>All entities of typeof(T)</returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await dbset.AsNoTracking().ToListAsync(cancellationToken);
        }
        #endregion

        #region Update Function Area : Entity 수정 
        /// <summary>
        /// Entity 내용 수정
        /// </summary>
        /// <param name="entity">Entity of typeof(T)</param>
        public virtual void Update(T entity)
        {
            dbset.Update(entity);
            Context.SaveChanges();
        }
        /// <summary>
        /// Entity 내용 수정 : 비동기
        /// </summary>
        /// <param name="entity">Entity of typeof(T)</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns></returns>
        public virtual async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            dbset.Update(entity);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Entities 내용 수정
        /// </summary>
        /// <param name="entities">Entities of typeof(T)</param>
        public virtual void Updates(IEnumerable<T> entities)
        {
            dbset.UpdateRange(entities);
            Context.SaveChanges();
        }
        /// <summary>
        /// Entities 내용 수정
        /// </summary>
        /// <param name="entities">Entities of typeof(T)</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns></returns>
        public virtual async Task<int> UpdatesAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            dbset.UpdateRange(entities);
            return await Context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IQuerable Function Area
        /// <summary>
        /// 쿼리 반환
        /// </summary>
        /// <returns>dbset</returns>
        public virtual IQueryable<T> Queryable()
        {
            return dbset;
        }
        #endregion

        #region Count Function Area : Entity 갯수 반환 쿼리 생성
        /// <summary>
        /// 반환되는 Entities 의 갯수
        /// </summary>
        /// <param name="where">조건식</param>
        /// <returns>Entitiis 갯수</returns>
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            if (where == null)
            {
                return dbset.AsNoTracking().Count();
            }
            return dbset.Where(where).AsNoTracking().Count();
        }
        /// <summary>
        /// 반환되는 Entities 의 갯수 : 비동기
        /// </summary>
        /// <param name="where">조건식</param>
        /// <param name="cancellation">CancellationToken</param>
        /// <returns>Entitiis 갯수</returns>
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (where == null)
            {
                return await dbset.AsNoTracking().CountAsync(cancellationToken);
            }
            return await dbset.Where(where).AsNoTracking().CountAsync(cancellationToken);
        }
        #endregion

        #region Select Function Area : Paging 쿼리 구문 사용시 
        public IQueryable<T> Select(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<T> query = dbset;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.AsExpandable().Where(filter); //.AsQueryable().Where(filter); //.AsExpandable().Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query;

        }

        public async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           List<Expression<Func<T, object>>> includes = null,
           int? page = null,
           int? pageSize = null,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var query = Select(filter, orderBy, includes, page, pageSize);

            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }
        #endregion

        #endregion
    }
}
