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

using FitnessClub.DB;
using FitnessClub.Windows;
using FitnessClub.ClassHelper;

namespace FitnessClub.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    public partial class ServiceListWindow : Window
    {
        public ServiceListWindow()
        {
            InitializeComponent();
            GetServiceList();

        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = EFClass.context.Service.ToList();

            lvService.ItemsSource = serviceList;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }
    }
}
