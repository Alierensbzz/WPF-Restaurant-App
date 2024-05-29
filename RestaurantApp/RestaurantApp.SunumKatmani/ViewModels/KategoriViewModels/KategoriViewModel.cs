using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.VarlikKatmani.Models;

namespace RestaurantApp.SunumKatmani.ViewModels.KategoriViewModels
{
    public class KategoriViewModel : BaseViewModel
    {
        private Kategori _kategori;
        public Kategori Kategori { get {  return _kategori; } }
    
        public int Id
        {
            get
            {
                return _kategori.Id;
            }
            set
            {
                if(_kategori.Id != value)
                {
                    _kategori.Id = value;
                    onPropertyChanged();
                }
            }
        }
        public string Ad
        {
            get
            {
                return _kategori.Ad;
            }
            set
            {
                if(_kategori.Ad != value)
                {
                    _kategori.Ad = value;
                    onPropertyChanged();
                }
            }
        }
        public KategoriViewModel() : this(new Kategori()) { }
        public KategoriViewModel(Kategori item)
        {
            this._kategori = item;
        }
    }
}
