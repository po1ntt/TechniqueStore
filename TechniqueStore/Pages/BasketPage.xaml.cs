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
using TechniqueStore.Pages.Windows;
using TechniqueStore.Service;

namespace TechniqueStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
            LvBasket.ItemsSource = BasketService.GetBasketCol();
        }

        private void PlusClick(object sender, MouseButtonEventArgs e)
        {
            BasketService.EditBasket(LvBasket.SelectedItem as BasketUser, "plus");
            LvBasket.ItemsSource = null;
            LvBasket.ItemsSource = BasketService.GetBasketCol();


        }
        private void MinusClick(object sender, MouseButtonEventArgs e)
        {

            BasketService.EditBasket(LvBasket.SelectedItem as BasketUser, "minus");
            LvBasket.ItemsSource = null;
            LvBasket.ItemsSource = BasketService.GetBasketCol();


        }
        private void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            BasketService.DeleteBasket(LvBasket.SelectedItem as BasketUser);
            LvBasket.ItemsSource = null;
            LvBasket.ItemsSource = BasketService.GetBasketCol();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavFrame.FrameOBJ.Navigate(new HomePage());
        }

        private void Ordering_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new OrderWindow());
        }
    }
}
