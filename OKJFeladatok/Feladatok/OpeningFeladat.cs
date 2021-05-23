using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class OpeningFeladat
    {
        static readonly List<Film> filmek = new();
        public static bool OpeningKiir()
        {
            ReadData();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadData()
        {
            foreach (var item in File.ReadAllLines("opening.txt", Encoding.UTF8).Skip(1))
            {
                Film film = new(item);
                filmek.Add(film);
            }
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Filmek szama az allomanyban: {filmek.Count} db");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"4. feladat: UIP Duna Film forgalmazo 1. hetes bevetelenek osszege: {filmek.Where(x => x.Forgalmazo == "UIP").OrderBy(b => b.Bemutato).Select(y => y.Bevetel).Sum()} Ft");
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: Legtobb latogato az elso hetvegen: ");
            Console.WriteLine($"\tEredeti cim: {filmek.OrderByDescending(a => a.Latogato).First().EredetiCim}");
            Console.WriteLine($"\tMagyar cim: {filmek.OrderByDescending(a => a.Latogato).First().MagyarCim}");
            Console.WriteLine($"\tForgalmazo: {filmek.OrderByDescending(a => a.Latogato).First().Forgalmazo}");
            Console.WriteLine($"\tBevetel az elso heten: {filmek.OrderByDescending(a => a.Latogato).First().Bevetel} Ft");
            Console.WriteLine($"\tLatogatok szama: {filmek.OrderByDescending(a => a.Latogato).First().Latogato} fo");
        }
        private static void Feladat6()
        {
            Console.WriteLine($"6. feladat: {(filmek.All(a => a.EredetiCim.StartsWith("W") && a.MagyarCim.StartsWith("W")) ? "Ilyen film volt" : "Ilyen film nem volt")}");
        }
        private static void Feladat7()
        {
            using StreamWriter writer = new("stat.csv");
            writer.WriteLine("UIP" + ";" + filmek.Where(x => x.Forgalmazo == "UIP").Count());
            writer.WriteLine("Forum" + ";" + filmek.Where(x => x.Forgalmazo == "Forum").Count());
            writer.WriteLine("InterCom" + ";" + filmek.Where(x => x.Forgalmazo == "InterCom").Count());
            writer.WriteLine("Szinfolt film" + ";" + filmek.Where(x => x.Forgalmazo == "Szinfolt film").Count());
            writer.WriteLine("Big Bang Media" + ";" + filmek.Where(x => x.Forgalmazo == "Big Bang Media").Count());
            writer.WriteLine("MoziNet" + ";" + filmek.Where(x => x.Forgalmazo == "MoziNet").Count());
            writer.WriteLine("Vertigo" + ";" + filmek.Where(x => x.Forgalmazo == "Vertigo").Count());
            writer.WriteLine("Freeman" + ";" + filmek.Where(x => x.Forgalmazo == "Freeman").Count());
            writer.WriteLine("ADS" + ";" + filmek.Where(x => x.Forgalmazo == "ADS").Count());
            writer.Close();
        }
        private static void Feladat8()
        {
            /*DateTime filmegy = filmek.Where(a => a.Forgalmazo == "InterCom").ToList().Select(x => x.Bemutato).First();
            DateTime filketto = filmek.Where(a => a.Forgalmazo == "InterCom").ToList().Select(x => x.Bemutato).Last();
            filmek.Count((y => y.Bemutato == filmegy.Date));*/
            int leghosszabb = 0;
            for (int i = 0; i < filmek.Count - 1; i++)
            {
                if (filmek[i].Forgalmazo == "InterCom")
                {
                    if (int.Parse((filmek[i + 1].Bemutato.Day).ToString()) - int.Parse((filmek[i].Bemutato.Day).ToString()) > leghosszabb)
                    {
                        leghosszabb = int.Parse((filmek[i + 1].Bemutato.Day).ToString()) - int.Parse((filmek[i].Bemutato.Day).ToString());
                    }
                }
            }
            Console.WriteLine($"8. feladat: A leghosszabb idoszak ket InterCom-os bemutato kozott: {leghosszabb} nap");
        }
    }
    class Film
    {
        public string EredetiCim { get; set; }
        public string MagyarCim { get; set; }
        public DateTime Bemutato { get; set; }
        public string Forgalmazo { get; set; }
        public long Bevetel { get; set; }
        public int Latogato { get; set; }
        public Film(string sor)
        {
            string[] sa = sor.Split(';');
            EredetiCim = sa[0];
            MagyarCim = sa[1];
            Bemutato = DateTime.Parse(sa[2]);
            Forgalmazo = sa[3];
            Bevetel = long.Parse(sa[4]);
            Latogato = int.Parse(sa[5]);
        }
    }
}
