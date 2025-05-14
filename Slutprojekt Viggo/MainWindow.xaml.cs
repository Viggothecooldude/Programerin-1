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
            Varulista();
        }
        
        void Varulista()
        {
            List<int> serie =   [001,    002,     003];
            List<string> name = ["äpple","bannan","päron"];
            List<int> kostnad = [10,     15,      17];
            for (int i = 0; i < serie.Count; i++)
            {
                Vara vara = new(serie[i], name[i], kostnad[i]);
                List<Vara> varor = vara;
            }
        }

        private void btnCheckInskaningProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kollanummer(tbxProduktInskaning.Text);
        }
        int Kollanummer(string nummer)
        {
 
            return  1;
            
        }
    }
}