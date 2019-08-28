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

                lbPreview.ItemsSource = shortenTheArray(entityForDisplay);
            }
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected entities?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int numberOfSelectedInstances = 0;

                string temp = "";
                string eMail = "";

                foreach(object selectedInstance in lbPreview.SelectedItems)
                {
                    numberOfSelectedInstances++;
                }

                string[] tempArray = new string[3];

                if(numberOfSelectedInstances == 0)
                {
                    foreach (object selectedItem in lbEntities.SelectedItems)
                    {
                        dictionary.Remove(selectedItem.ToString());
                    }
                    Entity.deleteEntities(dictionary);
                }
                else
                {
                    foreach (object selectedInstance in lbPreview.SelectedItems)
                    {
                        temp = selectedInstance.ToString();
                        tempArray = temp.Split('\n');
                        eMail = tempArray[1];
                        eMail = eMail.Substring(10, eMail.Length - 10);

                        dictionary.TryGetValue(lbEntities.SelectedItem.ToString(), out string dictionaryValueOnKey);
                        string[] temp2 = dictionaryValueOnKey.Split(';');
                        string[] temp3 = new string[temp2.Length];
                        int j = 0;
                        string result = "";

                        for(int i = 0; i < temp2.Length-1; i++)
                        {
                            if (!temp2[i].Contains(eMail))
                            {
                                temp3[j] = temp2[i] + ";";
                                j++;
                            }
                        }

                        for(int i = 0; i < temp3.Length - 1; i++)
                        {
                            result += temp3[i];
                        }

                        dictionary[lbEntities.SelectedItem.ToString()] = result;
                        Entity.deleteEntities(dictionary);
                        this.NavigationService.Navigate(new savedEntitiesPage());
                    }
                }
            }
        }


        private void BtnAlter_Click(object sender, RoutedEventArgs e)
        {
            string[] tempArray = new string[3];
            string entityToAlter = lbPreview.SelectedItem.ToString();
            tempArray = entityToAlter.Split('\n');

            string username = tempArray[0];
            string eMail = tempArray[1];
            string password = tempArray[2];
            string entityName = lbEntities.SelectedItem.ToString();

            username = username.Substring(12, username.Length - 12);
            eMail = eMail.Substring(10, eMail.Length - 10);
            password = password.Substring(12, password.Length - 12);
            

            NavigationService.Navigate(new editEntityPage(entityName, username, eMail, password, dictionary));
        }


        private static string[] shortenTheArray(string[] arrayToBeShortened)
        {
            string[] shortenedArray;
            int j = 0;
    
            for(int i = 0; i < arrayToBeShortened.Length - 1; i++)
            {
                if(arrayToBeShortened[i] != null)
                {
                    j++;
                }
            }

            shortenedArray = new string[j];
            j = 0;

            for (int i = 0; i < arrayToBeShortened.Length - 1; i++)
            {
                if (arrayToBeShortened[i] != null)
                {
                    shortenedArray[j] = arrayToBeShortened[i];
                    j++;
                }
            }

            return shortenedArray;
        }


    }
}