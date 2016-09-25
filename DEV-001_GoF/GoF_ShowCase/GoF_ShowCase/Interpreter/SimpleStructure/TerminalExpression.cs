using System;

namespace GoF_ShowCase.Interpreter.SimpleStructure {
    internal class TerminalExpression : AbstractExpression {
        public override void Interpret(Context context) {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }
}