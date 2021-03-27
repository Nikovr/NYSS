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

namespace Caesar_Cipher
{
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Interface());
        }
    }
}
