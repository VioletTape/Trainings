using System;

namespace GoF_ShowCase.Flyweight.NearRealLife {
    public static class Example{
        public static IMapComponent BuildCity(MapComponentFactory mapFactory) {
            IMapComposite road1 = new MapComposite {Title = "Main Street"};
            road1.AddComponent(mapFactory.CreateRoad(MapComponentFactory.Roads.Direct), 0, 2);
            road1.AddComponent(mapFactory.CreateRoad(MapComponentFactory.Roads.Direct), 1, 2);
            road1.AddComponent(mapFactory.CreateRoad(MapComponentFactory.Roads.TurnRight), 2, 2);
            road1.AddComponent(mapFactory.CreateRoad(MapComponentFactory.Roads.Direct), 2, 1);
            road1.AddComponent(mapFactory.CreateRoad(MapComponentFactory.Roads.Direct), 2, 0);

            IMapComposite district1 = new MapComposite {Title = "District 1"};
            district1.AddComponent(mapFactory.CreateHouse("House 1"), 1, 3);
            district1.AddComponent(mapFactory.CreateHouse("House 2"), 3, 1);
            district1.AddComponent(road1, 0, 0);

            IMapComposite park1 = new MapComposite {Title = "City Park"};
            park1.AddComponent(mapFactory.CreateTree(MapComponentFactory.Trees.Oak), 0, 0);
            park1.AddComponent(mapFactory.CreateTree(MapComponentFactory.Trees.Aspen), 1, 0);
            park1.AddComponent(mapFactory.CreateTree(MapComponentFactory.Trees.Aspen), 1, 1);
            park1.AddComponent(mapFactory.CreateTree(MapComponentFactory.Trees.Aspen), 0, 1);
            district1.AddComponent(park1, 0, 0);

            IMapComposite city = new MapComposite {Title = "New city"};
            city.AddComponent(district1, 0, 0);

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
            var city = BuildCity(MapComponentFactory.Instance);
            DrawArea(city);

            var road = city.FindChild("Main Street");
            DrawArea(road);

            var house = city.FindChild("City Park");
            DrawArea(house);
        }
    }
}