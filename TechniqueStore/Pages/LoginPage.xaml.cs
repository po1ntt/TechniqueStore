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
using TechniqueStore.Service;

namespace TechniqueStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = UserService.LoginUser(txbLogin.Text, txbPassword.Text);
            if (result == true)
            {
                Base.LoginUser = txbLogin.Text;
                HomePage.isAutorized = true;
                NavFrame.FrameOBJ.Navigate(new HomePage());

            }
            else
            {
                MessageBox.Show("Неправильно введенные данные");
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavFrame.FrameOBJ.Navigate(new HomePage());
        }
    }
}
