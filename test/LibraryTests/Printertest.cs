using Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Game"/>.
    /// </summary>
    [TestFixture]
    public class PrinterTests{

    
    public void TestPrint(){

         bool[,] exampleBoard = new bool[,]
        {
            { true, false, true },
            { false, true, false },
            { true, false, true }
        };

        Printer printer = new Printer(new Board(exampleBoard), 3, 3);

        using (ConsoleCapture consoleCapture = new ConsoleCapture())
        {
            printer.Print();
            string printedOutput = consoleCapture.CapturedOutput;

            // Comparar la salida con el texto esperado
            if (printedOutput == expectedOutput)
            {
                Console.WriteLine("");
            }
        }
    }
    }
    internal class ConsoleCapture
    {
        public string CapturedOutput { get; internal set; }
    }
}


