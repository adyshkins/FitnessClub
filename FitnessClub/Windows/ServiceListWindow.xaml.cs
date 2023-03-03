﻿using System;
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

            // фильтрация, поиск и сортировку


            //поиск
            serviceList = serviceList.Where(i => i.NameService.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            lvService.ItemsSource = serviceList;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;


            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetServiceList();
        }
    }
}
