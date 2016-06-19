using System.Drawing;

namespace GoF_TryOut.AbstractFactory.Flyweight {
    public class Game {
        public Game() {
            var playerA = new Player(new Human(), "Joe");
            var playerB = new Player(new Human(), "Sandy");
            var playerC = new Player(new Protos(), "Kim");


            var factoryHuman = new Factory<Human>();
            var factoryProtos = new Factory<Protos>();



            var infantry = factoryHuman.CreateInfantry(playerA);
            infantry.Point = new Point(1, 1);

            var infantry1 = factoryHuman.CreateInfantry(playerA);
            infantry1.Point = new Point(2, 2);

            var infantry2 = factoryHuman.CreateInfantry(playerB);
            infantry2.Point = new Point(2, 2);

            var infantry3 = factoryProtos.CreateInfantry(playerC);


            infantry.Draw();
            infantry1.Draw();
            infantry2.Draw();
            infantry3.Draw();
        }
    }
}