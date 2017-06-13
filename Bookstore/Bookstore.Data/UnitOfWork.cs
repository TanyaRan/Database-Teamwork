using Bookstore.Data.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "DbContext").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public void Dispose()
        {
        }

        public void Complete()
        {
            this.dbContext.SaveChanges();
        }
    }
}
