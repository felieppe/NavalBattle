using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavalBattle
{
    public class Configuration
    {
        private string Name;
        private string Username;
        private string Token;

        public Configuration() { this.Load(); }

        private void Load() {
            string jpath = "../settings.json";

            if (!File.Exists(jpath)) { break; }

            try {
                string jstring = File.ReadAllText(jpath);

                JsonDocument jdoc = JsonDocument.Parse(jstring);
                JsonElement elem = jdoc.RootElement;

                this.Name = elem.GetProperty("name").GetString();
                this.Username = elem.GetProperty("username").GetString();
                this.Token = elem.GetProperty("token").GetString();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private string GetName() {
            return this.Name;
        }
        private string GetUsername() {
            return this.Username;
        }
        private string GetToken() {
            return this.Token;
        }
    }
}