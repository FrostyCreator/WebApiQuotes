using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuotesApi.Data.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class, new()
    {
        bool Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        int Count();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate);
        void Commit();
        int GetNextId();
    }
}