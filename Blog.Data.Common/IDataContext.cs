using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Common
{
    public interface IDataContext : IDisposable
    {
        #region Public Properties

        /// <summary>
        ///     Turns on/off an automatical detection of changes within context change tracker
        /// </summary>
        bool AutoDetectChangesEnabled { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Creates a new transaction scope to join few SaveChanges operations.
        /// </summary>
        /// <remarks>
        ///     Should be properly disposed before leaving usage scope.
        /// </remarks>
        /// <returns>
        ///     A transaction object
        /// </returns>
        IDataContextTransaction BeginTransaction();

        /// <summary>
        ///     Detaches all the entities of type <typeparamref name="T" /> from context change tracker.
        /// </summary>
        /// <typeparam name="T">
        ///     An entity type to detach
        /// </typeparam>
        void DetachEntries<T>();

        /// <summary>
        ///     Detects changes from context change tracker.
        /// </summary>
        void DetectChanges();

        /// <summary>
        ///     Creates new repository for specified type <typeparamref name="T" /> which
        ///     is intented to apply CRUD operations on entities.
        /// </summary>
        /// <typeparam name="T">
        ///     An entity type to create repository for
        /// </typeparam>
        /// <returns>
        ///     A repository instance
        /// </returns>
        IRepository<T> GetRepository<T>()
            where T : class, IEntity;

        /// <summary>
        ///     Saves changes applied in repositories to database. Can save many batch changes applied by repositories of different types per one call.
        /// </summary>
        void SaveChanges();

        /// <summary>
        ///     Executes raw SQL request againt database and materializes results of specified type <typeparamref name="T" />
        /// </summary>
        /// <typeparam name="T">
        ///     Result type
        /// </typeparam>
        /// <param name="sql">
        ///     Query text
        /// </param>
        /// <param name="parameters">
        ///     Query parameters
        /// </param>
        /// <returns>
        ///     Materialized results of query execution
        /// </returns>
        int SqlQuery<T>(string sql, params object[] parameters);

        #endregion
    }
}
