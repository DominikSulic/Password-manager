using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for savedEntitiesPage.xaml
    /// </summary>
    public partial class savedEntitiesPage : Page
    {

        private Dictionary<string, List<Entity>> dictionary = new Dictionary<string, List<Entity>>();
        private string[] listOfEntityNames;

        public savedEntitiesPage()
        {
            InitializeComponent();

            btnDelete.IsEnabled = false;
            btnAlter.IsEnabled = false;

            dictionary = Entity.readFromFile();
            listOfEntityNames = new string[dictionary.Count];
            int i = 0;

            foreach(KeyValuePair<string, List<Entity>> kvp in dictionary)
            {
                listOfEntityNames[i] = kvp.Key;
                i++;
            }

            lbEntities.ItemsSource = listOfEntityNames;
        }

        private void LbEntities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbEntities.SelectedIndex != -1)
            {
                btnDelete.IsEnabled = true;
                btnAlter.IsEnabled = true;

                string entityName = lbEntities.SelectedItem.ToString();
                List<Entity> list = new List<Entity>();

                foreach (KeyValuePair<string, List<Entity>> item in dictionary)
                {
                    if (item.Key == entityName)
                    {
                        list = item.Value;
                    }
                }
                lbPreview.ItemsSource = list;
            }           
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected entities?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int i = 0;

                foreach (object selectedItem in lbEntities.SelectedItems)
                {
                    i++;
                }

                int[] indexesForDeletion = new int[i];
                i = 0;

                foreach (object selectedItem in lbEntities.SelectedItems)
                {
                    indexesForDeletion[i] = lbEntities.Items.IndexOf(selectedItem);
                    i++; 
                }

                Entity.deleteEntitiesFromFile(indexesForDeletion);  
            }

        }

        private void BtnAlter_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new editEntityPage());


        }
    }
}