using CollegeMS.Model.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.Handlers
{
    static class Logger
    {
        private static string path_logger = "./logger.txt";
        static public void SaveLogger(string message , string source)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{source}] {message}";
                File.AppendAllText(path_logger, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBoxShow.show($"Failed to write to log: {ex.Message}");
            }
        }
    }
}
