using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Slutprojekt_Viggo
{
    /// <summary>
    /// Interaction logic for BankKonto.xaml
    /// </summary>
    public partial class BankKonto : Window
    {

   
        public BankKonto( bool medlem, string namn, string lösenord, double saldo )//denna sida planerades att användas när man loggat in på sitt konto genom att öppna en ny flik 
            //Hittade inget sätt att ändra saker som saldo i det här fönstret så jag skickade tillbaka allt till orginalfönstret men kanske kommer tillbaka till det här om jag har tid i veckan
        {
            kontot.Add(new Kund(medlem, namn, lösenord, saldo));
            InitializeComponent();
           
            Open(medlem,namn,lösenord,saldo);
            
           
        }
       List<Kund> kontot = new List<Kund>();
        
        void Open(bool medlem, string namn, string lösenord, double saldo)
        {
            tbxBankKontoId.Text = namn;
            tblBankTotalSaldo.Text = saldo.ToString();
            if (medlem)
            {
                btnBliMedlem.Content = "Är medlem";
            }
        }
        private void btnBliMedlem_Click(object sender, RoutedEventArgs e)
        {
            if (!kontot[0].Medlem)
            {
                
                btnBliMedlem.Content = "Är medlem";
            }
        }
        private void btnLaggTillPengar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnKöp_Click(object sender, RoutedEventArgs e)
        {

        }
        

    }
}
