using CheckWork.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckWork.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerEditPage.xaml
    /// </summary>
    public partial class ManufacturerEditPage : Page
    {
        private Manufacterer _manufacterer;
        public ManufacturerEditPage(Manufacterer manufacterer)
        {
            InitializeComponent();
            this.DataContext = this;
            _manufacterer = manufacterer;


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Manufacterer.Add(_manufacterer);
            App.db.SaveChanges();
            MessageBox.Show("Успешно изменено!");
            NavigationService.Navigate(new ManufacturerList());
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTB.Clear();
            AddressTb.Clear();
            PhoneTb.Clear();
            EmailTb.Clear();
        }
    }
}
