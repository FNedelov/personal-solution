using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CallMethod();
            Console.WriteLine("Callmethod runs in background");
            Console.ReadKey();

        }

        public static async Task CallMethod()
        {
            List<Task<int>> tasksList = new();
            for (int i = 0; i < 9; i++)
            {
                tasksList.Add(Method1(i));
            }
            // Method2 runs parallel with Method1s.
            Method2();
            await Method1(1);
            Console.WriteLine("Finished single method1");
            // Code will stop here and wait until all Method1 are finished.
            int[] count = await Task.WhenAll(tasksList);
            Console.WriteLine("All Method1 finished!");

            // After await Method3 is called.
            Method3(count);
        }

        public static async Task<int> Method1(int num)
        {
            Console.WriteLine($"Task {num} started");
            await Task.Delay(num*1000);
            Console.WriteLine($"Task {num} finished");

            return num;
        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Method2 running in background");
            }
        }

        public static void Method3(int[] count)
        {
            Console.WriteLine("Return value of each method:");
            count.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
