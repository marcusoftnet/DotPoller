using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotPoller.Web.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T GetById(int id);
        T GetById(string id);
        void Add(IEnumerable<T> entities);
        T Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(string id);
        IQueryable<T> All(Expression<Func<T, bool>> criteria);
        IQueryable<T> All();
    }
}