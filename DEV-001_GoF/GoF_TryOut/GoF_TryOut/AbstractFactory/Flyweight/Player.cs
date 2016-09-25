using System;
using System.Collections.Generic;
using System.Drawing;

namespace GoF_TryOut.AbstractFactory.Flyweight {
    public class Player {
        public string Name;
        public IRace Race { get; set; }

        public Player(IRace race, string name) {
            Name = name;
            Race = race;
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

    public interface IRace {
        RaceType RaceType { get; }
    }

    public class Human : IRace {
        public RaceType RaceType {
            get { return RaceType.Human; }
        }
    }

    public class Zerg : IRace {
        public RaceType RaceType {
            get { return RaceType.Zerg; }
        }
    }

    public class Protos : IRace {
        public RaceType RaceType {
            get { return RaceType.Protos; }
        }
    }

    public interface IInfantry {
        void Draw(Player player, Point point);
    }

    public class InfantryBase : IInfantry {
        public int Armor;
        public int HP;
        public int Attack;

        public object Image;

        public void Draw(Player player, Point point) {
            var format = string.Format("{0}-{3} {1} {2} {4}", player.Race.RaceType, point.X, point.Y, player.Name, Image);
            Console.WriteLine(format);
        }
    }

    // Factory
    public class InfantryFactory {
        private static readonly Dictionary<RaceType, InfantryBase> prototypes
            = new Dictionary<RaceType, InfantryBase> {
         {
             RaceType.Human, new InfantryBase {
                                                  Armor = 10,
                                                  HP = 20,
                                                  Attack = 5,
                                                  Image = "human big image"
                                              }
         }
         , {
               RaceType.Zerg, new InfantryBase {
                                                   Armor = 5,
                                                   HP = 25,
                                                   Attack = 10,
                                                   Image = "Zerg big image"
                                               }
           }
         , {
               RaceType.Protos, new InfantryBase {
                                                     Armor = 25,
                                                     HP = 5,
                                                     Attack = 15,
                                                     Image = "Protos big image"
                                                 }
           },
                                                     };


        public Infantry<T> Create<T>(Player player) {
            var infantry = new Infantry<T>(player) {
                          InfantryBase = prototypes[player.Race.RaceType]
                                                   };

            return infantry;
        }
    }

    public class Infantry<T> {
        internal InfantryBase InfantryBase;

        public Point Point = new Point();
        public Player Player { get; private set; }

        public Infantry(Player player) {
            Player = player;
        }

        public void Draw() {
            InfantryBase.Draw(Player, Point);
        }
    }


    // Abstract Factory
    public class Factory<T> where T : IRace {
        private InfantryFactory infantryFactory;

        public Infantry<T> CreateInfantry(Player player) {
            infantryFactory = new InfantryFactory();
            return infantryFactory.Create<T>(player);
        }
    }
}