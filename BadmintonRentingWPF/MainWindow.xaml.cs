using BadmintonRentingBusiness;
using BadmintonRentingData.Model;
using BadmintonRentingData;
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
using BadmintonRentingWPF.UI;

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
        private async void Open_wSchedule_Click(object sender, RoutedEventArgs e)
        {
            var unitOfWork = new UnitOfWork();
            IScheduleBusiness scheduleBusiness = new ScheduleBusiness(unitOfWork);
            var p = new wSchedule(scheduleBusiness);
            p.Owner = this;
            p.Show();
        }
    }
}