using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani.DatabaseAccess;
using RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Concrete
{
    public class UrunRepository : Repository<Urun>, IUrunRepository
    {
        public UrunRepository(AppDbContext context) : base(context)
        {
        }

        public List<Urun> GetAllWithKategori()
        {
            return context.Urunler.Include(x=>x.Kategori).ToList();
        }

        public Urun GetItemWithKategori(int id)
        {
            return context.Urunler.Include(x=>x.Kategori).FirstOrDefault(x=> x.Id == id);
        }
    }
}
