using System;

namespace CustomEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new(new Random().Next(10));
            c.ThresholdReached += C_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }

            Console.ReadLine();
        }
        static void C_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Environment.Exit(0);
        }
    }
}