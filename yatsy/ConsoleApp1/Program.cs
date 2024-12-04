using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;
Random tarningslag = new Random();
string keep;
int[] tarning = new int[5];

int avsluta=0;
while (avsluta == 0) {
    for (int i = 0; i < 5; i++)
    {

        tarning[i] = tarningslag.Next(1, 7);
    }
    
    //asci-art
    string[] tarningsbilder = [" -----\r\n|     |\r\n|  o  |\r\n|     |\r\n -----\r", "\r -----\r\n|  o  |\r\n|     |\r\n|  o  |\r\n -----\r", "\r -----\r\n| o   |\r\n|  o  |\r\n|   o |\r\n -----\r", "\r -----\r\n| o o |\r\n|     |\r\n| o o |\r\n -----\r", "\r -----\r\n| o o |\r\n|  o  |\r\n| o o |\r\n -----\r", "\r -----\r\n| o o |\r\n| o o |\r\n| o o |\r\n -----"];

    int antalpar = 0;
    bool triss = false;
    bool fyrtal = false;
    bool yatzy = false;
    int poang = 0;
    int[] slag = new int[5];

    Console.WriteLine("tryck enter för att slå tärningar");
    Console.ReadLine();
    for (int e = 0; e < 3; e++)
    {
        //koll på omslag
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(tarningsbilder[tarning[i] - 1]);
        }
        if (e < 2)
        {
            Console.WriteLine("Vilka tärningar vill du slå om? (1 för att spara 0 för att slå om t.ex 10010)");
            keep = Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {

                //visa tärningar
                if (keep[i] == '0')
                {
                    tarning[i] = tarningslag.Next(1, 7);
                }

            }
        }
    }

    //koll på hur många av samma nummer det finns för att kolla par,triss m.m
    for (int i = 1; i <= 6; i++)
    {
        int portal = 0;
        for (int j = 0; j < 5; j++)
        {
            if (i == tarning[j])
            { portal++; }
        }
        if (portal==2)
        {
            antalpar++;
            poang += i * 2;
        }
        if (portal == 3)
        {
            triss=true;
            poang += i * 3;
        }
        if (portal == 4)
        {
            fyrtal=true;
            poang += i * 4;
        }
        if (portal == 5)
        {
            yatzy=true;
            poang += 50;
        }
        Console.WriteLine(portal);
    }

    //poängutdelning
    if (yatzy == true)
    {
        Console.WriteLine("Du fick yatsy + 50 poäng");
    }
    else if (fyrtal == true)
    {
        Console.WriteLine("Du fick fyrtal + " + poang + " poäng");
    }
    else if (triss == true && antalpar == 1)
    {
        Console.WriteLine("Du fick kåk + " + poang + " poäng");
    }
    else if (triss == true)
    {
        Console.WriteLine("Du fick triss + " + poang + " poäng");
    }
    else if (antalpar == 2)
    {
        Console.WriteLine("Du fick tvåpar + " + poang + " poäng");
    }
    else if (antalpar == 1)
    {
        Console.WriteLine("Du fick par + " + poang + " poäng");
    }
    else if (!slag.Contains(6))
    {
        poang += 15;
        Console.WriteLine("Du fick lilla stegen + " + poang + " poäng");
    }
    else if (!slag.Contains(1))
    {
        poang += 20;
        Console.WriteLine("Du fick stora stegen + " + poang + " poäng");
    }
    else
    {
        Console.WriteLine("du fick inget 0 poäng");
    }
}