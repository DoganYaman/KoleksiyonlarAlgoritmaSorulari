using System;
using System.Collections;

namespace Koleksiyonlar_Soru_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList numberList = new();
            ArrayList smallestList = new();
            ArrayList biggestList = new();
            
            string inputText;
            int sayi =0;
            double avgSmallest = 0;
            double avgBiggest = 0;

            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0}. saıyı giriniz: ",i+1);
                inputText = Console.ReadLine();
                while(!int.TryParse(inputText,out sayi))
                {
                    Console.WriteLine("Girdiğiniz değer bir sayı değil !!!");
                    Console.Write("Lütfen numerik bir değer giriniz: ");
                    inputText = Console.ReadLine();
                } 
                numberList.Add(sayi);
            }

            smallestList = numberList.SmallestInList(3);
            biggestList = numberList.BiggestInList(3);
            avgSmallest = smallestList.AvgOfList();
            avgBiggest = biggestList.AvgOfList();

            Console.WriteLine("*** Listedeki En Küçük 3 Sayı ***");
            foreach (var item in smallestList)
                Console.Write(item+" ");
            Console.WriteLine();

            Console.WriteLine("*** Listedeki En Büyük 3 Sayı ***");
            foreach (var item in biggestList)
                Console.Write(item+" ");
            Console.WriteLine();

            Console.WriteLine("Küçük liste ortalaması: "+avgSmallest);
            Console.WriteLine("Büyük liste ortalaması: "+avgBiggest);
            Console.WriteLine("İki listenin ortalama toplamı: "+(avgSmallest+avgBiggest));

        }
    }
    static class CustomMethods
    {
        public static ArrayList BiggestInList(this ArrayList list, int count)
        {
            list.Sort();
            list.Reverse();
            ArrayList biggestList = new();
            for (int i = 0; i < count; i++)
            {
                biggestList.Add(list[i]);
            }

            return biggestList;
        }

        public static ArrayList SmallestInList(this ArrayList list, int count)
        {
            list.Sort();
            ArrayList smallestList = new();
            for (int i = 0; i < count; i++)
            {
                smallestList.Add(list[i]);
            }
            return smallestList;
        }

        public static double AvgOfList(this ArrayList list)
        {
            double sumList=0;
            double avgList=0;
            foreach (var item in list)
                sumList += Convert.ToDouble(item);
            avgList = sumList/list.Count;

            return Math.Round(avgList,2);
        }
    }
}
