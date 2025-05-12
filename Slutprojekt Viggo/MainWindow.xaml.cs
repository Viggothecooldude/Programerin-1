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

namespace Slutprojekt_Viggo
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

        private void btnCheckInskaningProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kollanummer(tbxProduktInskaning.Text);
        }
        int Kollanummer(string nummer)
        {
            for (int i = 0; i < length; i++)
            {
                
            }
            if (nummer == Serienummer)
            { 
                
            }
            
            return  1;
            
        }
    }
}