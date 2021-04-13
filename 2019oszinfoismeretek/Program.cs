using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2019oszinfoismeretek
{
    class Beolvas
    {
        public int ora;
        public int perc;
        public int adasdb;
        public string nev;
        public Beolvas(string sor)
        {
            string[] bonto = sor.Split(';');
            ora = Convert.ToInt32(bonto[0]);
            perc = Convert.ToInt32(bonto[1]);
            adasdb = Convert.ToInt32(bonto[2]);
            nev = bonto[3];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Beolvas> lista = new List<Beolvas>();   
            foreach(var i in File.ReadLines("cb.txt").Skip(1))
            {
                lista.Add(new Beolvas(i));
            }
            // 3. feladat
            Console.WriteLine($"3. feladat: Bejegyzések száma: {lista.Count} db");
            // 4. feladat
            foreach(var i in lista)
            {
                if(i.adasdb == 4)
                {
                    Console.WriteLine("Volt négy adást indító sofőr.");
                    break;
                }
            }

            // 5. feladat
            Console.WriteLine("5. feladat: Kérek egy nevet: ");
            string nevbeker = Console.ReadLine();
            int radiocnt = 0;
            foreach(var i in lista)
            {
                if(i.nev == nevbeker)
                {
                    radiocnt += i.adasdb;
                }
            }
            if(radiocnt == 0)
            {
                Console.WriteLine("Nincs ilyen nevű sofőr!");
            }
            else {Console.WriteLine($"\t{nevbeker} {radiocnt}x használta a CB-rádiót.");}

            // 6. feladat
            static int AtszamolPercre(int ora, int perc)
            {
                int percek = 0;
                percek = ora * 60 + perc;
                return percek;
            }
            // 7. feladat
            StreamWriter stream = new StreamWriter("cb2.txt");
            stream.WriteLine("Kezdes;Nev;AdasDb");
            foreach(var i in lista)
            {
                stream.WriteLine($"{AtszamolPercre(i.ora, i.perc)};{i.nev};{i.adasdb}");
            }
            // 8. feladat
            List<string> segit = new List<string>();
            foreach(var i in lista)
            {
                if (!segit.Contains(i.nev))
                {
                    segit.Add(i.nev);
                }
            }
            Console.WriteLine($"8. feladat: Sofőrök száma: {segit.Count} fő");

            // 9. feladat
            int maxadas = 0;
            string maxadasnev = "";
            foreach (var i in segit)
            {
                int adasperfo = 0;
                foreach (var j in lista)
                {
                    if(i == j.nev)
                    {
                        adasperfo += j.adasdb;
                    }
                    if (adasperfo > maxadas)
                    {
                        maxadas = adasperfo;
                        maxadasnev = j.nev;
                    }
                }
            }
            Console.WriteLine($"9. feladat: Legtöbb adást indító sofőr\n\tNév: {maxadasnev}\n\tAdások száma: {maxadas} alkalom");
        }
    }
}
