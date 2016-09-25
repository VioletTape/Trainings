using System;

namespace GoF_ShowCase.Facade.SimpleStructure {
    // "Subsystem ClassA" 
    internal class SubSystemOne {
        public void MethodOne() {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    // Subsystem ClassB" 
    internal class SubSystemTwo {
        public void MethodTwo() {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    // Subsystem ClassC" 
    internal class SubSystemThree {
        public void MethodThree() {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    // Subsystem ClassD" 
    internal class SubSystemFour {
        public void MethodFour() {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
}