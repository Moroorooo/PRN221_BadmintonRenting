using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using BadmintonRentingData.Model;
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

namespace BadmintonRentingWPFApp.UI
{
    /// <summary>
    /// Interaction logic for FieldScheduleWindow.xaml
    /// </summary>
    public partial class FieldScheduleWindow : Window
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;
        public FieldScheduleWindow(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }
        public FieldScheduleWindow()
        {

            InitializeComponent();
            LoadGrid();
        }

        private async void LoadGrid()
        {
            var list = new List<BookingBadmintonFieldSchedule>();
            var result = await _business.GetAll();
            if (result.Message != Const.FAIL_READ_MSG)
            {
                list = (List<BookingBadmintonFieldSchedule>)result.Data;
            }
            grdFieldSchedule.ItemsSource = list;
        }

        private async void grdFieldSchedule_Mouse_DoubleClick(object sender, RoutedEventArgs e)
        {
            var row = grdFieldSchedule.SelectedItem;
            var fieldSchedule = row as BookingBadmintonFieldSchedule;
            txtFieldScheduleID.Text = fieldSchedule.OrderBadmintonFieldScheduleId.ToString();
            txtBadmintonField.Text = fieldSchedule.BadmintonField.ToString();
            txtSchedule.Text = fieldSchedule.ScheduleId.ToString();
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = await _business.GetById(txtFieldScheduleID.Text);
                if (item.Message != Const.FAIL_READ_MSG)
                {
                    var fieldSchedule = new BookingBadmintonFieldSchedule()
                    {

                    };

                    await _business.Update(fieldSchedule);               
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        private async void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void grdFieldSchedule_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
