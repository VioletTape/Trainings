using System;
using GoF_TryOut.Builder.Refactored;

namespace TestConsole {
    internal class Program {
        /// <summary>
        /// Метод для запуска примеров
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) {
            new BuilderExampleRefactored();

            Console.ReadLine();
        }
    }
}