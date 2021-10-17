using System;
using System.Linq;
using System.Linq.Expressions;

namespace NewtonChallenge.DataAccessObjects.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
        IQueryable<T> NoTrackingList(Expression<Func<T, bool>> expression);
    }
}
