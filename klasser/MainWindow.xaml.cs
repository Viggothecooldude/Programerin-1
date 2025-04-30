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

namespace klasser
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
        
        string Testfunktion()
        {
            Test test = new();
            test.färg = "Röd";
            return test.färg;
        }

        private void knap_Click(object sender, RoutedEventArgs e)
        {
            
            text.Text = Testfunktion();
        }
    }
}