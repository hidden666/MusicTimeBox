using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Data;
using Data.Interfaces;
using Infrastructure;

namespace Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MoviesDBEntities dbContext;

        public MoviesDBEntities Init()
        {
            return this.dbContext ?? (this.dbContext = new MoviesDBEntities());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
                dbContext.Dispose();
        }
    }
}