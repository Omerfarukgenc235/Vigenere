using System;
using System.Collections.Generic;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
            string kelime;
            Console.WriteLine("Lütfen bir anahtar kelime giriniz");
            kelime = Console.ReadLine();
            kelime = kelime.ToUpper();
            char[] kelimeler = kelime.ToCharArray();

            List<char> dogrukarakterler = new List<char>();
            List<int> dogrukarakterlerdegerleri = new List<int>();
            int deger2 = 0;
            foreach (var y in kelimeler)
            {
                foreach (var x in alfabe)
                {
                    if (x == y)
                    {
                        dogrukarakterler.Add(x);
                        dogrukarakterlerdegerleri.Add(deger2);
                    }
                    deger2++;
                }
                deger2 = 0;
            }
            int kelimeuzunlugu = dogrukarakterler.Count;

            string kelime2;
            Console.WriteLine("Lütfen bir kelime giriniz");
            kelime2 = Console.ReadLine();
            kelime2 = kelime2.ToUpper();
            char[] kelimeler2 = kelime2.ToCharArray();
            List<char> dogrukarakterler2 = new List<char>();
            List<int> dogrukarakterler2degerleri = new List<int>();
            int deger = 0;
            foreach (var y in kelimeler2)
            {
                foreach (var x in alfabe)
                {
                    if (x == y)
                    {
                        dogrukarakterler2.Add(x);
                        dogrukarakterler2degerleri.Add(deger);
                    }
                    deger++;
                }
                deger = 0;
            }
            int sifrelenecekkelimeuzunlugu = dogrukarakterler2.Count;

            if (sifrelenecekkelimeuzunlugu % kelimeuzunlugu != 0)
            {
                for (int i = 0; i < (kelimeuzunlugu - (sifrelenecekkelimeuzunlugu % kelimeuzunlugu)); i++)
                {
                    dogrukarakterler2.Add('A');
                    dogrukarakterler2degerleri.Add(0);
                }
            }
            int sondeger = 0;
            List<int> sondegerlericin = new List<int>();
            int degercik = dogrukarakterler2degerleri.Count;
            int atama = 0;
            for (int i = 0; i < degercik; i++)
            {
                atama = Mod((dogrukarakterler2degerleri[i] + dogrukarakterlerdegerleri[sondeger]),29);
                sondegerlericin.Add(atama);        
                sondeger++;

                if(sondeger == kelimeuzunlugu)
                {
                    sondeger = 0;
                }
            }
            int Mod(int modalinacaksayi, int boluneceksayi)
            {

                while (modalinacaksayi >= boluneceksayi)
                {
                    modalinacaksayi = modalinacaksayi - boluneceksayi;
                }
                while (modalinacaksayi < 0)
                {
                    modalinacaksayi = modalinacaksayi + boluneceksayi;
                }
                return modalinacaksayi;
            }
            Console.WriteLine();
            Console.Write("Vigenere Algoritmasına Göre Şifrelenmiş Hali = ");
            foreach (var z in sondegerlericin)
            {
                Console.Write(alfabe[z]);
            }

            int degercik2 = sondegerlericin.Count;
            List<int> sondegerlericin2 = new List<int>();

            int atama2 = 0;
            int sondeger2 = 0;
            for (int i = 0; i < degercik2; i++)
            {
                atama2 = Mod((sondegerlericin[i] - dogrukarakterlerdegerleri[sondeger2]), 29);
                sondegerlericin2.Add(atama2);
                sondeger2++;

                if (sondeger2 == kelimeuzunlugu)
                {
                    sondeger2 = 0;
                }
            }
            Console.WriteLine();
            Console.Write("Vigenere Algoritmasına Göre Çözülmüş Hali = ");
            foreach(var x in sondegerlericin2)
            {
                Console.Write(alfabe[x]);
            }
        }
     
    }
}
