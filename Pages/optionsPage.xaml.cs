using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Navigation;


namespace Pasword_Manager
{
    /// <summary>
    /// Interaction logic for optionsPage.xaml
    /// </summary>
    public partial class optionsPage : Page
    {
        private string path = Directory.GetCurrentDirectory() + "/options.txt";


        public optionsPage()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new mainPage());
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int broj;
            if (!File.Exists(path))
            {
                if (int.TryParse(txtNumberOfCharacters.Text, out broj))
                {
                    using (StreamWriter newTask = new StreamWriter(path))
                    {
                        newTask.WriteLine(Encryption.Encrypt(broj.ToString(), "HungryForApples?"));
                    }
                    txtNumberOfCharacters.Clear();
                }
                else
                {
                    MessageBox.Show("You did not enter a value of type 'integer'");
                }

            }
            else
            {
                if (int.TryParse(txtNumberOfCharacters.Text, out broj))
                {
                    using (StreamWriter newTask = new StreamWriter(path, false))
                    {
                        newTask.WriteLine(Encryption.Encrypt(broj.ToString(), "HungryForApples?"));
                    }
                    txtNumberOfCharacters.Clear();
                }
                else
                {
                    MessageBox.Show("You did not enter a value of type 'integer'");
                }
            }
        }
    }
}