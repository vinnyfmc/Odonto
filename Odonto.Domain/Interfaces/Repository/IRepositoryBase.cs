using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Odonto.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(long id);

        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
