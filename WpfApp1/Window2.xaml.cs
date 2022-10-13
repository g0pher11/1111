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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            listView.ItemsSource = Instances.db.products_users_table
            .OrderBy(q => q.pk_product_with_user_id)
            .Skip(0)
            .Take(50)
            .ToList();
            comb1.ItemsSource = Instances.db.categories.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (comb1.SelectedItem == null)
                return;
            var selectedCategory = (categories)comb1.SelectedItem;

            var data = Instances.db.products_users_table
                .Where(q => q.products.categories.pk_category_id == selectedCategory.pk_category_id)
                .OrderBy(w => w.pk_product_with_user_id)
                .Skip(0)
                .Take(50)
                .ToList();

            listView.ItemsSource = data;


        }
    }
}
