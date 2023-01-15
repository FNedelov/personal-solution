using System;

namespace DictionaryFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            DictClass dCl = new();

            int num = 4;
            if (dCl.DictFunction.ContainsKey(num))
            {

                Console.WriteLine(dCl.DictFunction[num]());
            }
            dCl.DictAction[1]();

            Console.ReadLine();
        }
    }
}