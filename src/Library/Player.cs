using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class Player
    {
        private string Id {get; set;}
        private string Username {get; set;}
        
        public Player(string id) {
            this.Id = id;
        }

        public void SetId(string id) {
            if (!string.IsNullOrEmpty(id)) { this.Id = id; }
        }
        public void SetUsername(string username) {
            if (!string.IsNullOrEmpty(username)) { this.Username = username; }
        }

        public string GetId() {
            return this.Id;
        }
        public string GetUsername() {
            return this.Username;
        }
    }
}