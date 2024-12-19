//övning a 
string froga = Console.ReadLine();
string capital = froga.ToLower();
string blank = capital.Replace(" ","");
string omvand= "";
if ((blank.Length) > 1)
{
    for (int i = blank.Length - 1; i >= 0; i--)
        omvand += blank[i];
    if (blank.Equals(omvand))
        Console.WriteLine(froga + " är ett palindrom");
    else
        Console.WriteLine(froga + " är inte ett palindrom" + blank + omvand);
}
else
    Console.WriteLine("Du måste skriva en längre string");

//övning b
string ord1 = Console.ReadLine().ToLower();
string ord2 = Console.ReadLine().ToLower();
int[] protocol = new int[ord1.Length];
int[] omlika = new int[protocol.Length];
if (ord1.Length.Equals(ord2.Length))
{
    for (int i = 0; i < ord1.Length; i++) // kollar hur många av varje bokstav o ord 1 som finns i ord2
    {
        int chek = 0;
        for (int j = 0; j < ord2.Length; j++)
        {
            if (ord1[i].Equals(ord2[j]))
                chek++;
        }
        protocol[i] = chek;
    }
    
    for (int i = 0; i < protocol.Length; i++)// kollar så det inte är olika många av samma bokstav när ett l i ord1 och två i ord2 eller liknande
    {
        for (int j = 0; j < protocol.Length; j++)
        {            
            if (protocol[i]== j)               
            omlika[j]++;
        }
    }
    if (omlika[0] != 0)
    {
        Console.WriteLine("Orden är inte anagram");
    }
    else
    {
        bool sant = false;
        for (int i = 2; i < omlika.Length; i++)
        {
            if (omlika[i]%2 !=0 )           
                sant = true;
        }
        if (sant)
            Console.WriteLine($"{ord1} och {ord2} är inte anagram");
        else
            Console.WriteLine($"{ord1} och {ord2} är anagram");
    }
}
else
    Console.WriteLine("Orden är inte anagram");