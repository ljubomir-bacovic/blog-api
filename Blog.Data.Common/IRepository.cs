using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Data.Common
{
    public interface IRepository<T>
            where T : class, IEntity
    {
        #region Public Methods

        /// <summary>
        ///     Adds entity to context if it has not been saved or attaches and sets to modified state.
        /// </summary>
        /// <param name="entity">
        ///     An entity reference.
        /// </param>
        void AddOrUpdate(T entity);

        /// <summary>
        ///     Adds entities to context if they have not been saved or attaches and sets to modified state.
        /// </summary>
        /// <param name="entities">
        ///     Collection of entities
        /// </param>
        void AddOrUpdate(IEnumerable<T> entities);

        /// <summary>
        ///     Gets a reference to queryable entities.
        ///     Entities don't load immediately.
        /// </summary>
        /// <returns>
        ///     A reference to queryable entities
        /// </returns>
        IQueryable<T> AsQueryable(params Expression<Func<T, object>>[] includeExpressions);

        /// <summary>
        ///     Finds a single entity using primary key values <paramref name="keyValues" />
        /// </summary>
        /// <param name="keyValues">
        ///     Primary key values
        /// </param>
        /// <returns>
        ///     A single entity whose primary key matches <paramref name="keyValues" />
        /// </returns>
        T Find(params object[] keyValues);

        /// <summary>
        ///     Removes entity from context
        /// </summary>
        /// <param name="entity">
        ///     An entity reference
        /// </param>
        void Remove(T entity);

        /// <summary>
        ///     Removes entities from context
        /// </summary>
        /// <param name="entities">
        ///     Collection of entities
        /// </param>
        void Remove(IEnumerable<T> entities);

        /// <summary>
        ///     Removes entities from context using <paramref name="expression" /> as condition.
        /// </summary>
        /// <param name="expression">
        ///     A condition for selected entities to remove.
        /// </param>
        void Remove(Expression<Func<T, bool>> expression);

        #endregion
    }
}
