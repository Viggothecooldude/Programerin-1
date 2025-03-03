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

namespace WpfApp1
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textLeft.Foreground= Brushes.Red;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            textLeft.Foreground = Brushes.Blue;

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            textLeft.Foreground = Brushes.Yellow;

        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            textLeft.Foreground = Brushes.Green;

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            textRight.Foreground = Brushes.Red;

        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            textRight.Foreground = Brushes.Blue;

        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            textRight.Foreground = Brushes.Yellow;

        }

        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            textRight.Foreground = Brushes.Green;

        }
    }
}