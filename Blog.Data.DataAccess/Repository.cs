using Blog.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Data.DataAccess
{
    public class Repository<T> : IRepository<T>
            where T : class, IEntity
    {
        #region Private Fields and Constants

        private readonly DbContext _context;
        private readonly DbSet<T> _dataSet;

        public Repository()
        {
        }

        #endregion

        #region Constructors

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dataSet = context.Set<T>();
        }

        #endregion

        #region IRepository<T> Members

        public void AddOrUpdate(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dataSet.Add(entity);
            }
        }

        public void AddOrUpdate(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            foreach (var entity in entities)
            {
                AddOrUpdate(entity);
            }
        }

        public IQueryable<T> AsQueryable(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> result = _dataSet;
            if (includeExpressions != null && includeExpressions.Any())
            {
                result = includeExpressions.Aggregate(result, (query, expression) => query.Include(expression));
            }

            return result.AsQueryable();
        }

        public T Find(params object[] keyValues)
        {
            if (keyValues == null)
            {
                throw new ArgumentNullException(nameof(keyValues));
            }
            if (keyValues.Length == 0)
            {
                throw new ArgumentException("Key values array shouldn't be empty", nameof(keyValues));
            }

            return _dataSet.Find(keyValues);
        }

        public void Remove(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dataSet.Attach(entity);
            }

            _dataSet.Remove(entity);
        }

        public void Remove(Expression<Func<T, bool>> expression)
        {
            var entities = _dataSet.Where(expression);
            _dataSet.RemoveRange(entities);
        }

        #endregion
    }
}
