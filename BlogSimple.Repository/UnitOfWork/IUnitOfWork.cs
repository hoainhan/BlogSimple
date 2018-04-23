using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSimple.Repository.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
