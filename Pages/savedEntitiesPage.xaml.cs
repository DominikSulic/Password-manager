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

        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private string[] listOfEntityNames;
        private string[] listOfEntities;

        public savedEntitiesPage()
        {
            InitializeComponent();

            btnDelete.IsEnabled = false;
            btnAlter.IsEnabled = false;

            dictionary = Entity.readFromFile();
            listOfEntityNames = new string[dictionary.Count];
            listOfEntities = new string[dictionary.Count];
            int i = 0;

            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                listOfEntityNames[i] = kvp.Key;
                listOfEntities[i] = kvp.Value;
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
                string entityData = "";

                string[] returns = new string[listOfEntities.Length];
                int j = 0;
                for(int i = 0; i <= listOfEntities.Length; i++)
                {
                    string[] dataToDisplay = listOfEntities[i].Split(',');
                    if(dataToDisplay[0] == entityName)
                    {
                        for(int k = 0; k < dataToDisplay.Length; k+=3)
                        {
                            entityData += "Username: " + dataToDisplay[k] + "\n";
                            entityData += "E-mail: " + dataToDisplay[k + 1] + "\n";
                            entityData += "Password: " + dataToDisplay[k + 2] + "\n";
                        }
                        returns[j] = entityData;
                        j++;
                    }
                }

                lbPreview.ItemsSource = returns;
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