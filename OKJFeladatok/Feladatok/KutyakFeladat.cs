using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class KutyakFeladat
    {
        static readonly List<KutyaFajtak> kutyaFajtak = new();
        static readonly List<KutyaNevek> kutyaNevek = new();
        static readonly List<Kutyak> kutyak = new();
        public static bool KutyakKiiras()
        {
            ReadCSVs();
            Feladat3();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
            Feladat10();
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadCSVs()
        {
            foreach (var item in File.ReadAllLines("KutyaFajtak.csv", Encoding.UTF8).Skip(1))
            {
                KutyaFajtak kutya = new(item);
                kutyaFajtak.Add(kutya);
            }
            foreach (var item in File.ReadAllLines("KutyaNevek.csv", Encoding.UTF8).Skip(1))
            {
                KutyaNevek kutya = new(item);
                kutyaNevek.Add(kutya);
            }
            foreach (var item in File.ReadAllLines("Kutyak.csv", Encoding.UTF8).Skip(1))
            {
                Kutyak kutya = new(item);
                kutyak.Add(kutya);
            }
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladt: Kutyanevek szama: {kutyaNevek.Count}");
        }
        private static void Feladat6()
        {
            Console.WriteLine($"6. feladat: Kutyak atlag eletkora: {Math.Round(kutyak.Average(a => a.Kor), 2)}");
        }
        private static void Feladat7()
        {
            var kutya = kutyak.OrderByDescending(a => a.Kor).First();
            Console.WriteLine($"7. feladat: A legidosebb kutya neve es fajtaja: {kutyaNevek.Where(a => a.Azonosito == kutya.NevId).FirstOrDefault().Nev + ", " + kutyaFajtak.Where(x => x.Id == kutya.FajtaId).FirstOrDefault().Nev}");
        }
        private static void Feladat8()
        {
            Dictionary<string, int> fajtak = new();
            foreach (Kutyak kutya in kutyak)
            {
                if (kutya.OrvosiEll == DateTime.Parse("2018.01.10"))
                {
                    string key = kutyaFajtak.Where(a => a.Id == kutya.FajtaId).Single().Nev;
                    if (fajtak.ContainsKey(key))
                    {
                        fajtak[key]++;
                    }
                    else
                    {
                        fajtak.Add(key, 1);
                    }
                }
            }
            Console.WriteLine("8. feladat: Januar 10.-en vizsgalt kutya fajtak: ");
            foreach (var item in fajtak)
            {
                Console.WriteLine($"\t{item.Key}: {item.Value} kutya");
            }
        }
        private static void Feladat9()
        {
            Dictionary<string, int> napok = new();
            foreach (Kutyak kutya in kutyak)
            {
                string key = kutya.OrvosiEll.ToString("yyyy-MM-dd");
                if (napok.ContainsKey(key))
                {
                    napok[key]++;
                }
                else
                {
                    napok.Add(key, 1);
                }
            }
            Console.WriteLine($"9. feladat: Legjobban leterhelt nap: {napok.FirstOrDefault(x => x.Value == napok.Values.Max()).Key + ": " + napok.Values.Max()} kutya");
        }
        private static void Feladat10()
        {
            using StreamWriter writer = new("NevStatisztika.txt", false, Encoding.UTF8);
            Dictionary<string, int> nevek = new();
            foreach (Kutyak kutya in kutyak)
            {
                string key = kutyaNevek.Where(a => a.Azonosito == kutya.NevId).Single().Nev;
                if (nevek.ContainsKey(key))
                {
                    nevek[key]++;
                }
                else
                {
                    nevek.Add(key, 1);
                }
            }
            var sortedNevek = from entry in nevek orderby entry.Value descending select entry;
            foreach (var item in sortedNevek)
            {
                writer.WriteLine(item.Key + ";" + item.Value);
            }
            Console.WriteLine("10. feladat: NevStatisztika.txt");
        }
    }
    class KutyaFajtak
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string EredetiNev { get; set; }
        public KutyaFajtak(string sor)
        {
            string[] sa = sor.Split(';');
            Id = int.Parse(sa[0]);
            Nev = sa[1];
            EredetiNev = sa[2];
        }
    }
    class KutyaNevek
    {
        public int Azonosito { get; set; }
        public string Nev { get; set; }
        public KutyaNevek(string sor)
        {
            string[] sa = sor.Split(';');
            Azonosito = int.Parse(sa[0]);
            Nev = sa[1];
        }
    }
    class Kutyak
    {
        public int VizsgazoId { get; set; }
        public int FajtaId { get; set; }
        public int NevId { get; set; }
        public double Kor { get; set; }
        public DateTime OrvosiEll { get; set; }
        public Kutyak(string sor)
        {
            string[] sa = sor.Split(';');
            VizsgazoId = int.Parse(sa[0]);
            FajtaId = int.Parse(sa[1]);
            NevId = int.Parse(sa[2]);
            Kor = double.Parse(sa[3]);
            OrvosiEll = DateTime.Parse(sa[4]);
        }
    }
}
