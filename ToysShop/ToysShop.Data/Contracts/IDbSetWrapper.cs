using System;
using System.Linq;
using System.Linq.Expressions;

namespace ToysShop.Data.Contracts
{
    public interface IDbSetWrapper<T>
        where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includeExpression);

        T GetById(int? id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
