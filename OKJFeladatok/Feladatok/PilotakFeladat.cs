using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKJFeladatok.Feladatok
{
    static class PilotakFeladat
    {
        static readonly List<Pilota> pilotak = new();
        public static bool PilotakKiir()
        {
            ReadCSV();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Console.WriteLine();
            Console.ReadKey();
            return true;
        }
        private static void ReadCSV()
        {
            using StreamReader reader = new("pilotak.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                pilotak.Add(new Pilota(reader.ReadLine()));
            }
            reader.Close();
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {pilotak.Count}");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"4. feladat: {pilotak.Last().Nev}");
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: ");
            pilotak.Where(x => x.SzulDatum < DateTime.Parse("1901.01.01")).ToList().ForEach(a => Console.WriteLine($"\t{a.Nev} ({a.SzulDatum.ToShortDateString()})"));
        }
        private static void Feladat6()
        {
            Console.WriteLine($"6. feladat: {pilotak.FindAll(b => b.Rajtszam > 0).OrderBy(a => a.Rajtszam).First().Nemzetiseg}");
        }
        private static void Feladat7()
        {
            Console.Write("7. feladat: ");
            pilotak.GroupBy(j => j.Rajtszam).Where(g => g.Count() > 1 && g.Key != 0).ToList().ForEach(a => Console.Write(a.Key + ", "));
        }
    }
    class Pilota
    {
        public string Nev { get; set; }
        public DateTime SzulDatum { get; set; }
        public string Nemzetiseg { get; set; }
        public int Rajtszam { get; set; }
        public Pilota(string sor)
        {
            string[] sa = sor.Split(';');
            Nev = sa[0];
            SzulDatum = DateTime.Parse(sa[1]);
            Nemzetiseg = sa[2];
            if (!string.IsNullOrEmpty(sa[3]))
            {
                Rajtszam = int.Parse(sa[3]);
            }
        }
    }
}
