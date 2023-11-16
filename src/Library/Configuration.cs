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
        private bool Debug;

        public Configuration() { this.Load(); }

        private void Load() {
            string jpath = "../settings.json";

            if (!File.Exists(jpath)) { throw new ConfigFileNotExistsException("The configuration file does not exist."); }

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
                try {
                    this.Debug = elem.GetProperty("debug").GetBoolean();
                } catch (KeyNotFoundException ex) { throw new DebugNotFoundException("The property 'debug' in configuration file does not exist."); }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetName() {
            return this.Name;
        }
        public string GetUsername() {
            return this.Username;
        }
        public string GetToken() {
            return this.Token;
        }
        public bool GetDebug() {
            return this.Debug;
        }
    }
}