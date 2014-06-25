using System;
using System.Collections;

namespace GoF_ShowCase.Interpreter.SimpleStructure {
    public class Example {
        public Example() {
            var context = new Context();

            // Usually a tree 
            var list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret 
            foreach (AbstractExpression exp in list) {
                exp.Interpret(context);
            }

            // Wait for user 
            Console.Read();
        }
    }
}