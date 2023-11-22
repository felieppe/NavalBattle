using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.utils
{
    public class Deserializer
    {
        private static Deserializer instance;

        public static Deserializer Instance {
            get {
                if (instance == null) { instance = new Deserializer(); }
                return instance;
            }
        }

        public Deserializer() {}
    }
}