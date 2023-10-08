using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Player
    {
        public string Id {get; set;}
        public Player(string id) {
            this.Id = id;
        }

        public void SetId(string id) {
            if (!string.IsNullOrEmpty(id)) { this.Id = id; }
        }
    }
}