using Odonto.Domain.Interfaces.Repository;
using Odonto.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Odonto.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal OdontoContext context;
        internal DbSet<T> dbSet;

        public RepositoryBase(OdontoContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public virtual void Remove(T obj)
        {
            if (context.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);
        }

        public virtual void Remove(long id)
        {
            T TObj = GetById(id);
            Remove(TObj);
        }

        public virtual void Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
