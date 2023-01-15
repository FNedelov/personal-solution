using System;
using System.IO;

namespace Logging
{
    class Logger
    {
        public static void AppendLogLine(string deviceID, string text)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} \t - {deviceID} - \t {text}";
            string logfile = @$"{AppDomain.CurrentDomain.BaseDirectory}Logs\{DateTime.Now.Year:0000}{DateTime.Now.Month:00}{DateTime.Now.Day:00} - ServiceName.log";

            try
            {
                using StreamWriter w = File.AppendText(logfile);
                w.WriteLine(line);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}