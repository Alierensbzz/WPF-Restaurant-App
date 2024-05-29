using RestaurantApp.SunumKatmani.Views.KullanıcıViews;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantApp.SunumKatmani
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            LoginPage loginVM = new LoginPage();
            if (loginVM.ShowDialog() == true)
            {
                main.Show();
            }
            else
            {
                main.Close();
            }
        }
    }
}
