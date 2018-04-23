using BlogSimple.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BlogSimple.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
    }
}
