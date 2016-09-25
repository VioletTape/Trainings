namespace GoF_ShowCase.Composite.MapExample {
    public abstract class MapComponent : IMapComponent {
        protected int X;

        protected int Y;

        public IMapComponent Parent { get; set; }

        public string Title { get; set; }

        // Common method for map drawing
        public abstract void Draw(int x, int y);

        public virtual IMapComponent FindChild(string name) {
            return (Title == name) ? this : null;
        }
    }
}