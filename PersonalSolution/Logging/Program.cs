using System;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.AppendLogLine("deviceID", "logText");
            Console.ReadLine();
        }
    }
}