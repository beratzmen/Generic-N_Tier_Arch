using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Generic.Dal
{
    public interface IRepository<T>/* where T : class, new()*/
    {
        T Get(Expression<Func<T, bool>> predicate = null);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        void Insert(T Entity);
        void Update(T Entity);
        /*T Entity*/
        //Expression<Func<T, bool>> predicate = null
        void Delete(T Entity);
    }
}
