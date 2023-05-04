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
    /// Логика взаимодействия для ManufacturerList.xaml
    /// </summary>
    public partial class ManufacturerList : Page
    {
        public ManufacturerList()
        {
            InitializeComponent();
            LVManufacterer.ItemsSource = App.db.Manufacterer.Where(x => x.isDelete != true).ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var manuf = (sender as Button).DataContext as Manufacterer;
            NavigationService.Navigate(new ManufacturerEditPage(manuf));
        }
         
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();

        }
        public void Refresh()
        {
            IEnumerable<Manufacterer> filterManuf = App.db.Manufacterer;
            if (SortCb.SelectedIndex > 0)
            {
                if (SortCb.SelectedIndex == 1)
                    filterManuf = filterManuf.OrderBy(x => x.PhoneNumber);
                else if (SortCb.SelectedIndex == 2)
                    filterManuf = filterManuf.OrderByDescending(x => x.PhoneNumber);
            }
            // Сортировка
            // ЕСли CB в положении 0 (по умолчанию нисего не происходит)
            //// ЕСли CB в положении 1 (по умолчанию нисего не происходит)
            //



        }

        private void LVPreparation_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void DataGridBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PreparationListPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selmanuf = (sender as Button).DataContext as Manufacterer;
            if (MessageBox.Show("Delete?", "WARNING",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                selmanuf.isDelete = true;
                App.db.SaveChanges();
            }
        }
    }
}
