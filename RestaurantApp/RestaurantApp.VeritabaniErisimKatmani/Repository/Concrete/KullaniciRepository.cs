using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani.DatabaseAccess;
using RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Concrete
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici Login(string username, string password)
        {
            return context.Set<Kullanici>().FirstOrDefault(x =>
            x.KullaniciAdi.ToLower().Equals(username.ToLower()) &&
            x.Parola.Equals(password));
        }
    }
}
