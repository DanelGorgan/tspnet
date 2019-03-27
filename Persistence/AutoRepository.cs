using Microsoft.EntityFrameworkCore;
using ModelDesignFirst_L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence
{
    public class AutoRepository<T> : IRepository<T> where T : IEntity
    {
        DbSet<T> table = null;
        AutoContext context { get; }

        public AutoRepository()
        {

        }

        public AutoRepository(AutoContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int entityId)
        {
            var entity = table.Find(entityId);
            table.Remove(entity);
        }

        public T FindById(int entityId)
        {
            return table.Find(entityId);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        IQueryable<T> IRepository<T>.Where(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).AsQueryable();
        }
    }
}
