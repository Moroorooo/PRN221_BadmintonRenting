using BadmintonRentingBusiness;
using BadmintonRentingData.DTO;
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

namespace BadmintonRentingWPF.UI
{
    /// <summary>
    /// Interaction logic for wCustomer.xaml
    /// </summary>
    public partial class wCustomer : Window
    {
        private readonly ICustomerBusiness customerBusiness;
        public wCustomer(ICustomerBusiness customerBusiness)
        {
            InitializeComponent();
            this.customerBusiness = customerBusiness;
            Loaded += Window_Loaded;
        }

        private async void grdCustomer_ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            //chuyen doi sender thanh button, cho phep truy cap vao cac thuoc tinh và phuong thuc cua button khi click
            Button btn =(Button)sender;
            //get id have been save in CommandParameter
            long customerId = long.Parse(btn.CommandParameter.ToString());
            await customerBusiness.DeleteById(customerId);
            await LoadGrdCustomer();
        }

        private void grdCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //chuyen doi sender thanh DataGrid, cho phep truy cap vao cac thuoc tinh và phuong thuc cua DataGrid khi click
            DataGrid grd = sender as DataGrid;
            if (grd != null && grd.SelectedItems != null && grd.SelectedItems.Count == 1)
            {
                //get data from data grid view
                var row = grd.ItemContainerGenerator.ContainerFromItem(grd.SelectedItem) as DataGridRow;
                if (row != null)
                {
                    if (grdCustomer.SelectedItem is Customer selectedCustomer)
                    {
                        txtCustomerId.Text = selectedCustomer.CustomerId.ToString();
                        txtCustomerName.Text = selectedCustomer.CustomerName;
                        txtPhone.Text = selectedCustomer.Phone.ToString();
                        txtEmail.Text = selectedCustomer.Email;
                        txtIsStatus.Text = selectedCustomer.IsStatus;
                    }
                }
            }
        }
        
        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long customerId = long.Parse(txtCustomerId.Text);

                var existcustomer = await customerBusiness.GetById(customerId);
                var newCustomer = existcustomer.Data as Customer; //Doi tu kieu BusinessResult thanh Customer
                if (newCustomer == null)                  
                {                   
                    var customerDTO = new CustomerRequestDTO
                    {
                        CustomerName = txtCustomerName.Text,
                        Phone = int.Parse(txtPhone.Text),
                        Email = txtEmail.Text,
                        IsStatus = txtIsStatus.Text
                    };

                    var result = await customerBusiness.Create(customerDTO);
                    MessageBox.Show(result.Message, "Save");
                }
                else
                {
                    var customerDTO = new CustomerRequestDTO
                    {
                        CustomerName = txtCustomerName.Text,
                        Phone = int.Parse(txtPhone.Text),
                        Email = txtEmail.Text,
                        IsStatus = txtIsStatus.Text
                    };
                    
                    var result = await customerBusiness.Update(customerId, customerDTO);
                    MessageBox.Show(result.Message, "Update");
                }

                txtCustomerName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtIsStatus.Text = string.Empty;
                await this.LoadGrdCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIsStatus.Text = string.Empty;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGrdCustomer();
        }
        private async Task LoadGrdCustomer()
        {
            var result = await customerBusiness.GetAll();

            if (result.Status > 0 && result.Data != null)
            {
                grdCustomer.ItemsSource = result.Data as List<Customer>;
            }
            else
            {
                grdCustomer.ItemsSource = new List<Customer>();
            }
        }
    }
}
