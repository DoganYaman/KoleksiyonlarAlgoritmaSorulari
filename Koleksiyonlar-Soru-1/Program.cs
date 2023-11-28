using System;
using System.Collections;
using System.Linq.Expressions;

namespace Koleksiyonlar_Soru_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList primeNumberList = new();
            ArrayList NonPrimeNumberList = new();
            bool isNumber=true;
            bool isNegative=false;
            bool checkResult=true;
            string inputText;
            int number;
            int primeNumberCount=0;
            int NonPrimeNumberCount=0;
            double primeNumberSum=0;
            double NonPrimeNumberSum=0;
            double primeNumberAverage=0;
            double NonPrimeNumberAverage=0;
            
            Console.WriteLine("Lütfen 20 adet pozitif sayı giriniz.");
            
            for (int i = 0; i < 20; i++)
            {
                Console.Write("{0}. sayıyı giriniz: ",i+1);
                inputText = Console.ReadLine();

                checkResult = inputText.CheckNumericAndNegative(out isNumber, out isNegative);

                while(!checkResult)
                {
                    if(!isNumber)
                    {
                        Console.WriteLine("Girdiğiniz değer bir sayı değil !!!");
                        Console.Write("Lütfen numerik bir değer giriniz: ");
                    }
                    else if(isNegative)
                    {
                        Console.WriteLine("Girdiğiniz sayı negatif !!!");
                        Console.WriteLine("Lütfen pozitif bir değer giriniz: ");
                    }
                    inputText = Console.ReadLine();
                    checkResult = inputText.CheckNumericAndNegative(out isNumber, out isNegative);
                }
                
                number = int.Parse(inputText);

                if(number.IsPrimeNumber() && number!=0 && number!=1)
                {
                    primeNumberList.Add(number);
                    primeNumberSum += number;
                    primeNumberCount++;
                }
                else
                {
                    NonPrimeNumberList.Add(number);
                    NonPrimeNumberSum += number;
                    NonPrimeNumberCount++;
                }
            }

            primeNumberList.Sort();
            primeNumberList.Reverse();
            NonPrimeNumberList.Sort();
            NonPrimeNumberList.Reverse();
            primeNumberAverage = primeNumberSum / primeNumberCount;
            NonPrimeNumberAverage = NonPrimeNumberSum / NonPrimeNumberCount;

            Console.WriteLine("***** Asal Sayılar Listesi *****");
            foreach (int primeNumber in primeNumberList)
                Console.Write(primeNumber+ " ");
            Console.WriteLine();

            Console.WriteLine("***** Asal Olmayan Sayılar Listesi *****");
            foreach (int nonPrimeNumber in NonPrimeNumberList)
                Console.Write(nonPrimeNumber+ " ");
            Console.WriteLine();

            Console.WriteLine("Asal sayıların -> Adeti: " + primeNumberCount+", Ortalaması: "+Math.Round(primeNumberAverage,2));
            Console.WriteLine("Asal olmayan sayıların -> Adeti: " + NonPrimeNumberCount+", Ortalaması: "+Math.Round(NonPrimeNumberAverage,2));

            

        }
    }
    static class CustomExtensions
    {
        public static bool IsPrimeNumber(this int number)
        {
            bool stepCheck=true;
            for (int i = 2; i <= number/2; i++)
            {
                if(number%i==0)
                {
                    stepCheck=false;
                    break;
                }
            }
        
            return stepCheck;
        }

        public static bool IsNegative(this int number)
        {
            if(number<0)
                return true;
            else
                return false;
        }

        public static bool IsNumeric(this string param)
        {
            return int.TryParse(param, out _);
        }

        public static bool CheckNumericAndNegative(this string param, out bool isNumber, out bool isNegative)
        {
            int number;
            bool checkResult=true;
            isNumber=true;
            isNegative=false;
            if(!param.IsNumeric())
            {
                checkResult = false;
                isNumber=false;
            }
            else
            {
                number = int.Parse(param);

                if(number.IsNegative())
                {
                    checkResult = false;
                    isNegative=true;
                }
            }


            return checkResult;   
            
        }
    }
}
