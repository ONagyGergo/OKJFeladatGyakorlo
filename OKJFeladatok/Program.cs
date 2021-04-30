using OKJFeladatok.Feladatok;
using System;

namespace OKJFeladatok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a feladat szamat: (pl.: 1, 2, 3): ");
            char szam = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.ReadKey();
            switch (szam)
            {
                default:
                    Console.WriteLine("Ilyen feladat nincs");
                    break;
                case '1':
                    Console.Clear();
                    PilotakFeladat.PilotakKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case '2':
                    Console.Clear();
                    OperatorokFeladat.OperatorKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case '3':
                    Console.Clear();
                    Kosar2004Feladat.KosarKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case '4':
                    Console.Clear();
                    BalkezesekFeladat.BalkezesekKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
            }
        }
    }
}
