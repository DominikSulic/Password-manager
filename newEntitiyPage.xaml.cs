using Newtonsoft.Json;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for newEntitiyPage.xaml
    /// </summary>
    public partial class newEntitiyPage : Page
    {
        public newEntitiyPage()
        {
            InitializeComponent();

        }

        private void btnGeneratePassword_Click(object sender, RoutedEventArgs e)
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+=-_$%&#!?*/@";
            var randomlyGeneratedPassword = new char[16];
            var random = new Random();

            for (int i = 0; i < randomlyGeneratedPassword.Length; i++)
            {
                randomlyGeneratedPassword[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(randomlyGeneratedPassword);

            txtPasswordBox.Text = finalString;
        }


        private void btnSaveEntity_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\entities.txt";

            Entity entity = new Entity

            {
                userName = txtUserName.Text,
                siteName = txtSiteName.Text,
                password = txtPasswordBox.Text,
                email = txtEmail.Text
            };

            string json = JsonConvert.SerializeObject(entity, Formatting.Indented);



            if (File.Exists(path))
            {
                File.AppendAllText(path, json);
            }
            else
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    file.WriteLine(json);
                    file.Close();
                }
            }

            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);





        }
    }
}


