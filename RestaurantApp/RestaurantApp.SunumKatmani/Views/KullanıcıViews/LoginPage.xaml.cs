using RestaurantApp.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestaurantApp.SunumKatmani.Views.KullanıcıViews
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VeritabaniErisimKatmani.UnitOfWork uow = new VeritabaniErisimKatmani.UnitOfWork();
            Kullanici kullanıcı = uow.KullaniciRepo.Login(txtKullanıcıAdı.Text, txtParola.Password);

            if (kullanıcı != null)
            {
                lblError.Text = "";
                this.DialogResult = true;
            }
            else
            {
                lblError.Text = "Kullanıcı Adı ya da parola hatalı!!!";
            }
        }
    }
}
