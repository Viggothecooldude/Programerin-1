using System.Diagnostics.CodeAnalysis;
int avsluta = 0;
while (avsluta == 0)
{
    Console.WriteLine("vad vill du göra\n1) Slå färdigheter\n2) visa färdigheter");

    int val = int.Parse(Console.ReadLine());

    int[] fardigheter = new int[4];

    Random tarning = new Random();
    switch (val)
    {
        case 1:
            for (int i = 0; i < 4; i++)// Färdighetsdistributering
            {
                int fardighet = tarning.Next(1, 11);
                Console.WriteLine("Du slog en " + fardighet + " vilken attribute vill du tilldela den");
                Console.WriteLine("Dina val är");
                if (fardigheter[0] == 0)
                {
                    Console.WriteLine("1) styrka");
                }
                if (fardigheter[1] == 0)
                {
                    Console.WriteLine("2) träffsäkerhet");
                }
                if (fardigheter[2] == 0)
                {
                    Console.WriteLine("3) intalligens");
                }
                if (fardigheter[3] == 0)
                {
                    Console.WriteLine("4) smidighet");
                }
                fardigheter[(int.Parse(Console.ReadLine())) - 1] = fardighet;
            }
            break;
        case 2:
            if (fardigheter[0] == 0 || fardigheter[1] == 0 || fardigheter[2] == 0 || fardigheter[3] == 0)
            {
                Console.WriteLine("Du har antingen inte tilldelat färdigheter eller tilldelat fel gör om det för att fortsätta");
            }
            else
            {
                Console.WriteLine($"Styrka {fardigheter[0]} \nträffsäkerhet {fardigheter[1]} \ninteligens {fardigheter[3]} \nsmidighet {fardigheter[4]} \n");
            }
            break;
        case 3:
            Console.WriteLine("vad vill du testa 1-4");
            int test = int.Parse(Console.ReadLine());
            int rand = tarning.Next(1, 11);
            Console.WriteLine("Du slog en" + rand);
            if (fardigheter[test] >= rand)
            {
                Console.WriteLine("Du lyckades");
            }
            else
            {
                Console.WriteLine("du misslyckades");
            }
            break;
    }       
}