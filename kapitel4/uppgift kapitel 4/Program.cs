Console.WriteLine("välkommen till abc bank skriv användarnamn och lösenord för att logga in");
Console.WriteLine("Användarnamn");
string användarnamn = Console.ReadLine();
Console.WriteLine("lösenord");
string losen = Console.ReadLine();
int saldo = 10000;
int val = 0;
if (användarnamn == "petter" && losen == "abc123")
{
    Console.WriteLine("Välkomen peter\nDitt saldo är " + saldo + " kr" +
        " \nVill du:\n1.Ta ut pengar\n2.sätta in pengar\n3.Logga ut");

     val = int.Parse(Console.ReadLine());
} 

int uttag = -1;
int insätning=-1;
    switch (val)
{
    case  1:
        Console.WriteLine("Hur mycket vill du ta ut?");
        uttag = int.Parse(Console.ReadLine());
       
        break;
    case  2:
        Console.WriteLine("Hur mycket vill du sätta in");
        insätning=int.Parse(Console.ReadLine());
        break;
    case  3:
        Console.WriteLine("Du är utloggad\nHa en bra dag");
        break;
        case 0:
        Console.WriteLine("Fel vid inlogning");
        break;
}

if (uttag > saldo)
{
    Console.WriteLine("du har inte tillräckligt mycket pengar");
}
else if ((uttag <= saldo) && uttag>0 )
{
   saldo -= uttag;
    Console.WriteLine("Uttag avklarat ditt kvarvarande saldo är\n" + saldo); 
}
if (insätning > 50000)
{
    Console.WriteLine("Fel: max insätning är 50 000 kr");
}
else if (insätning <= 50000 && insätning > 0)
{
    saldo += insätning;
    Console.WriteLine("Din insätning har dokumenterats ditt nya saldo är " + saldo + "kr");
}