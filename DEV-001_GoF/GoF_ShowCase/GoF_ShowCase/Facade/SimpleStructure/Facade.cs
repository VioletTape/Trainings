using System;

namespace GoF_ShowCase.Facade.SimpleStructure {
    internal class Facade {
        private readonly SubSystemOne one;
        private readonly SubSystemTwo two;
        private readonly SubSystemThree three;
        private readonly SubSystemFour four;

        public Facade() {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA() {
            Console.WriteLine("\nMethodA() ---- ");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }

        public void MethodB() {
            Console.WriteLine("\nMethodB() ---- ");
            two.MethodTwo();
            three.MethodThree();
        }
    }
}