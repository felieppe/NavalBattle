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
        private static Configuration instance;

        private string Name;
        private string Username;
        private string Token;
        private bool Debug;

        public static Configuration Instance {
            get {
                if (instance == null) { instance = new Configuration(); }
                return instance;
            }
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <returns>  </returns>

        public Configuration() { this.Load(); }

        private void Load() {
            string jpath = "../settings.json";

            if (!File.Exists(jpath)) { throw new ConfigFileNotExistsException("The configuration file does not exist."); }

            try {
                string jstring = File.ReadAllText(jpath);

                JsonDocument jdoc = JsonDocument.Parse(jstring);
                JsonElement elem = jdoc.RootElement;

                try {
                    JsonElement prop = elem.GetProperty("name");
                    this.Name = prop.GetString();
                } catch (KeyNotFoundException ex) { throw new NameNotFoundException("The property 'name' in configuration file does not exist."); }
                try {
                    JsonElement prop = elem.GetProperty("username");
                    this.Username = prop.GetString();
                } catch (KeyNotFoundException ex) { throw new UsernameNotFoundException("The property 'username' in configuration file does not exist."); }
                try {
                    JsonElement prop = elem.GetProperty("token");
                    this.Token = prop.GetString();
                } catch (KeyNotFoundException ex) { throw new TokenNotFoundException("The property 'token' in configuration file does not exist."); }
                try {
                    JsonElement prop = elem.GetProperty("debug");
                    this.Debug = prop.GetBoolean();
                } catch (KeyNotFoundException ex) { throw new DebugNotFoundException("The property 'debug' in configuration file does not exist."); }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene el nombre.
        /// </summary>
        /// <returns> Devuelve el nombre. </returns>
        public string GetName() {
            return this.Name;
        }
        /// <summary>
        /// Obtiene el Nombre de usuario
        /// </summary>
        /// <returns> Devuelve el Nombre de usuario. </returns>

        public string GetUsername() {
            return this.Username;
        }
        /// <summary>
        /// Obtiene el Token de Telegram
        /// </summary>
        /// <returns> Devuelve elToken de Telegram . </returns>
        
        public string GetToken() {
            return this.Token;
        }
        /// <summary>
        /// Obtiene el valor booleano de Debug 
        /// </summary>
        /// <returns> Devuelve el valor booleano de Debug  </returns>
        public bool GetDebug() {
            return this.Debug;
        }
    }
}