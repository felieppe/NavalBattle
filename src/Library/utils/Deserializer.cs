using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.utils.core;

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

        public dynamic Deserialize(DataType opt) {
            string baseFolder = $"../../save/{Configuration.Instance.GetUsername()}";

            switch (opt) {
                case DataType.Game:
                    break;
                case DataType.Player:
                    break;
            }

            return null;
        } 
    }
}