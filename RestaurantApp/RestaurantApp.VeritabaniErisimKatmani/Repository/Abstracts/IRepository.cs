using System;
using System.Collections.Generic;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T GetItem(object id);
        T Insert(T item);    
        T Update(T item);
        void Remove(object id);

    }
}
