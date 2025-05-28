using System.Diagnostics;
using System.Runtime.Serialization;
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
        List<Vara> produkt = new List<Vara>();
        //skapar classobejekt som man sedan kan skanna ut
        void Varulista()
        {
            List<string> serie =   ["001"    ,"002"     ,"003"    ,"004"    ,"005"          ,"006"   ,"007"  ,"008"   ,"009"     ,"010"];
            List<string> name = ["äpple","bannan","päron","mjölk","chokladkaka","bröd","ost","smör","skinka","pasta"];
            List<int> kostnad = [10,     15      ,17     ,22     ,20           ,14    ,52   ,32    , 27     ,43];
            
            for (int i = 0; i < serie.Count; i++)
            {
                produkt.Add(new Vara(serie[i], name[i], kostnad[i]));               
            }
        }

        private void btnCheckInskaningProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kollanummer(tbxProduktInskaning.Text,"sökning");
        }
        
        int Kollanummer(string nummer,string knapp,)
        {
            for (int i = 0; i < produkt.Count; i++)
            {
                
                if (nummer == produkt[i].Serienummer.ToString() && knapp == "sökning")
                {
                    tblProduktInskaningNamn.Text = produkt[i].Namn.ToString();
                    tblProduktInskaningPris.Text = produkt[i].Pris.ToString() + "kr";
                    string addera = nummer;
                    break;
                }
                else if (nummer != produkt[i].Serienummer.ToString() && knapp == "sökning")
                {
                    tblProduktInskaningNamn.Text = "ingen vara hittades";
                    tblProduktInskaningPris.Text = "ingen vara hittades";
                   
                }
                else if (nummer == "" && knapp == "sökning")
                {
                    tblProduktInskaningNamn.Text = "";
                    tblProduktInskaningPris.Text = "";
                }


            }





            return 1;
            
        }

        private void btnSenareProdukt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTidigareProdukt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}