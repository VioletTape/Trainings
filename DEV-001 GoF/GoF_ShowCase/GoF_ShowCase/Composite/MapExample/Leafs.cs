using System;

namespace GoF_ShowCase.Composite.MapExample {
    public class MapHouse : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} House", Title);
        }
    }

    public class MapRoad : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} Road", Title);
        }
    }

    public class MapLeftTurn : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} Left turn", Title);
        }
    }

    public class MapRightTurn : MapComponent {
        public override void Draw(int x, int y) {
            Console.WriteLine("{0} Right turn", Title);
        }
    }
}