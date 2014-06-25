using System;

namespace GoF_ShowCase.Interpreter.SimpleStructure {
    internal class NonterminalExpression : AbstractExpression {
        public override void Interpret(Context context) {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}