﻿string timme = Console.ReadLine();   
int timmar = int.Parse(timme);  
string minut = Console.ReadLine();
int minuter = int.Parse(minut);
string tidskillnad = Console.ReadLine();
int tid = int.Parse(tidskillnad);
int total = timmar * 60 + minuter+ tid;
int dag = (total / 60) / 24;
int dagcheck = total/60 - dag * 24;
Console.WriteLine($"sluttid är {dagcheck}:{total%60}");