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

namespace WpfApp_uppgift_1
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


        int Skottår()
        {
            int.TryParse(tbxår.Text, out int årsnummer);
            if (årsnummer == -1)
            {
                tblresultat.Text = "Något gick fel försök med ny indata";
                return -1;
            }
            else if (årsnummer %4 == 0 && årsnummer%100 != 0 || årsnummer%400 == 0)
            {
                tblresultat.Text = "år" + tbxår.Text + "+är ett skottår";
                return 1;
            }
            else
            {
                tblresultat.Text = "år" + tbxår.Text + "+är inte ett skottår";
                return 0;
            }
           
        }
       void Månad(bool år)
        {

        }

        private void ärdet_Click(object sender, RoutedEventArgs e)
        {
            Skottår();
        }
    }
}