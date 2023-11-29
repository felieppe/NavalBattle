//---------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using Library.Exceptions;

namespace Library
{
    /// <summary>
    /// Clase que se encarga de la configuración del bot.
    /// </summary>
    public class Configuration
    {
         /// <summary>
        /// Instancia de Singleton.
        /// </summary>
        /// <value>  </value>
        private static Configuration instance;

        /// <summary>
        /// Nombre.
        /// </summary>
        private string Name;

        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        private string Username;

        /// <summary>
        /// Token del bot.
        /// </summary>
        private string Token;

        /// <summary>
        /// Estado del Debug.
        /// </summary>
        private bool Debug;

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="ServerManager"/> si no existe una, de lo contrario devuelve la instancia que existe.
        /// </summary>
        public static Configuration Instance
        {
            get
            {
                if (instance == null) { instance = new Configuration(); }
                return instance;
            }
        }
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Configuration() { Load(); }
        
        /// <summary>
        /// Carga la configuración del bot.
        /// </summary>
        private void Load()
        {
            string jpath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\")) + "/src/settings.json";

            if (!File.Exists(jpath)) { throw new ConfigFileNotExistsException("The configuration file does not exist."); }

            try
            {
                string jstring = File.ReadAllText(jpath);

                JsonDocument jdoc = JsonDocument.Parse(jstring);
                JsonElement elem = jdoc.RootElement;

                try
                {
                    JsonElement prop = elem.GetProperty("name");
                    Name = prop.GetString();
                }
                catch (KeyNotFoundException ex) { throw new NameNotFoundException("The property 'name' in configuration file does not exist."); }
                try
                {
                    JsonElement prop = elem.GetProperty("username");
                    Username = prop.GetString();
                }
                catch (KeyNotFoundException ex) { throw new UsernameNotFoundException("The property 'username' in configuration file does not exist."); }
                try
                {
                    JsonElement prop = elem.GetProperty("token");
                    Token = prop.GetString();
                } catch (KeyNotFoundException ex) { throw new TokenNotFoundException("The property 'token' in configuration file does not exist."); }
                try
                {
                    JsonElement prop = elem.GetProperty("debug");
                    Debug = prop.GetBoolean();
                } catch (KeyNotFoundException ex) { throw new DebugNotFoundException("The property 'debug' in configuration file does not exist."); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Obtiene el nombre.
        /// </summary>
        /// <returns> Nombre. </returns>
        public string GetName()
        {
            return Name;
        }
        /// <summary>
        /// Obtiene el Nombre de usuario.
        /// </summary>
        /// <returns> Nombre de usuario. </returns>

        public string GetUsername()
        {
            return Username;
        }
        /// <summary>
        /// Obtiene el Token de Telegram.
        /// </summary>
        /// <returns> Token de Telegram. </returns>
        
        public string GetToken()
        {
            return Token;
        }
        /// <summary>
        /// Obtiene el valor booleano de Debug. 
        /// </summary>
        /// <returns> Valor booleano de Debug.  </returns>
        public bool GetDebug()
        {
            return Debug;
        }
    }
}

///Cumple con el principio de responsabilidad única, porque solo tiene la responsabilidad de generar la configuracion del Bot.
/// Cumple con el patrón Singleton porque solo se puede tener una única instancia de la clase.