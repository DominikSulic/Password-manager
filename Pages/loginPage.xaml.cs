using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path += "\\masterPassword.txt";

            if (File.Exists(path))
            {
                string[] masterPasswordCheck = File.ReadAllLines(path);
                if (txtMasterPasswordInput.Text == Encryption.Decrypt(masterPasswordCheck[0], "HungryForApples?"))
                {
                    NavigationService.Navigate(new mainPage());
                }
                else
                {
                    MessageBox.Show("Access Denied!");
                }
            }
            else
            {
                if (txtMasterPasswordInput.Text != "" && ((from c in txtMasterPasswordInput.Text where c != ' ' select c).Count() != 0))
                {
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        file.WriteLine(Encryption.Encrypt(txtMasterPasswordInput.Text, "HungryForApples?"));
                        file.Close();
                        MessageBox.Show("New Password Saved!");

                        NavigationService.Navigate(new mainPage());
                    }
                }
                else
                {
                    MessageBox.Show("You didn't enter anything");
                }
            }
        }
    }
}