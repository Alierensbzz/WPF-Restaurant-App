using MaterialDesignThemes.Wpf;
using RestaurantApp.SunumKatmani.Commons;
using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.SunumKatmani.Views.KategoriViews;
using RestaurantApp.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.SunumKatmani.ViewModels.KategoriViewModels
{
    public class KategoriListViewModel : BaseViewModel
    {
        private readonly UnitOfWork unitOfWork;
        private ObservableCollection<KategoriViewModel> _items;
        private KategoriViewModel _selectedItem;


        public ObservableCollection<KategoriViewModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    onPropertyChanged();
                }
            }
        }
        public KategoriViewModel SelectedItem
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


        public KategoriListViewModel()
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
            var items = unitOfWork.KategoriRepo.GetAll();
            Items = new ObservableCollection<KategoriViewModel>();
            foreach (var item in items)
            {
                Items.Add(new KategoriViewModel(item));
            }
        }
        private void OnInsert()
        {
            KategoriViewModel vm = new KategoriViewModel();
            KategoriView view = new KategoriView
            {
                Title = "Kategori Ekle",
                DataContext = vm,
            };
            if (view.ShowDialog() == true)
            {
                var item = unitOfWork.KategoriRepo.Insert(vm.Kategori);
                unitOfWork.Save();
                Items.Add(new KategoriViewModel(item)); 
            }
        }

        private void OnDelete()
        {
            if (MessageBox.Show(_selectedItem.Ad + " adlı kategoriyi silmek istiyor musunuz?", "Departman Sil", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                unitOfWork.KategoriRepo.Remove(_selectedItem.Id);
                unitOfWork.Save();
                Items.Remove(_selectedItem);
            }
        }

        private void OnUpdate()
        {
            KategoriView view = new KategoriView
            {
                Title = "Kategori Güncelle",
                DataContext = _selectedItem,
            };

            if (view.ShowDialog() == true)
            {
                var item = unitOfWork.KategoriRepo.Update(_selectedItem.Kategori);
                unitOfWork.Save();
            }
        }
    }
}
