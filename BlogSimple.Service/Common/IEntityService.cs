using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSimple.Service
{
    public interface IEntityService<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        
    }
}
