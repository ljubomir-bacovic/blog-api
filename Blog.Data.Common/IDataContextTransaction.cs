using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Common
{
    public interface IDataContextTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
