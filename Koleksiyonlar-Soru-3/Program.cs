using System;
using System.Collections.Generic;

namespace Koleksiyonlar_Soru_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir cümle giriniz: ");
            string sentence = Console.ReadLine();
            string vowelsString = "";
            char[] vowelsArr;
            for (int i=0;i<sentence.Length;i++)
            {
                switch (sentence[i])
                {
                    case 'A':
                    case 'a':
                    case 'E':
                    case 'e':
                    case 'I':
                    case 'ı':
                    case 'İ':
                    case 'i':
                    case 'O':
                    case 'o':
                    case 'Ö':
                    case 'ö':
                    case 'Ü':
                    case 'ü':
                        vowelsString+=sentence[i];
                        break;
                }
            }
            vowelsArr = vowelsString.ToCharArray();
            Array.Sort(vowelsArr);
            Console.WriteLine("***** Cümle içerisindeki Sesli Harfler *****");
            foreach (var item in vowelsArr)
                Console.Write(item+" ");
        }
    }
}
