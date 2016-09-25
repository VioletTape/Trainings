using System;

namespace GoF_ShowCase.Composite.MapExample {
    public static class Example {
        public static IMapComponent BuildCity() {
            IMapComposite road1 = new MapComposite {Title = "Main Street"};
            road1.AddComponent(new MapRoad {Title = road1.Title});
            road1.AddComponent(new MapRoad {Title = road1.Title});
            road1.AddComponent(new MapLeftTurn {Title = road1.Title});
            road1.AddComponent(new MapRoad {Title = road1.Title});
            road1.AddComponent(new MapRightTurn {Title = road1.Title});

            IMapComposite district1 = new MapComposite {Title = "District 1"};
            district1.AddComponent(new MapHouse {Title = "House 1"});
            district1.AddComponent(new MapHouse {Title = "House 2"});
            district1.AddComponent(new MapHouse {Title = "House 3"});
            district1.AddComponent(road1);

            IMapComposite city = new MapComposite {Title = "New city"};
            city.AddComponent(district1);

            return city;
        }

        public static void DrawArea(IMapComponent component) {
            if (component == null) {
                return;
            }

            Console.WriteLine("Drawing ...");
            component.Draw(0, 0);
            Console.WriteLine("==============\n");
        }

        public static void Execute() {
            var city = BuildCity();
            DrawArea(city);

            var road = city.FindChild("Main Street");
            DrawArea(road);

            var house = city.FindChild("House 2");
            DrawArea(house);
        }
    }
}