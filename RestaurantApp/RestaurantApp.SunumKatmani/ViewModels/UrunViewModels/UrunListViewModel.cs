using RestaurantApp.SunumKatmani.Commons;
using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.SunumKatmani.Views.UrunViews;
using RestaurantApp.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.SunumKatmani.ViewModels.UrunViewModels
{
    public class UrunListViewModel : BaseViewModel
    {
        private readonly UnitOfWork unitOfWork;
        private ObservableCollection<UrunViewModel> _items;
        private UrunViewModel _selectedItem;


        public ObservableCollection<UrunViewModel> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    onPropertyChanged();
                }
            }
        }
        public UrunViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    onPropertyChanged();
                }
            }
        }


        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }


        public UrunListViewModel()
        {
            unitOfWork = new UnitOfWork();
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { OnDelete(); }, o => { return _selectedItem != null; });
            UpdateCommand = new RelayCommand(o => { OnUpdate(); }, o => { return _selectedItem != null; });


            OnRefresh();
        }
        private void OnRefresh()
        {
            var items = unitOfWork.UrunRepo.GetAllWithKategori();
            Items = new ObservableCollection<UrunViewModel>();
            foreach (var item in items)
            {
                Items.Add(new UrunViewModel(item));
            }
        }

        private void OnInsert()
        {
            UrunViewModel vm = new UrunViewModel();
            UrunView view = new UrunView
            {
                Title = "Ürün Ekle",
                DataContext = vm
            };

            if (view.ShowDialog() == true)
            {
                var item = unitOfWork.UrunRepo.Insert(vm.Urun);
                unitOfWork.Save();
                Items.Add(new UrunViewModel(item));
            }

        }

        private void OnDelete()
        {
            if (MessageBox.Show(_selectedItem.Urun.Ad + " adlı ürünü silmek istiyor musunuz?", "Ürünü Sil?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                unitOfWork.UrunRepo.Remove(_selectedItem.Urun.Id);
                unitOfWork.Save();
                Items.Remove(_selectedItem);
            }
        }

        private void OnUpdate()
        {
            UrunView view = new UrunView
            {
                Title = "Personel Güncelle",
                DataContext = _selectedItem
            };

            if (view.ShowDialog() == true)
            {
                var item = unitOfWork.UrunRepo.Update(_selectedItem.Urun);
                unitOfWork.Save();
            }
        }
    }
}
