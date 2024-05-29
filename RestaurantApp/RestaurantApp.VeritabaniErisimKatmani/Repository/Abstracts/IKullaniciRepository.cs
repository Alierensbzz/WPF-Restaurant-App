using RestaurantApp.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Kullanici Login(string username, string password);
    }
}
