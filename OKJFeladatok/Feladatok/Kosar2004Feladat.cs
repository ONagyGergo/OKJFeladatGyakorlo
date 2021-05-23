using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class Kosar2004Feladat
    {
        static readonly List<Eredmeny> eredmenyek = new();
        public static bool KosarKiiras()
        {
            ReadCSV();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadCSV()
        {
            foreach (var item in File.ReadAllLines("kosar.csv", Encoding.UTF8).Skip(1))
            {
                Eredmeny eredmeny = new(item);
                eredmenyek.Add(eredmeny);
            }
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {eredmenyek.Count(a => a.Hazai.Contains("Real Madrid"))}, Idegen: {eredmenyek.Count(a => a.Idegen.Contains("Real Madrid"))} ");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"4. feladat: Volt dontetlen? {(eredmenyek.All(a => a.HazaiPont == a.IdegenPont) ? "igen" : "Nem")}");
        }
        private static void Feladat5()
        {
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {eredmenyek.Where(a => a.Hazai.Contains("Barcelona")).FirstOrDefault().Hazai}");
        }
        private static void Feladat6()
        {
            Console.WriteLine("6. feladat: ");
            eredmenyek.Where(a => a.Idopont == DateTime.Parse("2004.11.21")).ToList().ForEach(x => Console.WriteLine($"\t{x.Hazai} - {x.Idegen} ({x.HazaiPont}:{x.IdegenPont})"));
        }
        private static void Feladat7()
        {
            Console.WriteLine("7. feladat: ");
            eredmenyek.GroupBy(a => a.Helyszin).Where(y => y.Count() > 20).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));
        }
    }
    class Eredmeny
    {
        public string Hazai { get; set; }
        public string Idegen { get; set; }
        public int HazaiPont { get; set; }
        public int IdegenPont { get; set; }
        public string Helyszin { get; set; }
        public DateTime Idopont { get; set; }
        public Eredmeny(string sor)
        {
            string[] sa = sor.Split(';');
            Hazai = sa[0];
            Idegen = sa[1];
            HazaiPont = int.Parse(sa[2]);
            IdegenPont = int.Parse(sa[3]);
            Helyszin = sa[4];
            Idopont = DateTime.Parse(sa[5]);
        }
    }
}
