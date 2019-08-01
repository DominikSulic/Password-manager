using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Interaction logic for savedEntitiesPage.xaml
    /// </summary>
    public partial class savedEntitiesPage : Page
    {
        public savedEntitiesPage()
        {
            InitializeComponent();

            string path = Directory.GetCurrentDirectory();
            path += "\\entities.txt";

            if (File.Exists(path))
            {

            }
            else
            {
                MessageBox.Show("The file could not be loaded"); 
            }
        }
    }
}
