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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public static bool isAutorized = false;
        public HomePage()
        {
            InitializeComponent();
            LvHomePageCategory.ItemsSource = CategoryService.GetСategoryCol();
            LvHomePageCategory.SelectedIndex = 0;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void LvHomePageCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LvHomePageCategory.SelectedItem != null)
            {
                var selectcateg = LvHomePageCategory.SelectedItem as CategoryTech;
                LvItemsCategory.ItemsSource = null;
                LvItemsCategory.ItemsSource = ItemCategoryService.GetItemsCategoryCol(LvHomePageCategory.SelectedItem as CategoryTech);
            }
         
        }
        public static ItemCategory ItemCategorystatic { get; set; }
        private  void AddToBasket_Click(object sender, RoutedEventArgs e)
        {
            if(isAutorized == false)
            {
                MessageBox.Show("Авторизуйся!");
            }
            else
            {
                string result = BasketService.AddBasketItem(LvItemsCategory.SelectedItem as ItemCategory);
                MessageBox.Show(result);
            }
          
            
        }

     
       
      
        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            NavFrame.FrameOBJ.Navigate(new LoginPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(isAutorized == true)
            {
                LoginUs.Text = Base.LoginUser;
                btnOrders.Visibility = Visibility.Visible;
                VoitiButton.Visibility = Visibility.Collapsed;
                RegButton.Visibility = Visibility.Collapsed;
                bntOut.Visibility = Visibility.Visible;
            }
          
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if(isAutorized == true)
            {
                NavFrame.FrameOBJ.Navigate(new Profile());

            }
            else
            {
                MessageBox.Show("Авторизуйся!");

            }
        }

        private void Basket_Click_1(object sender, RoutedEventArgs e)
        {
            if(isAutorized == true)
            {
                NavFrame.FrameOBJ.Navigate(new BasketPage());
            }
            else
            {
                MessageBox.Show("Авторизуйся!");

            }
        }

        private void bntOut_Click(object sender, RoutedEventArgs e)
        {
            Base.LoginUser = null;
                LoginUs.Text = null;
            isAutorized = false;
                btnOrders.Visibility = Visibility.Collapsed;
                VoitiButton.Visibility = Visibility.Visible;
                RegButton.Visibility = Visibility.Visible;
                bntOut.Visibility = Visibility.Collapsed;
            
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            if (isAutorized == true)
            {
                NavFrame.FrameOBJ.Navigate(new MyOrders());

            }
           
        }
    }
}
