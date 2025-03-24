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

namespace Metoder
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


        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            int[] klar = TaFram();
            Beräkna(klar[0], klar[1], '+');


        }



        private void btnmult_Click(object sender, RoutedEventArgs e)
        {
            int[] klar = TaFram();
            Beräkna(klar[0], klar[1],'*');
        }
        
       private void btnsub_Click(object sender, RoutedEventArgs e)
        {
            int[] klar = TaFram();
            Beräkna(klar[0], klar[1], '-');
        }
        private void btndub_Click(object sender, RoutedEventArgs e)
        {
            int[] klar = TaFram();
            Beräkna(klar[0], klar[1], '2');
        }
        int[] TaFram()
        {
            int.TryParse(tbxtal1.Text, out int tal1);
            int.TryParse(tbxtal2.Text, out int tal2);
            int[] talen = [tal1, tal2];
            return talen;
        } 
        
         int Beräkna(int nr1, int nr2,char sätt)
        {

            int total;

            if (sätt == '+')
            {
                total = nr1 + nr2;
            }
            else if (sätt == '-')
            {
                total = nr1 - nr2;
            }
            else if (sätt == '2')
            {
                total = 2*(nr1 + nr2);
            }
            else 
            {
                total = (nr1 * nr2);
            }

           Summa.Text = total.ToString();
            return total;
        }

        
    }
}