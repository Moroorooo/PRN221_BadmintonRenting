﻿using BadmintonRentingBusiness;
using BadmintonRentingData;
using BadmintonRentingWPF.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadmintonRentingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Open_wCustomer_Click(object sender, RoutedEventArgs e)
        {
            var unitOfWork = new UnitOfWork();
            ICustomerBusiness customerBusiness = new CustomerBusiness(unitOfWork);
            var p = new wCustomer(customerBusiness);
            p.Owner = this;
            p.Show();
        }

    }
}