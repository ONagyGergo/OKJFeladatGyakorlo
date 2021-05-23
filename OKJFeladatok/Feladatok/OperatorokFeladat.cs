using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OKJFeladatok.Feladatok
{
    static class OperatorokFeladat
    {
        static readonly List<Kifejezes> kifejezesek = new();
        public static bool OperatorKiir()
        {
            ReadData();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat7();
            Feladat8(); 
            Console.WriteLine();
            Console.ReadLine();
            return true;
        }
        private static void ReadData()
        {
            foreach (var item in File.ReadAllLines("operatorok.txt", Encoding.UTF8))
            {
                Kifejezes kifejezes = new(item);
                kifejezesek.Add(kifejezes);
            }
        }
        private static void Feladat2()
        {
            Console.WriteLine($"2. feladat: Kifejezese szama: {kifejezesek.Count}");
        }
        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Kifejezesek maradekos osztassal: {kifejezesek.Count(a => a.Operator == "mod")}");
        }
        private static void Feladat4()
        {
            Console.WriteLine($"3. feladat: {(kifejezesek.FirstOrDefault(a => a.ElsoOperandus % 10 == 0 && a.MasodikOperandus % 10 == 0) != null ? "Van ilyen kifejezes" : "Nincs ilyen kifejezes")}");
        }
        private static void Feladat5()
        {
            Console.WriteLine("5. feladat: ");
            Console.WriteLine($"\tmod -> {kifejezesek.Count(o => o.Operator == "mod")}");
            Console.WriteLine($"\t/   -> {kifejezesek.Count(o => o.Operator == "/")}");
            Console.WriteLine($"\tdiv -> {kifejezesek.Count(o => o.Operator == "div")}");
            Console.WriteLine($"\t-   -> {kifejezesek.Count(o => o.Operator == "-")}");
            Console.WriteLine($"\t*   -> {kifejezesek.Count(o => o.Operator == "*")}");
            Console.WriteLine($"\t+   -> {kifejezesek.Count(o => o.Operator == "+")}");
        }
        private static string Feladat6(string beolvasott)
        {
            if (beolvasott.Equals("vege"))
            {
                return "vege";
            }
            string[] darab = beolvasott.Split(' ');
            string adat = darab[0] + " " + darab[1] + " " + darab[2];
            string visszater;
            try
            {
                switch (darab[1])
                {
                    default:
                        return ($"{darab} = Hibas operator");
                    case "mod":
                        visszater = adat + " = " + (int.Parse(darab[0]) % int.Parse(darab[2]));
                        break;
                    case "div":
                        visszater = adat + " = " + (int.Parse(darab[0]) / int.Parse(darab[2]));
                        break;
                    case "/":
                        visszater = adat + " = " + (int.Parse(darab[0]) / double.Parse(darab[2]));
                        break;
                    case "-":
                        visszater = adat + " = " + (int.Parse(darab[0]) - int.Parse(darab[2]));
                        break;
                    case "*":
                        visszater = adat + " = " + (int.Parse(darab[0]) * int.Parse(darab[2]));
                        break;
                    case "+":
                        visszater = adat + " = " + (int.Parse(darab[0]) + int.Parse(darab[2]));
                        break;
                }
            }
            catch (Exception)
            {
                return ($"{adat} = egyeb hiba");
            }
            return visszater;
        }
        private static void Feladat7()
        {
            string beolvasott = "";
            while (!beolvasott.Equals("vege"))
            {
                Console.WriteLine("7. feladat: Kerek egy kifejezest: ");
                beolvasott = Console.ReadLine();
                if (Feladat6(beolvasott).Equals("vege"))
                {
                    beolvasott = Feladat6(beolvasott);
                }
                else
                {
                    Console.WriteLine(Feladat6(beolvasott) + "\n");
                }
            }
        }
        private static void Feladat8()
        {
            using StreamWriter writer = new("eredmenyek.txt");
            string beir = "";
            foreach (Kifejezes item in kifejezesek)
            {
                beir = item.ElsoOperandus + " " + item.Operator + " " + item.MasodikOperandus;
                writer.Write($"{Feladat6(beir)} \t");
            }
            writer.Close();
            Console.WriteLine("8. feladat: eredmenyek.txt");
        }
    }
    class Kifejezes
    {
        public int ElsoOperandus { get; set; }
        public string Operator { get; set; }
        public int MasodikOperandus { get; set; }
        public Kifejezes(string sor)
        {
            string[] sa = sor.Split(' ');
            ElsoOperandus = int.Parse(sa[0]);
            Operator = sa[1];
            MasodikOperandus = int.Parse(sa[2]);
        }
    }
}
