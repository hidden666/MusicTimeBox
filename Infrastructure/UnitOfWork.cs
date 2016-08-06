using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data
{
    class UnitOfWork : IUnitOfWork 
    {
        private readonly IDbFactory dbFactory;
        private  DbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DbContext DbContext
        {
            get { return this.dbContext ?? (this.dbContext = this.dbFactory.Init()); }
        }

        public void Commit()
        {
            this.DbContext.SaveChanges();
        }
    }
}
