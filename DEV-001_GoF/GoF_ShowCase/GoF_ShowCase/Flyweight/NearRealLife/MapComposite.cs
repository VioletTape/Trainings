using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Flyweight.NearRealLife {
    public class MapComposite : MapComponent, IMapComposite {
        private class ComponentContainer {
            public int X { get; set; }
            public int Y { get; set; }
            public IMapComponent Component { get; set; }
        }

        private readonly List<ComponentContainer> _components = new List<ComponentContainer>();

        public void AddComponent(IMapComponent component, int x, int y) {
            var newContainer = new ComponentContainer {
                X = x,
                Y = y,
                Component = component
            };

            _components.Add(newContainer);
            component.Parent = this;
        }

        public override void Draw(int x, int y) {
            Console.WriteLine(Title);

            foreach (var container in _components) {
                container.Component.Draw(x + container.X, y + container.Y);
            }
        }

        public override IMapComponent FindChild(string name) {
            if (Title == name) {
                return this;
            }

            foreach (var container in _components) {
                var found = container.Component.FindChild(name);

                if (found != null) {
                    return found;
                }
            }

            return null;
        }
    }
}