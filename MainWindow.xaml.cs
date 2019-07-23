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

namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void BtnNewEntity_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridNewEntity.Visibility = Visibility.Visible;
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridHistory.Visibility = Visibility.Visible;
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridOptions.Visibility = Visibility.Visible;
        }


        private void BtnSavedEntities_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridSavedEntities.Visibility = Visibility.Visible;
        }

        private void BtnReturnHomeNE_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Visible;
            gridNewEntity.Visibility = Visibility.Collapsed;
        }
        private void BtnReturnHomeHIST_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Visible;
            gridHistory.Visibility = Visibility.Collapsed;
        }

        private void BtnReturnHomeOPT_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Visible;
            gridOptions.Visibility = Visibility.Collapsed;
        }
        private void BtnReturnHomeSE_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Visible;
            gridSavedEntities.Visibility = Visibility.Collapsed;
        }

    }
    
}
