using System;

namespace GoF_ShowCase.Flyweight.NearRealLife {
    public class MapTreeFlyweight : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} Tree at {1}:{2}", Title, x, y);
        }
    }

    public class MapRoadFlyweight : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} Road at {1}:{2}", Title, x, y);
        }
    }

    public class MapHouse : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} House at {1}:{2}", Title, x, y);
        }
    }
}