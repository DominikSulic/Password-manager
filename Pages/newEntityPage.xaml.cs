using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for NewEntityPage.xaml
    /// </summary>
    public partial class NewEntityPage : Page
    {
        private Entity entity = new Entity();

        private static readonly string path = Directory.GetCurrentDirectory() + "/options.txt";

        public NewEntityPage()
        {
            InitializeComponent();
        }

        private void btnGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(path))
            {
                txtPasswordBox.Text = generatePassword(16);
            }
            else
            {
                int numberOfChars = int.Parse(Encryption.Decrypt(File.ReadAllText(path), "HungryForApples?"));
                txtPasswordBox.Text = generatePassword(numberOfChars);
            }
        }


        private void btnSaveEntity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEntityName.Text == "" || (from c in txtEntityName.Text where c != ' ' select c).Count() == 0)
                {
                    throw new CustomException("You need to enter the entity's name");
                }
                else if (txtUserName.Text == "" || (from c in txtUserName.Text where c != ' ' select c).Count() == 0)
                {
                    throw new CustomException("You need to enter a username");
                }
                else if (txtEmail.Text == "" || (from c in txtEmail.Text where c != ' ' select c).Count() == 0)
                {
                    throw new CustomException("You need to enter an e-mail address");
                }
                else if (txtPasswordBox.Text == "" || (from c in txtPasswordBox.Text where c != ' ' select c).Count() == 0)
                {
                    throw new CustomException("You need to enter a password");
                }
                else
                {
                    entity.entityName = txtEntityName.Text;
                    entity.userName = txtUserName.Text;
                    entity.email = txtEmail.Text;
                    entity.password = txtPasswordBox.Text;

                    Entity.saveToFile(entity);

                    txtUserName.Clear();
                    txtEntityName.Clear();
                    txtPasswordBox.Clear();
                    txtEmail.Clear();
                }
            }
            catch (CustomException ce)
            {
                MessageBox.Show(ce.exceptionText);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new mainPage());
        }

        private string generatePassword(int numberOfCharacters)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+=-_$%&#!?*/@";
            var randomlyGeneratedPassword = new char[numberOfCharacters];
            var random = new Random();

            for (int i = 0; i < randomlyGeneratedPassword.Length; i++)
            {
                randomlyGeneratedPassword[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(randomlyGeneratedPassword);

            return finalString;
        }
    }
}