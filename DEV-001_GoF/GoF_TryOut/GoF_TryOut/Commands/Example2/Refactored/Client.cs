using System;

namespace GoF_TryOut.Commands.Example2.Refactored {
    public class Client {
        public Client() {
            var heroA = new HeroA("XX09");
            var controller = new Controller(new LayoutScheme(heroA, 1)
//                new Command(heroA.Run),
//                new Command(heroA.Jump),
//                new Command(heroA.Shoot),
//                new Command(heroA.SwapWeapon)
                );

            controller.PressA();
            controller.PressB();
            controller.PressD();

            var heroB = new HeroB("OO_S");
            controller = new Controller(
                new Command(heroB.Jump),
                new Command(heroB.Run),
                new Command(heroB.CastSpell),
                new Command(heroB.SwapSpell)
                );

            controller.PressA();
            controller.PressB();
            controller.PressD();

        }
    }


    public class HeroA {
        private readonly string name;

        public HeroA(string name) {
            this.name = name;
        }

        public void Jump() {
            Console.WriteLine("HeroA {0} Jumped", name);
        }

        public void Run() {
            Console.WriteLine("HeroA {0} Running", name);
        }

        public void Shoot() {
            Console.WriteLine("HeroA {0} Shooted", name);
        }

        public void SwapWeapon() {
            Console.WriteLine("HeroA {0} Swaped Weapons", name);
        }
    }

    public class HeroB {
        private readonly string name;

        public HeroB(string name) {
            this.name = name;
        }

        public void Jump() {
             Console.WriteLine("HeroB {0} Jumped", name);
        }

        public void Run() {
             Console.WriteLine("HeroB {0} Running", name);
        }

        public void CastSpell() {
             Console.WriteLine("HeroB {0} CastedSpell", name);
        }

        public void SwapSpell() {
             Console.WriteLine("HeroB {0} Swaped Spells", name);
        }
    }


    public class Command {
        private readonly Action action;

        public Command(Action action) {
            this.action = action;
        }

        public void Execute() {
            action.Invoke();
        }
    }


    public class Controller {
        private readonly Command a;
        private readonly Command b;
        private readonly Command c;
        private readonly Command d;

        public Controller(Command a, Command b, Command c, Command d) {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public void PressA() {
            a.Execute();
        }

        public void PressB() {
            b.Execute();
        }

        public void PressС() {
            c.Execute();
        }

        public void PressD() {
            d.Execute();
        }
    }
}