using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
using Data;
using Data.Interfaces;
using Infrastructure;

namespace Data
{
    public class EntityBaseRepo<T> : IEntityBaseRepo<T> where T : class, IEntityBase, new()
    {
        private MoviesDBEntities dataContext;

        private readonly IDbFactory dbFactory;

        public EntityBaseRepo(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MoviesDBEntities DataContext {
            get { return dataContext ?? (dataContext = this.dbFactory.Init()); }
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var querry = this.GetAll();
            foreach (var property in includeProperties)
            {
                querry.Include(property);
            }
            return querry;
        }

        public virtual IQueryable<T> All
        {
            get { return this.GetAll(); }
        }

        public virtual IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public T GetSingle(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> FindBy(Func<T, bool> predicate)
        {
            return this.GetAll().AsEnumerable().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            var dbEntityEntry = DataContext.Entry<T>(entity);
            DataContext.Set<T>().Add(entity);
            dbEntityEntry.State = EntityState.Added;
        }

        public virtual void Delete(T entity)
        {
            var dbEntityEntry = DataContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Edit(T entity)
        {
            var dbEntityEntry = DataContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}