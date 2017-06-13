using Bookstore.Data.Contracts;
using Bytes2you.Validation;
using System.Data.Entity;
using System.Linq;

namespace Bookstore.Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        public Repository(DbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();

            this.Context = dbContext;
            this.Set = this.Context.Set<T>();
        }

        protected IDbSet<T> Set { get; set; }

        protected DbContext Context { get; set; }

        public T GetById(object id)
        {
            return this.Set.Find(id);
        }

        public IQueryable<T> All
        {
            get { return this.Set; }
        }

        public void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
