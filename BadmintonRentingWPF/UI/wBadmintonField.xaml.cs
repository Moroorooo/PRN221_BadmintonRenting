using System.Windows;

namespace BadmintonRentingWPF.UI
{
    /// <summary>
    /// Interaction logic for wBadmintonField.xaml
    /// </summary>
    public partial class wBadmintonField : Window
    {
        public wBadmintonField()
        {
            InitializeComponent();
            this.customerBusiness = customerBusiness;
            Loaded += Window_Loaded;
        }
    }
}
