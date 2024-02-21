using ShopDb;
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

namespace shopWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopDbContex context;
        public MainWindow()
        {
            InitializeComponent();
            context = new ShopDbContex();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Shops.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Workers.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Products.ToList();
        }
    }
}
