using OKJFeladatok.Feladatok;
using System;

namespace OKJFeladatok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a feladat szamat: (pl.: 1, 2, 3, 4): ");
            string bevitt = Console.ReadLine();            
            Console.WriteLine();
            switch (bevitt)
            {
                default:
                    Console.WriteLine("Ilyen feladat nincs");
                    break;
                case "1":
                    Console.Clear();
                    AdoFeladat.AdoKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "2":
                    Console.Clear();
                    BalkezesekFeladat.BalkezesekKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "3":
                    Console.Clear();
                    FuvarFeladat.FuvarKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "4":
                    Console.Clear();
                    KemiaFeladat.KemiaKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "5":
                    Console.Clear();
                    Kosar2004Feladat.KosarKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "6":
                    Console.Clear();
                    KutyakFeladat.KutyakKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "7":
                    Console.Clear();
                    OpeningFeladat.OpeningKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "8":
                    Console.Clear();
                    OperatorokFeladat.OperatorKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "9":
                    Console.Clear();
                    PilotakFeladat.PilotakKiir();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
                case "10":
                    Console.Clear();
                    TelekocsiFeladat.TelekocsiKiiras();
                    if (true)
                    {
                        Console.WriteLine("Feladat vege. Press enter to continue.");
                    }
                    break;
            }
        }
    }
}
