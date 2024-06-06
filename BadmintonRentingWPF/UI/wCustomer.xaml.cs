//using BadmintonRentingBusiness;
//using BadmintonRentingData.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace BadmintonRentingWPF.UI
//{
//    /// <summary>
//    /// Interaction logic for wCustomer.xaml
//    /// </summary>
//    public partial class wCustomer : Window
//    {
//        private readonly ICustomerBusiness customerBusiness;
//        public wCustomer()
//        {
//            InitializeComponent();
//        }

//        private void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
//        {

//        }

//        private void grdCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
//        {

//        }
//        private void grdCustomer_SelectionChanged(object sender, MouseButtonEventArgs e)
//        {

//        }
//        private void ButtonSave_Click(object sender, RoutedEventArgs e)
//        {

//        }

//        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
//        {

//        }

//        private async void LoadGrdCustomer()
//        {
//            var result = await customerBusiness.GetAll();

//            if (result.Status > 0 && result.Data != null)
//            {
//                grdCustomer.ItemsSource = result.Data as List<Customer>;
//            }
//            else
//            {
//                grdCustomer.ItemsSource = new List<Customer>();
//            }
//        }
//    }
//}
