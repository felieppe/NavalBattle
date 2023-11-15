using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class Logger
    {
        private Configuration Config;

        public Logger(Configuration config) {
            this.Config = config;
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