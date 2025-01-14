// Skapa ett slumpobjekt
Random slump = new Random();

// Läs in hur stor arrayen ska vara OBS! Måste ange heltal
Console.WriteLine("Ange hur många nummer du vill ha: ");
int.TryParse(Console.ReadLine(),out int längd);
if (längd < 0) längd = -1*längd;

// skapa arrayen
int[] siffror = new int[längd];

// slumpa fram värden och skriv ut
Console.Write("Före sortering: ");
for (int i = 0; i < längd; i++)
{
    siffror[i] = slump.Next(11);
    Console.Write($"{siffror[i]}, ");
}

// Sortera arrayen med bubbelsortering
// ett varv för varje nummer
for (int i = 0; i < längd; i++)
{
    // ett varv för varje nummer förutom redan sorterade (i)
    for (int j = 0; j < längd - i - 1; j++)
    {
        // spara aktuellt och nästa värde
        int första = siffror[j];
        int andra = siffror[j + 1];

        // jämför värdena med varandra
        if (första > andra)
        {
            // byt plats på värdena
            siffror[j] = andra;
            siffror[j + 1] = första;
        }
    }
}

// Skriv ut sorterad lista
Console.WriteLine();
Console.Write("Efter sortering: ");
foreach (int nr in siffror)
    Console.Write($"{nr}, ");
Console.WriteLine();
