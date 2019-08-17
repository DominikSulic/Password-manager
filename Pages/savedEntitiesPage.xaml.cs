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
                string[] tempArray = { };
                List<string> separatedBySemicolon = new List<string>();

                for (int i = 0; i < listOfEntities.Length; i++)
                {
                    tempArray = listOfEntities[i].Split(';');
                    foreach (string entity in tempArray)
                    {
                        separatedBySemicolon.Add(entity);
                    }
                }

                string[] separatedByComma = new string[separatedBySemicolon.Count() * 4];
                string[] entityForDisplay = new string[separatedByComma.Length];

                for (int i = 0; i < separatedBySemicolon.Count(); i++)
                {
                    tempArray = separatedBySemicolon[i].Split(',');
                    if (tempArray[0] == entityName)
                    {
                        entityForDisplay[i] = "Username: " + tempArray[1] + "\n" + "E-mail: " + tempArray[2] +
                            "\n" + "Password: " + tempArray[3] + "\n";
                    }

                }
                lbPreview.ItemsSource = entityForDisplay;
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