using System.Net.Http.Headers;

int avsluta=0;
Random tarningslag = new Random();
int[] tarning = new int[5];
while ( avsluta ==0 ) {
    for (int i = 0; i < 5; i++)
    {
       
        tarning[i] = tarningslag.Next(1, 7);
    }
    
    string[] tarningsbilder = [" -----\r\n|     |\r\n|  o  |\r\n|     |\r\n -----\r", "\r -----\r\n|  o  |\r\n|     |\r\n|  o  |\r\n -----\r", "\r -----\r\n| o   |\r\n|  o  |\r\n|   o |\r\n -----\r", "\r -----\r\n| o o |\r\n|     |\r\n| o o |\r\n -----\r", "\r -----\r\n| o o |\r\n|  o  |\r\n| o o |\r\n -----\r", "\r -----\r\n| o o |\r\n| o o |\r\n| o o |\r\n -----"];

    int antalpar = 0;
    bool triss = false;
    bool fyrtal = false;
    bool yatzy = false;
    int poang = 0;
    
    bool[] keep = new bool[5];


    Console.WriteLine("tryck enter för att slå tärningar");
    Console.ReadLine();
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine(i);
        Console.WriteLine(tarning[i]);
        Console.WriteLine(tarningsbilder[tarning[i]-1]);
    }
    
        }
    
    for (int i = 1; i <= 6; i++)
    {
        int portal = 0;
        for (int j = 0; j < 5; j++)
        {
            if (i == slag[j])
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
    }
    Console.WriteLine("Resultat");
    Console.WriteLine(antalpar);
    Console.WriteLine(triss);
    Console.WriteLine(fyrtal);
    Console.WriteLine(yatzy);
}