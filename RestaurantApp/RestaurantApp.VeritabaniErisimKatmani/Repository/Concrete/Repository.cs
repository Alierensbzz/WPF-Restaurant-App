using RestaurantApp.VarlikKatmani.Base;
using RestaurantApp.VeritabaniErisimKatmani.DatabaseAccess;
using RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Concrete
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetItem(object id)
        {
            return context.Set<T>().Find(id);
        }

        public T Insert(T item)
        {
            return context.Set<T>().Add(item);
        }

        public void Remove(object id)
        {
            context.Set<T>().Remove(GetItem(id));
        }

        public T Update(T item)
        {
            if (context.Entry<T>(item).State == System.Data.Entity.EntityState.Detached)
                item = context.Set<T>().Attach(item);
            context.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
