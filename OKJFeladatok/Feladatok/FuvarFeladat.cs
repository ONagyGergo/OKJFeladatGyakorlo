using System;
using System.IO;
using System.Linq;
using System.Text;
using OKJFeladatok.Properties;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class FuvarFeladat
    {
        static readonly List<Taxi> taxik = new();
        public static bool FuvarKiiras()
        {
            ReadCSV();
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
        private static void ReadCSV() => Resources.fuvar.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList().ForEach(a => taxik.Add(new Taxi(a)));
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: {taxik.Count}");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"4. feladat: {taxik.Count(a => a.Taxi_Id == 6185)} fuvar alatt: {taxik.Where(a => a.Taxi_Id == 6185).Sum(x => x.Viteldij)}$");
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: ");
            taxik.GroupBy(a => a.Fizetes_Modja).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()}"));
        }
        private static void Feladat6()
        {
            Console.WriteLine($"6. feladat: {Math.Round(taxik.Sum(a => a.Tavolsag * 1.6), 2)} km");
        }
        private static void Feladat7()
        {
            Console.WriteLine("7. feladat: Leghosszabb fuvar: ");
            Console.WriteLine($"\tFuvar hossza: {taxik.OrderBy(a => a.Idotartam).Last().Idotartam} masodperc");
            Console.WriteLine($"\tTaxi azonositoja: {taxik.OrderBy(a => a.Idotartam).Last().Taxi_Id}");
            Console.WriteLine($"\tMegtett tavolsag: {taxik.OrderBy(a => a.Idotartam).Last().Tavolsag} km");
            Console.WriteLine($"\tViteldij: {taxik.OrderBy(a => a.Idotartam).Last().Viteldij} $");
        }
        private static void Feladat8()
        {
            List<Taxi> hibak = taxik.OrderBy(x => x.Indulas).ToList();
            StreamWriter writer = new("hibak.txt", false, Encoding.UTF8);
            writer.WriteLine("taxi_id;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            for (int i = 2; i < hibak.Count; i++)
            {
                if (hibak[i].Tavolsag == 0 && (hibak[i].Idotartam > 0 || hibak[i].Viteldij > 0))
                {
                    writer.Write(hibak[i].Taxi_Id + ";");
                    writer.Write(hibak[i].Indulas + ";");
                    writer.Write(hibak[i].Tavolsag + ";");
                    writer.Write(hibak[i].Viteldij + ";");
                    writer.Write(hibak[i].Borravalo + ";");
                    writer.Write(hibak[i].Fizetes_Modja + ";");
                    writer.Write("\n");
                }
            }
            writer.Close();
            Console.WriteLine("8. feladat: hibak.txt");
        }
    }
    class Taxi
    {
        public int Taxi_Id { get; set; }
        public DateTime Indulas { get; set; }
        public int Idotartam { get; set; }
        public double Tavolsag { get; set; }
        public double Viteldij { get; set; }
        public double Borravalo { get; set; }
        public string Fizetes_Modja { get; set; }
        public Taxi(string sor)
        {
            string[] sa = sor.Split(';');
            Taxi_Id = int.Parse(sa[0]);
            Indulas = DateTime.Parse(sa[1]);
            Idotartam = int.Parse(sa[2]);
            Tavolsag = double.Parse(sa[3]);
            Viteldij = double.Parse(sa[4]);
            Borravalo = double.Parse(sa[5]);
            Fizetes_Modja = sa[6];
        }
    }
}
