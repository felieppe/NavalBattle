using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.utils
{
    public class Serializer
    {
        private static Serializer instance;

        public static Serializer Instance {
            get {
                if (instance == null) { instance = new Serializer(); }
                return instance;
            }
        }

        public Serializer() {}
    }
}