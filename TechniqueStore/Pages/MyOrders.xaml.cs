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
using TechniqueStore.Model;
using TechniqueStore.Service;

namespace TechniqueStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyOrders.xaml
    /// </summary>
    public partial class MyOrders : Page
    {
        public MyOrders()
        {
            InitializeComponent();
            LvItemsOrders.ItemsSource = OrderService.GetOrderCol();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavFrame.FrameOBJ.Navigate(new HomePage());
        }
    }
}
