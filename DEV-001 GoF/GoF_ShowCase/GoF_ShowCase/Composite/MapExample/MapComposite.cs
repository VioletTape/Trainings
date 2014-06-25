using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Composite.MapExample {
    public class MapComposite : MapComponent, IMapComposite {
        private readonly List<IMapComponent> components = new List<IMapComponent>();

        public void AddComponent(IMapComponent component) {
            components.Add(component);
            component.Parent = this;
        }

        // common method
        public override void Draw(int x, int y) {
            Console.WriteLine(Title);

            foreach (var component in components) {
                // can treat all components uniform
                component.Draw(X + x, Y + y);
            }
        }

        public override IMapComponent FindChild(string name) {
            if (Title == name) {
                return this;
            }

            foreach (var component in components) {
                var found = component.FindChild(name);

                if (found != null) {
                    return found;
                }
            }

            return null;
        }
    }
}