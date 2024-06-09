using BadmintonRentingBusiness;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BadmintonRentingWPF.UI
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wSchedule : Window
    {
        private readonly IScheduleBusiness scheduleBusiness;
        public wSchedule(IScheduleBusiness scheduleBusiness)
        {
            InitializeComponent();
            this.scheduleBusiness = scheduleBusiness;
            Loaded += Window_Loaded;
        }

        private async void grdSchedule_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            long scheduleId = long.Parse(btn.CommandParameter.ToString());
            await scheduleBusiness.DeleteById(scheduleId);
            await LoadGrdSchedule();
        }

        private void grdSchedule_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    if (grd.SelectedItem is Schedule selectedSchedule)
                    {
                        txtScheduleId.Text = selectedSchedule.ScheduleId.ToString();
                        txtScheduleName.Text = selectedSchedule.ScheduleName;
                        txtStartTimeFrame.Text = selectedSchedule.StartTimeFrame.ToString();
                        txtEndTimeFrame.Text = selectedSchedule.EndTimeFrame.ToString();
                        txtPrice.Text = selectedSchedule.Price.ToString();
                        txtTotalHours.Text = selectedSchedule.TotalHours.ToString();
                    }
                }
            }
        }


        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse scheduleId from txtScheduleId.Text
                if (long.TryParse(txtScheduleId.Text, out long scheduleId))
                {
                    // Calculate total hours from start and end time frames
                    DateTime startTimeFrame = DateTime.Parse(txtStartTimeFrame.Text);
                    DateTime endTimeFrame = DateTime.Parse(txtEndTimeFrame.Text);
                    double totalHours = (endTimeFrame - startTimeFrame).TotalHours;

                    ScheduleDTO scheduleDTO = new ScheduleDTO
                    {
                        ScheduleName = txtScheduleName.Text,
                        StartTimeFrame = startTimeFrame,
                        EndTimeFrame = endTimeFrame,
                        Price = double.Parse(txtPrice.Text),
                        TotalHours = totalHours,
                    };

                    // Check if the schedule already exists
                    var existSchedule = await scheduleBusiness.GetById(scheduleId);
                    var newSchedule = existSchedule.Data as Schedule;
                    if (newSchedule == null)
                    {
                        var result = await scheduleBusiness.Create(scheduleDTO);
                        MessageBox.Show(result.Message, "Save");
                    }
                    else
                    {
                        var result = await scheduleBusiness.Update(scheduleId, scheduleDTO);
                        MessageBox.Show(result.Message, "Update");
                    }

                    // Clear text boxes and reload grid
                    txtScheduleName.Clear();
                    txtStartTimeFrame.Clear();
                    txtEndTimeFrame.Clear();
                    txtPrice.Clear();
                    txtTotalHours.Clear();
                    await LoadGrdSchedule();
                }
                else
                {
                    MessageBox.Show("Invalid schedule ID.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            txtScheduleName.Clear();
            txtStartTimeFrame.Clear();
            txtEndTimeFrame.Clear();
            txtPrice.Clear();
            txtTotalHours.Clear();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGrdSchedule();
        }
        private async Task LoadGrdSchedule()
        {
            var result = await scheduleBusiness.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdSchedule.ItemsSource = result.Data as List<Schedule>;
            }
            else
            {
                grdSchedule.ItemsSource = new List<Schedule>();
            }
        }
    }
}
