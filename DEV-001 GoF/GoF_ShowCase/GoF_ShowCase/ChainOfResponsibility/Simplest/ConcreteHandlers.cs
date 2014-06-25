using System;

namespace GoF_ShowCase.ChainOfResponsibility.Simplest {
    // "ConcreteHandler1" 
    internal class ConcreteHandler1 : Handler {
        public override void HandleRequest(int request) {
            if (request >= 0 && request < 10) {
                Console.WriteLine("{0} handled request {1}",
                                  GetType().Name, request);
            }
            else if (successor != null) {
                successor.HandleRequest(request);
            }
        }
    }

    // "ConcreteHandler2" 
    internal class ConcreteHandler2 : Handler {
        public override void HandleRequest(int request) {
            if (request >= 10 && request < 20) {
                Console.WriteLine("{0} handled request {1}",
                                  GetType().Name, request);
            }
            else if (successor != null) {
                successor.HandleRequest(request);
            }
        }
    }

    // "ConcreteHandler3" 
    internal class ConcreteHandler3 : Handler {
        public override void HandleRequest(int request) {
            if (request >= 20 && request < 30) {
                Console.WriteLine("{0} handled request {1}",
                                  GetType().Name, request);
            }
            else if (successor != null) {
                successor.HandleRequest(request);
            }
        }
    }
}