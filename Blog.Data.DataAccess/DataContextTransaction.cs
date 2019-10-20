using Blog.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.DataAccess
{
    internal class DataContextTransaction : IDataContextTransaction
    {
        #region Private Fields and Constants

        private readonly IDbContextTransaction _transaction;
        private bool _disposed;

        #endregion

        #region Constructors

        public DataContextTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        #endregion

        #region Private Methods

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #region IDataContextTransaction Members

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
