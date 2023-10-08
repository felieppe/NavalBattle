using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Player : IPlayer
    {
        public string Id {get; set;}
        public Player() {}

        public void SetId(string id) {
            if (string.IsNullOrEmpty(id)) { this.Id = id; }
        }
    }
}