using System;

namespace GoF_ShowCase.Proxy.SimpleStructure {
    internal class RealSubject : Subject {
        public override void Request() {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }
}