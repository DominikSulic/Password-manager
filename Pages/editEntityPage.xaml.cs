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
    /// Interaction logic for editEntityPage.xaml
    /// </summary>
    public partial class editEntityPage : Page
    {
        private string entityName;
        private string username;
        private string eMail;
        private string password;
        private Dictionary<string, string> dictionary;

        public editEntityPage()
        {
            InitializeComponent();
        }

        public editEntityPage(string entityName, string username, string eMail, string password, Dictionary<string, string> dictionary)
        {
            InitializeComponent();
            this.entityName = entityName;
            this.username = username;
            this.eMail = eMail;
            this.password = password;
            this.dictionary = dictionary;

            txtNewUserName.Text = username;
            txtNewEmail.Text = eMail;
            txtNewPassword.Text = password;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUserName.Text;
            string eMail = txtNewEmail.Text;
            string password = txtNewPassword.Text;
            string dictionaryValueOnKey = "";

            dictionary.TryGetValue(entityName, out dictionaryValueOnKey);

            string[] temp2 = dictionaryValueOnKey.Split(';');
            string saveToDictionary = "";

            for (int i = 0; i < temp2.Length - 1; i++)
            {
                if (temp2[i].Contains(this.eMail))
                {
                    temp2[i] = this.entityName + ", " + username + ", " + eMail + ", " + password;
                }
                saveToDictionary += temp2[i] + ";";
            }

            dictionary[this.entityName] = saveToDictionary;

            Entity.updateEntityInFile(dictionary);

            this.NavigationService.Navigate(new savedEntitiesPage());
        }
    }
}
