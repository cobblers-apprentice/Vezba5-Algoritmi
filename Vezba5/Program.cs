using System;
using System.Diagnostics;
namespace Vezba5
{
    class Program
    {
        static void Main(string[] args)
        {
            Ispisi("Vezba 5 Algoritmi");
            Ispisi("Zadatak 1");

            // 1.Napisati metodu koja za zadati niz proverava da li postoji vrednost koja se ponavlja.
            // Testirati metodu nad nizom od 100 nasumičnih brojeva u rasponu između najmanjeg i
            // najvećeg integera.


            int brojac = 0, kucica = 0;
            Stopwatch vreme = new Stopwatch();

            vreme.Start();
            do
            {
                int[] nizZadatak1 = KreirajNiz(100);
                SortirajNizNajmanjiKaNajvecem(nizZadatak1);
                DaLiSeNekaVrednostPonavlja(nizZadatak1);
                brojac++;
                kucica = DaLiSeNekaVrednostPonavlja(nizZadatak1);

            } while (kucica != 1);
            Console.WriteLine($"Trebalo je {brojac} pokusaja da se ponove dva broja");
            vreme.Stop();
            Console.WriteLine("Proteklo milisekundi :" + vreme.ElapsedMilliseconds);
            Crta();

            Ispisi("Zadatak 2");

            // 2.Napisati program koji generiše 10000 različitih(ne smeju da se ponavljaju, nije bitan
            // raspon) nasumičnih brojeva, a zatim zamenjuje mesto najvećem i najmanjem članu.
            vreme.Reset();
            vreme.Start();

            int[] nizZadatak2 = KreirajNizBezPonavljanja(10000);
            NadjiMinIMaxIZameni(nizZadatak2);
            vreme.Stop();
            Console.WriteLine($"Proteklo milisekundi: {vreme.ElapsedMilliseconds}");
            
            Crta();

            Ispisi("Zadatak 3");

            // 3.Napisati program koji generiše 10000 nasumičnih brojeva između 0 i 5 i pomera sve 0 na
            // kraj niza.
            vreme.Restart();
            vreme.Start();
            int[] nizZadatak3 = GenerisiNasumicneBrojeveIzmedjuNulaIPet(10);
            PomeriNuleNaKrajNiza(nizZadatak3);
            vreme.Stop();
            Console.WriteLine($"Proteklo milisekundi: {vreme.ElapsedMilliseconds}");

            Crta();

            Ispisi("Zadatak 4");

            // 4.Generisati niz od 10000 nasumičnih brojeva sa vrednošću između 1 i 20.Izračunati
            // koliko puta se svaki broj od 1 do 20 pojavljuje u generisanom nizu.

            vreme.Restart();
            vreme.Start();
            int[] nizZadatak4 = GenerisiNizSaProizvoljnimRasponomVrednosti(10000, 1, 21);
            int[] nizZadatak4Jedan = KOlikoSePutaSvakiBrojPonavlja(nizZadatak4);
            for (int i = 1; i < nizZadatak4Jedan.Length; i++)
            {
                Console.WriteLine($"Broj {i} se pojavio: {nizZadatak4Jedan[i]} puta");
            }
            vreme.Stop();
            Console.WriteLine($"Proteklo milisekundi: {vreme.ElapsedMilliseconds}");


        }

        static int[] KOlikoSePutaSvakiBrojPonavlja (int[] a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if(max < a[i])
                {
                    max = a[i];
                }
            }
            max++;
            int[] b = new int[max];
            for (int i = 0; i < a.Length; i++)
            {
                b[a[i]]++;
            }
            return b;
        }
        static int[] GenerisiNizSaProizvoljnimRasponomVrednosti (int a, int x, int y)
        {
            Random rand = new Random();
            int[] b = new int[a];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = rand.Next(x, y);
            }
            return b;
        }
        static int[] GenerisiNasumicneBrojeveIzmedjuNulaIPet(int b)
        {
            Random rand = new Random();
            int[] a = new int[b];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0, 5);
            }
            return a;
        }
        static int[] PomeriNuleNaKrajNiza(int[] vs)
        {
            int a = vs.Length - 1;
            for (int i = 0; i < a; i++)
            {
                int b = 0;
                if (vs[i] == 0)
                {
                    b = vs[a];
                    vs[a] = vs[i];
                    vs[i] = b;
                    a--;
                }
            }
            return vs;
        }

        static void Ispisi(string a)
            {
                Console.WriteLine(a);
                // kako da napisem svoju metodu celu writeline? 
            }
            static int[] KreirajNiz(int a)
            {
                int[] b = new int[a];
                Random rand = new Random();

                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = rand.Next(1000);
                }
                return b;
            }
            static int[] SortirajNizNajmanjiKaNajvecem(int[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    int temp = 0;
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[i] > a[j])
                        {
                            temp = a[i];
                            a[i] = a[j];
                            a[j] = temp;
                        }
                    }
                }
                return a;
            }
            static int DaLiSeNekaVrednostPonavlja(int[] a)
            {
                
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[i] == a[j])
                        {
                            return 1;
                        }
                    }
                }
                return -1;
            }
            static void Crta()
        {
            Console.WriteLine("".PadRight(50, '_'));
        }
            
        static int[] KreirajNizBezPonavljanja(int a)
        {
            Random rand = new Random();
            int[] niz = new int[a];
            int kucica;
            for (int i = 0; i < niz.Length;)
            {
                kucica = rand.Next(1,10001);

                if (ProveriDaliJeIzvucenIsti(niz, kucica) < 0)
                {
                    niz[i] = kucica;
                    i++;
                }
            }
            return niz;
        }
        static int ProveriDaliJeIzvucenIsti(int[] a, int b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b)
                {
                    return 1;
                }
            }
            return -1;
        }
        static int[] NadjiMinIMaxIZameni (int[] vs)
        {
            int max = vs[0], min = vs[0], indexMin = 0, indexMax = 0;
            for (int i = 0; i < vs.Length; i++)
            {
                if (max < vs[i])
                {
                    max = vs[i];
                    indexMax = i;
                }
                if (min > vs[i])
                {
                    min = vs[i];
                    indexMin = i;
                }
            }
            vs[indexMin] = max;
            vs[indexMax] = min;
            return vs;
        }

    }
}

