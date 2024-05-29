using RestaurantApp.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VeritabaniErisimKatmani.Repository.Abstracts
{
    public interface IUrunRepository : IRepository<Urun>
    {
        List<Urun> GetAllWithKategori();
        Urun GetItemWithKategori(int id);
    }
}
