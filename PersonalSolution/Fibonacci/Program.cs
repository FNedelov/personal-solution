using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        static readonly List<int> fibonacciNumsList = new();
        static void Main(string[] args)
        {
            FibnacciNumCalc(10);
            Console.ReadLine();
        }

        private static void FibnacciNumCalc(int count)
        {
            fibonacciNumsList.AddRange(new List<int> { 0, 1 });

            for (int i = 0; i < count; i++)
            {
                int listLength = fibonacciNumsList.Count;
                fibonacciNumsList.Add(fibonacciNumsList[listLength - 1] + fibonacciNumsList[listLength - 2]);
            }
        }
    }
}