//---------------------------------------------------------------------------------
// <copyright file="Response.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------

using System;
using Library.bot.core;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.bot
{
    /// <summary>
    /// Respuestas del bot.
    /// </summary>
    public class Response
    {
        private ResponseType Type;
        private string Message;
        private string Return;
        private InlineKeyboardMarkup Keyboard;

<<<<<<< HEAD
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Response"/>.
        /// </summary>
        /// <param name="type"> Tipo de respuesta. </param>
        /// <param name="msg"> Mensaje. </param>
        public Response(ResponseType type, string msg)
        {
            Type = type;
            Message = msg;
=======
        public Response(ResponseType type, string msg, string? ret = null, InlineKeyboardMarkup? ikm = null) {
            this.Type = type;
            this.Message = msg;
            this.Return = ret;
            this.Keyboard = ikm;
>>>>>>> 130e6caf9191761934f45e25028bd936745bdf3c
        }

        /// <summary>
        /// Set del tipo de respuesta.
        /// </summary>
        /// <param name="type"> Tipo de respuesta. </param>
        public void SetType(ResponseType type)
        {
            if (type != null) { Type = type; }
        }
        public void SetReturn (string ret) {
            this.Return = ret;
        }

        /// <summary>
        /// Set del mensaje.
        /// </summary>
        /// <param name="msg"> Mensaje. </param>
        public void SetMessage(string msg)
        {
            if (!string.IsNullOrEmpty(msg)) { Message = msg; }
        }

        /// <summary>
        /// Set del teclado.
        /// </summary>
        /// <param name="kb"> ???? </param>
        public void SetKeyboard(InlineKeyboardMarkup kb)
        {
            Keyboard = kb;
        }

        /// <summary>
        /// Devuelve el tipo.
        /// </summary>
        /// <returns> Tipo de respuesta. </returns>
        public ResponseType GetType()
        {
            return Type;
        }

        /// <summary>
        /// Devuelve el mensaje.
        /// </summary>
        /// <returns> Mensaje. </returns>
        public string GetMessage()
        {
            return Message;
        }

        /// <summary>
        /// Devuelve el teclado.
        /// </summary>
        /// <returns> Teclado. </returns>
        public InlineKeyboardMarkup GetKeyboard()
        {
            return Keyboard;
        }
        public string GetReturn() {
            return this.Return;
        }
    }
}