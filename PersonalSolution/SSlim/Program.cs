using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SSlim
{
    class Program
    {
        static readonly int taskNum = 5;
        private static readonly SemaphoreSlim semaphore = new(2);

        static readonly Dictionary<string, Action> intervallListDict = new()
        {
            {"8 óra", () => StartEndTCalc(8, true)},
            {"1 nap", () => StartEndTCalc(24, true)},
            {"2 nap", () => StartEndTCalc(48, true)},
            {"1 hét", () => StartEndTCalc(168, true)},
            {"Havi", () => StartEndTCalc(1, false)},
            {"Féléves", () => StartEndTCalc(6, false)}
        };

        static void Main(string[] args)
        {
            intervallListDict["8 óra"]();

            Console.WriteLine($"{semaphore.CurrentCount} tasks can enter semaphore.");

            Task[] tasks = new Task[taskNum];
            for (int i = 0; i < taskNum; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    // Each task begins by requesting the semaphore.
                    Console.WriteLine($"Task {Task.CurrentId} begins and waits for semaphore.");
                    int semaphoreCount;
                    semaphore.Wait();
                    try
                    {
                        Console.WriteLine($"Task {Task.CurrentId} enters semaphore.");
                        // The task just sleeps for 1+ seconds.
                        Thread.Sleep(2000);
                        Console.WriteLine($"Task {Task.CurrentId} finished");
                    }
                    finally
                    {
                        semaphoreCount = semaphore.Release();
                        Console.WriteLine($"Task {Task.CurrentId} releases semaphore; previous count: {semaphoreCount}.");
                    }
                });
            }
            // Wait for half a second, to allow all the tasks to start and block.
            Thread.Sleep(500);
 
            Task.WaitAll(tasks);
            Console.WriteLine(semaphore.CurrentCount);
            Console.WriteLine("Main thread exits.");
            Console.ReadLine();
        }

        static int StartEndTCalc(int selectedTSpan, bool isHours)
        {
            Console.WriteLine($"Selected tSpan: {selectedTSpan}. Is hours: {isHours}");
            return 5;
        }
    }
}
