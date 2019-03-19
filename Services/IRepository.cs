using ModelDesignFirst_L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        void Add(T entity);
        T FindById(int entityId);
        void Delete(T entity);
        void Save();
    }
}
