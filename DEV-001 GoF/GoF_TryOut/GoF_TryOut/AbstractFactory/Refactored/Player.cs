using System;
using System.Collections.Generic;
using System.Drawing;
using AutoMapper;

namespace GoF_TryOut.AbstractFactory.Refactored {
    public class Player {
        public IRace Race { get; set; }
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
        Player Player { get; }
        int Armor { get; set; }
        int HP { get; set; }
        int Attack { get; set; }

        Point Point { get; set; }
        void Draw();
    }

    // Factory method
    public class Infantry<T> : IInfantry where T : IRace {
        private static Dictionary<Type, IInfantry> prototypes
            = new Dictionary<Type, IInfantry> {
                  {
                      typeof(Human), new Infantry<Human> {
                                                             Armor = 10,
                                                             HP = 20,
                                                             Attack = 5
                                                         }
                  }
                  , {
                        typeof(Zerg), new Infantry<Zerg> {
                                                             Armor = 5,
                                                             HP = 25,
                                                             Attack = 10
                                                         }
                    }
                  , {
                        typeof(Protos), new Infantry<Protos> {
                                                                 Armor = 25,
                                                                 HP = 5,
                                                                 Attack = 15
                                                             }
                    },
                                              };

        public int Armor { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public Point Point { get; set; }
        public Player Player { get; private set; }

        public Infantry() {
            Mapper.CreateMap<Infantry<Human>, Infantry<Human>>();
            Mapper.CreateMap<Infantry<Zerg>, Infantry<Zerg>>();
            Mapper.CreateMap<Infantry<Protos>, Infantry<Protos>>();
        }

        public static IInfantry CreateFor(Player player) {
            var infantry = Mapper.Map<Infantry<T>>(prototypes[typeof(T)]);
            infantry.Player = player;
            return infantry;
        }

        public void Draw() {
            var format = string.Format("{0} {1} {2}", Player.Race, Point.X, Point.Y);
            Console.WriteLine(format);
        }


    }

    // Abstract Factory
    public class Factory<T> where T : IRace {
        public IInfantry CreateInfantry(Player player) {
            return Infantry<T>.CreateFor(player);
        }

       


    }



    public enum HumanSpecial {
        Sniper,
        Spy
    }
}