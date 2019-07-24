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
    /// Interaction logic for mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {

        newEntitiyPage newEntity = new newEntitiyPage();
        optionsPage options = new optionsPage();
        historyPage history = new historyPage();
        savedEntitiesPage savedEntities = new savedEntitiesPage();

        public mainPage()
        {
            InitializeComponent();

        }


        private void BtnNewEntity_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(newEntity);
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(history);
        }

        private void BtnSavedEntities_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(savedEntities);
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(options);
        }
    }
}
