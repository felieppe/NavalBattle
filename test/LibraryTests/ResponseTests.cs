//---------------------------------------------------------------------------------
// <copyright file="BoardSizeTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------
using Library;
using Library.bot;
using Library.bot.core;
using NUnit.Framework;
using Telegram.Bot.Types.ReplyMarkups;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Response"/>.
    /// </summary>
    [TestFixture]
    public class ResponseTests
    {
        /// <summary>
        /// Clase Response para probar.
        /// </summary>
        private Response res;

        /// <summary>
        /// Crea un Response para probar.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            res = new Response(ResponseType.None, null);
        }

        /// <summary>
        /// Prueba que se establezca correctamente el type en la clase.
        /// </summary>
        [Test]
        public void SetTypeTest() {
            ResponseType type = ResponseType.Message;

            res.SetType(type);
            Assert.AreEqual(type, res.GetType());
        }

        /// <summary>
        /// Prueba que se establezca correctamente el message en la clase.
        /// </summary>
        [Test]
        public void SetMessageTest() {
            string msg = "Hola!";

            res.SetMessage(msg);
            Assert.AreEqual(msg, res.GetMessage());
        }

        /// <summary>
        /// Prueba que se establezca correctamente el keyboard en la clase.
        /// </summary>
        [Test]
        public void SetKeyboardTest() {
            InlineKeyboardMarkup keyboard = new(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Button 1", callbackData: "button1"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Button 2", callbackData: "button2"),
                },
            });

            res.SetKeyboard(keyboard);
            Assert.AreEqual(keyboard, res.GetKeyboard());
        }
    }
}