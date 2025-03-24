using System.Diagnostics;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Verkstaden
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

        Queue<string> garage = [];
        List<string> parkeringsplats = new List<string>(10);

        string behandlad = "";
        void Garageinkörning() //metod för att enqueuea bilar
        {
            int control = Ledigparkering("");
            if (tbxRegParkera.Text == "")
            {
                tblParkerad.Text = "regnummer krävs";

            }
            else if (control != -1)
            {
                
                
                garage.Enqueue(tbxRegParkera.Text);
                parkeringsplats.Insert(control,tbxRegParkera.Text);               
                tblParkerad.Text = "Bilen är parkerad";
                tbxRegParkera.Text = "";
            }
            else
            {
                tblParkerad.Text = "Garaget är fult";
            }
        }
        int Ledigparkering(string plats)//kolar var parkeringsplatser är lediga och vart bilen som ska behandlas står
        {
            for (int i = 0; i < 10; i++)
            {
                if (parkeringsplats[i] == plats)
                {
                    return i;
                }
                else if (i == 9)
                {
                    return -1;
                }
                else 
                { 
                    i++;
                }

            }
            return -1;
        }
        void Bilbehandling()// metod för förhandling
        {
            int control = Ledigparkering(garage.Peek());
            if (control != -1)
            {
                behandlad = garage.Dequeue();
                parkeringsplats.Insert(control,"");
                tblHämtad.Text = "Bil " + behandlad + " behandlas nu";
            }
            else 
            {
                tblHämtad.Text = "garaget är tomt";
            }
        }
        void Sök()
        {
            string regnummer = tbxRegSök.Text;
            if (behandlad == regnummer)
            {
                tblSök.Text = "bilen med registreringsnummeret" + regnummer + "bahandlas i verkstaden";
                tbxRegSök.Text = "";
            }
            else if (garage.Count==0 && behandlad == "")
            {
                tblSök.Text = "inga bilar behandlas eller finns i garaget";
            }
            else
            {
                for (int i = 0; i < garage.Count; i++)
                {
                    if (garage.Peek()==regnummer)
                tblSök.Text = "bilen med registreringsnummeret" + regnummer + "är på plats";

                }
            }

        }
        private void btnParkera_Click(object sender, RoutedEventArgs e)
        {
            Garageinkörning();
        }

        private void btnSök_Click(object sender, RoutedEventArgs e)
        {
            Sök();
        }

        private void btnBehandla_Click(object sender, RoutedEventArgs e)
        {
            Bilbehandling();
        }
    }
}