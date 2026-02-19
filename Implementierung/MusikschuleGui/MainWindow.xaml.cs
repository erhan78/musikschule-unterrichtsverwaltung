using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusikschuleGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SchuelerButton_Click(object sender, RoutedEventArgs e)
        {
            var fenster = new SchuelerWindow();
            fenster.ShowDialog();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Unterricht_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zahlungen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}