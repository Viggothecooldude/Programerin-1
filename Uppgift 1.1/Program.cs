using System;

Console.BackgroundColor = ConsoleColor.White;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Black;

//Inlämningsuppgift 1 a
Console.WriteLine("A Hur mycket pengar vill du ta ut");string uttag = Console.ReadLine();
int tagUt = int.Parse(uttag);
int Hundra = tagUt/100;
Console.WriteLine("du tar ut " + Hundra*100 + "kr");

//Inlämningsuppgift 1 b
Console.WriteLine("B Hur mycket pengar vill du ta ut"); 
string uttagb = Console.ReadLine();

int tagUtb = int.Parse(uttagb);
int hundralappar = tagUtb / 100;
double femdelning = hundralappar/5;
int femhundralappar = (int) femdelning;
Console.WriteLine("Du tar ut " + (femhundralappar * 500) + "kr i femhundralappar");

int belopp = (hundralappar * 100) - (femhundralappar * 500);
Console.WriteLine("Du tar ut " + (belopp) + "kr i hundralappar");