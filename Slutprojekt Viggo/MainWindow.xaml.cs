﻿using System.Diagnostics;
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
        void Varulista()
        {
            List<string> serie = ["001", "002", "003", "004", "005", "006", "007", "008", "009", "010"];
            List<string> name = ["äpple", "bannan", "päron", "mjölk", "chokladkaka", "bröd", "ost", "smör", "skinka", "pasta"];
            List<int> kostnad = [10, 15, 17, 22, 20, 14, 52, 32, 27, 43];

            for (int i = 0; i < serie.Count; i++)
            {
                produkt.Add(new Vara(serie[i], name[i], kostnad[i]));   //0            
            }
        }
        //knappevent
        private void btnAddProdukt_Click(object sender, RoutedEventArgs e)
        {
             
            if (Kollanummer(tbxProduktInskaning.Text, "sökning"))
            {
                TillaggsLista(tbxProduktInskaning.Text);
                VisaVaraKundvagn(tbxProduktInskaning.Text);
            }
            
        }
        private void btnCheckInskaningProdukt_Click(object sender, RoutedEventArgs e)
        {
            Kollanummer(tbxProduktInskaning.Text, "sökning");
        }
        private void btnRemoveFrånVagn_Click(object sender, RoutedEventArgs e)
        {
            Remove();
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
        }
        private void btnLoggaIn_Click(object sender, RoutedEventArgs e)
        {
            LoggaIn(tbxKontoid.Text, tbxKontoLösenord.Text);
        }
        //methoder
        bool Kollanummer(string nummer, string knapp)
        {
            bool oupphittad = true;
            for (int i = 0; i < produkt.Count; i++)
            {
                //check knappen
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
        //lista med varor till kundvagnen
        void TillaggsLista(string nummer)
        {
                    if (kundvagnen.Count > 0)
                    {
                        bool tillagd = false;
                        for (int i = 0; i < kundvagnen.Count; i++)
                        {
                            if (kundvagnen[i].Serienummer == nummer)
                            {
                                kundvagnen[i].Mangd = kundvagnen[i].Mangd + 1;
                                tillagd = true;
                                break;
                            }

                        }
                        for (int i = 0; i < produkt.Count; i++)
                        {
                            if (!tillagd && produkt[i].Serienummer.ToString() == nummer)
                            {
                                kundvagnen.Add(new Kundvagn(nummer, 1));

                                break;
                            }

                        }


                    }
                    else
                    {
                        kundvagnen.Add(new Kundvagn(nummer, 1));
                    } 
           
        }
        void VisaVaraKundvagn(string nummer)
        {
            for (int i = 0; i < kundvagnen.Count ; i++)
            {


                if (nummer == kundvagnen[i].Serienummer)
                {
                    for (int j = 0; j < produkt.Count; j++)
                    {
                        if (nummer == produkt[j].Serienummer)
                        {



                            tblProduktNamn.Text = produkt[j].Namn.ToString();
                            tblProduktPris.Text = produkt[j].Pris.ToString() + "kr";
                            tblProduktmängd.Text = kundvagnen[i].Mangd.ToString();
                            tblTotalpris.Text = TotalPris().ToString();
                            break;
                        }
                    }
                }


            }

        }
        void Remove()
        {
            for (int i = 0; i < produkt.Count; i++)
            {
                if (tblProduktNamn.Text == produkt[i].Namn && kundvagnen[i].Mangd > 0)
                {
                    kundvagnen[i].Mangd -= 1;
                    tblProduktmängd.Text = kundvagnen[i].Mangd.ToString();
                    tblTotalpris.Text = TotalPris().ToString();
                }
            }
        }
        int TotalPris()
        {
            int total = 0;
            for (int i = 0; i < kundvagnen.Count; i++)
            {
                total = total + Pris(kundvagnen[i].Serienummer) * kundvagnen[i].Mangd;
            }
            return total;
        }
        int Pris(string nummer)
        {
            int pris = 0;
            for (int i = 0; i < produkt.Count; i++)
            {
                if (nummer == produkt[i].Serienummer)
                {
                    pris = produkt[i].Pris;
                }

            }
            return pris;

        }
        void Flytta(bool framåt)
        {
            string nummer = "";

            for (int i = 0; i < produkt.Count; i++)
            {
                if (tblProduktNamn.Text == produkt[i].Namn)
                {

                    if (framåt && i < kundvagnen.Count-1)
                    {
                        nummer = kundvagnen[i + 1].Serienummer;
                        VisaVaraKundvagn(nummer);
                        break;
                    }
                    else if (!framåt && i > 0 )
                    {
                        nummer = kundvagnen[i - 1].Serienummer;
                        VisaVaraKundvagn(nummer);
                        break;
                        
                    }
                }

            }
        }
        List<Kund> kunder = new List<Kund>();
        void SkapaKonto(string namn, string lösenord)
        {
            bool första = true;
            for (int i = 0; i < kunder.Count; i++)
            {
                if (kunder[i].Lösenord == lösenord || kunder[i].Namn == namn)
                {
                    tblKontoInformationSkapas.Text = "id/lösen finns redan";
                    första = false;
                    break;
                }
            }
            if (första && lösenord.Trim() != "" && namn.Trim() != "")
            {
                kunder.Add(new Kund(false, namn, lösenord, 0));
                tblKontoInformationSkapas.Text = "Konto har skapats ";
            }
            else if (första) 
            {
                tblKontoInformationSkapas.Text = "Fyll i alla fält";
            }

        }
        void LoggaIn(string namn,string lösenord)
        {
            for (int i = 0; i < kunder.Count; i++)
            {
                if (kunder[i].Lösenord== lösenord && kunder[i].Namn==namn)
                {
                    Open(i); 
                }
            }
        }
        void Open(int vilken)
        {
            tbxBankKontoId.Text = kunder[vilken].Namn;
            tblBankTotalSaldo.Text = kunder[vilken].Saldo.ToString();
            if (kunder[vilken].Medlem)
            {
                btnBliMedlem.Content = "Är medlem";
            }

        }
        void Pängatilläg(int pengar)
        {

        }
        private void btnLaggTillPengar_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbxBankPengarTilläg.Text, out int money);
            Pängatilläg(money);
        }

        private void btnKöp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBliMedlem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

      