using BadmintonRentingData.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
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

namespace WPFJson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Customer> _customers;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                //lay duong dan cua file can doc
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                if (filePath.EndsWith(".json"))
                {
                    //chuyen doi fileContent thanh Customer
                    _customers = JsonConvert.DeserializeObject<List<Customer>>(fileContent);
                }
                else if (filePath.EndsWith(".xml"))
                {
                    //phan tich noi dung thanh mot xDocument, xDocument dai dien cho file xml
                    var xDocument = System.Xml.Linq.XDocument.Parse(fileContent);
                    //chuyen doi xDocument thanh new Customer va dua vao list
                    _customers = xDocument.Descendants("Customer")
                        .Select(c => new Customer
                        {
                            CustomerId = (long)c.Element("CustomerId"),
                            CustomerName = (string)c.Element("CustomerName"),
                            Phone = (int)c.Element("Phone"),
                            Email = (string)c.Element("Email"),
                            IsStatus = (string)c.Element("IsStatus")
                        })
                        .ToList();
                }

                CustomerDataGrid.ItemsSource = _customers;
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|XML files (*.xml)|*.xml"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                //chon noi muon luu
                string filePath = saveFileDialog.FileName;

                if (filePath.EndsWith(".json"))
                {
                    string jsonContent = JsonConvert.SerializeObject(_customers, Formatting.Indented);
                    File.WriteAllText(filePath, jsonContent);
                }
                else if (filePath.EndsWith(".xml"))
                {
                    //tao 1 xDocument tu danh sach customer bang linq
                    var xDocument = new System.Xml.Linq.XDocument(
                        new System.Xml.Linq.XElement("Customers",
                            _customers.Select(c => new System.Xml.Linq.XElement("Customer",
                                new System.Xml.Linq.XElement("CustomerId", c.CustomerId),
                                new System.Xml.Linq.XElement("CustomerName", c.CustomerName),
                                new System.Xml.Linq.XElement("Phone", c.Phone),
                                new System.Xml.Linq.XElement("Email", c.Email),
                                new System.Xml.Linq.XElement("IsStatus", c.IsStatus)
                            ))
                        )
                    );
                    xDocument.Save(filePath);
                }
            }
        }
    }
}