using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Player
    {
        private string Id {get; set;}
        public Player(string id) {
            this.Id = id;
        }

        public void SetId(string id) {
            if (!string.IsNullOrEmpty(id)) { this.Id = id; }
        }

        public string GetId() {
            return this.Id;
        }
    }
}