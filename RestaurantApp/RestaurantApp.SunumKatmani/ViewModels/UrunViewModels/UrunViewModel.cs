using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.SunumKatmani.ViewModels.UrunViewModels
{
    public class UrunViewModel : BaseViewModel
    {
        private Urun _urun;
        private ObservableCollection<Kategori> _kategori;
        public Urun Urun { get { return _urun; }}

        public int Id
        {
            get { return _urun.Id; }
            set
            {
                if(_urun.Id != value)
                {
                    _urun.Id = value;
                    onPropertyChanged();
                }
            }
        }
        public string Ad
        {
            get { return _urun.Ad; }
            set
            {
                if (_urun.Ad != value)
                {
                    _urun.Ad = value;
                    onPropertyChanged();
                }
            }
        }
        public decimal Fiyat
        {
            get { return _urun.Fiyat; }
            set
            {
                if (_urun.Fiyat != value)
                {
                    _urun.Fiyat = value;
                    onPropertyChanged();
                }
            }
        }

        public int KategoriId
        {
            get { return _urun.KategoriId; }
            set
            {
                if(_urun.KategoriId != value)
                {
                    _urun.KategoriId = value;
                    onPropertyChanged();
                }
            }
        }
        public Kategori Kategori
        {
            get { return _urun.Kategori; }
            set
            {
                if (_urun.Kategori != value)
                {
                    _urun.Kategori = value;
                    onPropertyChanged();
                }
            }
        }
        public ObservableCollection<Kategori> Kategoriler
        {
            get { return _kategori; }
            set
            {
                if (_kategori != value)
                {
                    _kategori = value;
                    onPropertyChanged();
                }
            }
        }
        
        public UrunViewModel() : this(new Urun()){ }
        public UrunViewModel(Urun urun)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
                Kategoriler = new ObservableCollection<Kategori>(unitOfWork.KategoriRepo.GetAll());
            this._urun = urun;
        }

    }
}
