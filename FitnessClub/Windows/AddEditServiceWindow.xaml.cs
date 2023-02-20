using Microsoft.Win32;
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
using System.IO;

namespace FitnessClub.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditServiceWindow.xaml
    /// </summary>
    public partial class AddEditServiceWindow : Window
    {
        private string pathImage = null;

        public AddEditServiceWindow()
        {
            InitializeComponent();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            // выбор фото 

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddEditService_Click(object sender, RoutedEventArgs e)
        {
            // валидация

            // добавление
            Service service = new Service();
            service.NameService = TbNameService.Text;
            service.PriceService = Convert.ToDecimal(TbPriceService.Text);
            service.TimeService = Convert.ToInt32(TbTimeService.Text);
            service.Description = TbDescription.Text;
            service.Photo = File.ReadAllBytes(pathImage);

            EFClass.context.Service.Add(service);
            EFClass.context.SaveChanges();
            MessageBox.Show("Услуга успешно добавлена");

            this.Close();
        }
    }
}
