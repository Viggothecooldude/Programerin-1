using System.ComponentModel.DataAnnotations;
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

        //initsialicering av klasser
        List<Vara> produkt = new List<Vara>();
        List<Kundvagn> kundvagnen = new List<Kundvagn>();
        List<Kund> kunder = new List<Kund>();
        //fyller i databasen utav varor
        void Varulista()
        {
            List<string> serie = ["001", "002", "003", "004", "005", "006", "007", "008", "009", "010"];
            List<string> name = ["äpple", "bannan", "päron", "mjölk", "chokladkaka", "bröd", "ost", "smör", "skinka", "pasta"];
            List<int> kostnad = [10, 15, 17, 22, 20, 14, 52, 32, 27, 43];

            for (int i = 0; i < serie.Count; i++)
            {
                produkt.Add(new Vara(serie[i], name[i], kostnad[i]));             
            }
        }
        //knappevent vars funktion ses i namnen
        private void btnAddProdukt_Click(object sender, RoutedEventArgs e)
        {  
            if (Kollanummer(tbxProduktInskaning.Text, "sökning"))
            {
                TillaggsLista(tbxProduktInskaning.Text);
                VisaVaraKundvagn(tbxProduktInskaning.Text);
            }
            Open(vilkenKund);
        }
        private void btnCheckInskaningProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kollanummer(tbxProduktInskaning.Text, "sökning");
        }
        private void btnRemoveFrånVagn_Click(object sender, RoutedEventArgs e)
        {
            Remove();
            Open(vilkenKund);
        }
        private void btnSenareProdukt_Click(object sender, RoutedEventArgs e)
        {
            Flytta(false);
        }
        private void btnTidigareProdukt_Click(object sender, RoutedEventArgs e)
        {
            Flytta(true);
        }
        private void btnSkapaKonto_Click(object sender, RoutedEventArgs e)
        {
            SkapaKonto(tbxKontoidSkapas.Text, tbxKontoLösenordSkapas.Text);
            tbxKontoidSkapas.Text = "";
            tbxKontoLösenordSkapas.Text = "";
        }
        private void btnLoggaIn_Click(object sender, RoutedEventArgs e)
        {
            LoggaIn(tbxKontoid.Text, tbxKontoLösenord.Text);
            tbxKontoid.Text = "";
            tbxKontoLösenord.Text = "";
        }
        private void btnLaggTillPengar_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbxBankPengarTilläg.Text, out int money);
            Pängatilläg(money);
        }
        private void btnKöp_Click(object sender, RoutedEventArgs e)
        {
            Köp();
        }
        private void btnBliMedlem_Click(object sender, RoutedEventArgs e)//Drar 100kr och gör kontot till medlem
        {
            if (!kunder[vilkenKund].Medlem && kunder[vilkenKund].Saldo >= 100)
            {
                kunder[vilkenKund].Medlem = true;
                btnBliMedlem.Content = "Är medlem";
                Pängatilläg(-100);

            }
        }
        //methoder
        bool Kollanummer(string nummer, string knapp)//Kollar serienummer och skickar ut vad det är för sorts produkt samt pris
        {
            bool oupphittad = true;
            for (int i = 0; i < produkt.Count; i++)
            {
                if (knapp == "sökning")
                {
                    if (nummer == produkt[i].Serienummer.ToString())
                    {
                        tblProduktInskaningNamn.Text = produkt[i].Namn.ToString();
                        tblProduktInskaningPris.Text = produkt[i].Pris.ToString() + "kr";
                        oupphittad = false;
                        return true;
                    }
                }
                if (oupphittad)
                {
                    tblProduktInskaningNamn.Text = "ingen vara hittades";
                    tblProduktInskaningPris.Text = "ingen vara hittades";
                }
            }
            return false;
        }
        void TillaggsLista(string nummer)//Lägger till obejekt kundvagnen listan och om samma obejektredan finns ökar den mängden
        {
            if (kundvagnen.Count > 0)
            {
                bool tillagd = false;
                for (int i = 0; i < kundvagnen.Count; i++)//kontroll för mängdökning
                {
                    if (kundvagnen[i].Serienummer == nummer)
                    {
                        kundvagnen[i].Mangd = kundvagnen[i].Mangd + 1;
                        tillagd = true;
                        break;
                    }
                }
                for (int i = 0; i < produkt.Count; i++)//lägger till objekt i listan
                {
                    if (!tillagd && produkt[i].Serienummer.ToString() == nummer)
                    {
                        kundvagnen.Add(new Kundvagn(nummer, 1));
                        break;
                    }
                }
            }
            else//löser felkälla då kundvagnen har 0 objekt
            {
                kundvagnen.Add(new Kundvagn(nummer, 1));
            } 
        }
        void VisaVaraKundvagn(string nummer)//Visar varan som har ett visst serienummer sammt dess mängd i kundvagnen listan(vid blädring eller addering utav objekt)
        {
            for (int i = 0; i < kundvagnen.Count ; i++)
            {
                if (nummer == kundvagnen[i].Serienummer)//gämför med produktlista för att hitta serienummer
                {
                    for (int j = 0; j < produkt.Count; j++)
                    {
                        if (nummer == produkt[j].Serienummer)
                        {
                            tblProduktNamn.Text = produkt[j].Namn.ToString();
                            tblProduktPris.Text = produkt[j].Pris.ToString() + "kr";
                            tblProduktmängd.Text = kundvagnen[i].Mangd.ToString();
                            tblTotalpris.Text = (kundvagnen[i].Mangd* produkt[j].Pris).ToString() + "kr";
                            break;
                        }
                    }
                }
            }
        }
        void Remove()//sänker mängden från kundvagns objektet
        {
            for (int i = 0; i < produkt.Count; i++)
            {
                if (tblProduktNamn.Text == produkt[i].Namn )
                {
                    for ( int j = 0; j < kundvagnen.Count; j++)
                    {
                        if (produkt[i].Serienummer == kundvagnen[j].Serienummer && kundvagnen[j].Mangd > 0)//gämför med produktlista för att hitta serienummer
                        {
                            kundvagnen[j].Mangd -= 1;
                            VisaVaraKundvagn(produkt[i].Serienummer);
                        }
                    }
                }
            }
        }
        double TotalPris(bool medlemsrea)//Räknar ut totalpriset från alla inividuella pris uträknade i Pris() metoden
        {
            double total = 0;
            for (int i = 0; i < kundvagnen.Count; i++)
            {
                total += Pris(kundvagnen[i].Serienummer , medlemsrea, i) * kundvagnen[i].Mangd;
            }
            return total;
        }
        double Pris(string nummer,bool medlemsrea, int kundvagnsmangd)//räknar ut kostnaden för ett specifikt obejekt
        {
            double pris = 0;
            for (int i = 0; i < produkt.Count; i++)
            {
                if (nummer == produkt[i].Serienummer && medlemsrea && kundvagnen[kundvagnsmangd].Mangd >= 3)//ger 30% rea om man har medlemskap och köpt 3 eller mer av samma vara
                {
                    
                    pris = produkt[i].Pris * 0.7;
                }
                else if (nummer == produkt[i].Serienummer && medlemsrea || nummer == produkt[i].Serienummer && kundvagnen[kundvagnsmangd].Mangd >=3)//ger rea på 10% om man har medlemskap eller köpt 3 eller mer av samma vara
                {
                    pris = produkt[i].Pris*0.9  ;
                }
                else if (nummer == produkt[i].Serienummer)
                {
                    pris = produkt[i].Pris;
                }
            }
            return pris;
        }
        void Flytta(bool framåt)//blädrar fram och tillbaka igenom objekten i kundvagnen beroende på bool värdet
        {
            string nummer = "";
            bool fortsätt = true;
            for (int i = 0; i < produkt.Count; i++)
            {
                if (tblProduktNamn.Text == produkt[i].Namn&& fortsätt)//gämför med produktlista för att hitta serienummer
                {
                    for (int j = 0; j < kundvagnen.Count; j++)
                    {
                        if (produkt[i].Serienummer == kundvagnen[j].Serienummer)
                        {
                            if (framåt && j < kundvagnen.Count -1)
                            {
                                nummer = kundvagnen[j + 1].Serienummer;
                                VisaVaraKundvagn(nummer);
                                fortsätt = false;
                                break;
                            }
                            else if (!framåt && j > 0)
                            {
                                nummer = kundvagnen[j - 1].Serienummer;
                                VisaVaraKundvagn(nummer);
                                fortsätt = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
        void SkapaKonto(string namn, string lösenord)//skapar ett konto av objektet Kund i kunder listan
        {
            bool första = true;
            for (int i = 0; i < kunder.Count; i++)
            {
                if (kunder[i].Lösenord == lösenord || kunder[i].Namn == namn)//kollar så namn och lösenord inte redan finns
                {
                    tblKontoInformationSkapas.Text = "id/lösen finns redan";
                    första = false;
                    break;
                }
            }
            if (första && lösenord.Trim() != "" && namn.Trim() != "")//kollar så namn eller lösenordet inte är tomt
            {
                kunder.Add(new Kund(false, namn, lösenord, 0));
                tblKontoInformationSkapas.Text = "Konto har skapats ";
            }
            else if (första) 
            {
                tblKontoInformationSkapas.Text = "Fyll i alla fält";
            }
        }
        void LoggaIn(string namn,string lösenord)//öppnar Kund konto om lösenord stämer
        {
            for (int i = 0; i < kunder.Count; i++)
            {
                if (kunder[i].Lösenord== lösenord && kunder[i].Namn==namn)
                {
                    Open(i); 
                    tblKontoInformation.Text = "Du är inloggad";
                }
                else if (namn == "" || lösenord == "")
                {
                    tblKontoInformation.Text = "Fyll i alla fält";
                }
                else
                {
                    tblKontoInformation.Text = "Konto kunde ej hittas";
                }
            }
        }
        void Open(int vilken)//öppnar ett kontos information dels vid inlogning men också vid ändring i kundvagn för att uppdatera kostnader
        {
            if (vilken != -1)
            {
                tbxBankKontoId.Text = kunder[vilken].Namn;
                tblBankTotalSaldo.Text = kunder[vilken].Saldo.ToString();
                if (kunder[vilken].Medlem)
                {
                    btnBliMedlem.Content = "Är medlem";
                }
                else
                {
                    btnBliMedlem.Content = "Bli medlem 100kr";
                }
                vilkenKund = vilken;
                tblTotalKostnad.Text = TotalPris(false).ToString();
                tblMedlemskostnad.Text = TotalPris(true).ToString();
            }
        }
        int vilkenKund = -1;//Variabel som håller koll så inte något oönskat konto öppnas innan första kontot öppnats
        void Pängatilläg(double pengar)//lägger till pengar (eller tar bort med ett negativt värde)
        {
                if (kunder[vilkenKund].Namn == tbxBankKontoId.Text)
                {
                    kunder[vilkenKund].Saldo += pengar;
                    tblBankTotalSaldo.Text= kunder[vilkenKund].Saldo.ToString();
                    tblBankKontoInfo.Text = "Ditt saldo har uppdaterats";
                }
        }
        void Köp()//kollar så man har pengar ssen drar pengar lika med vad man är skyldig jämfört med ens medlemsskap
        {
            if (kunder[vilkenKund].Saldo>= TotalPris(kunder[vilkenKund].Medlem))
            {
                 Pängatilläg(-TotalPris(kunder[vilkenKund].Medlem));
            }
        }
       
    }
}   