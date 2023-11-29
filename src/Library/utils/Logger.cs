//---------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.IO;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    public class Logger
    {
         /// <summary>
        /// Instancia de singleton.
        /// </summary>
        /// <value> Logger. </value>
        private static Logger instance;

         /// <summary>
        /// Instancia de la clase Configuration.
        /// </summary>
        private Configuration Config = Configuration.Instance;
        private string LogPath;
        
        /// <summary>
        /// Crea las carpetas que necesita el Logger para funcionar.
        /// </summary>
        private void Setup()
        {
            string folderPath = "../../logs";
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            string GenerateLogfile()
            {
                DateTime currentTime = DateTime.UtcNow;
                int timestamp = (int)currentTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                return $"{timestamp}_@{Config.GetUsername()}.log";
            }
            string logFile = GenerateLogfile();
            
            string logPath = $"{folderPath}/{logFile}";
            if (!File.Exists(logPath))
            { 
                FileStream fs = File.Create(logPath); 
                fs.Close();
            }
            LogPath = logPath;
        }
        
        /// <summary>
        /// Escribe un mensaje en el archivo del registro.
        /// </summary>
        private void Log(string log)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogPath, true))
                {
                    string GenerateTimestamp()
                    {
                        DateTime now = DateTime.Now;
                        string formatted = now.ToString("dd/MM/yy | HH:mm:ss");
                        return formatted;
                    }

                    writer.WriteLine($"[{GenerateTimestamp()}] {log}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! Impossible to write in logfile.");
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// Constructor único.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null) { instance = new Logger(); }
                return instance;
            }
        }
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Logger()
        {
            Setup();
            Info("Logger has been configured correctly!");
        }
        
        /// <summary>
        /// Escribe un mensaje de tipo información en la consola.
        /// </summary>
        public void Info(string msg)
        {
            string output = $"[@{Config.GetUsername()}/INFO]: {msg}";
            Console.WriteLine(output);
            Log(output);
        }
        
        /// <summary>
        /// Escribe un mensaje de tipo Debug en la consola.
        /// </summary>
        public void Debug(string msg)
        {
            if (Config.GetDebug())
            {
                string output = $"[@{Config.GetUsername()}/DEBUG]: {msg}";
                Console.WriteLine(output);
                Log(output);
            }
        }
        /// <summary>
        /// Escribe un mensaje de tipo Error en la consola.
        /// </summary>
        public void Error(string msg)
        {
            string output = $"[@{Config.GetUsername()}/ERROR]: {msg}";
            Console.WriteLine(output);
            Log(output);
        }
    }
}