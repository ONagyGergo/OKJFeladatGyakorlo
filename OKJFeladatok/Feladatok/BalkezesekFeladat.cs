using System;
using System.Linq;
using OKJFeladatok.Properties;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class BalkezesekFeladat
    {
        static readonly List<Jatekos> jatekosok = new();
        public static bool BalkezesekKiir()
        {
            ReadCSV();
            Feladat3();
            Feladat4();
            Feladat5_6();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadCSV() => Resources.balkezesek.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => jatekosok.Add(new Jatekos(a)));
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {jatekosok.Count}");
        }
        private static void Feladat4()
        {
            Console.WriteLine("4. feladat: ");
            jatekosok.FindAll(a => a.UtolsoDatum < DateTime.Parse("1999.11") && a.UtolsoDatum > DateTime.Parse("1999.10")).ToList().ForEach(x => Console.WriteLine($"\t{x.Nev}, {Math.Round(x.Magassag * 2.54, 1)}"));
        }
        private static void Feladat5_6()
        {
            bool bennevan = false;
            int bevitt = 0;
            Console.WriteLine("5. feladat: ");
            Console.WriteLine("Kerek egy 1990 es 1999 kozotti evszamot: ");
            while (bennevan == false)
            {
                bevitt = int.Parse(Console.ReadLine());
                if (bevitt >= 1990 && bevitt <= 1999)
                {
                    bennevan = true;
                }
                else
                {
                    Console.WriteLine("Hibas adat");
                }
            }
            double osszSuly = 0;
            double darab = 0;
            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (bevitt >= jatekosok[i].ElsoDatum.Year && bevitt <= jatekosok[i].UtolsoDatum.Year)
                {
                    osszSuly += jatekosok[i].Suly;
                    darab++;
                }
            }
            double atlag = osszSuly / darab;
            Console.WriteLine($"6. feladat: {Math.Round(atlag, 2)} font");
        }
    }
    class Jatekos
    {
        public string Nev { get; set; }
        public DateTime ElsoDatum { get; set; }
        public DateTime UtolsoDatum { get; set; }
        public int Suly { get; set; }
        public double Magassag { get; set; }
        public Jatekos(string sor)
        {
            string[] sa = sor.Split(';');
            Nev = sa[0];
            ElsoDatum = DateTime.Parse(sa[1]);
            UtolsoDatum = DateTime.Parse(sa[2]);
            Suly = int.Parse(sa[3]);
            Magassag = double.Parse(sa[4]);
        }
    }
}
