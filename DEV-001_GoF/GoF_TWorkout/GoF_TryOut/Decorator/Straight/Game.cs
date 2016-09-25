using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Decorator.Straight {
    public class Game {
        public Game() {
            var sm = new SpaceMarine {
                                         BaseAttack = 10,
                                         BaseDefence = 15
                                     };

            sm.SetPowerUp(PowerUp.GrenadeShoot);
            Console.WriteLine(sm.Shoot());

            var sm1 = new SpaceMarine {
                                          BaseAttack = 10,
                                          BaseDefence = 15
                                      };

            sm1.SetPowerUp(PowerUp.Critical);
            Console.WriteLine(sm1.Shoot());

            sm.SetPowerUp(PowerUp.Critical);
            Console.WriteLine(sm.Shoot());
        }
    }

    public class SpaceMarine {
        public decimal BaseAttack;
        public decimal Attack;
        public decimal BaseDefence;
        public decimal Defence;
        private readonly List<PowerUp> powerUp = new List<PowerUp>();

        public decimal Shoot() {
            var shoot = BaseAttack;
            if (powerUp.Any(p => p == PowerUp.GrenadeShoot))
                shoot *= 2.2m*powerUp.Sum(p => p == PowerUp.GrenadeShoot ? 1 : 0);

            if (powerUp.Any(p => p == PowerUp.Critical))
                shoot *= 4m*powerUp.Sum(p => p == PowerUp.Critical ? 1 : 0);

            if (powerUp.Any(p => p == PowerUp.EmperorBless))
                shoot *= 1.5m*powerUp.Sum(p => p == PowerUp.EmperorBless ? 1 : 0);

            if (powerUp.Any(p => p == PowerUp.Berserk))
                shoot *= 1.3m*powerUp.Sum(p => p == PowerUp.Berserk ? 1 : 0);

            if (powerUp.Any(p => p == PowerUp.Commander))
                shoot *= 1.7m*powerUp.Sum(p => p == PowerUp.Commander ? 1 : 0);

            return shoot;
        }

        public decimal Slash() {
            var slash = BaseAttack;
            // some calc

            return slash;
        }

        public void Bless() {
            // etc
        }

        public void SetPowerUp(PowerUp powerUp) {
            this.powerUp.Add(powerUp);
        }

        public void RemovePowerUp(PowerUp powerUp) {
            this.powerUp.Remove(powerUp);
        }
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