using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace aspNetEssencial.Repository 
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        T GetById(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}