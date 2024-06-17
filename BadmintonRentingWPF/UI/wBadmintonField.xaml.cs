using BadmintonRentingBusiness;
using BadmintonRentingData.DTO;
using BadmintonRentingData.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BadmintonRentingWPF.UI
{
    /// <summary>
    /// Interaction logic for wBadmintonField.xaml
    /// </summary>
    public partial class wBadmintonField : Window
    {

        private readonly IBadmintonFieldBusiness badmintonFieldBusiness;
        public wBadmintonField(IBadmintonFieldBusiness badmintonFieldBusiness)
        {
            InitializeComponent();
            this.badmintonFieldBusiness = badmintonFieldBusiness;
            Loaded += Window_Loaded;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.CommandParameter == null)
                {
                    MessageBox.Show("CommandParameter is null");
                    return;
                }

                long badmintonFieldId;
                if (!long.TryParse(btn.CommandParameter.ToString(), out badmintonFieldId))
                {
                    MessageBox.Show("Invalid CommandParameter value");
                    return;
                }

                var result = await badmintonFieldBusiness.DeleteById(badmintonFieldId);
                if (result.Status > 0)
                {
                    MessageBox.Show("Delete successful", "Success");
                }
                else
                {
                    MessageBox.Show($"Delete failed: {result.Message}", "Error");
                }

                await LoadGrdCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void grdCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    if (grdCustomer.SelectedItem is BadmintonField selectedBadmintonField)
                    {
                        txtBadmintonFieldId.Text = selectedBadmintonField.BadmintonFieldId.ToString();
                        txtBadmintonFieldName.Text = selectedBadmintonField.BadmintonFieldName;
                        txtAddress.Text = selectedBadmintonField.Address.ToString();
                        txtDescription.Text = selectedBadmintonField.Description;
                        txtStartTime.Text = selectedBadmintonField.StartTime.ToString();
                        txtEndTime.Text = selectedBadmintonField.EndTime.ToString();
                        txtIsActive.Text = selectedBadmintonField.IsActive.ToString();
                    }
                }
            }
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long badmintonFieldId = long.Parse(txtBadmintonFieldId.Text);

                var existbadmintonfield = await badmintonFieldBusiness.GetById(badmintonFieldId);
                var newBadmintonField = existbadmintonfield.Data as BadmintonField; //Doi tu kieu BusinessResult thanh Customer
                if (newBadmintonField == null)
                {
                    var badmintonFieldDTO = new BadmintonFieldRequestDTO
                    {
                        BadmintonFieldName = txtBadmintonFieldName.Text,
                        Address = txtAddress.Text,
                        Description = txtDescription.Text,
                        StartTime = TimeSpan.Parse(txtStartTime.Text),
                        EndTime = TimeSpan.Parse(txtEndTime.Text),
                        IsActive = bool.Parse(txtIsActive.Text),
                    };

                    var result = await badmintonFieldBusiness.Create(badmintonFieldDTO);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var badmintonFieldDTO = new BadmintonFieldRequestDTO
                    {
                        BadmintonFieldName = txtBadmintonFieldName.Text,
                        Address = txtAddress.Text,
                        Description = txtDescription.Text,
                        StartTime = TimeSpan.Parse(txtStartTime.Text),
                        EndTime = TimeSpan.Parse(txtEndTime.Text),
                        IsActive = bool.Parse(txtIsActive.Text),
                    };

                    var result = await badmintonFieldBusiness.Update(badmintonFieldId, badmintonFieldDTO);
                    MessageBox.Show(result.Message, "Update");
                }

                txtBadmintonFieldName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtStartTime.Text = string.Empty;
                txtEndTime.Text = string.Empty;
                txtIsActive.Text = string.Empty;
                await this.LoadGrdCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            txtBadmintonFieldId.Text = string.Empty;
            txtBadmintonFieldName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;
            txtIsActive.Text = string.Empty;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGrdCustomer();
        }
        private async Task LoadGrdCustomer()
        {
            var result = await badmintonFieldBusiness.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdCustomer.ItemsSource = result.Data as List<BadmintonField>;
            }
            else
            {
                grdCustomer.ItemsSource = new List<BadmintonField>();
            }
        }
    }
}
