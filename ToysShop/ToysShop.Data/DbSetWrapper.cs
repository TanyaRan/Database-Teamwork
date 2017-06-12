using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using ToysShop.Data.Contracts;

namespace ToysShop.Data
{
    public class DbSetWrapper<T> : IDbSetWrapper<T>
        where T : class
    {
        private readonly ToysShopDbContext context;
        private readonly IDbSet<T> dbSet;

        public DbSetWrapper(ToysShopDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> All
        {
            get
            {
                return this.dbSet;
            }
        }

        public T GetById(int? id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }

        //public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression)
        //{
        //    return this.dbSet.Where(filterExpression).ToList();
        //}

        public IQueryable<T> AllWithInclude<TProperty>(Expression<Func<T, TProperty>> includeExpression)
        {
            return this.All.Include(includeExpression);
        }
    }
}
