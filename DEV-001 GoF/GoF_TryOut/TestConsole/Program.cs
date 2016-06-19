using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoF_TryOut.AbstractFactory.Flyweight;
using GoF_TryOut.Builder.Refactored;
using GoF_TryOut.Commands.Refactored;
using GoF_TryOut.Composite.Refactored;
using GoF_TryOut.Composite.Straight;
using GoF_TryOut.Interpreter.Refactored;
using GoF_TryOut.Memento.Refactored;
using GoF_TryOut.Memento.StraightCode;
using GoF_TryOut.Visitor.Refactored;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args) {
//            new GoF_TryOut.Commands.Example2.StraightCode.Client();
            new GoF_TryOut.Commands.Example2.Refactored.Client();


            Console.ReadLine();
        }
    }
}
