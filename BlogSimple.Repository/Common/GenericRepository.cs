using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BlogSimple.Model;
using BlogSimple.Model.Common;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing;

namespace BlogSimple.Repository
{
    public abstract class GenericRepository<T, TContext> : IGenericRepository<T> where T : BaseEntity where TContext:DbContext
    {
        private readonly TContext _dbContext;
        private readonly DbSet<T> _entity;

    protected GenericRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _entity = dbContext.Set<T>();
    }

    public void Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException();
        _dbContext.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _entity.AsEnumerable();
    }

    public void Insert(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException();

        _dbContext.Add(entity);
    }

    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException();

    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _entity.Where(predicate).AsEnumerable();
    }
    }
}
