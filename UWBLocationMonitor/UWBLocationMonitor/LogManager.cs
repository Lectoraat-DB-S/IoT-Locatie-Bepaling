using System;
using System.Collections.Generic;

namespace UWBLocationMonitor
{
    public static class LogManager
    {
        private static readonly List<string> logMessages = new List<string>();
        public static event Action<string> OnLogUpdate;

        public static void Log(string message)
        {
            logMessages.Add(message);
            OnLogUpdate?.Invoke(message);
        }

        public static IEnumerable<string> GetLogMessages()
        {
            return logMessages;
        }

        public static void printLogToCSV()
        {
            var tempPath = Path.GetTempPath();
            var fileName = "log_" + DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.ToString("HH_mm_ss") + ".csv";
            var path = Path.Combine(tempPath, fileName);

            using var sw = new StreamWriter(path);
            foreach (var line in logMessages)
            {
                sw.WriteLine(line);
            }
        }
    }
}
