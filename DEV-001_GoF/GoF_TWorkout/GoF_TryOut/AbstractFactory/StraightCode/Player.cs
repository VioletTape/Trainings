using System;
using System.Drawing;

namespace GoF_TryOut.AbstractFactory.StraightCode {
    public class Player {
        public RaceType Race { get; set; }

        public IInfantry CreateInfantry() {
            switch (Race) {
                case RaceType.Human:
                    return new HumanInfantry(this);
                case RaceType.Protos:
                    return new ProtosInfantry(this);
                case RaceType.Zerg:
                    return new ZergInfantry(this);
            }

            throw new Exception();
        }
    }

    public enum RaceType {
        Human,
        Zerg,
        Protos
    }

    public enum UnitType {
        Infantry,
        Rangers,
        LightVehicle,
        Tank,
        Helicopter
    }

    public interface IInfantry {
        int Armor { get; set; }
        int HP { get; set; }
        int Attack { get; set; }
        Player Player { get; }
        Point Point { get; set; }
        void Draw();
    }

    public class HumanInfantry : IInfantry {
        public int Armor { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public Player Player { get; private set; }
        public Point Point { get; set; }

        public void Draw() {
            var format = string.Format("{0} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }

        public HumanInfantry(Player player) {
            Player = player;
            Armor = 10;
            HP = 20;
            Attack = 5;
        }
    }

    public class ZergInfantry : IInfantry {
        public int Armor { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public Player Player { get; private set; }
        public Point Point { get; set; }

        public ZergInfantry(Player player) {
            Player = player;
            Armor = 5;
            HP = 25;
            Attack = 10;
        }

        public void Draw() {
            var format = string.Format("{0}-{3} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }
    }

    public class ProtosInfantry : IInfantry {
        public int Armor { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public Player Player { get; private set; }
        public Point Point { get; set; }

        public ProtosInfantry(Player player) {
            Player = player;
            Armor = 25;
            HP = 5;
            Attack = 15;
        }

        public void Draw() {
            var format = string.Format("{0}-{3} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }
    }
}