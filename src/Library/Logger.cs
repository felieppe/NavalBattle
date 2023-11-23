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
        private static Logger instance;
        private Configuration Config = Configuration.Instance;
        private string LogPath;
        
        /// <summary>
        /// Crea las carpetas que necesita el Logger para funcionar.
        /// </summary>
        /// <returns> . </returns>

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
            if (!File.Exists(logPath)) { 
                FileStream fs = File.Create(logPath); 
                fs.Close();
            }
        
            this.LogPath = logPath;
        }
        
        /// <summary>
        /// Escribe un mensaje en el archivo del registro.
        /// </summary>
        /// <returns>  </returns>
        private void Log(string log) {
            try {
                using (StreamWriter writer = new StreamWriter(this.LogPath, true)) {
                    string GenerateTimestamp() {
                        DateTime now = DateTime.Now;
                        string formatted = now.ToString("dd/MM/yy | HH:mm:ss");
                        
                        return formatted;
                    }

                    writer.WriteLine($"[{GenerateTimestamp()}] {log}");
                }
            } catch (Exception ex) {
                Console.WriteLine("ERROR! Impossible to write in logfile.");
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// Patron singleton.
        /// </summary>
        /// <returns> </returns>

        public static Logger Instance {
            get {
                if (instance == null) { instance = new Logger(); }
                return instance;
            }
        }
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <returns>  </returns>

        public Logger() {
            this.Setup();

            this.Info("Logger has been configured correctly!");
        }
        
        /// <summary>
        /// Escribe un mensaje de tipo informacion en la consola.
        /// </summary>
        /// <returns>  </returns>

        public void Info(string msg) {
            string output = $"[@{Config.GetUsername()}/INFO]: {msg}";
            Console.WriteLine(output);

            this.Log(output);
        }
        
        /// <summary>
        /// Escribe un mensaje de tipo Debug en la consola.
        /// </summary>
        /// <returns> </returns>
        public void Debug(string msg) {
            if (this.Config.GetDebug()) {
                string output = $"[@{Config.GetUsername()}/DEBUG]: {msg}";
                Console.WriteLine(output);

                this.Log(output);
            }
        }
        /// <summary>
        /// Escribe un mensaje de tipo Error en la consola.
        /// </summary>
        /// <returns> </returns>
        public void Error(string msg) {
            string output = $"[@{Config.GetUsername()}/ERROR]: {msg}";
            Console.WriteLine(output);

            this.Log(output);
        }
    }
}