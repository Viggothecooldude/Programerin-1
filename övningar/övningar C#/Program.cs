Random slump = new Random();
int slumpad = slump.Next(1, 11);
int[,] lista = new int[4,4];
int i = 0;
int j = 0;

for (int k = 0; k < 1; k++)
{


    for ( i = 0; i < lista.GetLength(0); i++)
    {


        for ( j = 0; j < lista.GetLength(1); j++)
        {
            Random rad = new Random();
            int radd = rad.Next(0, 21);

            lista[i, j] = radd;

            Console.Write($"{lista[i, j]} ");
            if (j==0)
            {
                int forsta = 0;
                forsta = +lista[i, j];
            }
            if (j == 1)
            {
                int andra = 0;
                andra = +lista[i, j];
            }
            if (j == 2)
            {
                int tredje = 0;
                tredje = +lista[i, j];
            }
            if (j == 3)
            {
                int fjarde = 0;
                fjarde = +lista[i, j];
            }
        }
        Console.WriteLine();
    }
}


