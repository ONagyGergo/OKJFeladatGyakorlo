using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OKJFeladatok.Feladatok
{
    static class KemiaFeladat
    {
        static readonly List<Elem> elemek = new();
        public static bool KemiaKiir()
        {
            ReadCSV();
            Feladat3();
            Feladat4();
            string Vegyjel = Feladat5();
            Feladat6(Vegyjel);
            Feladat7();
            Feladat8();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadCSV()
        {
            foreach (var item in File.ReadAllLines("kemia.csv", Encoding.UTF8).Skip(1))
            {
                Elem elem = new(item);
                elemek.Add(elem);
            }
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Elemek szama: {elemek.Count}");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"4. feladat: {elemek.Count(a => a.Ev.Contains("Okor"))}");
        }
        private static string Feladat5()
        {
            string pattern = @"^[a-zA-Z]+$";
            Regex regex = new(pattern);
            Match match;
            string vegyjel;
            Console.Write("5. feladat: Kerek egy vegyjelet: ");
            vegyjel = Console.ReadLine();
            do
            {
                match = regex.Match(vegyjel);
            } while (!(vegyjel.Length == 1 || vegyjel.Length == 2) && match.Success);
            return vegyjel;
        }
        private static void Feladat6(string vegyjel)
        {
            Console.WriteLine("6. feladat: Kereses: ");
            bool vanevegyjel = false;
            for (int i = 0; i < elemek.Count; i++)
            {
                if (elemek[i].Vegyjel.ToUpper() == vegyjel.ToUpper())
                {
                    vanevegyjel = true;
                    Console.WriteLine($"\tAz elem vegyjele: {elemek[i].Vegyjel}");
                    Console.WriteLine($"\tAz elem neve: {elemek[i].Nev}");
                    Console.WriteLine($"\tRendszama: {elemek[i].Rendszam}");
                    Console.WriteLine($"\tFelfedezes eve: {elemek[i].Ev}");
                    Console.WriteLine($"\tFelfedezo: {elemek[i].Felfedezo}");
                }
            }
            if (vanevegyjel == false)
            {
                Console.WriteLine("Nincs ilyen kifejezes");
            }

        }
        private static void Feladat7()
        {
            int leghosszabb = 0;
            for (int i = 0; i < elemek.Count - 1; i++)
            {
                if (elemek[i].Ev != "Okor")
                {
                    if (int.Parse(elemek[i + 1].Ev) - int.Parse(elemek[i].Ev) > leghosszabb)
                    {
                        leghosszabb = int.Parse(elemek[i + 1].Ev) - int.Parse(elemek[i].Ev);
                    }
                }
            }
            Console.WriteLine($"7. feladat: {leghosszabb} ev volt a leghosszabb idoszak ket elem felfedezese kozott");
        }
        private static void Feladat8()
        {
            Console.WriteLine("8. feladat: Statisztika: ");
            elemek.GroupBy(j => j.Ev).Where(g => g.Count() > 3 && g.Key != "Okor").ToList().ForEach(a => Console.WriteLine($"\t{a.Key}: {a.Count()} db"));
        }
    }
    class Elem
    {
        public string Ev { get; set; }
        public string Nev { get; set; }
        public string Vegyjel { get; set; }
        public int Rendszam { get; set; }
        public string Felfedezo { get; set; }
        public Elem(string sor)
        {
            string[] sa = sor.Split(';');
            Ev = sa[0];
            Nev = sa[1];
            Vegyjel = sa[2];
            Rendszam = int.Parse(sa[3]);
            Felfedezo = sa[4];
        }
    }
}
