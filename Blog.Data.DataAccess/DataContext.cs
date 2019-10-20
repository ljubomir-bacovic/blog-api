using System;
using System.Linq;
using Blog.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.DataAccess
{
    public class DataContext : IDataContext
    {
        #region Private Methods

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();

                _disposed = true;
            }
        }

        #endregion

        #region Private Fields and Constants

        private readonly DbContext _context;
        private bool _disposed;

        #endregion

        #region Constructors

        /// <summary>
        ///     Creates new DataContext wrapper over DbContext.
        ///     This constructor only for internal usage and for unit-testing.
        /// </summary>
        /// <param name="context">
        ///     A DbContext reference.
        /// </param>
        internal DataContext(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        ///     Creates default DataContext wrapper for Keystone database DbContext instance.
        /// </summary>
        public DataContext(DbContextOptions<BlogContext> options)
            : this(new BlogContext(options))
        {
        }

        #endregion

        #region IDataContext Members

        public bool AutoDetectChangesEnabled
        {
            get => _context.ChangeTracker.AutoDetectChangesEnabled;
            set => _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

        public IDataContextTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return new DataContextTransaction(transaction);
        }

        public void DetachEntries<T>()
        {
            var entries = _context.ChangeTracker.Entries();
            foreach (var entry in entries.Where(e => e.Entity is T)) entry.State = EntityState.Detached;
        }

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IEntity
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public int SqlQuery<T>(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}