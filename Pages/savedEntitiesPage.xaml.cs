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

        public List<Entity> list = new List<Entity>();

        public savedEntitiesPage()
        {
            InitializeComponent();

            btnDelete.IsEnabled = false;
            btnAlter.IsEnabled = false;
            list = Entity.readFromFile();

            List<string> proizvoljnoIme = new List<string>();
            foreach(Entity item in list)
            {
                if(!proizvoljnoIme.Contains(item.entityName))
                {
                    proizvoljnoIme.Add(item.entityName);
                }
            }

            lbEntities.ItemsSource = proizvoljnoIme;
        }

        private void LbEntities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
            btnAlter.IsEnabled = true;
            string entityName = lbEntities.SelectedItem.ToString();
            string[] result = new string[list.Count];
            string temp = "";
            int i = 0;

            foreach(var item in list)
            {
                if(item.entityName == entityName)
                {
                    temp = "Username: " + item.userName + "\n" + "E-mail: " + item.email + "\n" + "Password: " + item.password + "\n";
                    result[i] = temp;
                    i++;
                }
            }
            lbPreview.ItemsSource = result;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete the selected entities?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int i = 0;

                foreach (var selectedItem in lbEntities.SelectedItems)
                {
                    i++;
                }

                int[] indexesForDeletion = new int[i];
                i = 0;

                foreach (var selectedItem in lbEntities.SelectedItems)
                {
                    indexesForDeletion[i] = lbEntities.Items.IndexOf(selectedItem);
                    i++; 
                }


                Entity.deleteEntitiesFromFile(indexesForDeletion);
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //return
            }
        }

        private void BtnAlter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}