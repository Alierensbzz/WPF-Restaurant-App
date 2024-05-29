using RestaurantApp.SunumKatmani.Commons;
using RestaurantApp.SunumKatmani.ViewModels.Base;
using RestaurantApp.SunumKatmani.ViewModels.KullanıcıViewModels;
using RestaurantApp.SunumKatmani.Views.KullanıcıViews;
using RestaurantApp.VarlikKatmani.Models;
using RestaurantApp.VeritabaniErisimKatmani;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.SunumKatmani.ViewModels.KullaniciViewModels
{
    public class KullanıcıListViewModel : BaseViewModel
    {
        private readonly UnitOfWork unitOfWork;
        private ObservableCollection<KullanıcıViewModel> _kullanıcılar;
        private KullanıcıViewModel _selectedKullanıcı;

        public ObservableCollection<KullanıcıViewModel> Kullanıcılar
        {
            get { return _kullanıcılar; }
            set
            {
                if (_kullanıcılar != value)
                {
                    _kullanıcılar = value;
                    onPropertyChanged();
                }
            }
        }

        public KullanıcıViewModel SelectedKullanıcı
        {
            get { return _selectedKullanıcı; }
            set
            {
                if (_selectedKullanıcı != value)
                {
                    _selectedKullanıcı = value;
                    onPropertyChanged();
                }
            }
        }

        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public KullanıcıListViewModel()
        {
            unitOfWork = new UnitOfWork();
            RefreshCommand = new RelayCommand(o => { OnRefresh(); }, o => { return true; });
            InsertCommand = new RelayCommand(o => { OnInsert(); }, o => { return true; });
            DeleteCommand = new RelayCommand(o => { OnDelete(); }, o => { return SelectedKullanıcı != null; });
            UpdateCommand = new RelayCommand(o => { OnUpdate(); }, o => { return SelectedKullanıcı != null; });

            OnRefresh();
        }

        private void OnRefresh()
        {
            var kullanıcılar = unitOfWork.KullaniciRepo.GetAll();
            Kullanıcılar = new ObservableCollection<KullanıcıViewModel>();
            foreach (var kullanıcı in kullanıcılar)
            {
                Kullanıcılar.Add(new KullanıcıViewModel(kullanıcı));
            }
        }

        private void OnInsert()
        {
            var vm = new KullanıcıViewModel();
            vm.Eklememi = true;
            var view = new KullaniciView
            {
                Title = "Kullanıcı Ekle",
                DataContext = vm
            };

            if (view.ShowDialog() == true)
            {
                var kullanıcı = unitOfWork.KullaniciRepo.Insert(vm.kullanici);
                unitOfWork.Save();
                Kullanıcılar.Add(new KullanıcıViewModel(kullanıcı));
            }
        }

        private void OnDelete()
        {
            if (MessageBox.Show($"{SelectedKullanıcı.kullanici.KullaniciAdi} adlı kullanıcıyı silmek istiyor musunuz?", "Kullanıcıyı Sil?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                unitOfWork.KullaniciRepo.Remove(SelectedKullanıcı.kullanici.KullaniciAdi);
                unitOfWork.Save();
                Kullanıcılar.Remove(SelectedKullanıcı);
            }
        }

        private void OnUpdate()
        {
            SelectedKullanıcı.Eklememi = false;
            var view = new KullaniciView
            {
                Title = "Kullanıcıyı Güncelle",
                DataContext = SelectedKullanıcı
            };

            if (view.ShowDialog() == true)
            {
                var kullanıcı = unitOfWork.KullaniciRepo.Update(SelectedKullanıcı.kullanici);
                unitOfWork.Save();
            }
        }
    }
}