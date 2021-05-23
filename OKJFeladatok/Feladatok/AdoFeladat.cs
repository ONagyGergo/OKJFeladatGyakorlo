using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class AdoFeladat
    {
        static readonly List<Adat> adatok = new();
        public static bool AdoKiiras()
        {
            ReadCSV();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadCSV()
        {
            foreach (var item in File.ReadAllLines("ado.csv", Encoding.UTF8).Skip(1))
            {
                Adat adat = new(item);
                adatok.Add(adat);
            }
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {adatok.Count}");
        }
        private static void Feladat4()
        {
            Console.Write("4. feladat: Kerek egy honapot: ");
            int honap = int.Parse(Console.ReadLine());
            if (honap < 1 || honap > 12)
            {
                Console.WriteLine("4. feladat: nincs ilyen honap");
            }
            else
            {
                int osszeg = 0;
                foreach (Adat item in adatok)
                {
                    if (item.Honap == honap)
                    {
                        osszeg += item.Ado;
                    }
                }
                Console.WriteLine($"4. feladat: {honap}. honap bevetele: {osszeg} petak");
            }
        }
        private static void Feladat5()
        {
            Console.WriteLine($"5. feladat: a legnagyobb adobevetel egyetlen ingatlan utan a {adatok.Where(a => a.Ev == 2).OrderByDescending(x => x.Ado).First().Honap}. honapban volt");
        }
        private static void Feladat6()
        {
            using StreamWriter writer = new("ado2.html", false, Encoding.UTF8);
            writer.WriteLine("<table>");
            foreach (Adat item in adatok)
            {
                writer.WriteLine(item.ToHTML());
            }
            writer.WriteLine("</table>");
            Console.WriteLine("6. feladat: ado2.html");
        }
    }
    class Adat
    {
        public int Ev { get; set; }
        public int Honap { get; set; }
        public int Alapterulet { get; set; }
        public string Telepules { get; set; }
        public string KomfortFokozat { get; set; }
        public int Ado { get; set; }
        public Adat(string sor)
        {
            string[] sa = sor.Split(';');
            Ev = int.Parse(sa[0]);
            Honap = int.Parse(sa[1]);
            Alapterulet = int.Parse(sa[2]);
            Telepules = sa[3];
            KomfortFokozat = sa[4];
            Ado = int.Parse(sa[5]);
        }
        public string ToHTML()
        {
            return $"<tr><td>{Ev}</td><td>{Honap}</td><td>{Alapterulet}</td><td>{Telepules}</td><td>{KomfortFokozat}</td><td>{Ado}</td></tr>";
        }
    }
}