using System.Runtime.InteropServices.ComTypes;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Exceptions;

namespace Library
{
    public class Configuration
    {
        private string Name;
        private string Username;
        private string Token;

        public Configuration() { this.Load(); }

        private void Load() {
            string jpath = "../settings.json";

            if (!File.Exists(jpath)) { return; }

            try {
                string jstring = File.ReadAllText(jpath);

                JsonDocument jdoc = JsonDocument.Parse(jstring);
                JsonElement elem = jdoc.RootElement;

                try {
                    this.Name = elem.GetProperty("name").GetString();
                } catch (KeyNotFoundException ex) { throw new NameNotFoundException("The property 'name' in configuration file does not exist."); }
                try {
                    this.Username = elem.GetProperty("username").GetString();
                } catch (KeyNotFoundException ex) { throw new UsernameNotFoundException("The property 'username' in configuration file does not exist."); }
                try {
                    this.Token = elem.GetProperty("token").GetString();
                } catch (KeyNotFoundException ex) { throw new TokenNotFoundException("The property 'token' in configuration file does not exist."); }
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