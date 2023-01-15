using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNums
{
    class Program
    {
        static readonly List<int> primeNumbers = new();
        delegate int MyDel(string msg);

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("This application helps you to find prime numbers in a given interval.");

            PrimeCalculator();

            Console.WriteLine("Press ENTER to exit the application!");
            Console.ReadLine();
        }

        static void PrimeCalculator()
        {
            MyDel numReader = ReadNum;
            int a = numReader("1st");
            int b = numReader("2nd");

            if (a > b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }

            Console.Clear();
            Console.WriteLine($"Your selected interval was from {a} to {b}");
            FillList(a, b);

            primeNumbers.ForEach(x => Console.WriteLine(x));
        }

        static int ReadNum(string numName)
        {
            int num = 0;
            bool correctNum = false;
            while (!correctNum)
            {
                Console.Write($"Give {numName} positive integer number:");
                string tmp = Console.ReadLine();

                if (!int.TryParse(tmp, out _))
                {
                    Console.WriteLine("Please write in a number!");
                    continue;
                }

                if (int.Parse(tmp) < 0)
                {
                    Console.WriteLine("Please give a positive integer!");
                    continue;
                }

                correctNum = true;
                num = int.Parse(tmp);
            }

            return num;
        }

        static void FillList(int startNum, int endNum)
        {
            primeNumbers.Add(2);

            for (int numToCheck = 3; numToCheck < endNum; numToCheck++)
            {
                if (IsPrime(numToCheck)) primeNumbers.Add(numToCheck);
            }

            List<int> neededNums = primeNumbers.Where(x => x > startNum).ToList();
        }

        static bool IsPrime(int numToCheck)
        {
            foreach (int divider in primeNumbers)
            {
                if (divider * 2 > numToCheck) break;
                if (numToCheck % divider == 0) return false;
            }

            return true;
        }
    }
}