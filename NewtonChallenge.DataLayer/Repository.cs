using Microsoft.EntityFrameworkCore;
using NewtonChallenge.DataAccessObjects.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NewtonChallenge.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }
        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(int id)
        {
            // this should return the full row find is faster than linq with first or default.
            return DbSet.Find(id);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public IQueryable<T> NoTrackingList(Expression<Func<T, bool>> expression)
        {
            return DbSet.AsNoTracking().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}