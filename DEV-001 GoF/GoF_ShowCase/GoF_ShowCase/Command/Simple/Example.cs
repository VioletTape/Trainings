using System;

namespace GoF_ShowCase.Command.Simple {
    public class Example {
        public Example() {
            // Create receiver, command, and invoker 
            var receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            var invoker = new Invoker();

            // Set and execute command 
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user 
            Console.Read();
        }
    }
}