﻿using System;
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

namespace RestaurantApp.SunumKatmani.Views.KategoriViews
{
    /// <summary>
    /// Interaction logic for KategoriView.xaml
    /// </summary>
    public partial class KategoriView : Window
    {
        public KategoriView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtAd.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            this.DialogResult = true;
        }
    }
}