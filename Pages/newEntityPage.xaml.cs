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
    /// Interaction logic for NewEntityPage.xaml
    /// </summary>
    public partial class NewEntityPage : Page
    {
        private Entity entity = new Entity();
        public NewEntityPage()
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
            try
            {
                if (txtUserName.Text == "")
                {
                    throw new CustomException("You need to enter a user name");
                }
                else if (txtPasswordBox.Text == "")
                {
                    throw new CustomException("You need to enter a password");
                }
                else if (txtEmail.Text == "")
                {
                    throw new CustomException("You need to enter an E-mail address");
                }
                else if (txtEntityName.Text == "")
                {
                    throw new CustomException("You need to enter an Entity name");
                }
                else
                {
                    entity.userName = txtUserName.Text;
                    entity.entityName = txtEntityName.Text;
                    entity.password = txtPasswordBox.Text;
                    entity.email = txtEmail.Text;

                    Entity.saveToFile(entity);
                }
            }
            catch (CustomException ce)
            {
                MessageBox.Show(ce.exceptionText);
            }
        }
    }
}