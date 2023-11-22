using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.utils.core;

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

        #nullable enable
        public void Serialize(DataType opt, Game? game, Player? player) {
            switch (opt) {
            case DataType.Game:
                if (game != null) { return; }
                break;
            case DataType.Player:
                if (player != null) { return; }
                break;
            }
        }
    }
}