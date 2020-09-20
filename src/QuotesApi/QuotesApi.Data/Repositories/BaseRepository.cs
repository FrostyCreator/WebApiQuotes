using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuotesApi.Data.Context;
using QuotesApi.Data.Models.Models;
using QuotesApi.Data.Repositories.Abstract;

namespace QuotesApi.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, IEntity, new()
    {
        protected readonly MainContext db;

        public BaseRepository(MainContext db)
        {
            this.db = db;
        }

        public virtual bool Add(T entity)
        {
            entity.Id = GetNextId();
            db.Set<T>().Add(entity);
            
            return true;
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = db.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = db.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entitysToRemove = db.Set<T>().Where(predicate);

            foreach (var entity in entitysToRemove) db.Entry(entity).State = EntityState.Deleted;
        }

        public virtual T GetById(int id)
        {
            return db.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsEnumerable();
        }

        public virtual int Count()
        {
            return db.Set<T>().Count();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>()
                .Where(predicate)
                .AsEnumerable();
        }

        public virtual void Commit()
        {
            db.SaveChanges();
        }

        public int GetNextId()
        {
            return db.Set<T>().Max(x => x.Id) + 1;
        }
    }
}