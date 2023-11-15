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
    }
}