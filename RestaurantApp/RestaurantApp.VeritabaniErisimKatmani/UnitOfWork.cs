using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani.DatabaseAccess;
using RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts;
using RestaurantApp.VeritabaniErisimKatmani.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VeritabaniErisimKatmani
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext context;
        private IRepository<Kategori> _kategoriRepo;
        private IUrunRepository _urunRepo;
        private IKullaniciRepository _kullaniciRepo;

        public UnitOfWork()
        {
            context = new AppDbContext();
        }

        public IUrunRepository UrunRepo
        {
            get
            {
                if (_urunRepo == null)
                    _urunRepo = new UrunRepository(context);
                return _urunRepo;
            }
        }
        public IKullaniciRepository KullaniciRepo
        {
            get
            {
                if(_kullaniciRepo == null) 
                    _kullaniciRepo = new KullaniciRepository(context);
                return _kullaniciRepo;
            }
        }
        public IRepository<Kategori> KategoriRepo
        {
            get
            {
                if (_kategoriRepo == null)
                    _kategoriRepo = new Repository<Kategori>(context);
                return _kategoriRepo;
            }
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context?.Dispose();
            _kategoriRepo?.Dispose();
            _urunRepo?.Dispose();
            _kullaniciRepo?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
