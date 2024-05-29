using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.SunumKatmani.ViewModels.KullanıcıViewModels
{
    public class KullanıcıViewModel : BaseViewModel
    {
        public Kullanici _kullanici;
        public Kullanici kullanici { get { return _kullanici; } }

        public bool Eklememi { get; set; }
        public string KullaniciAdi
        {
            get
            {
                return _kullanici.KullaniciAdi;
            }
            set
            {
                if (_kullanici.KullaniciAdi != value)
                {
                   _kullanici.KullaniciAdi = value;
                   onPropertyChanged();
                }
            }
        }
        public string Parola
        {
            get
            {
                return _kullanici.Parola;
            }
            set
            {
                if (_kullanici.Parola != value)
                {
                    _kullanici.Parola = value;
                    onPropertyChanged();
                }
            }
        }

        public KullanıcıViewModel(): this(new Kullanici()){}
        public KullanıcıViewModel(Kullanici kullanici)
        {
 
            _kullanici = kullanici;
        }

    }
}
