using System.Drawing;

namespace GoF_TryOut.AbstractFactory.Refactored {
    public class Game {
        public Game() {
            var player = new Player {
                                        Race = new Human()
                                    };

            var factory = new Factory<Human>();


            var infantry1 = factory.CreateInfantry(player);
            infantry1.Point = new Point(1, 1);

            var infantry2 = factory.CreateInfantry(player);

            infantry1.Draw();
            infantry2.Draw();
        }
    }
}