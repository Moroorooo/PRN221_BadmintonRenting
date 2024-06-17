using BadmintonRentingBusiness;
using BadmintonRentingData;
using BadmintonRentingWPF.UI;
using System.Windows;

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

        private async void Open_wBadmintonField_Click(object sender, RoutedEventArgs e)
        {
            var unitOfWork = new UnitOfWork();
            IBadmintonFieldBusiness badmintonFieldBusiness = new BadmintonFieldBusiness(unitOfWork);
            var p = new wBadmintonField(badmintonFieldBusiness);
            p.Owner = this;
            p.Show();
        }
    }
}