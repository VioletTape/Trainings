using System;

namespace GoF_TryOut.Commands.Example2.StraightCode {
    public class Client {
        public Client() {
            var controller = new Controller(new HeroA());
            controller.PressA();
            controller.PressB();
            controller.PressD();
        }
    }

    public class HeroA {
        public void Jump() {
            Console.WriteLine("HeroA Jumped");
        }

        public void Run() {
            Console.WriteLine("HeroA Running");
        }

        public void Shoot() {
            Console.WriteLine("HeroA Shooted");
        }

        public void SwapWeapon() {
            Console.WriteLine("HeroA Swaped Weapons");
        }
    }

    public class HeroB {
        public void Jump() {
            Console.WriteLine("HeroB Jumped");
        }

        public void Run() {
            Console.WriteLine("HeroB Running");
        }

        public void CastMagic() {
            Console.WriteLine("HeroB CastMagic");
        }

        public void SwapSpell() {
            Console.WriteLine("Hero Swaped Spell");
        }
    }

    public class Controller {
        private readonly HeroA heroA;
        private readonly HeroB heroB;

        public Controller(HeroA heroA) {
            this.heroA = heroA;
        }

        public Controller(HeroB heroB) {
            this.heroB = heroB;
        }

        public void PressA() {
            if (heroA != null)
                heroA.Jump();
            else {
                heroB.Jump();
            }
        }

        public void PressB() {
            if (heroA != null)
                heroA.Run();
            else {
                heroB.Run();
            }
        }

        public void PressС() {
            if (heroA != null)
                heroA.Shoot();
            else {
                heroB.CastMagic();
            }
        }

        public void PressD() {
            if (heroA != null)
                heroA.SwapWeapon();
            else {
                heroB.SwapSpell();
            }
        }
    }
}