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
using TechniqueStore.Model;
using TechniqueStore.Service;

namespace TechniqueStore.Pages.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public static int Summa;
        public OrderWindow()
        {
            InitializeComponent();
            var basket = BasketService.GetBasketCol();
            lvOrder.ItemsSource = BasketService.GetBasketCol();
            ComboAdress.ItemsSource = AdresService.GetAdresCol();
            ComboCard.ItemsSource = CardsService.GetCardCol();
            Summa = 0;
            foreach(var item in basket)
            {
                Summa = (int)(Summa + (item.count * item.ItemCategory.price));
            }
            txbSumma.Text = $"Общая сумма: {Summa}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var basket = BasketService.GetBasketCol();
            if(ComboAdress.SelectedItem == null && ComboCard == null)
            {
                MessageBox.Show("Выберите адрес и карту");
            }
            else
            {
                string result = OrderService.AddOrder(Summa, ComboAdress.SelectedItem as Adress, ComboCard.SelectedItem as Cards);
                MessageBox.Show(result);
                BasketService.DeleteBasketAll();

                NavFrame.FrameOBJ.Navigate(new HomePage());
                Close();
            }
           
        }
    }
}
