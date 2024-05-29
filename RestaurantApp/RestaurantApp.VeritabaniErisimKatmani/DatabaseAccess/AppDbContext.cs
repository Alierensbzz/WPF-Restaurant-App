using RestaurantApp.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VeritabaniErisimKatmani.DatabaseAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kullanici> Kullanıcılar { get; set; }

        public AppDbContext() : base("RestaurantAppDb03")
        {
            Database.SetInitializer(new MyINIT());
        }
    }
    public class MyINIT : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            base.Seed(context);

            //Kullanıcı
            context.Kullanıcılar.Add(new Kullanici { KullaniciAdi = "admin", Parola = "1" });
            context.SaveChanges();

            //Kategori
            var kategori1 = context.Kategoriler.Add(new Kategori { Ad = "Başlangıç" });
            var kategori2 = context.Kategoriler.Add(new Kategori { Ad = "Ana Yemek" });
            var kategori3 = context.Kategoriler.Add(new Kategori { Ad = "Tatlılar" });
            var kategori4 = context.Kategoriler.Add(new Kategori { Ad = "İçecekler" });
            context.SaveChanges();


            //Ürünler
            context.Urunler.Add(new Urun { Ad = "Patates Kızartması", Fiyat = 150, Kategori = kategori1 });
            context.Urunler.Add(new Urun { Ad = "Döner", Fiyat = 250, Kategori = kategori2 });
            context.Urunler.Add(new Urun { Ad = "Sütlaç", Fiyat = 120, Kategori = kategori3 });
            context.Urunler.Add(new Urun { Ad = "Kola", Fiyat = 25, Kategori = kategori4 });
            context.SaveChanges();

        }
    }
}
