using System.Drawing;

namespace GoF_TryOut.AbstractFactory.StraightCode {
    public class Game {
        public Game() {
            var player = new Player {
                                        Race = RaceType.Human
                                    };

            var infantry = player.CreateInfantry();
            infantry.Point = new Point(1, 1);

            var infantry1 = player.CreateInfantry();
            infantry1.Point = new Point(2, 3);

            infantry.Draw();
            infantry1.Draw();
        }
    }
}