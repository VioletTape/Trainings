using System;
using System.Collections.Concurrent;

namespace GoF_ShowCase.Flyweight.NearRealLife {
    public class MapComponentFactory {
        private static readonly Lazy<MapComponentFactory> instance
            = new Lazy<MapComponentFactory>(() => new MapComponentFactory());

        public enum Trees {
            Oak,
            Spruce,
            Pine,
            Birch,
            Aspen
        };

        public enum Roads {
            Direct,
            TurnLeft,
            TurnRight
        }

        private readonly ConcurrentDictionary<Trees, IMapComponent> trees
            = new ConcurrentDictionary<Trees, IMapComponent>();

        private readonly ConcurrentDictionary<Roads, IMapComponent> roads
            = new ConcurrentDictionary<Roads, IMapComponent>();

        private MapComponentFactory() {}

        public static MapComponentFactory Instance {
            get { return instance.Value; }
        }

        public IMapComponent CreateTree(Trees treeType) {
            return trees.GetOrAdd(treeType,
                                   key => new MapTreeFlyweight {Title = key.ToString()});
        }

        public IMapComponent CreateRoad(Roads roadType) {
            return roads.GetOrAdd(roadType,
                                   key => new MapRoadFlyweight {Title = key.ToString()});
        }

        public IMapComponent CreateHouse(string title) {
            return new MapHouse {Title = title};
        }
    }
}