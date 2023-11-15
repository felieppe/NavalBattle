using System.Net;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class Logger
    {
        private Configuration Config;
        private string LogPath;

        private void Setup() {
            string folderPath = "../../logs";
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            string GenerateLogfile() {
                DateTime currentTime = DateTime.UtcNow;
                int timestamp = (int)(currentTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                return $"{timestamp}_@{this.Config.GetUsername()}.log";
            }
            string logFile = GenerateLogfile();
            
            string logPath = $"{folderPath}/{logFile}";
            if (!File.Exists(logPath)) { File.Create(logPath); }
        
            this.LogPath = logPath;
        }
        private void Log(string log) {
            try {
                using (StreamWriter writer = new StreamWriter(this.LogPath, true)) {
                    writer.WriteLine(log);
                }
            } catch (Exception ex) {
                Console.WriteLine("ERROR! Impossible to write in logfile.");
            }
        }

        public Logger(Configuration config) {
            this.Config = config;
            this.Setup();
        }

        public void Info(string msg) {
            Console.WriteLine($"[@{Config.GetUsername()}/INFO]: {msg}");
        }
        public void Debug(string msg) {
            if (this.Config.GetDebug()) { Console.WriteLine($"[@{Config.GetUsername()}/DEBUG]: {msg}"); }
        }
        public void Error(string msg) {
            Console.WriteLine($"[@{Config.GetUsername()}/ERROR]: {msg}");
        }
    }
}