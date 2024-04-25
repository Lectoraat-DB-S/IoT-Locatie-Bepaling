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
    }
}
