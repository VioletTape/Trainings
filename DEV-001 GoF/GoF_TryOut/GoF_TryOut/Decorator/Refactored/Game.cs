using System;

namespace GoF_TryOut.Decorator.Refactored {
    public class Game {
        public Game() {
            ISpaceMarine spaceMarine = new SpaceMarine {
                                                           BaseAttack = 10,
                                                           BaseDefence = 15
                                                       };

            spaceMarine = new GrenadeShootFor(spaceMarine);
            Console.WriteLine(spaceMarine.Shoot());

            spaceMarine = new CriticalShootFor(spaceMarine);
            Console.WriteLine(spaceMarine.Shoot());

            spaceMarine = new CriticalShootFor(spaceMarine);
            Console.WriteLine(spaceMarine.Shoot());


            ISpaceMarine spaceMarine2 = new SpaceMarine {
                                                            BaseAttack = 10,
                                                            BaseDefence = 15
                                                        };

            spaceMarine2 = new CriticalShootFor(spaceMarine2);
            Console.WriteLine(spaceMarine2.Shoot());

            spaceMarine = new CriticalShootFor(spaceMarine);
            Console.WriteLine(spaceMarine.Shoot());


        }
    }


    public interface ISpaceMarine {
        decimal Shoot();
        decimal Slash();
        void Bless();
    }









    public class SpaceMarine : ISpaceMarine {
        public decimal BaseAttack;
        public decimal BaseDefence;
        public decimal Defence;

        public decimal Shoot() {
            return BaseAttack;
        }

        public decimal Slash() {
             // some calc
            return BaseAttack;
        }

        public void Bless() {
            // etc
        }
    }















    public class GrenadeShootFor : ISpaceMarine {
        private readonly ISpaceMarine marine;

        public GrenadeShootFor(ISpaceMarine marine) {
            this.marine = marine;
        }

        public decimal Shoot() {
            return marine.Shoot()*2.2m;
        }

        public decimal Slash() {
            return marine.Slash();
        }

        public void Bless() {}
    }

    public class CriticalShootFor : ISpaceMarine {
        private readonly ISpaceMarine marine;

        public CriticalShootFor(ISpaceMarine marine) {
            this.marine = marine;
        }

        public decimal Shoot() {
            return marine.Shoot()*4;
        }

        public decimal Slash() {
            return marine.Slash();
        }

        public void Bless() {}
    }

    public enum PowerUp {
        None = 0,
        GrenadeShoot = 2,
        Critical = 4,
        Berserk = 8,
        DoubleDefence = 16,
        EmperorBless = 32,
        PowerSlash = 64,
        Medic = 128,
        Commander = 256
    }
}