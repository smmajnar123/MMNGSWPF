using System;
using System.IO;

namespace TestWpf.Helpers
{
    public static class Logger
    {
        private static readonly string LogFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        static Logger()
        {
            // Ensure log folder exists
            if (!Directory.Exists(LogFolder))
                Directory.CreateDirectory(LogFolder);
        }

        /// <summary>
        /// Logs exception to a text file with timestamp.
        /// </summary>
        public static void LogException(Exception ex)
        {
            try
            {
                string logFile = Path.Combine(LogFolder, $"ErrorLog_{DateTime.Now:yyyyMMdd}.txt");

                using (var writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine($"DateTime: {DateTime.Now}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    if (ex.InnerException != null)
                        writer.WriteLine($"InnerException: {ex.InnerException}");
                    writer.WriteLine("--------------------------------------------------");
                    writer.WriteLine();
                }
            }
            catch
            {
                // Avoid throwing exception from logger
            }
        }

        /// <summary>
        /// Logs custom messages
        /// </summary>
        public static void LogMessage(string message)
        {
            try
            {
                string logFile = Path.Combine(LogFolder, $"Log_{DateTime.Now:yyyyMMdd}.txt");
                using (var writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch { }
        }
    }
}
