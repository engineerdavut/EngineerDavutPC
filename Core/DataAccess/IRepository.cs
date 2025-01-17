﻿using System.Linq.Expressions;
using System.Security.Principal;
using RannaPanelManagement.Core.Entity;

namespace RannaPanelManagement.Core.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
