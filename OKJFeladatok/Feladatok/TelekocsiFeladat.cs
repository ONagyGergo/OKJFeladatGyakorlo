using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    public class TelekocsiFeladat
    {
        static readonly List<Auto> autok = new();
        static readonly List<Igeny> igenyek = new();
        public static bool TelekocsiKiiras()
        {
            ReadAutokCSV();
            Feladat2();
            Feladat3();
            Feladat4();
            ReadIgenyekCSV();
            Feladat5();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadAutokCSV()
        {
            using StreamReader reader = new("autok.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                autok.Add(new Auto(reader.ReadLine()));
            }
            reader.Close();
        }
        private static void ReadIgenyekCSV()
        {
            using StreamReader reader = new("igenyek.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                igenyek.Add(new Igeny(reader.ReadLine()));
            }
            reader.Close();
        }
        private static void Feladat2()
        {
            Console.WriteLine("2. feladat: ");
            Console.WriteLine($"{autok.Count} autos hirdetett fuvart");
        }
        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: ");
            Console.WriteLine($"Osszesen {autok.Where(a => a.Indulas.Contains("Budapest") && a.Cel.Contains("Miskolc")).Count()} ferohelyet hirdettek az autosok Budapestrol Miskolcra");
        }
        private static void Feladat4()
        {
            Console.WriteLine("4. feladat: ");
            Console.WriteLine($"A legtobb ferohelyet ({autok.OrderBy(x => x.Ferohely).Last().Ferohely}db) " + $"{autok.OrderBy(x => x.Ferohely).Last().Indulas}" + $" - {autok.OrderBy(x => x.Ferohely).Last().Cel} utvonalon ajanlottak fel a hirdetok");
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: ");
            string fero = autok.Sum(a => a.Ferohely).ToString();
            string szemely = igenyek.Sum(x => x.Szemelyek).ToString();
            Console.WriteLine(fero + ", " + szemely);
        }
    }
    class Auto
    {
        public string Indulas { get; set; }
        public string Cel { get; set; }
        public string Rendszam { get; set; }
        public string Telefonszam { get; set; }
        public int Ferohely { get; set; }
        public Auto(string sor)
        {
            string[] sa = sor.Split(";");
            Indulas = sa[0];
            Cel = sa[1];
            Rendszam = sa[2];
            Telefonszam = sa[3];
            Ferohely = int.Parse(sa[4]);
        }
    }
    class Igeny
    {
        public string Azonosito { get; set; }
        public string Indulas { get; set; }
        public string Cel { get; set; }
        public int Szemelyek { get; set; }
        public Igeny(string sor)
        {
            string[] sa = sor.Split(";");
            Azonosito = sa[0];
            Indulas = sa[1];
            Cel = sa[2];
            Szemelyek = int.Parse(sa[3]);
        }
    }
}