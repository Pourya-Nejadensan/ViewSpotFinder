using System;
using System.IO;

namespace ViewSpotFinder.Util
{
    public static class Logger
    {
        private static string _logFilePath;
        private static bool _isInitialized;

        public static void Initialize(string logFilePath)
        {
            _logFilePath = logFilePath;
            _isInitialized = true;
        }
        public static void Log(LogLevel level, string message)
        {
            if (!_isInitialized)
            {
                throw new Exception("Logger class must be initialized before use.");
            }

            string logEntry = $"{DateTime.Now} [{level.ToString().ToUpper()}] {message}";

            using (StreamWriter sw = new StreamWriter(_logFilePath, true))
            {
                sw.WriteLine(logEntry);
            }
        }
    }
}
